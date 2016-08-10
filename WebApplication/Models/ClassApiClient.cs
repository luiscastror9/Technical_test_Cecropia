using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Reflection;
using ApiClient;
using System.Runtime.Remoting; 

namespace ApiClient
{
                 

    public class ClassApiClient
    {
        public RestClient ConnectApi()
        {
        var client = new RestClient(System.Configuration.ConfigurationManager.AppSettings.Get("ruta"));
        
         return client;
        }

#region Operaciones
        public object content;

        public object ListApi(string carpeta, string tabla)
        {

            var request = new RestRequest(carpeta + "/" + tabla + "/", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.RootElement = tabla;
             RestClient client = ConnectApi();
            IRestResponse response = client.Execute(request);


  
            return response;
        }

        public object Api(string carpeta, string tabla, string accion, Dictionary<string, string> parametros)
        {
            var request = new RestRequest();
            switch (accion)
            {
                case "Details":
                    request = new RestRequest(carpeta + "/" + tabla + "/" + "Details", Method.GET);
                    break;
                case "Delete":
                    request = new RestRequest(carpeta + "/" + tabla + "/" + "Delete", Method.DELETE);
                    break;
                case "Update":
                    request = new RestRequest(carpeta + "/" + tabla + "/" + "Update", Method.POST);
                    break;
                case "Create":
                    request = new RestRequest(carpeta + "/" + tabla + "/" + "Create", Method.POST);
                    break;

            }
            request.RequestFormat = DataFormat.Json;
            request.RootElement = tabla;

            foreach (KeyValuePair<string, string> pair in parametros)
            {
                request.AddParameter(pair.Key, pair.Value);
            }
         
            RestClient client = ConnectApi();


            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return response;
            }
            else
            {
                return null;
            }
          
        }

#endregion



    }
}
