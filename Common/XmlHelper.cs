using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;

namespace Common
{
    public class XmlHelper
   { 
    string XmlPath = null;
    XDocument xmlDoc;
    XElement root;
    public XmlHelper()
    {
        XmlPath = "/TransportList.xml";
        xmlDoc = XDocument.Load(XmlPath);
        root = xmlDoc.Root;
    }
    public XmlHelper(string xmlPath)
    {
        XmlPath = xmlPath;
        xmlDoc = XDocument.Load(XmlPath);
        root = xmlDoc.Root;
    }

    public Dictionary<string, string> GetSetting()
    {
        var indexProduct = new Dictionary<string, string>();
        var setting = root.Elements("setting");
        foreach (var item in setting)
        {
            indexProduct.Add(item.Element("index").Value, item.Element("value").Value);
        }


        return indexProduct;
    }

    public void SetSetting(Dictionary<string, string> index)
    {
        foreach (var item in index)
        {
            var temp = from a in root.Elements("setting").Elements("index")
                       where a.Value == item.Key
                       select a.Parent;
            XElement xe = temp.FirstOrDefault<XElement>().Element("value");
            xe.SetValue(item.Value);


        }
        xmlDoc.Save(XmlPath);
    }
}
}
