using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rbk.mailrelay.Model;

namespace rbk.mailrelay
{
    internal static class Auth
    {
        private static List<string> _errores = new List<string>();
        private static List<string> _mensajes = new List<string>();
        private static string _mensaje = string.Empty;
        private static bool _exito = false;
        public static List<string> Errores
        {
            get { return _errores; }
        }
        public static bool Exito
        {
            get
            {
                return _exito;
            }
            set
            {
                _exito = value;
            }
        }
        public static string Mensaje
        {
            get
            {
                return _mensaje;
            }
            set
            {
                _mensaje = value;
            }
        }
        public static List<string> Mensajes
        {
            get { return _mensajes; }
        }
        private static string Password
        {
            get
            {
                return "{}";
            }
        }
        private static string User
        {
            get
            {
                return "{}";
            }
        }
        internal static string URL
        {
            get
            {
                string _url = "https://{}.ip-zone.com/ccm/admin/api/version/2/&type=json";
                return _url;
            }
        }
        public static string CodigoAutentificacion()
        {
            string Codigo = string.Empty;
            _exito = false;
            _errores.Clear();
            _mensajes.Clear();
            try
            {
                Result oResult = Authentication();
                if (Exito)
                {
                    if (oResult.status == 1)
                        Codigo = oResult.data;
                    else _exito = false;
                }
            }catch(Exception innerException){
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return Codigo;
        }
        private static Result Authentication()
        {
            Result oResult = new Result();

            try
            {                
                var client = new RestClient(URL);
                var request = new RestRequest(Method.POST);
                request.AddParameter("function", "doAuthentication");
                request.AddParameter("username", User);
                request.AddParameter("password", Password);
                request.RequestFormat = DataFormat.Json;

                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                _exito = true;


            }catch(Exception innerException){
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return oResult;
        }

    }
}
