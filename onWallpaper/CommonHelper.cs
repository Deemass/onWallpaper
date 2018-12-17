using System;
using System.IO;
using System.Xml;

namespace onWallpaper
{
    class CommonHelper
    {
        public static string RESO = "1920x1080";
        private static string CONFIGFILEPATH = AppDomain.CurrentDomain.BaseDirectory+"userdata.xml";
        public static void CreateFile()
        {
            if (!File.Exists(CONFIGFILEPATH))
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(dec);
                XmlElement root = doc.CreateElement("Root");
                doc.AppendChild(root);
                doc.Save(CONFIGFILEPATH);
            }
        }

        public static void SetConfigString(string key, string value)
        {
            CreateFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(CONFIGFILEPATH);
            XmlNode node = doc.SelectSingleNode("Root/"+key);
            if(node == null)
            {
                node = doc.CreateElement(key);
                doc.SelectSingleNode("Root").AppendChild(node);
            }
            node.InnerText = value;
            doc.Save(CONFIGFILEPATH);
        }

        public static string GetConfigValue(string key)
        {
            CreateFile();
            XmlDocument doc = new XmlDocument();
            doc.Load(CONFIGFILEPATH);
            XmlNode node = doc.SelectSingleNode("Root/" + key);
            if (node == null)
            {
                return "";
            }
            else
            {
                return node.InnerText;
            }
        }

        public static int GetConfigIntValue(string key)
        {
            string value = GetConfigValue(key);
            if ("" == value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        public static bool CheckReso(string resoParam)
        {
            string[] param = resoParam.Split('x');
            string[] locParam = RESO.Split('x');
            if (int.Parse(param[0]) < int.Parse(locParam[0]))
            {
                return false;
            }else if (int.Parse(param[1]) < int.Parse(locParam[1]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
