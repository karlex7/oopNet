using ClassLibrary;
using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp.Utils
{
    public class Utils
    {
        public Utils()
        {

        }
        public void UpdateConfig(string key, string value)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement xmlElement in xmlDoc.DocumentElement)
            {
                if (xmlElement.Name.Equals("appSettings"))
                {
                    foreach (XmlNode xNode in xmlElement.ChildNodes)
                    {
                        if (xNode.Attributes[0].Value.Equals(key))
                        {
                            xNode.Attributes[1].Value = value;
                        }
                    }
                }
            }

            ConfigurationManager.RefreshSection("appSettings");

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        public string getLangValue()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            string lang = "null";

            foreach (XmlElement xmlElement in xmlDoc.DocumentElement)
            {
                if (xmlElement.Name.Equals("appSettings"))
                {
                    foreach (XmlNode xNode in xmlElement.ChildNodes)
                    {
                        if (xNode.Attributes[0].Value.Equals("language"))
                        {
                            lang=xNode.Attributes[1].Value;
                        }
                    }
                }
            }

            return lang;

        }
        public StartingEleven GetStartingEleven(string name)
        {
            StartingEleven startingEleven = new StartingEleven();
            IRepo repo = RepoFactory.getRepo();
            List<StartingEleven> list = repo.GetStartingElevenForCountry("USA");
            foreach (StartingEleven item in list)
            {
                if (item.Name.Equals(name))
                {
                    startingEleven = item;
                }
            }

            return startingEleven;
        }
    }
}
