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
    class RestShJSONGetTest
    {

        [Test]
        public void GetJSONRestSharpTest()
        {
            IRestResponse response = APIActions.getResponce("http://www.nbrb.by/API/ExRates/Rates", "145?onDate=2019-02-15", Method.GET);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            dynamic api = JObject.Parse(response.Content);
            Assert.AreEqual("145", JsonConvert.SerializeObject(api.Cur_ID), "Currency ID");
            Assert.AreEqual("\"USD\"", JsonConvert.SerializeObject(api.Cur_Abbreviation), "Currency Abbreviation");
            Assert.AreEqual("2.1679", JsonConvert.SerializeObject(api.Cur_OfficialRate), "Exchange rate");
        }
    }
}
