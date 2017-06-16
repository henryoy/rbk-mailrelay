using rbk.mailrelay.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace rbk.mailrelay
{
    public class RbkMail
    {
        private List<string> _errores = new List<string>();
        private List<string> _mensajes = new List<string>();
        private string _mensaje = string.Empty;
        private bool _exito = false;
        public List<string> Errores
        {
            get { return _errores; }
        }
        public bool Exito
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
        public string Mensaje
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
        public List<string> Mensajes
        {
            get { return _mensajes; }
        }

        public static string Codigo
        {
            get
            {
                return Auth.CodigoAutentificacion();
            }
        }

        public List<Mailing> getMailingLists()
        {
            List<Mailing> lsMailing  = new List<Mailing>();

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);                
                request.AddParameter("function", "getMailingLists");
                request.AddParameter("apiKey", Codigo);
                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    lsMailing = JsonConvert.DeserializeObject<List<Mailing>>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return lsMailing;
        }

        public List<Mailing> addCampaign(Campana objeto)
        {
            List<Mailing> lsMailing = new List<Mailing>();

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "addCampaign");
                request.AddParameter("apiKey", Codigo);
                request.AddParameter("subject", objeto.subject);
                request.AddParameter("mailboxFromId", objeto.mailboxFromId);
                request.AddParameter("mailboxReplyId", objeto.mailboxReplyId);
                request.AddParameter("mailboxReportId", objeto.mailboxReportId);
                request.AddParameter("emailReport", objeto.emailReport);
                request.AddParameter("groups", objeto.groups.ToArray());
                request.AddParameter("text", objeto.text);
                request.AddParameter("html", objeto.html);
                request.AddParameter("packageId", objeto.packageId);
                request.AddParameter("campaignFolderId", objeto.campaignFolderId);               

                request.RequestFormat = DataFormat.Json;
                var item = client.Execute(request);
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    lsMailing = JsonConvert.DeserializeObject<List<Mailing>>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return lsMailing;
        }
    }
}
