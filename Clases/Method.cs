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
            List<Mailing> lsMailing = new List<Mailing>();

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


        public List<Mailing> getCampaign(parameterCampana objeto)
        {
            List<Mailing> lsMailing = new List<Mailing>();

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "getCampaigns");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("offset", objeto.offset);
                request.AddParameter("count", objeto.count);

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
        public int addCampaign(Campana objeto)
        {
            int CampanaId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "addCampaign");
                request.AddParameter("apiKey", objeto.apiKey);
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
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    CampanaId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return CampanaId;
        }
        public int updateCampaign(Campana objeto)
        {
            int CampanaId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "updateCampaign");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("id", objeto.id);
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
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    CampanaId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return CampanaId;
        }
        public int sendCampaign(SendCampana objeto)
        {
            int CampanaId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "sendCampaign");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("id", objeto.id);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    CampanaId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return CampanaId;
        }
        public int sendCampaignTest(SendCampana objeto)
        {
            int CampanaId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "sendCampaignTest");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("id", objeto.id);
                request.AddParameter("email", objeto.email);
                request.AddParameter("vmta", objeto.vmta);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    CampanaId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return CampanaId;
        }
        /*--{ Grioup }--*/
        public int addGroup(Group objeto)
        {
            int GrupoId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "addGroup");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("description", objeto.description);
                request.AddParameter("enable", objeto.enable);
                request.AddParameter("name", objeto.name);
                request.AddParameter("position", objeto.position);
                request.AddParameter("visible", objeto.visible);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    GrupoId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return GrupoId;
        }
        public int updateGroup(Group objeto)
        {
            int GrupoId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                request.AddParameter("function", "updateGroup");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("description", objeto.description);
                request.AddParameter("enable", objeto.enable);
                request.AddParameter("name", objeto.name);
                request.AddParameter("position", objeto.position);
                request.AddParameter("visible", objeto.visible);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;
                if (oResult.status == 1)
                {
                    GrupoId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return GrupoId;
        }
        /*--{ Suscriptores }--*/
        public int addSuscriber(Suscriber objeto)
        {
            int SuscriberId = 0;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);

                int[] Group = objeto.groups.ToArray();

                request.AddParameter("function", "addSubscriber");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("email", objeto.email);
                request.AddParameter("name", objeto.name);

                for (int i = 0; i <= objeto.groups.Count; i++)
                {
                    request.AddParameter("groups[" + i + "]", Group[i]);
                }

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    SuscriberId = JsonConvert.DeserializeObject<int>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return SuscriberId;
        }
        public bool updateSubscriber(Suscriber objeto)
        {
            bool isActive = false;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "updateSubscriber");
                request.AddParameter("apiKey", objeto.apiKey);
                request.AddParameter("id", objeto.id);
                request.AddParameter("email", objeto.email);
                request.AddParameter("name", objeto.name);
                for (int i = 0; i <= objeto.groups.Count; i++)
                {
                    request.AddParameter("groups[" + i + "]", objeto.groups[i]);
                }

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    isActive = JsonConvert.DeserializeObject<bool>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return isActive;
        }
        public bool assignSubscribersToGroups(Suscriber objeto)
        {
            bool isActive = false;

            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "assignSubscribersToGroups");
                request.AddParameter("apiKey", objeto.apiKey);

                for (int i = 0; i <= objeto.subscribers.Count; i++)
                {
                    request.AddParameter("subscribers[" + i + "]", objeto.subscribers[i]);
                }

                for (int i = 0; i < objeto.groups.Count; i++)
                {
                    request.AddParameter("groups[" + i + "]", objeto.groups[i]);
                }

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    isActive = JsonConvert.DeserializeObject<bool>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return isActive;
        }
        /*--{ Estadisticas}--*/
        public ResultStatistics getStats(Statistics objeto)
        {
            ResultStatistics Result = new ResultStatistics();
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getStats");
                request.AddParameter("apiKey", objeto.apiKey);

                if (objeto.id > 0)
                    request.AddParameter("id", objeto.id);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("startDate", objeto.startDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.endDate.Year > 1)
                    request.AddParameter("endDate", objeto.endDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.smtpTags != null)
                    for (int i = 0; i <= objeto.smtpTags.Count; i++)
                        request.AddParameter("smtpTags[" + i + "]", objeto.smtpTags[i]);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    Result = JsonConvert.DeserializeObject<ResultStatistics>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return Result;
        }

        public List<ResultsUniqueClicks> getClicksInfo(Statistics objeto)
        {
            List<ResultsUniqueClicks> lsClickInfo = new List<ResultsUniqueClicks>();
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getClicksInfo");
                request.AddParameter("apiKey", objeto.apiKey);

                if (objeto.id > 0)
                    request.AddParameter("id", objeto.id);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("startDate", objeto.startDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.endDate.Year > 1)
                    request.AddParameter("endDate", objeto.endDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.smtpTags != null)
                    for (int i = 0; i <= objeto.smtpTags.Count; i++)
                        request.AddParameter("smtpTags[" + i + "]", objeto.smtpTags[i]);
                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    lsClickInfo = JsonConvert.DeserializeObject<List<ResultsUniqueClicks>>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return lsClickInfo;
        }

        /*
        * apiKey	string	API key previously generated
        * id	integer	Optional parameter if you want to get stats for a single mailing list. If not set, will return for all mailing lists.
        * startDate	string	Optional parameter for start date. Must be in the following format: YYYY-MM-DD HH:MM:SS.
        * endDate	string	Optional parameter for end date. Must be in the following format: YYYY-MM-DD HH:MM:SS.
        * smtpTags	array	Optional parameter to search for clicks with specific smtp tags. You must be provide an array of smtp tags ids. 
        */
        public ResultsUniqueClicks getUniqueClicksInfo(Statistics objeto)
        {
            ResultsUniqueClicks UniqueClicks = new ResultsUniqueClicks();
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getUniqueClicksInfo");
                request.AddParameter("apiKey", objeto.apiKey);

                if(objeto.id > 0)
                    request.AddParameter("id", objeto.id);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("startDate", objeto.startDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.endDate.Year > 1)
                    request.AddParameter("endDate", objeto.endDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if(objeto.smtpTags != null)
                    for(int i = 0; i <= objeto.smtpTags.Count; i++)
                        request.AddParameter("smtpTags[" + i + "]", objeto.smtpTags[i]);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    UniqueClicks = JsonConvert.DeserializeObject<ResultsUniqueClicks>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return UniqueClicks;
        }

        public List<ResultImpressionsInfo> getImpressionsInfo(Statistics objeto)
        {
            List<ResultImpressionsInfo> lsImpresssionsInfo = new List<ResultImpressionsInfo>();
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getImpressionsInfo");
                request.AddParameter("apiKey", objeto.apiKey);

                if (objeto.id > 0)
                    request.AddParameter("id", objeto.id);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("startDate", objeto.startDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.endDate.Year > 1)
                    request.AddParameter("endDate", objeto.endDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if(objeto.smtpTags != null)
                    for (int i = 0; i <= objeto.smtpTags.Count; i++)                
                        request.AddParameter("smtpTags[" + i + "]", objeto.smtpTags[i]);
                

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    lsImpresssionsInfo = JsonConvert.DeserializeObject<List<ResultImpressionsInfo>>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return lsImpresssionsInfo;
        }

        public List<ResultImpressionsInfo> getUniqueImpressionsInfo(Statistics objeto)
        {
            List<ResultImpressionsInfo> lsImpresssionsInfo = new List<ResultImpressionsInfo>();
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getUniqueImpressionsInfo");
                request.AddParameter("apiKey", objeto.apiKey);

                if (objeto.id > 0)
                    request.AddParameter("id", objeto.id);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("startDate", objeto.startDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (objeto.endDate.Year > 1)
                    request.AddParameter("endDate", objeto.endDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if(objeto.smtpTags != null)
                    for (int i = 0; i <= objeto.smtpTags.Count; i++)
                        request.AddParameter("smtpTags[" + i + "]", objeto.smtpTags[i]);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    lsImpresssionsInfo = JsonConvert.DeserializeObject<List<ResultImpressionsInfo>>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return lsImpresssionsInfo;
        }

        /*
         *  apiKey	string	API key previously generated.
         *  offset	integer	Optional parameter to specify offset.
         *  count	integer	Optional parameter to specify the number of records.
         *  id	integer	Optional parameter to search by id.
         *  email	string	Optional parameter to search by email.
         *  startDate	string	Optional parameter for start date. Must be in the following format: YYYY-MM-DD HH:MM:SS.
         *   endDate	string	Optional parameter for end date. Must be in the following format: YYYY-MM-DD HH:MM:SS.
         *  sortField	string	Optional parameter to specify a search field.
         *  sortOrder	string	Optional parameter to specify a sort order. Accepted values are ASC and DESC (default).
         */
        public bool getSpamReports(StatisticsSpam objeto)
        {
            bool isActive = false;
            try
            {
                var client = new RestClient(Auth.URL);
                var request = new RestRequest(Method.POST);


                request.AddParameter("function", "getSpamReports");
                request.AddParameter("apiKey", objeto.apiKey);

                if (objeto.offset > 0)
                    request.AddParameter("offset", objeto.offset);

                if (objeto.count > 0)
                    request.AddParameter("count", objeto.count);

                if (!string.IsNullOrEmpty(objeto.email))
                    request.AddParameter("email", objeto.email);

                if (objeto.startDate.Year > 1)
                    request.AddParameter("id", objeto.startDate);

                if (objeto.endDate.Year > 1)
                    request.AddParameter("apiKey", objeto.endDate);

                if (!string.IsNullOrEmpty(objeto.sortField))
                    request.AddParameter("sortField", objeto.sortField);

                if (!string.IsNullOrEmpty(objeto.sortField))
                    request.AddParameter("sortOrder", objeto.sortOrder);

                request.RequestFormat = DataFormat.Json;
                Result oResult = new Result();
                IRestResponse<Result> response = client.Execute<Result>(request);
                oResult = response.Data;

                if (oResult.status == 1)
                {
                    isActive = JsonConvert.DeserializeObject<bool>(oResult.data);
                    _exito = true;
                }

            }
            catch (Exception innerException)
            {
                _mensajes.Add(innerException.StackTrace);
                _exito = false;
            }

            return isActive;
        }
    }
}
