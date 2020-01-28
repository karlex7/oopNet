using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //string hrvatski = "hr";
            //string engleski = "en-GB";
            //string path = Environment.CurrentDirectory + "/" + "lang.txt";
            string path = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\lang.txt";
            var language = ConfigurationManager.AppSettings["language"];

            if (!File.Exists(path))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                if (loadLanguage())
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form2());
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Restart();
                }
            }
            
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2());
            //var utils = new Utils.Utils();
            //if (utils.getLangValue()==hrvatski)
            //{
            //    Application.Run(new Form2());
            //}
            //else
            //{
            //    Application.Run(new Form2());
            //}
        }

        private static bool loadLanguage()
        {
            string path = Environment.CurrentDirectory + "/" + "lang.txt";
            string hrvatski = "hr";
            string engleski = "en-GB";

                using (StreamReader sr = new StreamReader(path))
                {
                    var utils = new Utils.Utils();
                    string text = sr.ReadLine();
                    string utilsLang = utils.getLangValue();

                    if (text == hrvatski && utilsLang==hrvatski)
                    {
                        return true;
                    }else if (text == hrvatski && utilsLang == engleski)
                    {
                        setHRLang();
                        return false;
                    }
                    else if (text == "en" && utilsLang == hrvatski)
                    {
                        setENGLang();
                        //Application.Restart();
                        return false;
                    }
                    else
                    {
                        return true;
                    }


                }
            

        }
        private static void setHRLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "hr");
        }
        private static void setENGLang()
        {
            var utils = new Utils.Utils();
            utils.UpdateConfig("language", "en-GB");
        }
        private static void runForm1()
        {
            var language = ConfigurationManager.AppSettings["language"];
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void runForm2()
        {
            var language = ConfigurationManager.AppSettings["language"];
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }

    }
}
