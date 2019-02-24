using System;
using System.Xml.Serialization;

namespace POMExample.API_Layer
{
    [Serializable(), XmlRoot("PRODUCT")]
    public class Product
    {        
        [System.Xml.Serialization.XmlElement("ID")]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlElement("NAME")]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlElement("PRICE")]
        public string Price { get; set; }
    }
}
