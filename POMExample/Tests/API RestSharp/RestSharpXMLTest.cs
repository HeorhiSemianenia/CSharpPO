using NUnit.Allure.Core;
using NUnit.Framework;
using POMExample.API_Layer;
using RestSharp;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace POMExample.Tests.API_RestSharp
{
    [AllureNUnit]
    class RestSharpXMLTest
    {

        [Test, Order(1)]
        public void GetXMLRequestOnProduct()
        {
            IRestResponse response = APIActions.getResponce("http://www.thomas-bayer.com/sqlrest/PRODUCT", "2", Method.GET);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using (TextReader textReader = new StringReader(response.Content))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Product));
                Product newProduct = (Product)serializer.Deserialize(textReader);
                Assert.AreEqual("2", newProduct.Id, "Product ID");
                Assert.AreEqual("Telephone Clock", newProduct.Name, "Product NAME");
                Assert.AreEqual("24.8", newProduct.Price, "Product PRICE");
            }
        }

        [Test, Order(2)]
        public void PostXMLRequestOnProduct()
        {
            var response = APIActions.getResponceXml("http://www.thomas-bayer.com/sqlrest/PRODUCT", "", Method.POST, "PostXML.xml");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test, Order(3)]
        public void PutXMLRequestOnProduct()
        {
            var response = APIActions.getResponceXml("http://www.thomas-bayer.com/sqlrest/PRODUCT", "456789", Method.PUT, "PutXML.xml");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test, Order(4)]
        public void DeleteXMLRequestOnProducts()
        {
            IRestResponse responsePost = APIActions.getResponce("http://www.thomas-bayer.com/sqlrest/PRODUCT", "987654", Method.DELETE);
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            IRestResponse responsePut = APIActions.getResponce("http://www.thomas-bayer.com/sqlrest/PRODUCT", "456789", Method.DELETE);
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
