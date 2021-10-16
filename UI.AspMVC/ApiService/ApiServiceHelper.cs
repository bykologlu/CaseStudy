using Core.DTOs;
using Core.Utilities.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UI.AspMVC.ApiService
{
    public class ApiServiceHelper
    {
        private string _baseUrl; 

        public ApiServiceHelper()
        {
            _baseUrl = ConfigurationManager.AppSettings["WebApiBaseUrl"].ToString();
        }

        public ApiServiceHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public T Post<T>(string method, IDto data) where T : IResponse
        {
            IRestRequest request = new RestRequest(method, Method.POST, DataFormat.Json);
            
            request.AddJsonBody(JsonConvert.SerializeObject(data));

            IRestClient client = new RestClient(_baseUrl);

            IRestResponse response = client.Post(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public T GetQuery<T>(string method, Dictionary<string, string> query) where T : IResponse
        {
            IRestRequest request = new RestRequest(method, Method.GET, DataFormat.Json);

            foreach (var parameter in query)
                request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);

            IRestClient client = new RestClient(_baseUrl);

            IRestResponse response = client.Get(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

    }
}