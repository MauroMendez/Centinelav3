using CentinelaV3.Data.sql;
using CentinelaV3.Data.npsql;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography;

namespace CentinelaV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // utiliza la clase contex para conetarnos a la base de datos
            using (var context = new Intererpv3testContext())
            {
                // consulta para TRAER Solicitudes siempre y cuando su estatus sea pendiente y la transaction no sea nula
                List<SolicitudPago> sp = (from SP in context.SolicitudPago where SP.EfecState == "PENDING" && SP.EfecTransaccion != "" select SP).ToList();

                string estatus = "";
                string metodoPago = "";
                int formaPago = 0;
                int cuentaBancaria = 0;

                // recorro el resultado de la lista
                foreach (SolicitudPago solicitudPago in sp)
                {
                    //obtenemos la solicitud ACTUAL
                    SolicitudPago solicitudUpd = (from SP in context.SolicitudPago where SP.SolicitudId == solicitudPago.SolicitudId select SP).FirstOrDefault();

                    #region x
                    // asigna el metodo de pago
                    if (solicitudPago.EfectivoMetodoPago == 1)
                    {
                        metodoPago = "OXXO";
                        formaPago = 6;
                    }
                    else if (solicitudPago.EfectivoMetodoPago == 5)
                    {
                        metodoPago = "SEVEN ELEVEN";
                        formaPago = 10;
                    }
                    else if (solicitudPago.EfectivoMetodoPago == 6)
                    {
                        metodoPago = "TRANSFERENCIA SPEI";
                        formaPago = 9;
                    }

                    // 
                    if (solicitudPago.EfectivoAccountNivel == 734182)
                    {
                        cuentaBancaria = 1019;
                    }
                    else if (solicitudPago.EfectivoAccountNivel == 730729)
                    {
                        cuentaBancaria = 1020;
                    }
                    else if (solicitudPago.EfectivoAccountNivel == 734183)
                    {
                        cuentaBancaria = 1021;
                    }


                    // Imprimo los datos de la solicitud
                    Console.WriteLine("<--->");
                    Console.WriteLine($"Solicitud: {solicitudPago.SolicitudId}");
                    Console.WriteLine($"Se pago por: {metodoPago}");
                    Console.WriteLine($"Descripción de pago: {solicitudPago.DescripcionE}");
                    Console.WriteLine($"Referencia: {solicitudPago.RReferenciaId} Alumno: {solicitudPago.Alumno}");

                    //Se prepara la petición a payu
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.payulatam.com/reports-api/4.0/service.cgi");
                    httpWebRequest.ContentType = "application/xml";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        //AQUI ENVIAMOS EL REQUEST PARA CHECAR ES STATUS DE CADA PAGO 
                        // Se crea la petición en XML
                        string solicitud = "<request><language>es</language><command>TRANSACTION_RESPONSE_DETAIL</command><merchant><apiLogin>o0ID2NvP5w8wLrw</apiLogin><apiKey>45nKKDo192xAUtOGZ3Gd86VGX2</apiKey></merchant><details class='java.util.HashMap'><entry><string>transactionId</string><object class='java.lang.String'>" + solicitudPago.EfecTransaccion.ToString().Trim() + "</object></entry></details><isTest>false</isTest></request>";
                        streamWriter.Write(solicitud);
                    }

                    // Recibimos la respuesta del request
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        // Se recibe el xml de la respuesta
                        var responseText = streamReader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();

                        //Cargamos el xml de la respuesta
                        doc.LoadXml(responseText);
                        //Console.WriteLine($"Respuesta de Payu: ${responseText}");

                        // Desestructuramos el XML de la respuesta para obtener los valores
                        XmlNodeList result = doc.GetElementsByTagName("result");
                        XmlNodeList xLista = ((XmlElement)result[0]).GetElementsByTagName("state");

                        // recorremos el xml
                        foreach (XmlElement nodo in xLista)
                        {

                            estatus = nodo.InnerText;

                            //estatus = "APPROVED";

                        }

                    }



                    Console.WriteLine("Estatus actual del pago: " + estatus);

                    // Si la solicitud ya esta expirada
                    if (estatus.Trim() == "EXPIRED")
                    {
                        // Cambiamos la propiedad de estatus y asignamos la fecha actual y el response code
                        solicitudUpd.EfecState = estatus.Trim();
                        solicitudUpd.FechaEstatus = DateTime.Now;
                        solicitudUpd.EfecResponseCode = "EXPIRED_TRANSACTION";
                        // Actualizamos
                        context.SaveChanges();
                        Console.WriteLine("Operación Expirada");
                    }

                    // Si la solicitud esta declinada
                    if (estatus.Trim() == "DECLINED")
                    {
                        // Cambiamos la propiedad de estatus y asignamos la fecha actual y el response code
                        solicitudUpd.EfecState = estatus.Trim();
                        solicitudUpd.FechaEstatus = DateTime.Now;
                        solicitudUpd.EfecResponseCode = "DECLINED_TRANSACTION";
                        // Actualizamos
                        context.SaveChanges();
                        Console.WriteLine("Operación Declinada");
                    }
                    #endregion
                    // Si la solicitud fue aprovada
                    if (estatus.Trim() == "APPROVED")
                    {

                        Console.WriteLine("Transacción aprovada");

                        string AP = solicitudPago.Alumno.Substring(0, 1);
                        int metodo = Convert.ToInt16(solicitudPago.EfectivoMetodoPago);

                        //AP == "P"
                        if (solicitudPago.Alumno.Contains("-P") || solicitudPago.Alumno.Contains("P"))
                        {
                            string mat = solicitudPago.Alumno.Replace("-", "").Trim();
                            Console.WriteLine("Es un prospecto");


                            //obtenemos el prospecto
                            GeneralesProspecto pros = (from PS in context.GeneralesProspecto where PS.GpporsMat == mat select PS).FirstOrDefault();

                            string matricula = "";
                            matricula = GeneraM(pros, 9);

                            //Obtenemos el id del alumno

                            long aluid = (from AL in context.Alumno where AL.AlMatricula.Trim() == matricula.Trim() select AL.AlId).FirstOrDefault();
                            //Obtenemos su referencia
                            Referencias referencia = (from RF in context.Referencias where RF.RReferencia == solicitudPago.RReferenciaId select RF).FirstOrDefault();


                            // creamos nuevo objeto para agregar un AlumnoPagos
                            AlumnoPagos ALUP = (from APA in context.AlumnoPagos where APA.ApReferencia.Trim() == mat.Trim() select APA).FirstOrDefault();

                            if (ALUP != null)
                            {
                                Console.WriteLine("ya existe el pago de este alumno");
                            }
                            else
                            {
                                AlumnoPagos pago = new AlumnoPagos();

                                pago.ApAlumnoId = aluid;
                                pago.ApAlumnoClave = matricula;
                                pago.ApCuentaBancaria = cuentaBancaria;
                                pago.ApMetodoPago = metodo;
                                pago.ApFormaPagoId = formaPago;
                                pago.ApMoneda = 1;
                                pago.ApImportePendiente = solicitudPago.EfectivoMonto;
                                pago.ApImporteTotal = solicitudPago.EfectivoMonto;
                                if (referencia == null)
                                {
                                    pago.ApReferenciaId = 1;
                                    pago.ApReferencia = mat;
                                }
                                else
                                {
                                    pago.ApReferenciaId = referencia.RReferenciaId;
                                    pago.ApReferencia = referencia.RReferencia;
                                }
                                pago.ApReferenciaBancaria = "Pago en línea";
                                pago.ApNoAprobacion = "";
                                pago.ApObservaciones = "Pago en línea";
                                pago.ApFechaCreacion = DateTime.Now;
                                pago.ApFechaContable = DateTime.Now;
                                pago.ApFechaBancaria = DateTime.Now;
                                pago.ApEstatus = 21;
                                pago.ApUsuid = 9;



                                // agrega alumno pagos
                                //int addAP = AddAlumnosPagos(pago);

                                string AddAP = AddAlumnoPagos(pago);

                                //Si hubo un error en la insersión termina la ejecución
                                if (AddAP.ToUpper().Contains("ERROR"))
                                {
                                    Console.WriteLine(AddAP);
                                    return;
                                }

                                // obtenemos el id del pago creado
                                int idPago = ObtenerPagoIdMatricula(pago.ApAlumnoClave);
                                // obtenemos el id de la referencia
                                int idRef = (int)ObtIdReferenciaRef(pago.ApReferencia);
                            }




                            //// Obtenemos el alumno
                            Alumno alumno = ObtAlumnoMatricula(matricula);

                            //Paso de alumno a la v2
                            string carrera = "";
                            int periodo = 0, anio = 0;
                            Campana campana = new Campana();
                            Carreras carreras = new Carreras();
                            GeneralesProspecto prospecto = new GeneralesProspecto();
                            Niveles nivel = new Niveles();

                            prospecto = context.GeneralesProspecto.First(gp => gp.GpporsMat == mat);
                            campana = GetCampana(prospecto.Campid);
                            carreras = context.Carreras.First(c => c.Idcarrera == prospecto.Idcarrera);
                            nivel = context.Niveles.First(n => n.NivelId == carreras.NivelId);
                            int idcrm = 0;

                            periodo = campana.Campperiodo;
                            anio = campana.Campanio;
                            carrera = carreras.CarreraClave.Trim();

                            using (var _npgsql_Context = new npsqlContext())
                            {
                                int crmidv2 = (from TCRM in _npgsql_Context.Tcrm where TCRM.Crmclave == prospecto.GpporsMat.Trim() select TCRM.Crmid).FirstOrDefault();
                                int ulid = _npgsql_Context.Tcrm.Max(x => x.Crmid);

                                if (crmidv2 == 0)
                                {
                                    Tcrm tc = new Tcrm();
                                    tc.Crmid = ulid + 1;
                                    tc.Crmclave = prospecto.GpporsMat;
                                    //tc.Crmnombre = vp.NombreCompleto;
                                    tc.Crmnombre = prospecto.GpNombre;
                                    tc.Crmapaterno = prospecto.GpApp;
                                    tc.Crmamaterno = prospecto.GpApm;
                                    tc.Crmfenac = DateTime.Now;
                                    tc.Crmedad = 0;
                                    tc.Crmsexo = 'H';
                                    tc.Crmedocivil = 'S';
                                    tc.Crmpaisid = 0;
                                    tc.Crmnacionalidad = "MEXICANA";
                                    tc.Crmedo = 0;
                                    tc.Crmmunicipio = 0;
                                    tc.Crmdireccion = "";
                                    tc.Crmcp = "";
                                    tc.Crmcomentarios = "";
                                    tc.Crmcompany = 1;
                                    tc.Crmactivo = 1;
                                    tc.Crmimagen = new byte[1];
                                    tc.CrmimagenGxi = "";
                                    tc.Crmcat01 = "";
                                    tc.Crmcat02 = "";
                                    tc.Crmcat03 = "";
                                    tc.Crmcat04 = "";
                                    tc.Crmcat05 = "";
                                    tc.Crmcat06 = "";
                                    tc.Crmcat07 = "";
                                    tc.Crmcat08 = "";
                                    tc.Crmcat09 = "";
                                    tc.Crmcat10 = "";
                                    tc.Crmmoneda = "MX";
                                    tc.Crmmanagercrd = 0;
                                    tc.Crmmanagercrb = 0;
                                    tc.Crmregusuario = 0;
                                    tc.Crmregfecha = DateTime.Now;
                                    tc.Crmreghora = "";
                                    tc.Crmregprog = "";
                                    tc.Crmmodusuario = 0;
                                    tc.Crmmodfecha = DateTime.Now;
                                    tc.Crmmodhora = "";
                                    tc.Crmmodprog = "";

                                    string msj21 = "";
                                    try
                                    {
                                        _npgsql_Context.Tcrm.Add(tc);
                                        _npgsql_Context.SaveChanges();
                                    }
                                    catch (Exception e)
                                    {
                                        msj21 = e.Message;
                                    }

                                    int crmidv3 = (from TCRM in _npgsql_Context.Tcrm where TCRM.Crmclave == prospecto.GpporsMat.Trim() select TCRM.Crmid).FirstOrDefault();

                                    idcrm = crmidv3;
                                }
                                else
                                {
                                    idcrm = crmidv2;
                                }

                                Talumno tal = (from TAL in _npgsql_Context.Talumno where TAL.Alunocontrol.Trim() == matricula.Trim() select TAL).FirstOrDefault();

                                if (tal != null)
                                {
                                    Console.WriteLine("Ya existe registro de este alumno");
                                    //return;
                                }
                                else
                                {



                                    Talumno alumov2 = new Talumno();

                                    //insersion de alumno
                                    alumov2.Aluid = idcrm;
                                    alumov2.Alucompany = 0;
                                    if (alumno == null)
                                    {
                                        alumov2.Alunocontrol = prospecto.Gpmatricula.Trim();
                                    }
                                    else
                                    {
                                        alumov2.Alunocontrol = alumno.AlMatricula.Trim();
                                    }

                                    alumov2.Alunoverifica = '1';
                                    alumov2.Alunoant = "";
                                    alumov2.Alunovant = ' ';
                                    alumov2.Alunopro = prospecto.GpporsMat.Trim();
                                    alumov2.Alunovpro = ' ';
                                    alumov2.Aluescprocedencia = " ";
                                    alumov2.Aluintereses = " ";
                                    alumov2.Alumunicipio2 = " ";
                                    alumov2.Aluestatusid = 3478;
                                    alumov2.Tpaident = "";
                                    alumov2.Covid = 1;
                                    alumov2.Alugeneracta = 0;
                                    alumov2.Aluimporte = 0;
                                    alumov2.Aluinspago = " ";
                                    alumov2.Aluadeudo = 0;
                                    alumov2.Aluretenfac = 0;
                                    alumov2.Alucredlim = 40000;
                                    alumov2.Alucredmsg = "";
                                    alumov2.Alucredopen = "";
                                    alumov2.Alucredreview = "";
                                    alumov2.Alucredfopen = DateTime.MinValue;
                                    alumov2.Alucredfreview = DateTime.MinValue;
                                    alumov2.Alucredfnreview = DateTime.MinValue;
                                    alumov2.Alucredmsgtmp = "";
                                    alumov2.Alucbrpolitica = "";
                                    alumov2.Alucbrenviocta = ' ';
                                    alumov2.Alucbrreporte = 0;
                                    alumov2.Alucbrpedo = 0;
                                    alumov2.Alucbrmorozidad = 0;
                                    alumov2.Alucbravisosmor = 0;
                                    alumov2.Aluactivo = 1;
                                    alumov2.Aluregusuario = 0;
                                    alumov2.Aluregfecha = DateTime.Now;
                                    alumov2.Alureghora = "";
                                    alumov2.Aluregprog = "PPasePRS_CRM_ManV2";
                                    alumov2.Alumodfecha = DateTime.Now;
                                    alumov2.Alumodhora = "";
                                    alumov2.Alumodprog = "PPasePRS_CRM_ManV2";
                                    alumov2.Alufac = null;
                                    alumov2.Alufacrfc = null;
                                    alumov2.Alufacrazons = null;
                                    alumov2.Alufacdir = null;
                                    alumov2.Alufacemail = null;
                                    alumov2.Alugeneracion = null;


                                    //GeneralesProspecto gp = (from GP in _context.GeneralesProspecto where GP.GpporsMat == prospecto.GpporsMat.Trim() select GP).FirstOrDefault();

                                    if (nivel.NivelId == 2)
                                    {
                                        alumov2.Aludivision = "BAC";
                                    }
                                    else if (nivel.NivelId == 3)
                                    {
                                        alumov2.Aludivision = "EDC";
                                    }
                                    else if (nivel.NivelId == 1)
                                    {
                                        alumov2.Aludivision = "LIC";
                                    }
                                    else if (nivel.NivelId == 4)
                                    {
                                        alumov2.Aludivision = "DOC";
                                    }
                                    else if (nivel.NivelId == 5)
                                    {
                                        alumov2.Aludivision = "CV";
                                    }
                                    else
                                    {
                                        alumov2.Aludivision = "TOD";
                                    }


                                    Tprospecto pro = (from PRO in _npgsql_Context.Tprospecto where PRO.Prsnocontrol.Trim() == prospecto.GpporsMat.Trim() select PRO).FirstOrDefault();
                                    alumov2.Alureganio = pro.Prspyear;

                                    if (pro.Prsperiodo.Trim() == "PRIMAVERA")
                                    {
                                        alumov2.Aluregperiodo = 1;
                                    }
                                    else if (pro.Prsperiodo.Trim() == "VERANO")
                                    {
                                        alumov2.Aluregperiodo = 2;
                                    }
                                    else if (pro.Prsperiodo.Trim() == "OTOÑO")
                                    {
                                        alumov2.Aluregperiodo = 3;
                                    }

                                    alumov2.Aluestatusacademico = 1;
                                    alumov2.Alumodalidad = "PRE";
                                    alumov2.Aluestado = "21";
                                    alumov2.Alucp = "";
                                    alumov2.Aluciudadnac = "";
                                    alumov2.Alufactipo = null;
                                    alumov2.Alufacverificacion = null;
                                    alumov2.Alufacfechareg = null;
                                    alumov2.Alufachorareg = null;
                                    alumov2.Alufacsolicitud = null;
                                    alumov2.Alufacusuid = null;
                                    alumov2.Alusexot = null;
                                    alumov2.Aluocupaciont = null;
                                    alumov2.Aluingresot = null;
                                    alumov2.Aluresidencia = null;
                                    alumov2.Alulocalidad = null;
                                    //alumov2.alufacregimen = "";

                                    string msj = "";
                                    string addAluv2 = "";

                                    try
                                    {
                                        _npgsql_Context.Talumno.Add(alumov2);
                                        _npgsql_Context.SaveChanges();
                                        addAluv2 = "alumno agregado en la versión 2";
                                    }
                                    catch (Exception e)
                                    {

                                        addAluv2 = "ERROR:" + e.Message;
                                    }


                                    //Insersion de alumno en tabla taalumno conexion 
                                    int idCon = _npgsql_Context.Taalumnoconexion.Max(x => x.Aacfid);
                                    Taalumnoconexion taalumnoconexion = new Taalumnoconexion();
                                    taalumnoconexion.Aluid = alumov2.Aluid;
                                    taalumnoconexion.Aacfid = idCon + 1;
                                    taalumnoconexion.Aacfoto = new byte[1];
                                    taalumnoconexion.AacfotoGxi = "";
                                    taalumnoconexion.Aacfcurp = "";
                                    taalumnoconexion.Aacftelefono = pro.Prstelefono.Trim();
                                    taalumnoconexion.Aacfmail = pro.Prsemergenciaemail.Trim();
                                    taalumnoconexion.Aacfnomtutor = pro.Prsnombre.Trim();
                                    taalumnoconexion.Aacfapellidop = pro.Prsapaterno.Trim();
                                    taalumnoconexion.Aacfapellidom = pro.Prsamaterno.Trim();


                                    //GeneralesProspecto gp = (from GP in context2.GeneralesProspecto where GP.GpporsMat == al.Alunopro.Trim() select GP).FirstOrDefault();

                                    if (prospecto == null)
                                    {
                                        Console.WriteLine("No se encontro ninguna direccion: ");
                                    }
                                    else
                                    {
                                        taalumnoconexion.Aacfcolonia = prospecto.GpDireccion.Trim();
                                        taalumnoconexion.Aacsemestreactual = (short?)prospecto.GpSemestre;
                                    }

                                    //string carrera = (from CA in context2.Carreras where CA.Idcarrera == gp.Idcarrera select CA.CarreraClave).FirstOrDefault();
                                    taalumnoconexion.Acarid = carrera.Trim();

                                    //alu.Aacfcallenumcont = "";
                                    taalumnoconexion.Aacfcallenum = "";
                                    taalumnoconexion.Aacfmunicipio = "";
                                    taalumnoconexion.Aacfestado = "PUEBLA";
                                    taalumnoconexion.Aacftelefonot = pro.Prstelefono.Trim();
                                    taalumnoconexion.Aacfmail = pro.Prsemergenciaemail.Trim();
                                    taalumnoconexion.Aacfalergias = null;
                                    taalumnoconexion.Aacftiposangre = null;
                                    taalumnoconexion.Aacfpadecimientos = null;
                                    taalumnoconexion.Aacfcomentarios = null;
                                    taalumnoconexion.Aacfsecundaria = null;
                                    taalumnoconexion.Aacfseclugar = null;
                                    taalumnoconexion.Aacfsecedo = null;
                                    taalumnoconexion.Aacfbachiller = null;
                                    taalumnoconexion.Aacfbachlugar = null;
                                    taalumnoconexion.Aacfbachedo = null;
                                    taalumnoconexion.Aacfparentescocont = null;
                                    taalumnoconexion.Aacftelefonocont = null;
                                    taalumnoconexion.Aacfedocont = null;
                                    taalumnoconexion.Aacfamunicipiocont = null;
                                    taalumnoconexion.Aacfcallenumcont = null;
                                    taalumnoconexion.Aacfcoloniacont = null;
                                    taalumnoconexion.Aacfamaternocont = null;
                                    taalumnoconexion.Aacfapaternocont = null;
                                    taalumnoconexion.Aacfnombrecont = null;
                                    taalumnoconexion.Aacfunirev = null;
                                    taalumnoconexion.Aacfnia = null;
                                    taalumnoconexion.Aacsemestregrupo = null;
                                    taalumnoconexion.Aacffb = null;
                                    taalumnoconexion.Aacfreligion = null;
                                    taalumnoconexion.Aacfresidente = null;
                                    taalumnoconexion.Aacforiginario = null;
                                    taalumnoconexion.Aacfcedula = null;
                                    taalumnoconexion.Aacftipotitulacion = null;
                                    taalumnoconexion.Aacffechatitulacion = null;
                                    taalumnoconexion.Aacfhoratitulacion = null;
                                    taalumnoconexion.Aacfnolibro = null;
                                    taalumnoconexion.Aacffoja = null;
                                    taalumnoconexion.Aacfnolibroo = null;
                                    taalumnoconexion.Aacffojao = null;
                                    taalumnoconexion.Aacfegreanio = null;
                                    taalumnoconexion.Aacfegreperiodo = null;
                                    taalumnoconexion.Aacftituladoanio = null;
                                    taalumnoconexion.Aacftituladoperiodo = null;
                                    taalumnoconexion.Aacfbachpais = null;
                                    taalumnoconexion.Aacfextranjero = null;
                                    taalumnoconexion.Aacfegresado = 0;
                                    taalumnoconexion.Aacftitulado = 0;
                                    taalumnoconexion.Aacfcertificado = null;
                                    taalumnoconexion.Aacgrupo = null;
                                    taalumnoconexion.Aacftitulotesis = null;
                                    taalumnoconexion.Aacftelefonoc = null;
                                    taalumnoconexion.Aacffacebook = null;
                                    taalumnoconexion.Aacftwitter = null;
                                    taalumnoconexion.Aacfsuspendido = null;
                                    taalumnoconexion.Aacfacusado = null;
                                    taalumnoconexion.Aacfseguro = null;
                                    taalumnoconexion.Aacfbachprom = null;
                                    taalumnoconexion.Aacfbachcert = null;
                                    taalumnoconexion.Aacfgradoest = null;
                                    taalumnoconexion.Aacfequimat = null;
                                    taalumnoconexion.Aacfnacionalidad = null;
                                    taalumnoconexion.Aacmodalidad = null;
                                    taalumnoconexion.Aacffechanact = null;

                                    try
                                    {
                                        _npgsql_Context.Taalumnoconexion.Add(taalumnoconexion);
                                        _npgsql_Context.SaveChanges();

                                        Console.WriteLine("Alumno registrado en tabla alumno conexion");
                                    }
                                    catch (Exception e)
                                    {
                                        msj = e.Message;
                                    }
                                    try
                                    {
                                        //_npgsql_Context.Taalumnoconexion.Add(taalumnoconexion);
                                        //_npgsql_Context.SaveChanges();
                                        //msj = "alumno conexión agregado en la versión 2";
                                    }
                                    catch (Exception e)
                                    {

                                        msj = "ERROR: " + e.Message;
                                    }

                                    //insersion en Taalumno estatus

                                    long idAEst = _npgsql_Context.Talumnoestatus.Max(x => x.Alueid);
                                    Talumnoestatus talumnoestatus = new Talumnoestatus();
                                    talumnoestatus.Alueid = idAEst + 1;
                                    talumnoestatus.Aluestid = 3478;
                                    talumnoestatus.Aluid = alumov2.Aluid;
                                    talumnoestatus.Aluestfecha = DateTime.Now;
                                    talumnoestatus.Aluesthora = DateTime.Now;
                                    talumnoestatus.Aluestanio = (short)anio;
                                    talumnoestatus.Aluestperiodo = (short)periodo;
                                    talumnoestatus.Usuid = 9;
                                    talumnoestatus.Aluestcomentario = "PREINSCRITO";
                                    string addAlumStatusv2 = "";

                                    try
                                    {
                                        _npgsql_Context.Talumnoestatus.Add(talumnoestatus);
                                        _npgsql_Context.SaveChanges();
                                        addAlumStatusv2 = "Estatus alumno agregado ";
                                    }
                                    catch (Exception e)
                                    {

                                        addAlumStatusv2 = "ERROR: " + e.Message;
                                    }


                                    //Insercion en tabla de semaforo
                                    //Tapreinscrito t = (from TA in _npgsql_Context.Tapreinscrito where TA.Aluid == crmidv2 select TA).FirstOrDefault();

                                    string msj2 = "";
                                    long idtapre = _npgsql_Context.Tapreinscrito.Max(x => x.Preid);
                                    Tapreinscrito preinscirtos = new Tapreinscrito();
                                    //id = _npgsql_Context.Tapreinscrito.Max(x => x.Preid);
                                    //if (t != null)
                                    //{
                                    //    msj= ("Ya existe un registro con este id");
                                    //}
                                    //else
                                    //{
                                    preinscirtos.Preid = idtapre + 1;
                                    preinscirtos.Aluid = alumov2.Aluid;
                                    preinscirtos.Aacfid = taalumnoconexion.Aacfid;
                                    preinscirtos.Prepag = true;
                                    preinscirtos.Prepagreg = DateTime.Now;
                                    preinscirtos.Prepagusuid = 1;
                                    preinscirtos.Preee = false;
                                    preinscirtos.Preeereg = DateTime.MinValue;
                                    preinscirtos.Predoc = false;
                                    preinscirtos.Predocusuid = 0;
                                    preinscirtos.Predocreg = DateTime.MinValue;
                                    preinscirtos.Prereg = false;
                                    preinscirtos.Prehorario = false;
                                    preinscirtos.Prehorariousuid = 0;
                                    preinscirtos.Prehorarioreg = DateTime.MinValue;
                                    preinscirtos.Preanio = alumov2.Alureganio;
                                    preinscirtos.Preperiodo = (short?)periodo;
                                    preinscirtos.Pretipo = "PRE";


                                    int gp = (from GP in context.GeneralesProspecto where GP.GpporsMat == prospecto.GpporsMat.Trim() select GP.GpBeca).FirstOrDefault();

                                    if (gp > 0)
                                    {
                                        preinscirtos.Prebecaa = true;
                                        preinscirtos.Prebeca = true;
                                        preinscirtos.Prebecareg = DateTime.Now;

                                    }
                                    else
                                    {
                                        preinscirtos.Prebecaa = false;
                                        preinscirtos.Prebeca = false;
                                        preinscirtos.Prebecareg = DateTime.MinValue;
                                    }



                                    preinscirtos.Prebecausuid = 5346;
                                    preinscirtos.Preesquemareg = DateTime.MinValue;
                                    preinscirtos.Preesquemausuid = 1;

                                    try
                                    {
                                        _npgsql_Context.Tapreinscrito.Add(preinscirtos);
                                        _npgsql_Context.SaveChanges();
                                        // Console.WriteLine("Alumno registrado: " + al.Alunocontrol + " en TaPreinscito");
                                        // msj = "Alumno registrado: " + al.Alunocontrol + " en TaPreinscito";
                                    }
                                    catch (Exception e)
                                    {
                                        msj = e.Message;
                                    }
                                    //}

                                    #region alumno
                                    //Insersion de alumno en tabla usuario
                                    Tusuario usu = new Tusuario();
                                    Tusuario usuario = new Tusuario();
                                    if (alumno == null)
                                    {
                                        usuario = (from US in _npgsql_Context.Tusuario where US.Usuusuario == prospecto.Gpmatricula.Trim() select US).FirstOrDefault();
                                    }
                                    else
                                    {
                                        usuario = (from US in _npgsql_Context.Tusuario where US.Usuusuario == alumno.AlMatricula.Trim() select US).FirstOrDefault();
                                    }


                                    if (usuario != null)
                                    {
                                        //Console.WriteLine("Este prospecto ya cuenta con un usuario creado");
                                        msj = "Este prospecto  ya cuenta con un usuario creado";

                                    }
                                    else
                                    {
                                        long id = 0;
                                        //Console.WriteLine("Generando usuario");
                                        if (alumno == null)
                                        {
                                            id = (from AL in _npgsql_Context.Talumno where AL.Alunocontrol == prospecto.Gpmatricula.Trim() select AL.Aluid).FirstOrDefault();
                                        }
                                        else
                                        {
                                            id = (from AL in _npgsql_Context.Talumno where AL.Alunocontrol == alumno.AlMatricula.Trim() select AL.Aluid).FirstOrDefault();
                                        }

                                        long ultiID = _npgsql_Context.Tusuario.Max(x => x.Usuid);

                                        usu.Usuid = ultiID + 1;
                                        usu.Crmid = id;
                                        if (alumno == null)
                                        {
                                            usu.Usuusuario = prospecto.Gpmatricula.ToUpper().Trim();
                                            usu.Usupassword = prospecto.Gpmatricula.ToUpper().Trim();
                                        }
                                        else
                                        {
                                            usu.Usuusuario = alumno.AlMatricula.ToUpper().Trim();
                                            usu.Usupassword = alumno.AlMatricula.ToUpper().Trim();
                                        }

                                        usu.Usumodulo = "academia";
                                        usu.Usuactivo = 1;
                                        usu.Usuperfil = "ALU";
                                        usu.Ususession = 1;
                                        usu.Altared = 0;
                                        usu.Redpassword = null;
                                        usu.Enviocorreo = null;
                                        usu.Usuusesion = DateTime.MinValue;
                                        usu.Anocontrol = null;
                                        usu.Usumoodle = null;
                                        usu.Usumoodleid = null;
                                        usu.Usumoodleidb = null;
                                        usu.Cambiocontra = 0;
                                        usu.Usucambiocontra = 0;
                                        usu.Usumoodleidm = null;
                                        usu.UsuimagemovGxi = null;
                                        usu.Usuimagemov = null;
                                        usu.Usumovil = null;
                                        usu.Usuip = null;
                                        usu.Usuequipo = null;
                                        usu.Usukey = null;
                                        usu.Usulastpasschange = null;

                                        try
                                        {
                                            _npgsql_Context.Tusuario.Add(usu);
                                            _npgsql_Context.SaveChanges();
                                            // Console.WriteLine("Se registro el usuario del alumno exitosamente");
                                        }
                                        catch (Exception e)
                                        {
                                            msj = e.Message;
                                            //Console.WriteLine("Error al ingresar al usuario");
                                        }
                                    }
                                    #endregion

                                    WsKardex(prospecto.Gpmatricula.Trim(), carrera);

                                    //string enviaCorreo = correoCreaAlumno(alumno.AlNombre, alumno.AlApp, alumno.AlApm, alumno.AlMatricula, user.Usuusuario, user.Usupassword, alumno.AlCorreoInst);
                                    if (alumno == null)
                                    {
                                        string nombre = prospecto.GpNombre.Trim() + " " + prospecto.GpApp.Trim() + " " + prospecto.GpApm.Trim();
                                        string envio = EnvioCorreo(prospecto.Gpmatricula.Trim(), solicitudPago.EfectivoEmailBuyer.Trim(), nombre);
                                    }
                                    else
                                    {
                                        string nombre = alumno.AlNombre.Trim() + " " + alumno.AlApp.Trim() + " " + alumno.AlApm.Trim();
                                        string envio = EnvioCorreo(alumno.AlMatricula.Trim(), solicitudPago.EfectivoEmailBuyer.Trim(), nombre);
                                    }

                                    // actualizacion de estatus a v3
                                    string updInscrito = upd_EstatusInsc(pros.GpProspectoId);

                                    if (updInscrito.ToUpper().Contains("ERROR"))
                                    {
                                        Console.WriteLine(updInscrito);
                                        //return;
                                    }
                                    else
                                    {
                                        solicitudUpd.EfecState = estatus;
                                        solicitudUpd.FechaEstatus = DateTime.Now;
                                        solicitudUpd.FlagAsocio = true;
                                        context.SaveChanges();
                                    }


                                    //ERROR
                                    if (alumno == null)
                                    {
                                        Console.WriteLine("Pago cerrado");
                                        Console.WriteLine("Alumno creado: " + prospecto.Gpmatricula);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pago cerrado");
                                        Console.WriteLine("Alumno creado: " + alumno.AlMatricula);
                                    }
                                }

                            }

                        }

                        //AP == "A"
                        //solicitudPago.SolicitudId == 10538
                        else if (AP == "A")
                        {
                            Console.WriteLine("Es un alumno");

                            // obtenemos el alumnopp
                            Alumno alumno = ObtAlumnoMatricula(solicitudPago.Alumno);
                            //Obtenemos su referencia
                            Referencias referencia = (from RF in context.Referencias where RF.RReferencia == solicitudPago.RReferenciaId select RF).FirstOrDefault();

                            // creamos nuevo objeto para agregar un AlumnoPagos
                            AlumnoPagos pago = new AlumnoPagos()
                            {
                                ApAlumnoId = alumno.AlId,
                                ApAlumnoClave = solicitudPago.Alumno,
                                ApCuentaBancaria = cuentaBancaria,
                                ApMetodoPago = metodo,
                                ApFormaPagoId = formaPago,
                                ApMoneda = 1,
                                ApImportePendiente = 0,
                                ApImporteTotal = solicitudPago.EfectivoMonto,
                                ApReferenciaId = referencia.RReferenciaId,
                                ApReferencia = referencia.RReferencia,
                                ApReferenciaBancaria = "Pago en línea",
                                ApNoAprobacion = "",
                                ApObservaciones = "Pago en línea",
                                ApFechaCreacion = DateTime.Now,
                                ApFechaContable = DateTime.Now,
                                ApFechaBancaria = DateTime.Now,
                                ApEstatus = 21,
                                ApUsuid = 9
                            };

                            ////Agregamos el pago a AlumnoPagos
                            string AddAP = AddAlumnoPagos(pago);

                            //////Si hubo un error en la insersión termina la ejecución
                            if (AddAP.ToUpper().Contains("ERROR"))
                            {
                                Console.WriteLine(AddAP);
                                return;
                            }

                            // obtenemos el id del pago creado
                            int idPago = ObtenerPagoIdMatricula(pago.ApAlumnoClave);
                            // obtenemos el id de la referencia
                            int idRef = (int)ObtIdReferenciaRef(pago.ApReferencia);

                            // Traemos los detalles de las referencias de la referenciua
                            List<DetalleReferencia> detalleReferencias = TraeDetalleReferencias(idRef);

                            // Traemos los detalles de cuentas por las referencias
                            //List<DetalleCuentaPorCobrar> detalleCuentasxC = detalleCuentaPorCobrars(detalleReferencias);
                            List<DetalleCuentaPorCobrar> detalleCuentasxC = LlenaDetalleRef(detalleReferencias);

                            // Llenamos los detalles de pagos
                            List<DetallePago> detallePagos = LlenaDetallePago(detalleCuentasxC);

                            // cargamos los detalles de pagos al alumno
                            string cargaDP = CargaDetalleAlumnoPago(idPago, pago.ApUsuid, detallePagos);
                            if (cargaDP.ToUpper().Contains("ERROR"))
                            {
                                Console.WriteLine(cargaDP + "Proceso cancelado");
                                return;
                            }


                            // Actualizamos y cerramos las cuentas
                            string cierrePago = ActualizaDetalleCuentaPago(detallePagos);

                            if (cierrePago.ToUpper().Contains("ERROR"))
                            {
                                Console.WriteLine(cierrePago + "Proceso cancelado");
                                return;
                            }

                            // ACTUALIZAMOS ALUMNO PAGOS
                            //pago.ApImportePendiente = 0;
                            //pago.ApAlumnoId = alumno.AlId;
                            //pago.ApReferenciaId = idRef;
                            //string updAP = UpdAlumnoPagos(pago);

                            // Actualizamos solicutud de pago
                            solicitudUpd.EfecState = estatus;
                            solicitudUpd.FechaEstatus = DateTime.Now;
                            solicitudUpd.FlagAsocio = true;
                            context.SaveChanges();


                            int AñoValidadcion = 0, PeriodoValidacion = 0;
                            
                            int valida = 0;


                            CuentasPorCobrar cpc = (from CP in context.CuentasPorCobrar where CP.CpcId == detalleCuentasxC[0].DcpcCuentaId select CP).FirstOrDefault();

                            AñoValidadcion = cpc.CpcAño;
                            PeriodoValidacion = cpc.CpcPeriodo;

                            if (alumno.AlAnoPeriodoActual == cpc.CpcAño && alumno.AlPeriodoActual == cpc.CpcPeriodo)
                            {
                                valida = 1;

                            }

                            //foreach (var item in detalleCuentasxC)
                            //{
                            //    CuentasPorCobrar cpc = (from CP in context.CuentasPorCobrar where CP.CpcId == item.DcpcCuentaId select CP).FirstOrDefault();

                            //    if (alumno.AlAnoPeriodoActual == cpc.CpcAño && alumno.AlPeriodoActual == cpc.CpcPeriodo)
                            //    {
                            //        valida = valida + 1;

                            //    }
                            //    else
                            //    {
                            //        valida = 0;
                            //    }

                            //    AñoValidadcion = cpc.CpcAño;
                            //    PeriodoValidacion = cpc.CpcPeriodo;
                            //}


                            int i = AlumnoPagoAcademia(alumno.AlMatricula.Trim(), AñoValidadcion, PeriodoValidacion);

                            if (i > 0)
                            {
                                //List<CuentasPorCobrar> CuentasAnteriores = (from cp in context.CuentasPorCobrar
                                //                                      where cp.CpcAlumnoClave == alumno.AlMatricula.Trim()
                                //                                      orderby cp.CpcAño descending
                                //                                      orderby cp.CpcPeriodo descending
                                //                                      select cp).ToList();

                                int j = 0;

                                //if (CuentasAnteriores[0].CpcAño == AñoValidadcion && CuentasAnteriores[0].CpcPeriodo == PeriodoValidacion && CuentasAnteriores.Count > 1)
                                //{
                                //    
                                //}

                                j = validaregistro(alumno.AlMatricula.Trim(), AñoValidadcion, PeriodoValidacion);

                                if (valida > 0 && j == 0)
                                {
                                    Ws(alumno.AlMatricula.Trim(), AñoValidadcion, PeriodoValidacion, "PRE");
                                    Console.WriteLine("Insersion de alumno PRE en semaforo en v2");
                                }
                                else if (valida == 0 && j == 0)
                                {
                                    Ws(alumno.AlMatricula.Trim(), AñoValidadcion, PeriodoValidacion, "REINS");
                                    Console.WriteLine("Insersion de alumno REINS en semaforo en v2");
                                }
                                else
                                {
                                    Console.WriteLine("ya existe en el semaforo un registro de este alumno");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No cuenta con un pago para cambio de estatus ");
                            }


                            Console.WriteLine("Pago cerrado");


                        }

                    }
                    Console.WriteLine("<--->");
                }

