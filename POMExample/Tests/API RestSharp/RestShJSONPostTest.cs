using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Core;
using NUnit.Framework;
using POMExample.API_Layer;
using RestSharp;
using System.Net;

namespace POMExample.Tests.API_RestSharp
{
    [AllureNUnit]
    class RestShJSONPostTest
    {

        [Test]
        public void PostJSONRestSharpTest()
        {
            IRestResponse response = APIActions.getResponceJSON("https://jsonformatter.curiousconcept.com", "process", Method.POST, "PostJSON.json");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            dynamic api = JObject.Parse(response.Content);
            Assert.AreEqual("\"{\"Key\":\"Value\"}\"", JsonConvert.SerializeObject(api.result.jsoncopy).Replace("\\", ""), "Currency ID");
            Assert.AreEqual("1", JsonConvert.SerializeObject(api.result.valid), "Currency Abbreviation");
        }
    }
}