using POMExample.Utils;
using RestSharp;
using System;
using System.IO;
using System.Xml.Linq;

namespace POMExample.API_Layer
{
    class APIActions
    {

        public static IRestResponse getResponce(String url, String endPoint, Method method) {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(endPoint, method);
            return client.Execute(request);
        }

        public static IRestResponse getResponceXml(String url, String endPoint, Method method, String fileName) {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(endPoint, method);
            XDocument xDoc = XDocument.Load(FilePathUtils.GetAbsolutePath(fileName));
            request.AddParameter("application/xml", xDoc.ToString(), ParameterType.RequestBody);
            return client.Execute(request);
        }

        public static IRestResponse getResponceJSON(String url, String endPoint, Method method, String fileName)
        {
            RestClient сlient = new RestClient(url);
            RestRequest request = new RestRequest(endPoint, method);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            StreamReader streamReader = File.OpenText(FilePathUtils.GetAbsolutePath(fileName));
            request.AddParameter("application/json", streamReader.ReadToEnd(), ParameterType.RequestBody);
            return сlient.Execute(request);
        }
    }
}