/*///////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/


                #region Prospectos

                //Devuelve la matricula
                string GeneraM(GeneralesProspecto existeM, long usuid)
                {
                    string matricula = "";
                    string msg = "";

                    Alumno alumno = new Alumno();


                    // Preguntamos si existe la matricula en ese prospecto
                    if (!string.IsNullOrEmpty(existeM.Gpmatricula.Trim()))
                    {
                        //terminamos proceso si existe matricula
                        string msg1 = "ERROR la matricula ya existe " + existeM.Gpmatricula;
                    }
                    else
                    {
                        matricula = Matricula(9);
                    }

                    //Generamos nueva matricula


                    // Preguntamos si hubo algun error al generar la nueva matricula
                    if (matricula.ToUpper().Contains("ERROR"))
                    {
                        // terminamos proceso si hubo error
                        return "ERROR: No se pudo generar la matricula";
                    }

                    //Actualizamos la matricula al prospecto
                    if (!string.IsNullOrEmpty(existeM.Gpmatricula.Trim()))
                    {
                        //Actualizamos si ya existe una matroucla
                        msg = Upd_GPMatricula(existeM, existeM.Gpmatricula);
                    }
                    else
                    {
                        msg = Upd_GPMatricula(existeM, matricula);
                    }


                    //preguntamos si hubo algun error 
                    if (msg.ToUpper().Contains("ERROR"))
                    {
                        // terminamos proceso si hubo error y devolvemos la matricula
                        return "ERROR: " + matricula;
                    }


                    if (!string.IsNullOrEmpty(existeM.Gpmatricula.Trim()))
                    {
                        //Actualizamos si ya existe una matroucla
                        alumno = paseProsAlum(existeM, existeM.Gpmatricula.Trim());
                        alumno = context.Alumno.First(a => a.AlMatricula.Trim() == existeM.Gpmatricula.Trim());
                    }
                    else
                    {
                        alumno = paseProsAlum(existeM, matricula);
                        alumno = context.Alumno.First(a => a.AlMatricula == matricula);
                    }

                    matricula = alumno.AlMatricula;

                    if (alumno.AlBecaActual > 0)
                    {
                        List<BecaAlumno> existe_becasAlu = existe_becasAluu((long)alumno.AlId, (short)alumno.AlAnoPeriodoActual, (int)alumno.AlPeriodoActual);
                        Becas beca = (from BE in context.Becas where BE.BecasId == alumno.AlBecaActual select BE).FirstOrDefault();
                        BecaAlumno becaAlumno = new BecaAlumno();
                        if (existe_becasAlu.Count == 0)
                        {
                            becaAlumno.AlId = alumno.AlId;
                            becaAlumno.BecasId = alumno.AlBecaActual;
                            becaAlumno.Beanio = (short?)alumno.AlAnoPeriodoActual;
                            becaAlumno.Beperiodo = alumno.AlPeriodoActual;
                            becaAlumno.Beinscrip = alumno.AlBecaInscripcion;
                            becaAlumno.Beparcialidades = alumno.AlBecaParcialidad;
                            becaAlumno.Betipo = 16;
                            becaAlumno.Usuid = existeM.Usuid;
                            becaAlumno.Beestatus = 12;
                            becaAlumno.Beconfirma = false;
                            AddBecaAlu(becaAlumno);

                            //Insersion de beca en v2
                            // string id = "";
                            int idbeca = 0;
                            string clavebeca = "", msj = "";
                            using (var context2 = new npsqlContext())
                            {
                                int id = context2.Ccbeca.Max(x => x.Beid);
                                //idbeca = Convert.ToInt32(id) + 1;


                                Ccbeca becav2 = new Ccbeca();
                                becav2.Beid = id + 1;
                                becav2.Beusario = alumno.AlMatricula.Trim();
                                becav2.Beperiodo = (short?)alumno.AlPeriodoActual;
                                becav2.Beanio = (short?)alumno.AlAnoPeriodoActual;
                                becav2.Beinscrip = alumno.AlBecaInscripcion;
                                becav2.Beparcialidades = alumno.AlBecaParcialidad;
                                becav2.Conceptoid = null;
                                becav2.Bcid = beca.BecasClave.Trim();
                                becav2.Betipo = "INI";
                                becav2.Beestatus = "ACT";
                                becav2.Beconfirma = 1;
                                becav2.Beconfecha = DateTime.Now;

                                try
                                {
                                    context2.Ccbeca.Add(becav2);
                                    context.SaveChanges();
                                    Console.WriteLine("Beca insertada en v2");
                                }
                                catch (Exception e)
                                {
                                    msj = e.Message;
                                    Console.WriteLine("ERROR al insertar beca en v2");
                                }
                            }
                        }

                    }


                    return matricula;
                }

                // Genera la nueva matricula de acuardo al Folio
                string Matricula(int usuid)
                {
                    string m = "";
                    char pad = '0';
                    DateTime today = DateTime.Today;
                    DateTime date1 = new DateTime(2000, 1, 1, 0, 00, 0);
                    int NewM = 0;
                    int id = 0;

                    Folio f = new Folio();


                    try
                    {
                        f = context.Folio
                          .Where(x => x.FolioAlu > 0)
                          .Where(x => x.FolioId == 1)
                          .OrderByDescending(x => x.FolioId)
                          .Take(1).First();

                        if (f.FolioAlu == 0)
                        {
                            NewM = 1;
                            id = 1;
                        }
                        else
                        {
                            NewM = f.FolioAlu + 1;
                            f.FolioAlu += 1;
                        }
                        f.FolioAluDate = today;
                        f.FolioAluUsuid = usuid;

                        m = "A" + NewM.ToString().PadLeft(9, pad);

                        context.Folio.Update(f);
                        context.SaveChanges();

                    }
                    catch (Exception e)
                    {
                        m = "ERROR " + e.Message;
                    }
                    return m;
                }

                // Pasamos de prospecto a Alumno
                Alumno paseProsAlum(GeneralesProspecto prospecto, string GPmatricula)
                {
                    string carrera = "", matricula = "";
                    int periodo = 0, anio = 0;

                    // Traemos objetos asociados del prospecto
                    Carreras carreras = context.Carreras.First(c => c.Idcarrera == prospecto.Idcarrera);
                    Campana campana = GetCampana(prospecto.Campid);
                    ContactoProspecto contacto = context.ContactoProspecto.FirstOrDefault(gp => gp.GpprospectoId == prospecto.GpProspectoId);

                    //Asignamos propiedades de los objetos creados
                    periodo = campana.Campperiodo;
                    anio = campana.Campanio;
                    carrera = carreras.CarreraClave.Trim();

                    Alumno alu = (from AL in context.Alumno where AL.AlMatricula.Trim() == GPmatricula.Trim() select AL).FirstOrDefault();
                    Alumno alumno = new Alumno();
                    #region Agrega alumno
                    // Creación de alumno

                    if (alu != null)
                    {
                        Console.WriteLine("El alumno ya existe");
                    }
                    else
                    {

                        alumno.AlMatricula = GPmatricula.Trim();
                        alumno.AlFechaIngreso = DateTime.Today.Date;
                        alumno.AlNombre = prospecto.GpNombre.Trim();
                        alumno.AlApp = prospecto.GpApp.Trim();
                        alumno.AlApm = prospecto.GpApm.Trim();
                        alumno.AlFechaNac = DateTime.Today.Date;
                        alumno.AlCorreoInst = GPmatricula.Trim().Replace("A", "a") + "@lainter.edu.mx";
                        alumno.AlSexo = false;
                        alumno.AlStatusActual = 34;
                        alumno.AlCarrera = prospecto.Idcarrera;
                        alumno.AlPeriodoActual = periodo;
                        alumno.AlAnoPeriodoActual = anio;
                        alumno.AlEsquemaPagoActual = (int)prospecto.GpModPago;
                        alumno.AlBecaActual = prospecto.GpBeca;
                        alumno.AlBecaParcialidad = prospecto.GpPorcentajeBeca;
                        alumno.AlBecaInscripcion = prospecto.GpBecaInscripcion;
                        alumno.AlDescPromocion = (int)prospecto.GpDescPromocion;
                        alumno.AlDocumentos = false;
                        alumno.AlFactura = false;
                        alumno.AlFechaInicioNivel = DateTime.Today.Date;
                        alumno.AlCicloActual = prospecto.Campid;
                        alumno.AlModalidadActual = prospecto.GpModalidadInterez;
                        alumno.AlCurp = "sinDatos";
                        alumno.AlBecaInscripcion = prospecto.GpBecaInscripcion;
                        alumno.AlDescPromocion = (int)prospecto.GpDescPromocion;
                        alumno.AlCoutaAdmin = prospecto.GpCoutaAdmin;
                        alumno.AlMontoDesc = prospecto.GpMontoDesc;
                        alumno.AlSemestre = prospecto.GpSemestre;
                        //Agregamos su usuario
                        add_Usuario(alumno);
                        #endregion

                        // Agregamos al alumno
                        matricula = Add_Alumno(alumno);
                        //Obtenemos alumno creado
                        alumno = context.Alumno.FirstOrDefault(a => a.AlMatricula == GPmatricula);

                        GeneralesAlumno generales = new GeneralesAlumno();
                        //Asignamos propiedades para generales alumnos
                        generales.GaAlumnoId = alumno.AlId;
                        if (contacto?.ContId > 0)
                        {
                            generales.GaNombreTutor = contacto.NombreC ?? "";
                            generales.GaApmtutor = contacto.ApmC ?? "";
                            generales.GaApptutor = contacto.AppC ?? "";
                            generales.GaTelefonoTutor = contacto.TelC ?? "";
                            generales.GaTelefonoCasa = contacto.TelC ?? "";
                            generales.GaCorreoAlternativo = contacto.EmailC ?? "";
                        }
                        else
                        {
                            generales.GaNombreTutor = "";
                            generales.GaApmtutor = "";
                            generales.GaApptutor = "";
                            generales.GaTelefonoTutor = "";
                            generales.GaCorreoAlternativo = prospecto.GpCorreoElectronico ?? "";
                            generales.GaTelefonoCasa = prospecto.GpTelefono ?? "";
                        }

                        generales.GaTelefonoAlumno = prospecto.GpTelefono;
                        generales.GaEstado = prospecto.GpEstado;
                        generales.GaMunicipio = 1;
                        generales.GaFechaNac = DateTime.Now;
                        // Agregamos generales alumno
                        Add_GenAlumno(generales);
                        #endregion
                        return alumno;
                    }

                    if (alu == null)
                    {
                        return alumno;
                    }
                    else
                    {
                        return alu;
                    }


                    #region GeneralesAlumno

                }

                // registra concepto
                string RegistraConcepto(long ALId, long usuario, int año, int periodo, ListaPrecios lista, DateTime fechaVencimiento, int unidad)
                {
                    string resultado = "";
                    List<DetalleCuentaPorCobrar> detalleCuentas = new List<DetalleCuentaPorCobrar>();
                    DetalleCuentaPorCobrar detalle = new DetalleCuentaPorCobrar();

                    if (BuscaEsquemaCargado(ALId, año, periodo, lista.LpId))
                    {
                        return "ERROR: El alumno ya tiene registrado este concepto de pago";
                    }

                    resultado = CargaCuenta(ALId, usuario, año, periodo, lista, 0, unidad);

                    if (resultado.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el concepto, comuniquese con el administrador";
                    }

                    for (int i = 0; i < unidad; i++)
                    {
                        detalle = new DetalleCuentaPorCobrar();
                        detalle.DcpcDescripcion = lista.LpDescripcion;
                        detalle.DcpcDocLinea = NumLinea(i + 1);
                        detalle.DcpcFechaVencimiento = DateTime.Now;
                        detalle.DcpcImportePendiente = lista.LpMonto;
                        detalle.DcpcImporteTotal = lista.LpMonto;
                        detalleCuentas.Add(detalle);
                    }

                    resultado = CargaDetalleCuenta(ALId, usuario, detalleCuentas);


                    if (resultado.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle del concepto, comuniquese con el administrador";
                    }


                    return "Registro de concepto correcto";


                }

                // registramos el esquema
                string RegistraEsquema(long ALId, long usuario, int año, int periodo, EsquemaPago esquema)
                {
                    string msg = "", resultado = "";
                    bool error = false;
                    List<DetalleCuentaPorCobrar> detalleCuentas;
                    ListaPrecios lista = ObtListaPrecio(esquema.EpListaPrecio);
                    if (lista is null)
                    {
                        lista = new ListaPrecios();
                    }

                    if (BuscaEsquemaCargado(ALId, año, periodo, lista.LpId))
                    {
                        return "ERROR: El alumno ya tiene registrado este esquema de pago";
                    }

                    resultado = CargaCuenta(ALId, usuario, año, periodo, lista, 0, 1);

                    if (resultado.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el concepto, comuniquese con el administrador";
                    }


                    detalleCuentas = CalculaEsquema(esquema);

                    resultado = CargaDetalleCuenta(ALId, usuario, detalleCuentas);


                    if (resultado.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle del concepto, comuniquese con el administrador";
                    }


                    return resultado;


                }
                //Asociamos el pago al alumno nuevo y cerramos la cuenta
                string AsociaPagoProspecto(AlumnoPagos pago)
                {
                    string msg = "", resultado = "";
                    bool error = false;
                    decimal pendCuenta = 0, pendBeca = 0;
                    List<DetallePago> list_detalle_pago = new List<DetallePago>();
                    List<DetalleCuentaPorCobrar> cuentasBeca;
                    DetallePago _detallePago;
                    int contador = 0;

                    //Obtiene lista de cuentas pendientes que incluya Inscripcion, Cuota y Primera Parcialidad, incluyendo descuentos
                    List<DetalleCuentaPorCobrar> cuentasTemp = ListaDetalleCuentaReqInscripcion((long)pago.ApAlumnoId);
                    // asigamos el importe del pago a una variable local
                    decimal pendPago = pago.ApImportePendiente;

                    foreach (var cuenta in cuentasTemp)
                    {
                        pendBeca = 0;
                        pendCuenta = 0;
                        cuentasBeca = cuenta.InverseDcpcReferenciaCuentaDetalleNavigation.ToList();

                        if (cuentasBeca.Count > 0)
                        {
                            foreach (var cuentab in cuentasBeca)
                            {
                                pendBeca += cuentab.DcpcImportePendiente;
                            }
                        }
                        else
                        {
                            pendBeca = 0;
                        }

                        pendCuenta = cuenta.DcpcImportePendiente + pendBeca;

                        if (pendPago >= pendCuenta)
                        {
                            pendPago -= pendCuenta;

                            contador++;
                            _detallePago = new DetallePago();
                            _detallePago.DpCuentaDetalle = cuenta.DcpcId;
                            _detallePago.DpCuentaDetalleNavigation = cuenta;
                            _detallePago.DpImportePendiente = cuenta.DcpcImportePendiente;
                            _detallePago.DpImporteAplicado = cuenta.DcpcImportePendiente;
                            _detallePago.DpDocLinea = NumLinea(contador);
                            list_detalle_pago.Add(_detallePago);


                            foreach (var beca in cuentasBeca)
                            {
                                contador++;
                                _detallePago = new DetallePago();
                                _detallePago.DpCuentaDetalle = beca.DcpcId;
                                _detallePago.DpCuentaDetalleNavigation = beca;
                                _detallePago.DpImportePendiente = beca.DcpcImportePendiente;
                                _detallePago.DpImporteAplicado = beca.DcpcImportePendiente;
                                _detallePago.DpDocLinea = NumLinea(contador);
                                list_detalle_pago.Add(_detallePago);
                            }



                        }
                        else if (pendPago < pendCuenta && pendPago > 0)
                        {
                            contador++;
                            _detallePago = new DetallePago();
                            _detallePago.DpCuentaDetalle = cuenta.DcpcId;
                            _detallePago.DpCuentaDetalleNavigation = cuenta;
                            _detallePago.DpImportePendiente = cuenta.DcpcImportePendiente;
                            _detallePago.DpImporteAplicado = pendPago + (pendBeca * -1);
                            _detallePago.DpDocLinea = NumLinea(contador);
                            list_detalle_pago.Add(_detallePago);



                            foreach (var beca in cuentasBeca)
                            {
                                contador++;
                                _detallePago = new DetallePago();
                                _detallePago.DpCuentaDetalle = beca.DcpcId;
                                _detallePago.DpCuentaDetalleNavigation = beca;
                                _detallePago.DpImportePendiente = beca.DcpcImportePendiente;
                                _detallePago.DpImporteAplicado = beca.DcpcImportePendiente;
                                _detallePago.DpDocLinea = NumLinea(contador);
                                list_detalle_pago.Add(_detallePago);
                            }
                            pendPago = 0;

                        }

                    }

                    // si sobra saldo a favor
                    if (pendPago > 0)
                    {
                        ConfiguracionPagos _configuracion = configuracion();

                        // obtenemos la lista de precio del descuento
                        ListaPrecios listap = ObtListaPrecio(1127);
                        listap.LpMonto = pendPago * -1;

                        // registramos el saldo a favor
                        string registraSaldoFavor = RegistraDescuento((long)pago.ApAlumnoId, pago.ApUsuid, (int)_configuracion.ConfAño, (int)_configuracion.ConfPeriodo, listap, 0);

                        if (!registraSaldoFavor.ToUpper().Contains("ERROR"))
                        {
                            // obtenemos la cuentaxcobrar del saldo
                            CuentasPorCobrar saldoCxc = ObtSaldoFavorAlumno((long)pago.ApAlumnoId);

                            // asiganos a detallepago el saldo a favor
                            foreach (var item in saldoCxc.DetalleCuentaPorCobrar)
                            {
                                contador++;
                                _detallePago = new DetallePago();
                                _detallePago.DpCuentaDetalle = item.DcpcId;
                                _detallePago.DpCuentaDetalleNavigation = item;
                                _detallePago.DpImportePendiente = item.DcpcImportePendiente;
                                _detallePago.DpImporteAplicado = item.DcpcImportePendiente;
                                _detallePago.DpDocLinea = NumLinea(contador);
                                _detallePago.DpSaldoCreado = true;
                                list_detalle_pago.Add(_detallePago);
                            }

                            pendPago = 0;

                        }
                        else
                        {
                            msg = "Ocurrio un error al registrar el saldo a favor, comuniquese con el administrador";
                        }
                    }

                    pago.ApImportePendiente = pendPago;
                    // Actualizamos pagos
                    string updatePago = ActualizarPagos(pago, list_detalle_pago);

                    if (updatePago.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle del pago, comuniquese con el administrador";
                    }


                    Referencias pagoRef = ObtReferenciaRef(pago.ApReferencia);
                    pagoRef.RReferenciaStatus = 28;
                    pagoRef.RAlumnoId = pago.ApAlumnoId;

                    // Llenamos la lista de detalle de referencia
                    List<DetalleReferencia> list_detalle_ref = LlenaDetalleReferenciaPago(list_detalle_pago);

                    string updReferencia = ActualizarReferencia(pagoRef, list_detalle_ref);

                    if (updReferencia.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle de la referencia, comuniquese con el administrador";
                    }

                    return "Cierre de pago prospecto correcto";


                }

                //Actualizamos el prospecto a inscrito
                string upd_EstatusInsc(long idPros)
                {
                    GeneralesProspecto GP = new GeneralesProspecto();
                    string msg = "";

                    GP = traer_prospecto(idPros);

                    if (GP.GpEstatus == 2)
                    {
                        GP.GpEstatus = 9;

                        msg = Upd_EstPros(GP);
                    }
                    else
                    {
                        msg = "ERROR Este prospecto no tiene el estatus aspirante";
                    }

                    return msg;
                }

                // Traemos el prospecto por su id
                GeneralesProspecto traer_prospecto(long GPId)
                {
                    return (from GP in context.GeneralesProspecto
                            where GP.GpProspectoId == GPId
                            select GP).FirstOrDefault();
                }

                #endregion

                #region Alumnos

                #endregion
                #region General
                // agregamos usuario
                Usuario add_Usuario(Alumno Alu)
                {
                    Usuario user = new Usuario();

                    user.Usuid = 0;
                    user.Usuusuario = Alu.AlMatricula;
                    user.Usupassword = Alu.AlMatricula;
                    user.Rolid = 14;
                    user.Usutipo = "ALU";
                    user.Usuidtipo = 4;
                    user.Usukey = "";
                    user.Usuactivo = false;
                    user.UsumoodleP = 0;
                    user.UsumoodleL = 0;
                    user.UsumoodleM = 0;
                    user.Usumovil = "0";
                    user.Usuip = "";
                    user.Usupid = 1;
                    user.Usuequipo = "";
                    user.Usuimage = null;
                    user.UsulastChange = DateTime.Now;
                    user.Ususession = DateTime.Now;

                    context.Usuario.Add(user);
                    context.SaveChanges();

                    return user;
                }

                //ObtenemosCampana
                Campana GetCampana(int campId)
                {
                    Campana c = new Campana();

                    c = context.Campana.First(c => c.Campid == campId);

                    return c;
                }

                //Obtiene la beca de un alumno
                List<BecaAlumno> existe_becasAluu(long alu, short anio, int periodo)
                {
                    List<BecaAlumno> existe_bealu = new List<BecaAlumno>();
                    existe_bealu = (from BecaAlumno in context.BecaAlumno
                                    where BecaAlumno.Beestatus != 15 && BecaAlumno.Beestatus != 14 &&
                                    BecaAlumno.Beanio == anio && BecaAlumno.Beperiodo == periodo && BecaAlumno.AlId == alu
                                    select BecaAlumno).ToList();
                    return existe_bealu;
                }

                //Busca la beca registrada
                BecaAlumno BuscaBecaReg(long ALId, int a, int periodo)
                {
                    BecaAlumno _becaReg = new BecaAlumno();

                    _becaReg = context.BecaAlumno.First(BA => BA.AlId == ALId && BA.Beanio == a && BA.Beperiodo == periodo);

                    return _becaReg;
                }

                // obtenemos el alumno por matricula
                Alumno ObtAlumnoMatricula(string Matricula)
                {
                    return (from AL in context.Alumno
                            join Car in context.Carreras on AL.AlCarrera equals Car.Idcarrera
                            join Est in context.EstatusList on AL.AlStatusActual equals Est.SlStatusId
                            where AL.AlMatricula == Matricula
                            orderby AL.AlMatricula
                            select new Alumno
                            {
                                AlId = AL.AlId,
                                AlMatricula = AL.AlMatricula.Trim(),
                                AlNombre = AL.AlNombre.Trim(),
                                AlApp = AL.AlApp.Trim(),
                                AlApm = AL.AlApm.Trim(),
                                AlCarrera = AL.AlCarrera,
                                AlCarreraNavigation = Car,
                                AlStatusActual = AL.AlStatusActual,
                                AlStatusActualNavigation = Est,
                                AlPeriodoActual = AL.AlPeriodoActual,
                                AlAnoPeriodoActual = AL.AlAnoPeriodoActual,
                                AlMontoDesc = AL.AlMontoDesc,
                                AlCoutaAdmin = AL.AlCoutaAdmin,
                                AlEsquemaPagoActual = AL.AlEsquemaPagoActual,
                                AlBecaActual = AL.AlBecaActual
                            }).FirstOrDefault();
                }

                // obtenemos alumno por id
                Alumno ObtAlumno(long Alid)
                {
                    return (from AL in context.Alumno
                            join Car in context.Carreras on AL.AlCarrera equals Car.Idcarrera
                            join Est in context.EstatusList on AL.AlStatusActual equals Est.SlStatusId
                            where AL.AlId == Alid
                            orderby AL.AlMatricula
                            select new Alumno
                            {
                                AlId = AL.AlId,
                                AlMatricula = AL.AlMatricula.Trim(),
                                AlNombre = AL.AlNombre.Trim(),
                                AlApp = AL.AlApp.Trim(),
                                AlApm = AL.AlApm.Trim(),
                                AlCarrera = AL.AlCarrera,
                                AlCarreraNavigation = Car,
                                AlStatusActual = AL.AlStatusActual,
                                AlStatusActualNavigation = Est,
                                AlPeriodoActual = AL.AlPeriodoActual,
                                AlAnoPeriodoActual = AL.AlAnoPeriodoActual,
                                AlMontoDesc = AL.AlMontoDesc,
                                AlCoutaAdmin = AL.AlCoutaAdmin,
                                AlEsquemaPagoActual = AL.AlEsquemaPagoActual,
                                AlBecaActual = AL.AlBecaActual
                            }).FirstOrDefault();
                }

                // Obtiene esquema actual de un alumno
                EsquemaPago ObtEsquema(int esquemaId)
                {
                    EsquemaPago esquema = (from E in context.EsquemaPago
                                           where E.EpId == esquemaId
                                           select E
                            ).FirstOrDefault();


                    return esquema;
                }

                // Obtiene la lista de precios
                ListaPrecios ObtListaPrecio(int listaId)
                {
                    return (from LP in context.ListaPrecios
                            join Con in context.CatalogoConceptos on LP.LpConcepto equals Con.ConId
                            join N in context.Niveles on LP.LpNivel equals N.NivelId into NIV
                            from Nivel in NIV.DefaultIfEmpty()
                            join C in context.Carreras on LP.LpCarrera equals C.Idcarrera into CAR
                            from Carrera in CAR.DefaultIfEmpty()
                            where LP.LpId == listaId
                            orderby LP.LpId descending
                            select new ListaPrecios
                            {
                                LpId = LP.LpId,
                                LpDescripcion = LP.LpDescripcion,
                                LpMonto = LP.LpMonto,
                                LpParcialidades = LP.LpParcialidades,
                                LpGeneracion = LP.LpGeneracion,
                                LpFechaInicio = LP.LpFechaInicio,
                                LpFechaFin = LP.LpFechaFin,
                                LpFechaRegistro = LP.LpFechaRegistro,
                                LpConcepto = LP.LpConcepto,
                                LpConceptoNavigation = Con,
                                LpCarrera = LP.LpCarrera,
                                LpCarreraNavigation = Carrera,
                                LpNivel = LP.LpNivel,
                                LpNivelNavigation = Nivel
                            }).FirstOrDefault();
                }

                // Carga cuenta por cobrar
                string CargaCuenta(long ALId, long usuario, int año, int periodo, ListaPrecios lista, int referenciaCuenta, int unidad)
                {
                    Alumno alumno = ObtAlumno(ALId);
                    CuentasPorCobrar _cuenta = new CuentasPorCobrar();
                    _cuenta.CpcAlumnoId = ALId;
                    _cuenta.CpcAlumnoClave = alumno.AlMatricula;
                    _cuenta.CpcListaPrecio = lista.LpId;
                    _cuenta.CpcFechaCreacion = DateTime.Now;
                    _cuenta.CpcReferenciaCuenta = referenciaCuenta;
                    _cuenta.CpcUnidad = unidad;
                    _cuenta.CpcPrecioUnitario = lista.LpMonto;
                    _cuenta.CpcImporteTotal = _cuenta.CpcPrecioUnitario * _cuenta.CpcUnidad;
                    _cuenta.CpcImportePendiente = _cuenta.CpcImporteTotal;
                    _cuenta.CpcAño = año;
                    _cuenta.CpcPeriodo = periodo;
                    _cuenta.CpcUsuid = usuario;
                    _cuenta.CpcEstatus = 21;

                    return AddCuentaPorCobrar(_cuenta);
                }

                // Carga detalle de cuentas 
                string CargaDetalleCuenta(long ALId, long usuario, List<DetalleCuentaPorCobrar> detalle)
                {
                    DetalleCuentaPorCobrar _cuentaD;
                    string msg = "";
                    bool error = false;
                    int cuentaId = ObtCuentaPorCobrarAlumno(ALId);

                    foreach (var det in detalle)
                    {
                        _cuentaD = new DetalleCuentaPorCobrar();
                        _cuentaD.DcpcCuentaId = cuentaId;
                        _cuentaD.DcpcDescripcion = det.DcpcDescripcion;
                        _cuentaD.DcpcDocLinea = det.DcpcDocLinea;
                        _cuentaD.DcpcImporteTotal = det.DcpcImporteTotal;
                        _cuentaD.DcpcImportePendiente = det.DcpcImportePendiente;
                        _cuentaD.DcpcFechaVencimiento = det.DcpcFechaVencimiento;
                        _cuentaD.DcpcFechaCierreCuenta = null;
                        _cuentaD.DcpcReferenciaCuentaDetalle = det.DcpcReferenciaCuentaDetalle;
                        _cuentaD.DcpcUsuid = usuario;
                        _cuentaD.DcpcEstatus = 21;



                        msg = AddCuentaPorCobrarDetalle(_cuentaD);
                        error = msg.ToUpper().Contains("ERROR");

                        if (error)
                        {
                            break;
                        }
                    }

                    return msg;
                }

                // busca esquema cargado 
                bool BuscaEsquemaCargado(long ALId, int año, int periodo, int lista)
                {
                    return (from CP in context.CuentasPorCobrar
                            where CP.CpcListaPrecio == lista
                            where CP.CpcAlumnoId == ALId
                            where CP.CpcPeriodo == periodo
                            where CP.CpcAño == año
                            where CP.CpcEstatus == 21
                            select CP
                            ).Any();
                }

                // Genera el numero de linea
                string NumLinea(int cont)
                {
                    string numDoc = "";

                    if (cont.ToString().Trim().Length == 1)
                    {
                        numDoc = "00" + cont.ToString().Trim();
                    }
                    else if (cont.ToString().Length == 2)
                    {
                        numDoc = "0" + cont.ToString().Trim();
                    }
                    else if (cont.ToString().Length == 3)
                    {
                        numDoc = cont.ToString().Trim();
                    }

                    return numDoc;
                }

                // obtiene id de cuenta por cobrar
                int ObtCuentaPorCobrarAlumno(long Alid)
                {
                    return (from CP in context.CuentasPorCobrar
                            where CP.CpcAlumnoId == Alid
                            orderby CP.CpcId descending
                            select CP.CpcId
                            ).FirstOrDefault();
                }

                //Calcula el esquema para asignarle a un nuevo alumno
                List<DetalleCuentaPorCobrar> CalculaEsquema(EsquemaPago esquema)
                {
                    List<DetalleCuentaPorCobrar> _cuentasDetalle = new List<DetalleCuentaPorCobrar>();
                    ListaPrecios listap = ObtListaPrecio(esquema.EpListaPrecio);
                    DetalleCuentaPorCobrar _detalle;
                    int mesInscripcion = 0, contadorCol = 1, contadorIns = 1;
                    DateTime fechaAux;

                    int diaVencimiento = (int)ObtDiaVencimiento();

                    if (esquema.EpNoInscripciones > 0)
                    {
                        if (esquema.EpNoInscripciones > 1)
                            mesInscripcion = esquema.EpNoMensualidades / esquema.EpNoInscripciones;
                        else
                            mesInscripcion = 1;
                    }

                    for (int i = 0; i < esquema.EpNoMensualidades; i++)
                    {
                        fechaAux = esquema.EpFechaInicio.AddMonths(i);
                        fechaAux = new DateTime(fechaAux.Year, fechaAux.Month, diaVencimiento);

                        if (esquema.EpNoInscripciones > 0)
                        {
                            if (esquema.EpNoInscripciones == contadorCol || mesInscripcion == contadorCol)
                            {
                                _detalle = new DetalleCuentaPorCobrar();

                                if (esquema.EpNoInscripciones > 1)
                                    _detalle.DcpcDescripcion = "Inscripción" + contadorIns.ToString().Trim();
                                else
                                    _detalle.DcpcDescripcion = "Inscripción";

                                _detalle.DcpcDocLinea = NumLinea(contadorCol);
                                _detalle.DcpcFechaVencimiento = fechaAux;
                                _detalle.DcpcImportePendiente = esquema.EpMontoInscripcion;
                                _detalle.DcpcImporteTotal = esquema.EpMontoInscripcion;
                                _cuentasDetalle.Add(_detalle);
                                contadorIns++;
                                contadorCol++;
                            }
                        }

                        _detalle = new DetalleCuentaPorCobrar();

                        if (esquema.EpNoInscripciones > 0)
                            _detalle.DcpcDescripcion = "Parcialidad " + MonthName(fechaAux.Month) + " " + fechaAux.Year;
                        else
                            _detalle.DcpcDescripcion = listap.LpConceptoNavigation.ConDescripcion + " # " + contadorCol;

                        _detalle.DcpcDocLinea = NumLinea(contadorCol);
                        _detalle.DcpcFechaVencimiento = fechaAux;
                        _detalle.DcpcImportePendiente = esquema.EpMontoMensualidad;
                        _detalle.DcpcImporteTotal = esquema.EpMontoMensualidad;
                        _cuentasDetalle.Add(_detalle);
                        contadorCol++;


                    }

                    return _cuentasDetalle;
                }

                // obtiene el dia vencimiento de la configuración
                int? ObtDiaVencimiento()
                {
                    return (from C in context.ConfiguracionPagos
                            where C.ConfId == 1
                            select C.ConfDiaVencimiento
                           ).FirstOrDefault();
                }

                //Obtiene el nombre del mes
                string MonthName(int numberMonth)
                {
                    DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                    string month = "", temp = "";

                    temp = dtinfo.GetMonthName(numberMonth).ToLower();
                    month = temp.Substring(0, 1).ToUpper() + temp.Substring(1);

                    return month;
                }

                // Traemos la beca del alumno
                VresolutivoBeca traer_resolutivoNI(long Aid)
                {
                    VresolutivoBeca _rbecaNI = new VresolutivoBeca();

                    _rbecaNI = context.VresolutivoBeca.First(RB => RB.AlId == Aid);

                    return _rbecaNI;
                }

                // trae la lista de rpecio de una beca
                int BuscaListaPBeca(int? bid)
                {
                    return (from B in context.Becas
                            join CC in context.CatalogoConceptos on B.ConId equals CC.ConId
                            join LP in context.ListaPrecios on CC.ConId equals LP.LpConcepto
                            where B.BecasId == bid
                            select LP.LpId
                            ).FirstOrDefault();
                }

                // Carga el esquema de una beca
                string cargaCuentas(VresolutivoBeca _becaAl)
                {
                    string mensaje = "";

                    CuentasPorCobrar _cuenta = new CuentasPorCobrar();
                    DetalleCuentaPorCobrar _cuentaD = new DetalleCuentaPorCobrar();

                    BecaAlumno _BA = new BecaAlumno();
                    bool error = false;

                    // trae el id de la lista de precio
                    int lp = BuscaListaPBeca((int)_becaAl.BecasId);

                    // si el id de la lista de precio es de 0
                    if (lp == 0)
                    {
                        // termina el proceso
                        return "ERROR: comunicate con el administrador";
                    }

                    // pregunta si existe un esquema actal  de beca del alumno
                    if (!BuscaEsquemaActual((long)_becaAl.AlId, (short)_becaAl.Beanio, (int)_becaAl.Beperiodo))
                    {
                        return "ERROR: No hay registros con importe pendiente para aplicar la beca";
                    }

                    // obtiene la cuenta por cobrar
                    CuentasPorCobrar _c = BuscaEsquemaA((long)_becaAl.AlId, (short)_becaAl.Beanio, (int)_becaAl.Beperiodo);

                    // trae detalle de cuentas xcobrar que elimporte sea mayor a 0 para aplicar la beca
                    List<DetalleCuentaPorCobrar> listaDet = Trae_detalleCxCPendiente(_c.CpcId);

                    // Si la lista no tiene nada
                    if (listaDet.Count <= 0)
                    {
                        return "ERROR: No hay registros con importe pendiente para aplicar la beca";
                    }


                    decimal total = 0;
                    foreach (var dts in listaDet)
                    {
                        if (dts.DcpcDocLinea == "001") //inscripcion
                        {
                            // aplicamos el descuento de la beca para la cuenta por cobrar
                            total += dts.DcpcImporteTotal * _becaAl.Beinscrip / 100;
                        }
                        else //parcialidades
                        {
                            // aplicamos el descuento de la beca para la cuenta por cobrar
                            total += dts.DcpcImporteTotal * _becaAl.Beparcialidades / 100;
                        }
                    }

                    decimal total2 = 0;
                    // total de la beca para la cuenta poor cobrar
                    total2 = total * -1;
                    _cuenta = new CuentasPorCobrar();
                    _cuenta.CpcAlumnoId = _becaAl.AlId;
                    _cuenta.CpcListaPrecio = lp;
                    _cuenta.CpcFechaCreacion = DateTime.Now;
                    _cuenta.CpcReferenciaCuenta = _c.CpcId;
                    _cuenta.CpcUnidad = 1;
                    _cuenta.CpcPrecioUnitario = total2;
                    _cuenta.CpcImporteTotal = total2 * _cuenta.CpcUnidad;
                    _cuenta.CpcImportePendiente = total2;
                    _cuenta.CpcAño = Convert.ToInt32(_becaAl.Beanio);
                    _cuenta.CpcPeriodo = Convert.ToInt32(_becaAl.Beperiodo);
                    _cuenta.CpcUsuid = 9;
                    _cuenta.CpcEstatus = 21;
                    _cuenta.CpcAlumnoClave = _becaAl.AlMatricula;
                    // agregamos la cuenta por cobrar 
                    string addCXCobrar = AddCuentaPorCobrar(_cuenta);

                    if (addCXCobrar.ToUpper().Contains("ERROR"))
                    {
                        return "No se pudo registrar la cuenta por cobrar de la beca";
                    }

                    // obtenemos cxcobrar de la beca id
                    _cuenta.CpcId = ObtCuentaPorCobrarBeca(_becaAl.AlId);
                    // traemos los detalles de la cuenta por cobrar para aplicar el descuento
                    List<DetalleCuentaPorCobrar> listaDetpend = Trae_detalleCxCPendiente(_c.CpcId);

                    foreach (var detp in listaDetpend)
                    {
                        if (_becaAl.Beinscrip > 0 && detp.DcpcDocLinea == "001") //inscripcion
                        {
                            decimal descuento = 0;
                            // se hace el descuento de la beca para inscripción
                            descuento += detp.DcpcImporteTotal * _becaAl.Beinscrip / 100;
                            _cuentaD = new DetalleCuentaPorCobrar();
                            _cuentaD.DcpcCuentaId = _cuenta.CpcId;
                            _cuentaD.DcpcDescripcion = _becaAl.BecasNombre;
                            _cuentaD.DcpcDocLinea = detp.DcpcDocLinea;
                            _cuentaD.DcpcImporteTotal = descuento * -1;
                            _cuentaD.DcpcImportePendiente = descuento * -1;
                            _cuentaD.DcpcFechaVencimiento = detp.DcpcFechaVencimiento;
                            _cuentaD.DcpcReferenciaCuentaDetalle = detp.DcpcId;
                            _cuentaD.DcpcFechaCierreCuenta = null;
                            _cuentaD.DcpcUsuid = 9;
                            _cuentaD.DcpcEstatus = 21;

                            mensaje = AddCuentaPorCobrarDetalle(_cuentaD);
                        }
                        else if (_becaAl.Beparcialidades > 0 && detp.DcpcDocLinea != "001")//parcialidades
                        {
                            decimal descuento = 0;
                            // se hace el descuento de la beca para cada paricalidad
                            descuento += detp.DcpcImporteTotal * _becaAl.Beparcialidades / 100;
                            _cuentaD = new DetalleCuentaPorCobrar();
                            _cuentaD.DcpcCuentaId = _cuenta.CpcId;
                            _cuentaD.DcpcDescripcion = _becaAl.BecasNombre;
                            _cuentaD.DcpcDocLinea = detp.DcpcDocLinea;
                            _cuentaD.DcpcImporteTotal = descuento * -1;
                            _cuentaD.DcpcImportePendiente = descuento * -1;
                            _cuentaD.DcpcFechaVencimiento = detp.DcpcFechaVencimiento;
                            _cuentaD.DcpcReferenciaCuentaDetalle = detp.DcpcId;
                            _cuentaD.DcpcFechaCierreCuenta = null;
                            _cuentaD.DcpcUsuid = 9;
                            _cuentaD.DcpcEstatus = 21;
                            mensaje = AddCuentaPorCobrarDetalle(_cuentaD);

                        }
                    }
                    //llama para actualizar la confirmacion
                    _BA = new BecaAlumno();
                    _BA.Beid = _becaAl.Beid;
                    _BA.BecasId = _becaAl.BecasId;
                    _BA.AlId = _becaAl.AlId;
                    _BA.Usuid = 14;//idusuario;
                    _BA.Beinscrip = _becaAl.Beinscrip;
                    _BA.Beparcialidades = _becaAl.Beparcialidades;
                    _BA.Beperiodo = _becaAl.Beperiodo;
                    _BA.Beanio = _becaAl.Beanio;
                    _BA.Beestatus = _becaAl.Beestatus;
                    int? est2 = _becaAl.Beestatus;
                    // confirmamos la beca
                    mensaje = ConfirmaBecaAlu(_BA, est2, 13);
                    return mensaje;
                }

                // busca esquema actual de un alumno
                bool BuscaEsquemaActual(long ALId, int a, int periodo)
                {
                    return (from CP in context.CuentasPorCobrar
                            where CP.CpcImporteTotal > 0 && CP.CpcAlumnoId == ALId && CP.CpcPeriodo == periodo && CP.CpcAño == a && CP.CpcEstatus == 21
                            select CP
                            ).Any();
                }

                // obtiene cuenta por cobrar alumno siempre que el importe sea mayor a 0
                CuentasPorCobrar BuscaEsquemaA(long ALId, int a, int periodo)
                {
                    return (from CC in context.CuentasPorCobrar
                            join LP in context.ListaPrecios on CC.CpcListaPrecio equals LP.LpId
                            join CO in context.CatalogoConceptos on LP.LpConcepto equals CO.ConId
                            where CC.CpcEstatus == 21
                            where CO.ConTipoConcepto == 1
                            where CC.CpcAlumnoId == ALId
                            where CC.CpcAño == a
                            where CC.CpcPeriodo == periodo
                            orderby CC descending
                            select CC).FirstOrDefault();
                }

                // Devuelve los detalles de pago de una cuenta
                List<DetalleCuentaPorCobrar> Trae_detalleCxCPendiente(int cuenta)
                {
                    List<DetalleCuentaPorCobrar> _detallePen = new List<DetalleCuentaPorCobrar>();

                    _detallePen = (from dc in context.DetalleCuentaPorCobrar
                                   where dc.DcpcEstatus == 21 && dc.DcpcImportePendiente > 0 && dc.DcpcCuentaId == cuenta
                                   select dc).ToList();

                    return _detallePen;
                }

                List<DetalleReferencia> TraeDetalleReferencias(int idRef)
                {
                    return (from DR in context.DetalleReferencia
                            where DR.DrReferencia == idRef
                            select DR).ToList();
                }

                // registra descuento
                string RegistraDescuento(long ALId, long usuario, int año, int periodo, ListaPrecios lista, int ReferenciaCpid)
                {
                    List<DetalleCuentaPorCobrar> detalleCuentas = new List<DetalleCuentaPorCobrar>();

                    //preguntamos si ya existe el esquema 
                    if (BuscaEsquemaCargado(ALId, año, periodo, lista.LpId))
                    {
                        return "ERROR El alumno ya tiene registrado este concepto.";
                    }
                    // cargamos la ceuntaxcobrar del decuento
                    string cargaDescuento = CargaCuenta(ALId, usuario, año, periodo, lista, ReferenciaCpid, 1);

                    // PREGUNTAMOS si hubo algun error al registrar la cuenta por cobrar
                    if (cargaDescuento.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR Ocurrio un error al registrar el concepto, comuniquese con el administrador";
                    }

                    // creamos nuevo detalle pago para insertar
                    DetalleCuentaPorCobrar detalle = new DetalleCuentaPorCobrar();
                    detalle.DcpcDescripcion = lista.LpDescripcion;
                    detalle.DcpcDocLinea = "001";
                    detalle.DcpcFechaVencimiento = DateTime.Now;
                    detalle.DcpcImportePendiente = lista.LpMonto;
                    detalle.DcpcImporteTotal = lista.LpMonto;
                    detalle.DcpcReferenciaCuentaDetalle = ObtInscripcion(ReferenciaCpid);
                    detalleCuentas.Add(detalle);

                    // agregamos detalle de pago
                    string cargaDetalle = CargaDetalleCuenta(ALId, 9, detalleCuentas);

                    if (cargaDetalle.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: No se pudo cargar el detalle de pago del desceunto";
                    }

                    return "Regstro descuento correcto";

                }

                // obtenemos la cxcobrar de beca del alumno
                int ObtCuentaPorCobrarBeca(long? Alid)
                {
                    return (from CP in context.CuentasPorCobrar
                            where CP.CpcAlumnoId == Alid && CP.CpcImporteTotal < 0
                            orderby CP.CpcId descending
                            select CP.CpcId
                            ).FirstOrDefault();
                }

                // obtiene el detalle de cuyenta de inscripcion
                int ObtInscripcion(int Cpid)
                {
                    return (from DC in context.DetalleCuentaPorCobrar
                            join CC in context.CuentasPorCobrar on DC.DcpcCuentaId equals CC.CpcId
                            join LP in context.ListaPrecios on CC.CpcListaPrecio equals LP.LpId
                            join CO in context.CatalogoConceptos on LP.LpConcepto equals CO.ConId
                            where CC.CpcEstatus == 21
                            where DC.DcpcEstatus == 21
                            where DC.DcpcImportePendiente > 0
                            //where CO.ConClave == "COL" || CO.ConClave == "MOD"
                            where CO.ConTipoConcepto == 1
                            where DC.DcpcDocLinea == "001"
                            where DC.DcpcCuentaId == Cpid
                            orderby DC.DcpcId ascending
                            select DC.DcpcId).FirstOrDefault();
                }

                // Obtiene id de Alumno pago por matricula
                int ObtenerPagoIdMatricula(string mat)
                {
                    return (from AP in context.AlumnoPagos
                            where AP.ApAlumnoClave == mat
                            orderby AP.ApPagoId descending
                            select AP.ApPagoId
                            ).FirstOrDefault();
                }

                // Obtiene id de referencias por referencia
                long ObtIdReferenciaRef(string referencia)
                {
                    return (from R in context.Referencias
                            where R.RReferencia == referencia
                            orderby R.RReferenciaId descending
                            select R.RReferenciaId
                            ).FirstOrDefault();
                }

                // trae ceuntas detalle de la inscripción 
                List<DetalleCuentaPorCobrar> ListaDetalleCuentaReqInscripcion(long Aluid)
                {
                    List<DetalleCuentaPorCobrar> detalleCuentas = (from DC in context.DetalleCuentaPorCobrar
                                                                   join CC in context.CuentasPorCobrar on DC.DcpcCuentaId equals CC.CpcId
                                                                   join LP in context.ListaPrecios on CC.CpcListaPrecio equals LP.LpId
                                                                   join CO in context.CatalogoConceptos on LP.LpConcepto equals CO.ConId
                                                                   where CC.CpcEstatus == 21
                                                                   where DC.DcpcEstatus == 21
                                                                   where DC.DcpcImportePendiente > 0
                                                                   where CC.CpcAlumnoId == Aluid
                                                                   where CO.ConRequisitoInscripcion == true
                                                                   where DC.DcpcDocLinea == "001" || DC.DcpcDocLinea == "002"
                                                                   orderby DC.DcpcId ascending
                                                                   select new DetalleCuentaPorCobrar
                                                                   {
                                                                       DcpcId = DC.DcpcId,
                                                                       DcpcCuentaId = DC.DcpcCuentaId,
                                                                       DcpcCuenta = CC,
                                                                       DcpcDescripcion = DC.DcpcDescripcion,
                                                                       DcpcDocLinea = DC.DcpcDocLinea,
                                                                       DcpcImportePendiente = DC.DcpcImportePendiente,
                                                                       DcpcImporteTotal = DC.DcpcImporteTotal,
                                                                       DcpcFechaVencimiento = DC.DcpcFechaVencimiento,
                                                                       DcpcEstatus = DC.DcpcEstatus,
                                                                       InverseDcpcReferenciaCuentaDetalleNavigation = (from DCR in context.DetalleCuentaPorCobrar
                                                                                                                       where DCR.DcpcEstatus == 21
                                                                                                                       where DCR.DcpcReferenciaCuentaDetalle == DC.DcpcId
                                                                                                                       select DCR).ToList()
                                                                   }).ToList();

                    return detalleCuentas;
                }

                // obtiene la configuración
                ConfiguracionPagos configuracion()
                {
                    ConfiguracionPagos configuracion = (from C in context.ConfiguracionPagos
                                                        where C.ConfId == 1
                                                        select C
                            ).FirstOrDefault();

                    return configuracion;
                }

                // obtenemos cuenta por cobrar del saldo a favor del alumno
                CuentasPorCobrar ObtSaldoFavorAlumno(long Alid)
                {
                    return (from CC in context.CuentasPorCobrar
                            where CC.CpcAlumnoId == Alid
                            where CC.CpcListaPrecio == 1127
                            orderby CC.CpcId descending
                            select new CuentasPorCobrar
                            {
                                CpcId = CC.CpcId,
                                CpcAlumnoId = CC.CpcAlumnoId,
                                CpcAlumnoClave = CC.CpcAlumnoClave,
                                CpcFechaCreacion = CC.CpcFechaCreacion,
                                CpcReferenciaCuenta = CC.CpcReferenciaCuenta,
                                CpcUnidad = CC.CpcUnidad,
                                CpcPrecioUnitario = CC.CpcPrecioUnitario,
                                CpcImporteTotal = CC.CpcImporteTotal,
                                CpcImportePendiente = CC.CpcImportePendiente,
                                CpcAño = CC.CpcAño,
                                CpcPeriodo = CC.CpcPeriodo,
                                CpcEstatus = CC.CpcEstatus,
                                DetalleCuentaPorCobrar = (from DC in context.DetalleCuentaPorCobrar
                                                          where DC.DcpcCuentaId == CC.CpcId
                                                          select new DetalleCuentaPorCobrar
                                                          {
                                                              DcpcId = DC.DcpcId,
                                                              DcpcCuentaId = DC.DcpcCuentaId,
                                                              DcpcDescripcion = DC.DcpcDescripcion,
                                                              DcpcDocLinea = DC.DcpcDocLinea,
                                                              DcpcImportePendiente = DC.DcpcImportePendiente,
                                                              DcpcImporteTotal = DC.DcpcImporteTotal,
                                                              DcpcFechaVencimiento = DC.DcpcFechaVencimiento,
                                                              DcpcEstatus = DC.DcpcEstatus,
                                                          }).ToList()
                            }).FirstOrDefault();
                }

                //Actualizamos pago
                string ActualizarPagos(AlumnoPagos ap, List<DetallePago> detalle)
                {

                    // ACTUALIZAMOS ALUMNO PAGOS
                    string updAP = UpdAlumnoPagos(ap);

                    if (updAP.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al actualizar el pago, comuniquese con el administrador";
                    }


                    string DelDP = DelDetallePagoCadena(ap.ApPagoId);
                    if (DelDP.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al actualizar el detalle del pago, comuniquese con el administrador";
                    }


                    string cargaDetalleA = CargaDetalleAlumnoPago(ap.ApPagoId, ap.ApUsuid, detalle);

                    if (cargaDetalleA.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle del pago, comuniquese con el administrador";
                    }


                    string actualizaDetalle = ActualizaDetalleCuentaPago(detalle);
                    if (actualizaDetalle.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al registrar el detalle de la cuenta aplicada, comuniquese con el administrador";
                    }

                    return actualizaDetalle;



                }

                // Actualizamos los detalles de ceuntas de pago
                string ActualizaDetalleCuentaPago(List<DetallePago> detalle)
                {
                    DetalleCuentaPorCobrar _cuentaD;
                    CuentasPorCobrar _cuenta;
                    string msg = "";
                    bool error = false;

                    foreach (var det in detalle)
                    {
                        if (det.DpSaldoCreado != true)
                        {
                            _cuentaD = new DetalleCuentaPorCobrar();
                            _cuentaD = det.DpCuentaDetalleNavigation;
                            _cuentaD.DcpcImportePendiente -= det.DpImporteAplicado;

                            if (_cuentaD.DcpcImportePendiente == 0)
                            {
                                _cuentaD.DcpcFechaCierreCuenta = DateTime.Now;
                            }
                            else
                            {
                                _cuentaD.DcpcFechaCierreCuenta = DateTime.MinValue;

                            }
                            msg = UpdCuentaPorCobrarDetalle(_cuentaD);

                            if (!msg.ToUpper().Contains("ERROR"))
                            {
                                _cuenta = ObtCuentaPorCobrarID(_cuentaD.DcpcCuentaId);
                                _cuenta.CpcImportePendiente -= det.DpImporteAplicado;

                                msg = UpdCuentaPorCobrar(_cuenta);

                                if (msg.ToUpper().Contains("ERROR"))
                                {
                                    break;
                                }

                            }
                            else
                            {
                                break;
                            }

                            string convenio = VerificacionConveniosIndividual(_cuentaD.DcpcId);
                        }
                    }

                    return msg;

                }

                //obtiene una cuenta pori cobrar por id
                CuentasPorCobrar ObtCuentaPorCobrarID(int Cpid)
                {
                    return (from CP in context.CuentasPorCobrar
                            where CP.CpcId == Cpid
                            orderby CP.CpcId descending
                            select CP
                            ).FirstOrDefault();
                }

                //obtenemos la referencia por la referencia
                Referencias ObtReferenciaRef(string referencia)
                {
                    return (from RE in context.Referencias
                            join AL in context.Alumno on RE.RAlumnoId equals AL.AlId into SAL
                            from ALU in SAL.DefaultIfEmpty()
                            join ES in context.EstatusList on RE.RReferenciaStatus equals ES.SlStatusId
                            where RE.RReferencia == referencia
                            orderby RE.RReferenciaId descending
                            select new Referencias
                            {
                                RReferenciaId = RE.RReferenciaId,
                                RAlumnoId = RE.RAlumnoId,
                                RAlumnoClave = RE.RAlumnoClave,
                                RAlumno = ALU,
                                RReferencia = RE.RReferencia,
                                RFechaCreacion = RE.RFechaCreacion,
                                RFechaInicio = RE.RFechaInicio,
                                RFechaVigencia = RE.RFechaVigencia,
                                RTotalReferencia = RE.RTotalReferencia,
                                RReferenciaStatus = RE.RReferenciaStatus,
                                RReferenciaStatusNavigation = ES,
                                RUsuid = RE.RUsuid,
                                RFechaRegistro = RE.RFechaRegistro,
                                DetalleReferencia = (from DR in context.DetalleReferencia
                                                     join DC in context.DetalleCuentaPorCobrar on DR.DrCuentaDetalle equals DC.DcpcId
                                                     where DR.DrReferencia == RE.RReferenciaId
                                                     select new DetalleReferencia
                                                     {
                                                         DrId = DR.DrId,
                                                         DrReferencia = DR.DrReferencia,
                                                         DrCuentaDetalle = DR.DrCuentaDetalle,
                                                         DrCuentaDetalleNavigation = new DetalleCuentaPorCobrar
                                                         {
                                                             DcpcId = DC.DcpcId,
                                                             DcpcCuentaId = DC.DcpcCuentaId,
                                                             //DcpcCuenta = CC,
                                                             DcpcDescripcion = DC.DcpcDescripcion,
                                                             DcpcDocLinea = DC.DcpcDocLinea,
                                                             DcpcImportePendiente = DC.DcpcImportePendiente,
                                                             DcpcImporteTotal = DC.DcpcImporteTotal,
                                                             DcpcFechaVencimiento = DC.DcpcFechaVencimiento,
                                                             DcpcEstatus = DC.DcpcEstatus,
                                                             DcpcReferenciaCuentaDetalle = DC.DcpcReferenciaCuentaDetalle,
                                                             InverseDcpcReferenciaCuentaDetalleNavigation = (from DCR in context.DetalleCuentaPorCobrar
                                                                                                             where DCR.DcpcEstatus == 21
                                                                                                             where DCR.DcpcReferenciaCuentaDetalle == DC.DcpcId
                                                                                                             select DCR).ToList()
                                                         },
                                                         DrFechaRegistro = DR.DrFechaRegistro,
                                                         DrUsuid = DR.DrUsuid
                                                     }).ToList()
                            }).FirstOrDefault();
                }

                // llenamos la lista de los detalles de la referencia
                List<DetalleReferencia> LlenaDetalleReferenciaPago(List<DetallePago> listDetallePago)
                {

                    List<DetalleReferencia> list_detalle_ref = new List<DetalleReferencia>();
                    DetalleReferencia _detalleReferencia;

                    foreach (var item in listDetallePago)
                    {
                        _detalleReferencia = new DetalleReferencia();
                        _detalleReferencia.DrCuentaDetalle = item.DpCuentaDetalle;
                        _detalleReferencia.DrCuentaDetalleNavigation = item.DpCuentaDetalleNavigation;
                        _detalleReferencia.DrMontoAplicado = item.DpImporteAplicado;
                        list_detalle_ref.Add(_detalleReferencia);
                    }

                    return list_detalle_ref;
                }

                // Actualiza la referencia
                string ActualizarReferencia(Referencias referencia, List<DetalleReferencia> detalle)
                {
                    string msg = "", resultado = "";
                    bool error = false;

                    string updReferencia = UpdReferencia(referencia);
                    if (updReferencia.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al actualizar la referencia, comuniquese con el administrador";
                    }


                    string delDetalleR = DelDetalleReferenciaCadena(referencia.RReferenciaId);

                    if (delDetalleR.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR: Ocurrio un error al actualizar el detalle de la referencia, comuniquese con el administrador";
                    }

                    string cargaDR = CargaDetalleReferencia(referencia.RReferenciaId, 9, detalle);


                    if (cargaDR.ToUpper().Contains("ERROR"))
                    {
                        return "ERROR Ocurrio un error al registrar el detalle de la referencia, comuniquese con el administrador";
                    }

                    return cargaDR;


                }

                // Agrega los detalle pago del alumno
                string CargaDetalleAlumnoPago(int apId, long usuario, List<DetallePago> detalle)
                {
                    DetallePago _pagoD;
                    string msg = "";
                    bool error = false;

                    foreach (var det in detalle)
                    {
                        _pagoD = new DetallePago();
                        _pagoD.DpPagoId = apId;
                        _pagoD.DpCuentaDetalle = det.DpCuentaDetalle;
                        _pagoD.DpDocLinea = det.DpDocLinea;
                        _pagoD.DpImporteAplicado = det.DpImporteAplicado;
                        _pagoD.DpImportePendiente = det.DpImportePendiente;
                        _pagoD.DpUsuid = usuario;
                        _pagoD.DpSaldoCreado = det.DpSaldoCreado;

                        msg = AddDetallePagos(_pagoD);
                        error = msg.ToUpper().Contains("ERROR");

                        if (error)
                        {
                            break;
                        }
                    }

                    return msg;
                }

                //Carga los detalles de la referencia
                string CargaDetalleReferencia(long referenciaId, long usuario, List<DetalleReferencia> detalle)
                {
                    DetalleReferencia _referenciaD;
                    string msg = "";
                    bool error = false;

                    foreach (var det in detalle)
                    {
                        _referenciaD = new DetalleReferencia();
                        _referenciaD.DrReferencia = referenciaId;
                        _referenciaD.DrCuentaDetalle = det.DrCuentaDetalle;
                        _referenciaD.DrMontoAplicado = det.DrMontoAplicado;
                        _referenciaD.DrUsuid = usuario;

                        msg = AddDetalleReferencia(_referenciaD);
                        error = msg.ToUpper().Contains("ERROR");

                        if (error)
                        {
                            break;
                        }
                    }

                    return msg;
                }

                #region Procedimientos Almacenados

                String AddAlumnoPagos(AlumnoPagos ap)
                {

                    string msg = "";

                    if (ap.ApCuentaBancaria == 0)
                    {
                        msg = "ERROR: Cuenta no valida";
                    }
                    else if (ap.ApMetodoPago == 0)
                    {
                        msg = "ERROR: Metodo de pago no valido";
                    }
                    else if (ap.ApFormaPagoId == 0)
                    {

                        msg = "ERROR: Forma de pago no valida";
                    }
                    else if (ap.ApMoneda == 0)
                    {
                        msg = "ERROR: Moneda no valida";
                    }
                    //else if (ap.ApImportePendiente == 0)

                    //{
                    //    msg = "ERROR: Importe pendiente no valido";

                    //} 
                    //else if (ap.ApImporteTotal == 0)

                    //{
                    //    msg = "ERROR: Importe total no valido";

                    //} 
                    else if (ap.ApFechaCreacion == default)
                    {
                        msg = "ERROR: Fecha de Creación no valida";
                    }
                    else if (ap.ApFechaContable == default)
                    {
                        msg = "ERROR: Fecha contable no valida";
                    }
                    else if (ap.ApFechaBancaria == default)
                    {
                        msg = "ERROR: Fecha bancaria no valida";
                    }
                    else if (ap.ApEstatus == 0)
                    {
                        msg = "ERROR: Estatus no valido";
                    }
                    else if (ap.ApUsuid == 0)
                    {
                        msg = "ERROR: Usuario no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@ap_AlumnoId",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApAlumnoId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_AlumnoClave",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApAlumnoClave ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_CuentaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApCuentaBancaria
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_MetodoPago",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApMetodoPago
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FormaPagoID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFormaPagoId
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Moneda",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApMoneda
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ImportePendiente",
                           SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ImporteTotal",
                           SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ReferenciaID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferenciaId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Referencia",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferencia ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ReferenciaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 36,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferenciaBancaria ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_NoAprobacion",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApNoAprobacion ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaCreacion",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaCreacion
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaContable",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaContable
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaBancaria
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Oservaciones",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApObservaciones ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApEstatus
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Usuid",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApUsuid
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec add_AlumnoPagos @ap_AlumnoId, @ap_AlumnoClave, @ap_CuentaBancaria, @ap_MetodoPago, @ap_FormaPagoID, @ap_Moneda, @ap_ImportePendiente, @ap_ImporteTotal, @ap_ReferenciaID, @ap_Referencia, @ap_ReferenciaBancaria, @ap_NoAprobacion, @ap_FechaCreacion, @ap_FechaContable, @ap_FechaBancaria, @ap_Oservaciones, @ap_Estatus, @ap_Usuid, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                //Actualiza ALumnoPagos
                String UpdAlumnoPagos(AlumnoPagos ap)
                {
                    string msg;

                    //if (r.RReferenciaId == 0)
                    //{
                    //    msg = "Seleccione la referencia";
                    //}
                    //else 
                    if (ap.ApCuentaBancaria == 0)

                    {
                        msg = "ERROR: Cuenta no valida";
                    }
                    else if (ap.ApMetodoPago == 0)
                    {

                        msg = "ERROR: Metodo de pago no valido";
                    }
                    else if (ap.ApFormaPagoId == 0)
                    {

                        msg = "ERROR: Forma de pago no valida";

                    }
                    else if (ap.ApMoneda == 0)

                    {
                        msg = "ERROR: Moneda no valida";

                    }
                    //else if (ap.ApImportePendiente == 0)
                    //{
                    //    msg = "ERROR: Importe pendiente no valido";

                    //}
                    //else if (ap.ApImporteTotal == 0)

                    //{
                    //    msg = "ERROR: Importe total no valido";

                    //}
                    else if (ap.ApFechaCreacion == default)

                    {
                        msg = "ERROR: Fecha de Creación no valida";

                    }
                    else if (ap.ApFechaContable == default)

                    {
                        msg = "ERROR: Fecha contable no valida";

                    }
                    else if (ap.ApFechaBancaria == default)

                    {
                        msg = "ERROR: Fecha bancaria no valida";

                    }
                    else if (ap.ApEstatus == 0)

                    {
                        msg = "ERROR: Estatus no valido";

                    }
                    else
                    {
                        var param = new SqlParameter[] {
                         new SqlParameter() {
                            ParameterName = "@ap_PagoID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApPagoId
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_AlumnoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApAlumnoId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_AlumnoClave",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApAlumnoClave ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_CuentaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApCuentaBancaria
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_MetodoPago",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApMetodoPago
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FormaPagoID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFormaPagoId
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Moneda",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApMoneda
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ImportePendiente",
                           SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ImporteTotal",
                           SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ReferenciaID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferenciaId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Referencia",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferencia ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_ReferenciaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 36,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApReferenciaBancaria ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_NoAprobacion",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApNoAprobacion ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaCreacion",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaCreacion
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaContable",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaContable
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_FechaBancaria",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApFechaBancaria
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Oservaciones",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 150,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApObservaciones ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@ap_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = ap.ApEstatus
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec upd_AlumnoPagos @ap_PagoID, @ap_AlumnoID, @ap_AlumnoClave, @ap_CuentaBancaria, @ap_MetodoPago, @ap_FormaPagoID, @ap_Moneda, @ap_ImportePendiente, @ap_ImporteTotal, @ap_ReferenciaID, @ap_Referencia, @ap_ReferenciaBancaria, @ap_NoAprobacion, @ap_FechaCreacion, @ap_FechaContable, @ap_FechaBancaria, @ap_Oservaciones, @ap_Estatus, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                //Elimina detallepago
                String DelDetallePagoCadena(int pagoId)
                {
                    string msg;

                    if (pagoId == 0)
                    {
                        msg = "ERROR: Referencia no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@dp_PagoId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pagoId
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec del_DetallePagoCadena @dp_PagoId,  @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                // Actualiza la matricula en generales prospecto
                string Upd_GPMatricula(GeneralesProspecto pros, String GPMatricula)
                {
                    string msg = "";

                    if (pros.GpProspectoId > 0)
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@GP_ProspectoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = pros.GpProspectoId
                        },
                        new SqlParameter() {
                            ParameterName = "@GPMatricula",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size = 15,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = GPMatricula
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};
                        try
                        {
                            context.Database
                                .ExecuteSqlRaw("Exec upd_GPMatricula @GP_ProspectoID,@GPMatricula,@msg output", param);
                            context.SaveChanges();

                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception ex)
                        {
                            msg = ex.Message.ToString();
                        }
                    }
                    else
                    {
                        msg = "ERROR El prospecto para actualizar es obligatorio";
                    }

                    return msg;
                }

                //Agrega alumno
                string Add_Alumno(Alumno Alu)
                {

                    string msg = null;

                    var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@AL_Matricula",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 15,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlMatricula.Trim()
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_FechaIngreso",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlFechaIngreso
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Nombre",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlNombre
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_APP",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlApp
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_APM",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 20,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlApm
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_FechaNac",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlFechaNac
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_CorreoInst",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 50,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlCorreoInst
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Sexo",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlSexo
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_StatusActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlStatusActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Carrera",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlCarrera
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_PeriodoActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlPeriodoActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_AnoPeriodoActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlAnoPeriodoActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_EsquemaPagoActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlEsquemaPagoActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_BecaActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlBecaActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Beca_parcialidad ",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlBecaParcialidad
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Documentos",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlDocumentos
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Factura",
                            SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlFactura
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_FechaInicioNivel",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlFechaInicioNivel
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_CicloActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlCicloActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_ModalidadActual",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlModalidadActual
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_CURP",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 18,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlCurp
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Beca_inscripcion",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlBecaInscripcion
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Desc_promocion",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlDescPromocion
                        },
                        new SqlParameter() {
                            ParameterName = "@Al_CoutaAdmin",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlCoutaAdmin ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@Al_MontoDesc",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 17,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlMontoDesc ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@AL_Semestre",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.AlSemestre
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }
                    };

                    try
                    {
                        context.Database
                        .ExecuteSqlRaw("Exec add_Alumno @AL_Matricula,@AL_FechaIngreso,@AL_Nombre,@AL_APP,@AL_APM,@AL_FechaNac,@AL_CorreoInst,@AL_Sexo,@AL_StatusActual,@AL_Carrera,@AL_PeriodoActual,@AL_AnoPeriodoActual,@AL_EsquemaPagoActual,@AL_BecaActual,@AL_Beca_parcialidad,@AL_Documentos,@AL_Factura,@AL_FechaInicioNivel,@AL_CicloActual,@AL_ModalidadActual,@AL_CURP,@AL_Beca_inscripcion,@AL_Desc_promocion,@Al_CoutaAdmin,@Al_MontoDesc,@AL_Semestre,@msg OUTPUT", param);
                        context.SaveChanges();

                        msg = param[param.Count() - 1].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        msg = "ERROR " + ex.Message.ToString();
                    }

                    return msg;
                }

                //Agrega generales alumnos
                string Add_GenAlumno(GeneralesAlumno Alu)
                {

                    string msg = null;

                    var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@GA_AlumnoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaAlumnoId
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_NombreTutor",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaNombreTutor ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_APPTutor",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaApptutor ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_APMTutor",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaApmtutor ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_Calle",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaCalle ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_NueroExt",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 5,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaNueroExt ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_NumeroInterior",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 30,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaNumeroInterior ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_Estado",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaEstado
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_Municipio",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaMunicipio
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_TelefonoTutor",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaTelefonoTutor ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_TelefonoAlumno",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaTelefonoAlumno ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_CorreoAlternativo",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 60,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaCorreoAlternativo ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_FechaNac ",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaFechaNac ?? DateTime.Now
                        },
                        new SqlParameter() {
                            ParameterName = "@GA_TelefonoCasa",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = Alu.GaTelefonoCasa ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }
                    };

                    try
                    {
                        context.Database
                        .ExecuteSqlRaw("Exec add_GenAlumno @GA_AlumnoID,@GA_NombreTutor,@GA_APPTutor,@GA_APMTutor,@GA_Calle,@GA_NueroExt,@GA_NumeroInterior,@GA_Estado,@GA_Municipio,@GA_TelefonoTutor,@GA_TelefonoAlumno,@GA_CorreoAlternativo,@GA_FechaNac,@GA_TelefonoCasa,@msg output", param);
                        context.SaveChanges();

                        msg = param[param.Count() - 1].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        msg = "ERROR " + ex.Message.ToString();
                    }

                    return msg;
                }

                // Agrega alumnos beca
                string AddBecaAlu(BecaAlumno bea)
                {
                    string Message = "";

                    if (bea.BecasId > 0)
                    {
                        if (bea.Usuid > 0)
                        {
                            if (bea.AlId > 0)
                            {
                                if (bea.Beperiodo > 0)
                                {
                                    if (bea.Beanio > 0)
                                    {
                                        if (bea.Betipo != 0)
                                        {
                                            if (bea.Beestatus != 0)
                                            {
                                                var param = new SqlParameter[] {

                                                    new SqlParameter() {
                                                        ParameterName = "@Becas_ID",
                                                        SqlDbType = System.Data.SqlDbType.SmallInt,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.BecasId
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@usuid",
                                                        SqlDbType = System.Data.SqlDbType.SmallInt,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Usuid
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@AL_ID",
                                                        SqlDbType = System.Data.SqlDbType.SmallInt,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.AlId
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@beperiodo",
                                                        SqlDbType = System.Data.SqlDbType.SmallInt,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Beperiodo
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@beanio",
                                                        SqlDbType = System.Data.SqlDbType.SmallInt,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Beanio
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@beinscrip",
                                                        SqlDbType =  System.Data.SqlDbType.Int,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Beinscrip
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@beparcialidades",
                                                        SqlDbType =  System.Data.SqlDbType.Int,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Beparcialidades
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@betipo",
                                                        SqlDbType = System.Data.SqlDbType.Int,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Betipo
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@beestatus",
                                                        SqlDbType = System.Data.SqlDbType.Int,
                                                        Direction = System.Data.ParameterDirection.Input,
                                                        Value = bea.Beestatus
                                                        },
                                                        new SqlParameter() {
                                                        ParameterName = "@Message",
                                                        SqlDbType = System.Data.SqlDbType.Char,
                                                        Size = 250,
                                                        Direction = System.Data.ParameterDirection.Output,
                                                        }
                                                    };
                                                try
                                                {
                                                    context.Database
                                                    .ExecuteSqlRaw("Exec add_BecaAlumno @Becas_ID, @usuid, @AL_ID, @beperiodo, @beanio, @beinscrip, @beparcialidades, @betipo,@beestatus, @Message out", param);
                                                    context.SaveChanges();

                                                    Message = param[9].Value.ToString();
                                                }
                                                catch (Exception m)
                                                {
                                                    Message = "ERROR: " + m.Message;
                                                }
                                            }
                                            else
                                            {
                                                Message = "ERROR: EL ESTATUS NO PUEDE IR VACIO";
                                            }
                                        }
                                        else
                                        {
                                            Message = "ERROR: EL TIPO DE BACA NO PUEDE IR VACIO";
                                        }
                                    }
                                    else
                                    {
                                        Message = "ERROR: EL AÑO NO PUEDE IR VACIO";
                                    }
                                }
                                else
                                {
                                    Message = "ERROR: EL PERIODO NO PUEDE IR VACIO";
                                }
                            }
                            else
                            {
                                Message = "ERROR: EL ALUMNO NO PUEDE IR VACIO";
                            }
                        }
                        else
                        {
                            Message = "ERROR: EL USUARIO NO PUEDE IR VACIO";
                        }
                    }
                    else
                    {
                        Message = "ERROR: EL ID DE LA BECA NO PUEDE IR VACIO";
                    }
                    bool error = Message.Trim().ToUpper().Contains("ERROR");
                    if (!error)
                    {
                        Becaalubitacora bitacora = new Becaalubitacora();
                        BecaAlumno bitac = new BecaAlumno();
                        bitac = BuscaBecaReg((long)bea.AlId, (short)bea.Beanio, (int)bea.Beperiodo);
                        if (bitac != null)
                        {
                            bitacora.Beid = bitac.Beid;
                            bitacora.Usuid = bitac.Usuid;
                            bitacora.AlId = bitac.AlId;
                            bitacora.Ccbbanio = bitac.Beanio;
                            bitacora.Ccbbperiodo = bitac.Beperiodo;
                            bitacora.Ccbbinscrip = bitac.Beinscrip;
                            bitacora.Ccbbparcial = bitac.Beparcialidades;
                            bitacora.BecasId = bitac.BecasId;
                            if (bea.Beestatus == 12)
                            {
                                bitacora.Ccbbmovimiento = 19;
                            }
                            else if (bea.Beestatus == 13)
                            {
                                bitacora.Ccbbmovimiento = bitac.Beestatus;
                            }
                            Message += AddBecaAluBitacora(bitacora);
                        }
                    }


                    return Message;
                }

                // agrega beca bitacora
                string AddBecaAluBitacora(Becaalubitacora beab)
                {
                    string Message = "";

                    if (beab.BecasId > 0)
                    {
                        if (beab.Usuid > 0)
                        {
                            if (beab.AlId > 0)
                            {
                                if (beab.Ccbbperiodo > 0)
                                {
                                    if (beab.Ccbbanio > 0)
                                    {
                                        if (beab.Ccbbparcial != 0)
                                        {
                                            if (beab.Ccbbmovimiento != 0)
                                            {
                                                var param = new SqlParameter[] {

                                                new SqlParameter() {
                                                    ParameterName = "@beid",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Beid
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@usuid",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Usuid
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@AL_ID",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.AlId
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@beperiodo",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Ccbbperiodo
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@beanio",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Ccbbanio
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@beinscrip",
                                                    SqlDbType =  System.Data.SqlDbType.Int,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Ccbbinscrip
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@beparcialidades",
                                                    SqlDbType =  System.Data.SqlDbType.Int,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Ccbbparcial
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@Becas_ID",
                                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.BecasId
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@ccbbmovimiento",
                                                    SqlDbType = System.Data.SqlDbType.Int,
                                                    Direction = System.Data.ParameterDirection.Input,
                                                    Value = beab.Ccbbmovimiento
                                                    },
                                                    new SqlParameter() {
                                                    ParameterName = "@Message",
                                                    SqlDbType = System.Data.SqlDbType.Char,
                                                    Size = 250,
                                                    Direction = System.Data.ParameterDirection.Output,
                                                    }
                                                };
                                                try
                                                {
                                                    context.Database
                                                    .ExecuteSqlRaw("Exec add_BecaAlumnoBitacora @beid, @usuid, @AL_ID, @beperiodo , @beanio , @beinscrip, @beparcialidades, @Becas_ID, @ccbbmovimiento, @Message out", param);
                                                    context.SaveChanges();

                                                    Message = param[9].Value.ToString();
                                                }
                                                catch (Exception m)
                                                {
                                                    Message = "ERROR: " + m.Message;
                                                }
                                            }
                                            else
                                            {
                                                Message = "ERROR: EL TIPO DE MOVIMIENTO NO PUEDE IR VACIO";
                                            }
                                        }
                                        else
                                        {
                                            Message = "ERROR: EL % DE BECA DE PARCIALIDAD NO PUEDE IR VACIO";
                                        }
                                    }
                                    else
                                    {
                                        Message = "ERROR: EL AÑO NO PUEDE IR VACIO";
                                    }
                                }
                                else
                                {
                                    Message = "ERROR: EL PERIODO NO PUEDE IR VACIO";
                                }
                            }
                            else
                            {
                                Message = "ERROR: EL ALUMNO NO PUEDE IRVACIO";
                            }
                        }
                        else
                        {
                            Message = "ERROR: EL USUARIO NO PUEDE IR VACIO";
                        }
                    }
                    else
                    {
                        Message = "ERROR: EL ID DEL REGISTRO DE BECA NO PUEDE IR VACIO";
                    }
                    return Message;
                }

                // agrega una cuenta por cobrar
                String AddCuentaPorCobrar(CuentasPorCobrar c)
                {

                    string msg;

                    //if (c.CpcId == 0)
                    //{
                    //    msg = "ERROR: ID de cuenta no valido";
                    //}
                    //else
                    if (c.CpcListaPrecio == 0)
                    {
                        msg = "ERROR: El ID de lista precio no valido";
                    }
                    //else if (c.CpcAlid == 0)
                    //{
                    //    msg = "ERROR: Alumno no valido";
                    //}
                    else if (c.CpcAlumnoId == 0)
                    {
                        msg = "ERROR: Alumno no valido";
                    }
                    else if (c.CpcFechaCreacion.ToString().Length == 0)
                    {
                        msg = "ERROR: Ingrese la fecha de creacion";
                    }
                    else if (c.CpcUnidad == 0)
                    {
                        msg = "ERROR: Ingrese el numero de unidades";
                    }
                    else if (c.CpcPrecioUnitario == 0)
                    {
                        msg = "ERROR: Ingrese el precio por unidad";
                    }
                    else if (c.CpcImporteTotal == 0)
                    {
                        msg = "ERROR: Ingrese el importe total";
                    }
                    else if (c.CpcImportePendiente == 0)
                    {
                        msg = "ERROR: Ingrese el importe pendiente";
                    }
                    else if (c.CpcAño == 0)
                    {
                        msg = "ERROR: Ingrese el año correspondiente";
                    }
                    else if (c.CpcPeriodo == 0)
                    {
                        msg = "ERROR: Ingrese el periodo correspondiente";
                    }
                    else if (c.CpcEstatus == 0)
                    {
                        msg = "ERROR: Ingrese el estatus actual";
                    }
                    else if (c.CpcUsuid == 0)
                    {
                        msg = "ERROR: Usuario no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        //new SqlParameter() {
                        //    ParameterName = "@cpc_Id",
                        //    SqlDbType =  System.Data.SqlDbType.Int,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = c.CpcId
                        //},
                        new SqlParameter() {
                            ParameterName = "@cpc_ListaPrecio",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcListaPrecio
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_AlumnoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAlumnoId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_AlumnoClave",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size=10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAlumnoClave ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_FechaCreacion",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcFechaCreacion
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ReferenciaCuenta",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcReferenciaCuenta ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Unidad",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcUnidad
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_PrecioUnitario",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcPrecioUnitario
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ImporteTotal",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ImportePendiente",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Año",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAño
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Periodo",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcPeriodo
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcEstatus
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Usuid",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcUsuid
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec add_CuentaPorCobrar @cpc_ListaPrecio, @cpc_AlumnoID, @cpc_AlumnoClave, @cpc_FechaCreacion, @cpc_ReferenciaCuenta, @cpc_Unidad, @cpc_PrecioUnitario, @cpc_ImporteTotal, @cpc_ImportePendiente, @cpc_Año, @cpc_Periodo, @cpc_Estatus, @cpc_Usuid, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                // actualiza una cuenta por cobrar
                String UpdCuentaPorCobrar(CuentasPorCobrar c)
                {
                    string msg;

                    if (c.CpcId == 0)
                    {
                        msg = "ERROR: ID de cuenta no valido";
                    }
                    else if (c.CpcListaPrecio == 0)
                    {
                        msg = "ERROR: El ID de lista precio no valido";
                    }
                    //else if (c.CpcAlid == 0)
                    //{
                    //    msg = "ERROR: Alumno no valido";
                    //}
                    else if (c.CpcFechaCreacion.ToString().Length == 0)
                    {
                        msg = "ERROR: Ingrese la fecha de creacion";
                    }
                    else if (c.CpcUnidad == 0)
                    {
                        msg = "ERROR: Ingrese el numero de unidades";
                    }
                    else if (c.CpcPrecioUnitario == 0)
                    {
                        msg = "ERROR: Ingrese el precio por unidad";
                    }
                    else if (c.CpcImporteTotal == 0)
                    {
                        msg = "ERROR: Ingrese el importe total";
                    }
                    //else if (c.CpcImportePendiente == 0)
                    //{
                    //    msg = "ERROR: Ingrese el importe pendiente";
                    //}
                    else if (c.CpcAño == 0)
                    {
                        msg = "ERROR: Ingrese el año correspondiente";
                    }
                    else if (c.CpcPeriodo == 0)
                    {
                        msg = "ERROR: Ingrese el periodo correspondiente";
                    }
                    //else if (c.CpcEstatus == 0)
                    //{
                    //    msg = "ERROR: Ingrese el estatus actual";
                    //}
                    //else if (c.CpcUsuid == 0)
                    //{
                    //    msg = "ERROR: Usuario no valido";
                    //}
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@cpc_Id",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcId
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ListaPrecio",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcListaPrecio
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_AlumnoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAlumnoId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_AlumnoClave",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size=10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAlumnoClave ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_FechaCreacion",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcFechaCreacion
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ReferenciaCuenta",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcReferenciaCuenta ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Unidad",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcUnidad
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_PrecioUnitario",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcPrecioUnitario
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ImporteTotal",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_ImportePendiente",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Año",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcAño
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Periodo",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcPeriodo
                        },
                        new SqlParameter() {
                            ParameterName = "@cpc_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = c.CpcEstatus
                        },
                        //new SqlParameter() {
                        //    ParameterName = "@cpc_Usuid",
                        //    SqlDbType =  System.Data.SqlDbType.BigInt,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = c.CpcUsuid
                        //},
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec upd_CuentaPorCobrar @cpc_Id, @cpc_ListaPrecio, @cpc_AlumnoID, @cpc_AlumnoClave, @cpc_FechaCreacion, @cpc_ReferenciaCuenta, @cpc_Unidad, @cpc_PrecioUnitario, @cpc_ImporteTotal, @cpc_ImportePendiente, @cpc_Año, @cpc_Periodo, @cpc_Estatus, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                // agrega detalle cuenta por cobrar
                String AddCuentaPorCobrarDetalle(DetalleCuentaPorCobrar d)
                {
                    string msg;

                    //if (d.DcpcId == 0)
                    //{
                    //    msg = "ERROR: ID de cuenta detalle no valido";
                    //}
                    //else 
                    if (d.DcpcCuentaId == 0)
                    {
                        msg = "ERROR: ID de cuenta no valido";
                    }
                    else if (string.IsNullOrEmpty(d.DcpcDescripcion))
                    {
                        msg = "ERROR: Ingrese la descripción";
                    }
                    else if (string.IsNullOrEmpty(d.DcpcDocLinea))
                    {
                        msg = "ERROR: Ingrese el numero de linea";
                    }
                    else if (d.DcpcImporteTotal == 0)
                    {
                        msg = "ERROR: Ingrese el importe total";
                    }
                    else if (d.DcpcImportePendiente == 0)
                    {
                        msg = "ERROR: Ingrese el importe pendiente";
                    }
                    else if (d.DcpcFechaVencimiento == default)
                    {
                        msg = "ERROR: Ingrese fecha de vencimiento";
                    }
                    else if (d.DcpcEstatus == 0)
                    {
                        msg = "ERROR: Ingrese el estatus correspondiente";
                    }
                    else if (d.DcpcUsuid == 0)
                    {
                        msg = "ERROR: Usuario no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        //new SqlParameter() {
                        //    ParameterName = "@dcpc_Id",
                        //    SqlDbType =  System.Data.SqlDbType.Int,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = d.DcpcId
                        //},
                        new SqlParameter() {
                            ParameterName = "@dcpc_CuentaId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcCuentaId
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_Descripcion",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcDescripcion
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_DocLinea",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 3,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcDocLinea
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_ImporteTotal",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_ImportePendiente",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_FechaVencimiento",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcFechaVencimiento
                        },
                        new SqlParameter() {
                            ParameterName = "@dcp_ReferenciaCuentaDetalle",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcReferenciaCuentaDetalle ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_FechaCierreCuenta",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcFechaCierreCuenta ?? DateTime.MinValue
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcEstatus
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_Usuid",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcUsuid
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec add_DetalleCuentaPorCobrar @dcpc_CuentaId, @dcpc_Descripcion, @dcpc_DocLinea, @dcpc_ImporteTotal, @dcpc_ImportePendiente, @dcpc_FechaVencimiento, @dcp_ReferenciaCuentaDetalle, @dcpc_FechaCierreCuenta, @dcpc_Estatus, @dcpc_Usuid, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }

                        //d.DcpcFechaRegistro = DateTime.Now;
                        //_context.DetalleCuentaPorCobrar.Add(d);

                        //try
                        //{
                        //    _context.SaveChanges();
                        //    msg = "Registro correcto";
                        //}
                        //catch (Exception m)
                        //{
                        //    msg = "ERROR: " + m.Message;
                        //}
                    }

                    return msg;
                }

                // actualiza detalle cuenta por cobrar
                String UpdCuentaPorCobrarDetalle(DetalleCuentaPorCobrar d)
                {
                    string msg;

                    if (d.DcpcId == 0)
                    {
                        msg = "ERROR: ID de cuenta detalle no valido";
                    }
                    else if (d.DcpcCuentaId == 0)
                    {
                        msg = "ERROR: ID de cuenta no valido";
                    }
                    else if (string.IsNullOrEmpty(d.DcpcDescripcion))
                    {
                        msg = "ERROR: Ingrese la descripción";
                    }
                    else if (string.IsNullOrEmpty(d.DcpcDocLinea))
                    {
                        msg = "ERROR: Ingrese el numero de linea";
                    }
                    else if (d.DcpcImporteTotal == 0)
                    {
                        msg = "ERROR: Ingrese el importe total";
                    }
                    //else if (d.DcpcImportePendiente == 0)
                    //{
                    //    msg = "ERROR: Ingrese el importe pendiente";
                    //}
                    else if (d.DcpcFechaVencimiento == default)
                    {
                        msg = "ERROR: Ingrese fecha de vencimiento";
                    }
                    //else if (d.DcpcEstatus == 0)
                    //{
                    //    msg = "ERROR: Ingrese el estatus correspondiente";
                    //}
                    //else if (d.DcpcUsuid == 0)
                    //{
                    //    msg = "ERROR: Usuario no valido";
                    //}
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@dcpc_Id",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcId
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_CuentaId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcCuentaId
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_Descripcion",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 100,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcDescripcion
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_DocLinea",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 3,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcDocLinea
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_ImporteTotal",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcImporteTotal
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_ImportePendiente",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_FechaVencimiento",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcFechaVencimiento
                        },
                        new SqlParameter() {
                            ParameterName = "@dcp_ReferenciaCuentaDetalle",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcReferenciaCuentaDetalle ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_FechaCierreCuenta",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcFechaCierreCuenta ?? DateTime.MinValue
                        },
                        new SqlParameter() {
                            ParameterName = "@dcpc_Estatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DcpcEstatus
                        },
                        //new SqlParameter() {
                        //    ParameterName = "@dcpc_Usuid",
                        //    SqlDbType =  System.Data.SqlDbType.BigInt,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = d.DcpcUsuid
                        //},
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec upd_DetalleCuentaPorCobrar @dcpc_Id, @dcpc_CuentaId, @dcpc_Descripcion, @dcpc_DocLinea, @dcpc_ImporteTotal, @dcpc_ImportePendiente, @dcpc_FechaVencimiento, @dcp_ReferenciaCuentaDetalle, @dcpc_FechaCierreCuenta, @dcpc_Estatus, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }

                        //_context.DetalleCuentaPorCobrar.Update(d);

                        //try
                        //{
                        //    _context.SaveChanges();
                        //    msg = "Registro correcto";
                        //}
                        //catch (Exception m)
                        //{
                        //    msg = "ERROR: " + m.Message;
                        //}
                    }

                    return msg;
                }

                // Confirma beca
                string ConfirmaBecaAlu(BecaAlumno bea, int? ban, int est)
                {
                    string Message = "";

                    if (bea.Beid > 0)
                    {
                        if (bea.BecasId > 0)
                        {
                            if (bea.Usuid > 0)
                            {
                                if (bea.AlId > 0)
                                {
                                    if (bea.Beperiodo > 0)
                                    {
                                        if (bea.Beanio > 0)
                                        {
                                            if (bea.Beparcialidades != 0)
                                            {
                                                if (ban != 0)
                                                {
                                                    if (est != 0)
                                                    {
                                                        var param = new SqlParameter[] {

                                                new SqlParameter() {
                                    ParameterName = "@beid",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Beid
                                    },
                                                new SqlParameter() {
                                    ParameterName = "@Becas_ID",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.BecasId
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@usuid",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Usuid
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@AL_ID",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.AlId
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@beperiodo",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Beperiodo
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@beanio",
                                    SqlDbType = System.Data.SqlDbType.SmallInt,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Beanio
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@beinscrip",
                                    SqlDbType =  System.Data.SqlDbType.Int,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Beinscrip
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@beparcialidades",
                                    SqlDbType =  System.Data.SqlDbType.Int,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = bea.Beparcialidades
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@bandera",
                                    SqlDbType = System.Data.SqlDbType.Int,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = ban
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@beestatus",
                                    SqlDbType = System.Data.SqlDbType.Int,
                                    Direction = System.Data.ParameterDirection.Input,
                                    Value = est
                                    },
                                    new SqlParameter() {
                                    ParameterName = "@Message",
                                    SqlDbType = System.Data.SqlDbType.Char,
                                    Size = 250,
                                    Direction = System.Data.ParameterDirection.Output,
                                    }
                                };
                                                        context.Database
                                                            .ExecuteSqlRaw("Exec upd_ConfirmaBeca @beid, @Becas_ID, @usuid, @AL_ID, @beperiodo, @beanio, @beinscrip, @beparcialidades, @bandera, @beestatus, @Message out", param);
                                                        context.SaveChanges();

                                                        Message = param[10].Value.ToString();
                                                    }
                                                    else
                                                    {
                                                        Message = "ERROR: EL ESTATUS NO PUEDE IR VACIO";
                                                    }
                                                }
                                                else
                                                {
                                                    Message = "ERROR: LA BANDERA NO PUEDE IR VACIA";
                                                }
                                            }
                                            else
                                            {
                                                Message = "ERROR: EL TIPO DE BACA NO PUEDE IR VACIO";
                                            }
                                        }
                                        else
                                        {
                                            Message = "ERROR: EL AÑO NO PUEDE IR VACIO";
                                        }
                                    }
                                    else
                                    {
                                        Message = "ERROR: EL PERIODO NO PUEDE IR VACIO";
                                    }
                                }
                                else
                                {
                                    Message = "ERROR: EL ALUMNO NO PUEDE IRVACIO";
                                }
                            }
                            else
                            {
                                Message = "ERROR: EL USUARIO NO PUEDE IR VACIO";
                            }
                        }
                        else
                        {
                            Message = "ERROR: EL ID DE LA BECA NO PUEDE IR VACIO";
                        }
                    }
                    else
                    {
                        Message = "ERROR: EL ID DE RESGISTRO DE ALUMNO CON BECA NO PUEDE IR VACIO";
                    }
                    return Message;
                }

                //ActualizamosReferencia
                String UpdReferencia(Referencias r)
                {
                    string msg;

                    if (r.RReferenciaId == 0)
                    {
                        msg = "Seleccione la referencia";
                    }
                    else if (string.IsNullOrEmpty(r.RAlumnoClave))
                    {
                        msg = "Ingrese al alumno";
                    }
                    //else if (r.RReferencia.Length == 0)
                    //{
                    //    msg = "Ingrese la referencia";
                    //}
                    else if (r.RReferencia.ToString() == "")
                    {
                        msg = "Ingrese la referencia";
                    }
                    else if (r.RFechaCreacion.ToString() == "")
                    {
                        msg = "ERROR: Ingrese la fecha de creacion";
                    }
                    else if (r.RFechaInicio.ToString() == "")
                    {
                        msg = "Ingrese la fecha inicio";
                    }
                    else if (r.RFechaVigencia.ToString() == "")
                    {
                        msg = "Ingrese la vigencia";
                    }
                    else if (r.RTotalReferencia == 0)
                    {
                        msg = "Ingrese el total";
                    }
                    else if (r.RReferenciaStatus == 0)
                    {
                        msg = "Ingrese el estatus";
                    }
                    //else if (r.Usuid.HasValue == false)
                    //{
                    //    msg = "Usuario no valido";
                    //}
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@r_ReferenciaID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RReferenciaId
                        },
                        new SqlParameter() {
                            ParameterName = "@r_AlumnoID",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RAlumnoId ?? 0
                        },
                        new SqlParameter() {
                            ParameterName = "@r_AlumnoClave",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RAlumnoClave ?? ""
                        },
                        new SqlParameter() {
                            ParameterName = "@r_Referencia",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 10,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RReferencia
                        },
                        new SqlParameter() {
                            ParameterName = "@r_FechaCreacion",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RFechaCreacion
                        },
                        new SqlParameter() {
                            ParameterName = "@r_Fechainicio",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RFechaInicio
                        },
                        new SqlParameter() {
                            ParameterName = "@r_FechaVigencia",
                            SqlDbType =  System.Data.SqlDbType.Date,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RFechaVigencia
                        },
                        new SqlParameter() {
                            ParameterName = "@r_TotalReferencia",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RTotalReferencia
                        },
                        new SqlParameter() {
                            ParameterName = "@r_ReferenciaStatus",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = r.RReferenciaStatus
                        },
                        //new SqlParameter() {
                        //    ParameterName = "@r_Referencia",
                        //    SqlDbType =  System.Data.SqlDbType.VarChar,
                        //    Size = 10,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = r.RReferencia
                        //},
                        //new SqlParameter() {
                        //    ParameterName = "@usuid",
                        //    SqlDbType =  System.Data.SqlDbType.BigInt,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = r.Usuid
                        //},
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec upd_Referencias @r_ReferenciaID, @r_AlumnoID, @r_AlumnoClave, @r_Referencia, @r_FechaCreacion, @r_Fechainicio, @r_FechaVigencia, @r_TotalReferencia, @r_ReferenciaStatus, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                //EliminamosDetallereferenica
                String DelDetalleReferencia(DetalleReferencia d)
                {
                    string msg;

                    if (d.DrId == 0)
                    {
                        msg = "ERROR: Detalle de convenio no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@dR_ID",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DrId
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec del_DetalleConvenio @dc_ID,  @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }

                        //_context.DetalleConvenio.Remove(d);

                        //try
                        //{
                        //    _context.SaveChanges();
                        //    msg = "Registro correcto";
                        //}
                        //catch (Exception m)
                        //{
                        //    msg = "ERROR: " + m.Message;
                        //}
                    }

                    return msg;
                }

                //EliminamosDetallereferenicacadena
                String DelDetalleReferenciaCadena(long referenciaId)
                {
                    string msg;

                    if (referenciaId == 0)
                    {
                        msg = "ERROR: Referencia no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@dr_Referencia",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = referenciaId
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec del_DetalleReferenciaCadena @dr_Referencia,  @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }

                // Agrega el detalle de una referencia
                String AddDetalleReferencia(DetalleReferencia d)
                {
                    string msg;

                    //if (d.DcId == 0)
                    //{
                    //    msg = "ERROR: Detalle de convenio no valido";
                    //}
                    //else 
                    if (d.DrReferencia == 0)
                    {
                        msg = "ERROR: Referencia no valido";
                    }
                    else if (d.DrCuentaDetalle == 0)
                    {
                        msg = "ERROR: Cuenta no valida";
                    }
                    else if (d.DrUsuid == 0)
                    {
                        msg = "ERROR: Usuario no valido";
                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        //new SqlParameter() {
                        //    ParameterName = "@dc_Id",
                        //    SqlDbType =  System.Data.SqlDbType.Int,
                        //    Direction = System.Data.ParameterDirection.Input,
                        //    Value = d.DcId
                        //},
                        new SqlParameter() {
                            ParameterName = "@dR_Referencia",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DrReferencia
                        },
                        new SqlParameter() {
                            ParameterName = "@dR_CuentaDetalle",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DrCuentaDetalle
                        },
                        new SqlParameter() {
                            ParameterName = "@dr_MontoAplicado",
                           SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DrMontoAplicado
                        },
                        new SqlParameter() {
                            ParameterName = "@dR_Usuid",
                            SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = d.DrUsuid
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec add_DetalleReferencias @dR_Referencia, @dR_CuentaDetalle, @dr_MontoAplicado, @dR_Usuid, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }

                        //d.DcFechaRegistro = DateTime.Now;
                        //_context.DetalleConvenio.Add(d);

                        //try
                        //{
                        //    _context.SaveChanges();
                        //    msg = "Registro correcto";
                        //}
                        //catch (Exception m)
                        //{
                        //    msg = "ERROR: " + m.Message;
                        //}
                    }

                    return msg;
                }

                // Actualiza estatus a inscrito
                string Upd_EstPros(GeneralesProspecto GP)
                {
                    string msg = null;

                    var param = new SqlParameter[] {
                new SqlParameter() {
                    ParameterName = "@GP_ProspectoID",
                    SqlDbType =  System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = GP.GpProspectoId
                },
                new SqlParameter() {
                    ParameterName = "@GP_Estatus",
                    SqlDbType =  System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = GP.GpEstatus
                },

                new SqlParameter() {
                    ParameterName = "@msg",
                    SqlDbType =  System.Data.SqlDbType.VarChar,
                    Size = 250,
                    Direction = System.Data.ParameterDirection.Output,
                }};

                    try
                    {
                        context.Database
                            .ExecuteSqlRaw("Exec upd_EstatusPros @GP_ProspectoID,@GP_Estatus,@msg OUTPUT", param);
                        context.SaveChanges();
                        msg = param[param.Count() - 1].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        msg = "ERROR " + ex.Message.ToString();
                    }

                    return msg;
                }

                // Agrega detalle de pagos
                String AddDetallePagos(DetallePago dp)
                {
                    string msg;


                    if (dp.DpPagoId == 0)
                    {
                        msg = "ERROR: El pago es obligatorio";

                    }
                    else if (dp.DpCuentaDetalle == 0)
                    {
                        msg = "ERROR: Cuenta no valida";

                    }
                    else if (dp.DpDocLinea == "")
                    {
                        msg = "ERROR: Linea no valida";

                    }
                    //else if (dp.DpImporteAplicado == 0)
                    //{
                    //    msg = "ERROR: Importe aplicado no valido";

                    //}
                    //else if (dp.DpImportePendiente == 0)
                    //{
                    //    msg = "ERROR: Importe pendiente no valido";

                    //}
                    else if (dp.DpUsuid == 0)
                    {
                        msg = "ERROR: Importe pendiente no valido";

                    }
                    else
                    {
                        var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@dp_PagoId",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpPagoId
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_CuentaDetalle",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpCuentaDetalle
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_DocLinea",
                            SqlDbType =  System.Data.SqlDbType.Char,
                            Size=3,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpDocLinea
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_ImporteAplicado",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpImporteAplicado
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_ImportePendiente",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 10,
                            Scale = 2,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpImportePendiente
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_Usuid",
                           SqlDbType =  System.Data.SqlDbType.BigInt,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpUsuid
                        },
                        new SqlParameter() {
                            ParameterName = "@dp_SaldoCreado",
                           SqlDbType =  System.Data.SqlDbType.Bit,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = dp.DpSaldoCreado ?? false
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                        try
                        {
                            context.Database.ExecuteSqlRaw("Exec add_DetallePagos @dp_PagoId, @dp_CuentaDetalle, @dp_DocLinea, @dp_ImporteAplicado, @dp_ImportePendiente, @dp_Usuid, @dp_SaldoCreado, @msg out", param);
                            msg = param[param.Count() - 1].Value.ToString();
                        }
                        catch (Exception m)
                        {
                            msg = "ERROR: " + m.Message;
                        }
                    }

                    return msg;
                }


                List<DetallePago> LlenaDetallePago(List<DetalleCuentaPorCobrar> listDetalleCuenta)
                {

                    List<DetallePago> list_detalle_pago = new List<DetallePago>();
                    List<DetalleCuentaPorCobrar> list_detalle_beca;
                    DetallePago _detallePago;
                    int contador = 0;

                    foreach (var item in listDetalleCuenta)
                    {
                        contador++;
                        _detallePago = new DetallePago();
                        _detallePago.DpCuentaDetalle = item.DcpcId;
                        _detallePago.DpCuentaDetalleNavigation = item;
                        _detallePago.DpImportePendiente = item.DcpcImportePendiente;
                        _detallePago.DpImporteAplicado = item.DcpcImportePendiente;
                        _detallePago.DpDocLinea = NumLinea(contador);
                        list_detalle_pago.Add(_detallePago);

                        list_detalle_beca = item.InverseDcpcReferenciaCuentaDetalleNavigation.ToList();
                        foreach (var beca in list_detalle_beca)
                        {
                            contador++;
                            _detallePago = new DetallePago();
                            _detallePago.DpCuentaDetalle = beca.DcpcId;
                            _detallePago.DpCuentaDetalleNavigation = beca;
                            _detallePago.DpImportePendiente = beca.DcpcImportePendiente;
                            _detallePago.DpImporteAplicado = beca.DcpcImportePendiente;
                            _detallePago.DpDocLinea = NumLinea(contador);
                            list_detalle_pago.Add(_detallePago);
                        }
                    }

                    return list_detalle_pago;
                }


                // trae detalles cuentas por cobrar
                List<DetalleCuentaPorCobrar> detalleCuentaPorCobrars(List<DetalleReferencia> detalleReferencias)
                {
                    List<DetalleCuentaPorCobrar> detalleCuentas = new List<DetalleCuentaPorCobrar>();
                    DetalleCuentaPorCobrar detalleCuentasTemp = new DetalleCuentaPorCobrar();

                    foreach (var detalles in detalleReferencias)
                    {
                        detalleCuentasTemp = (from DCPC in context.DetalleCuentaPorCobrar
                                              where DCPC.DcpcId == detalles.DrCuentaDetalle && DCPC.DcpcImportePendiente > 0
                                              select new DetalleCuentaPorCobrar()
                                              {
                                                  DcpcId = DCPC.DcpcId,
                                                  DcpcCuentaId = DCPC.DcpcCuentaId,
                                                  DcpcDescripcion = DCPC.DcpcDescripcion,
                                                  DcpcDocLinea = DCPC.DcpcDocLinea,
                                                  DcpcImporteTotal = DCPC.DcpcImporteTotal,
                                                  DcpcImportePendiente = DCPC.DcpcImportePendiente,
                                                  DcpcEstatus = DCPC.DcpcEstatus,
                                                  DcpcFechaRegistro = DCPC.DcpcFechaRegistro,
                                                  DcpcFechaVencimiento = DCPC.DcpcFechaVencimiento,
                                                  InverseDcpcReferenciaCuentaDetalleNavigation = (from DCPCR in context.DetalleCuentaPorCobrar
                                                                                                  where DCPC.DcpcId == DCPCR.DcpcReferenciaCuentaDetalle
                                                                                                  select DCPCR).ToList()

                                              }).FirstOrDefault();

                        detalleCuentas.Add(detalleCuentasTemp);

                    }
                    detalleCuentas.RemoveAll(x => x == null);
                    return detalleCuentas;
                }


                // GENERA EL DETALLE DE CUENTA POR COBRAR
                List<DetalleCuentaPorCobrar> LlenaDetalleRef(List<DetalleReferencia> listDetalleR)
                {

                    List<DetalleCuentaPorCobrar> list_detalle_pago = new List<DetalleCuentaPorCobrar>();
                    DetalleCuentaPorCobrar _detalleRef;
                    int contador = 0;

                    foreach (var item in listDetalleR)
                    {
                        contador++;
                        _detalleRef = lista_detCXC(item.DrCuentaDetalle);



                        if (_detalleRef.DcpcImporteTotal > 0)
                        {
                            list_detalle_pago.Add(_detalleRef);
                        }
                        else if (_detalleRef.DcpcImportePendiente < 0 && _detalleRef.DcpcReferenciaCuentaDetalle == 0)
                        {
                            // Esun saldo a favor
                            list_detalle_pago.Add(_detalleRef);
                        }
                    }

                    return list_detalle_pago;
                }


                DetalleCuentaPorCobrar lista_detCXC(long idc)
                {
                    DetalleCuentaPorCobrar verDetCXC = context.DetalleCuentaPorCobrar.First(DCPC => DCPC.DcpcId == idc);
                    return verDetCXC;
                }
                #endregion

                #endregion
                #region EnvioCorreo
                string EnvioCorreo(string Matricula, string correo, string Nombre)
                {
                    //string msj = "";
                    //Matricula = "A0000001";
                    //correo = "izacc.romero@gmail.com";
                    //Nombre = "izacc yair romero mastranzo";

                    string filename = Directory.GetCurrentDirectory() +"\\Manual.pdf";
                    Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);

                    Console.WriteLine("Entra al envio de correo");
                    MailMessage mail = new MailMessage();
                    mail.Bcc.Add(new MailAddress("iy.romero@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("m.martinez@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("j.victoriano@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("jefepromocion@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("depto.pagos@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("servicios.estudiantiles@lainter.edu.mx"));
                    mail.Bcc.Add(new MailAddress("depto.escolar@lainter.edu.mx"));

                    mail.To.Add(new MailAddress(correo.Trim()));
                    //mail.To.Add(new MailAddress("m.martinez@lainter.edu.mx"));
                    mail.Subject = "NUEVO ALUMNO | UNIVERSIDAD INTERAMERICANA";


                    //mail.Body = string.Format("<h2>Hola " +  + "</h2> <br> <p>Bienvenido a la Universidad Interamericana, " +
                    //    "para poder completar tu proceso de inscripción te pedimos que ingreses al siguiente link " +
                    //    "clic aquí con los siguientes accesos personales.</p>");

                    mail.Body = string.Format
                    (
                        "<div style='text-align:left;'><table style='text-align:left;'><br>" +
                           "<div style='text-align:left;'><table style='text-align:left;'><br>" +
                           "<tbody style='text-align:left;'><br>" +
                           "<tr style='text-align:center;'><th style='text-align:center;'><img src='https://ci6.googleusercontent.com/proxy/_Rewf1_XF-nMs_Rv0n0ze2VHP9hIetOvshnJlKW-wm_jHgA_VyiPIZjfjUfI8zIrapmsbzL92efVeMvWWoLQepdmrEqBll9b6ftGlWmn=s0-d-e1-ft#http://interpue.com.mx/registroenlinea/Resources/Banner.png' width='85%' height='145px' class='CToWUd'></th></tr><br>" +
                           "<table><tbody><tr><td><h4>HOLA " + Nombre.ToUpper().Trim() + "</h4> <br>" +
                           "<tr><td><p style='text - align:justify'>Bienvenido a la Universidad Interamericana, para poder completar tu proceso de inscripción te pedimos que ingreses al siguiente link <a href='http://www.lainter.edu.mx/'>clic aquí</a> con los siguientes accesos personales.<br><br><strong><span class='il'>Usuario</span>: " + Matricula.ToUpper().Trim() + "</strong><br><strong><span class='il'>Contraseña</span>: " + Matricula.ToUpper().Trim() + "</strong>" +

                           "<tr><td>Paso 1.- Ingresa al siguiente link <strong><a href='http://www.lainter.edu.mx/' target='_blank' data-saferedirecturl='https://www.google.com/url?q=http://www.lainter.edu.mx/&amp;source=gmail&amp;ust=1654099471182000&amp;usg=AOvVaw3gD2ov03EPIymAwdXDkEQx'>clic aquí</a></strong>.<br>Paso 2.- En la opción 'Estudiantes' del menú, haz clic en el nivel al que ingresas. <br>Paso 3.- Introduce el <span class='il'>usuario</span> y <span class='il'>contraseña</span> que acabas de recibir.<br><br></td></tr>" +

                           "<br><br><strong><span class='il'>Correo Institucional</span>: " + Matricula.Replace("A", "a").Trim() + "@lainter.edu.mx" + "</strong><br><strong><span class='il'>Contraseña</span>: " + Matricula.ToUpper().Trim() + "</strong><br><br></p></td></tr></tbody></table><br>" +
                           "<tr><td>Para ingresar a tu correo instiucional:" +
                           "<br><ol><li>Inicia sesión desde la plataforma de Gmail." +
                           "</li><li>Una vez que inicies sesion te solicitaran cambiar tu contraseña" +
                           "</li><li>Te adjuntamos el manual para ligar tu correo a tu dispositivo Android" +

                           "<tr><td>Para ser un verdadero Halcón requieres cumplir con:<br><ol><li>PAGO DE INSCRIPCIÓN (Área de Pagos)</li><li>EXPEDIENTE ELECTRÓNICO (Sistema Estudiantil)</li><li>DOCUMENTOS (Área Servicios Estudiantiles)</li><li>FIRMA DE REGLAMENTOS (Sistema Estudiantil, en el periodo y año de ingreso)</li><li>HORARIO (Coordinación correspondiente de la carrera)</li></ol>" +

                           "</li></ol>Te invitamos a que acudas a revisar tu estatus a los módulos de atención que te corresponden.<br><strong>Recuerda que tienes 30 días una vez iniciado el primer día de clases para cumplir con estos requisitos, de lo contrario puedes quedar inhabilitado.</strong><br></td></tr>" +
                           "<tr><td>Quedamos al pendiente por cualquier duda, poniendo a tu disposición el correo de <a href='mailto: helpdesk@lainter.edu.mx' target='_blank'> helpdesk@lainter.edu.mx </a></td></tr>" +
                           "<tr><td><br><center>Atentamente,</center></td></tr>" +
                           "<tr><td><center><strong>Departamento de Desarrollo.</strong></center></td></tr>" +
                           "</tbody></table></div>"
                    );

                    mail.From = new MailAddress("reportes@lainter.edu.mx", "Bienvenido Halcón");
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.Normal;
                    mail.Attachments.Add(data);



                    SmtpClient smtp = new SmtpClient(); //Objeto smtp
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    //Credenciales de inicio de sesion
                    smtp.Credentials = new NetworkCredential("reportes@lainter.edu.mx", "Root.inter20");

                    string output = null;

                    try
                    {
                        smtp.Send(mail);
                        output = "Corre electrónico fue enviado satisfactoriamente.";
                    }
                    catch (Exception ex)
                    {
                        output = "Error enviando correo electrónico: " + ex.Message;
                    }
                    finally
                    {
                        mail.Dispose();
                    }

                    Console.WriteLine(output);
                    return output;
                }


                #endregion
                #region Web panel

                void Ws(string alunocontrol, int anio, int periodo, string pretipo)
                {
                    var wb = new WebClient();
                    var data = new NameValueCollection();
                    string url = "https://interpue.com.mx/controlescolar/reinscripcion.aspx?" + alunocontrol + "," + anio + "," + periodo + "," + pretipo;
                    data[""] = "";

                    var response = wb.UploadValues(url, "POST", data);
                }


                //Web pandel de proceso de kardex en v2
                void WsKardex(string matricula, string carrera)
                {
                    var wb = new WebClient();
                    var data = new NameValueCollection();
                    string url = "https://interpue.com.mx/controlescolar/cargakardex.aspx?" + matricula + "," + carrera;
                    data[""] = "";

                    var response = wb.UploadValues(url, "POST", data);
                }


                int WsApiPagos(string matricula, int año, int periodo)
                {
                    int i = 0;
                    var wb = new WebClient();
                    var data = new NameValueCollection();
                    string url = "https://pagos.interpue.com.mx/api/pagos/AlumnoPagoAcademia/" + matricula + "/" + año + "/" + periodo;
                    data[""] = "";

                    var response = wb.OpenRead(url);

                    return i;
                }

                int AlumnoPagoAcademia(string matricula, int anio, int periodo)
                {
                    int tengo = 0;
                    List<ViewPagoAlumno> ListPagoAlumno = (from vi in context.ViewPagoAlumno
                                                           where vi.CpcAlumnoClave.Trim() == matricula.Trim() && vi.CpcAño == anio && vi.CpcPeriodo == periodo
                                                           select vi).ToList();
                    tengo = ListPagoAlumno.Count();
                    return tengo;
                }

                int validaregistro(string matriucla, int anio, int periodo)
                {
                    int x = 0;
                    List<Tapreinscrito> pre = new List<Tapreinscrito>();
                    using (var _npgsqlContext = new npsqlContext())
                    {
                        //Talumno al = (from TAL in _npgsqlContext.Talumno where TAL.Alunocontrol.Trim() == matriucla.Trim() select TAL).FirstOrDefault();
                        long id = (from ALUM in _npgsqlContext.Talumno where ALUM.Alunocontrol.Trim() == matriucla.Trim() select ALUM.Aluid).FirstOrDefault();
                        if (id == 0)
                        {
                            x = 0;
                        }
                        else
                        {
                            pre = (from P in _npgsqlContext.Tapreinscrito where P.Aluid == id && P.Preanio == anio && P.Preperiodo == periodo select P).ToList();
                        }

                        if (pre.Count > 0)
                        {
                            x = pre.Count;
                        }
                        else
                        {
                            x = 0;
                        }
                    }

                    return x;
                }


                String VerificacionConveniosIndividual(long id)
                {
                    string msg = "";
                    List<DetalleConvenio> listConvenios = new List<DetalleConvenio>();
                    using (var _context = new Intererpv3testContext())
                    {
                        listConvenios = ((from D in _context.DetalleConvenio
                                          join C in _context.Convenios on D.DcConvenio equals C.ConId
                                          where D.DcCuentaDetalle == id
                                          select D)).ToList();


                        if (listConvenios.Count > 0)
                        {
                            if (id == 0)
                                msg = "ERROR: ID DE CONVENIO INVÁLIDO";
                            else
                            {
                                var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@DC_CuentaDetalle",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = id
                        },
                        new SqlParameter() {
                            ParameterName = "@msg",
                            SqlDbType =  System.Data.SqlDbType.VarChar,
                            Size = 250,
                            Direction = System.Data.ParameterDirection.Output,
                        }};

                                try
                                {
                                    _context.Database.ExecuteSqlRaw("Exec VerificacionConveniosIndividual @DC_CuentaDetalle, @msg out", param);
                                    msg = param[param.Count() - 1].Value.ToString();
                                }
                                catch (Exception m)
                                {
                                    msg = "ERROR: " + m.Message;
                                }
                            }
                        }

                        else
                            msg = "ERROR: NO CUENTA CON CONVENIO";
                        return msg;
                    }
                }

                #endregion
            }
        }
    }
}
