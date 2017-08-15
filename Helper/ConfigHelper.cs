using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace rbk.mailrelay.Helper
{
    public static class ConfigHelper
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

        public static string GetUser()
        {
            string _name = string.Empty;
            try
            {
                _name = ConfigurationManager.AppSettings["rbkUser"];

                if (string.IsNullOrEmpty(_name))
                {
                    _exito = false;
                    _mensajes.Add("El nombre de autentificacion no ha sido asignado");
                }
                else _exito = true;
                
            }
            catch (Exception innerException)
            {
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                Errores.Add(innerException.Message + ". Metodo: " + innerException.TargetSite.Name);
                _exito = false;
            }
            return _name;
        }
        public static string GetPassword()
        {
            string _password = string.Empty;

            try
            {
                _password = ConfigurationManager.AppSettings["rbkPassword"];

                if (string.IsNullOrEmpty(_password))
                {
                    _exito = false;
                    _mensajes.Add("La contraseña no ha sido asignada");
                }
                else _exito = true;

            }
            catch (Exception innerException)
            {
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                Errores.Add(innerException.Message + ". Metodo: " + innerException.TargetSite.Name);
                _exito = false;
            }

            return _password;
        }
        public static string GetUrl()
        {
            string _url = string.Empty;

            try
            {
                _url = ConfigurationManager.AppSettings["rbkUrl"];

                if (string.IsNullOrEmpty(_url))
                {
                    _exito = false;
                    _mensajes.Add("La contraseña no ha sido asignada");
                }
                else _exito = true;

            }
            catch (Exception innerException)
            {
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                Errores.Add(innerException.Message + ". Metodo: " + innerException.TargetSite.Name);
                _exito = false;
            }

            return _url;
        }
    }
}
