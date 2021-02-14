using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace sahibinden
{

    public class Program
    {
        /// <summary>
        /// Writes The Given Value
        /// <param name="value">Value</param> 
        /// </summary>
        public static void writeToDoc(string value)
        {
            // masaüstünde bir txt dosyası oluşturabilirsin.
            string path = @"/users/deremakif/Desktop/sahibinden.txt";
            using (var sw = new StreamWriter(path, true))
            {
                sw.WriteLine(value);
            }

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //SafariOptions options = new SafariOptions();
            //ChromeOptions options = new ChromeOptions();
            //options.AddExcludedArgument("enable-automation");
            //options.AddArgument("--incognito");
            //options.AddArgument("--headless");
            //options.AddArgument("--start-maximized");
            //options.AddArgument("--disable-infobars");
            //options.AddArgument("--disable-extensions");
            //options.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");


            //IWebDriver driver = new FirefoxDriver(); // @"/users/deremakif/Downloads/", options
            IWebDriver driver = new ChromeDriver(); // @"/users/deremakif/Downloads/", options

            for (int i = 1; i < 21; i++)
            {
                // listeye git : önce en yeniler ... 1000 tane
                driver.Navigate().GoToUrl("https://www.sahibinden.com/minivan-panelvan/sahibinden?pagingOffset=" + ((i - 1) * 50) + "&pagingSize=50&sorting=date_desc");

                System.Threading.Thread.Sleep(2000);


                for (int j = 1; j < 51; j++)
                {
                    try
                    {
                        writeToDoc("------------------------------------------ " + (((i - 1) * 50) + j));

                        // marka
                        writeToDoc("marka : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[2]")).Text);

                        // seri
                        writeToDoc("seri : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[3]")).Text);

                        // model
                        writeToDoc("model : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[4]")).Text);

                        // yil
                        writeToDoc("yil : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[6]")).Text);

                        // km
                        writeToDoc("km : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[7]")).Text);

                        // kasa tipi
                        writeToDoc("kasa tipi : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[8]")).Text);

                        // fiyat
                        writeToDoc("fiyat : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[9]")).Text);

                        // ilan tarihi  + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[10]")).Text
                        writeToDoc("ilan tarihi : ");

                        // il ilce
                        string konum = driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[11]")).Text;
                        if (konum.Contains("\n"))
                        {
                            konum = konum.Replace("\n", " - ");
                        }
                        writeToDoc("il ilce : " + konum);

                    }
                    catch (Exception)
                    {
                        writeToDoc("marka : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("seri : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("model : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("yil : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("km : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("kasa tipi : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("fiyat : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("ilan tarihi : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        writeToDoc("il ilce : " + (((i - 1) * 50) + j) + " listede bulamadı");

                    }

                    try
                    {
                        // ilan detayina git - click ile gidemiyor.
                        driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[5]/a")).Click();

                        // https://www.sahibinden.com/ilan/vasita-otomobil-bentley-ss-motors-2017-bentley-continental-gt-supersports-v12-naim-bayi-811285595/detay
                        // driver.Navigate().GoToUrl("https://www.sahibinden.com/ilan/vasita-otomobil-bentley-ss-motors-2017-bentley-continental-gt-supersports-v12-naim-bayi-811285595/detay");

                        System.Threading.Thread.Sleep(2000);


                        // satici :
                        try
                        {
                            writeToDoc("satici : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/div[1]/div[2]/div[3]/div[1]/div/div[1]/h5")).Text);
                        }
                        catch (Exception)
                        {
                            writeToDoc("satici : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        }

                        // telefon
                        try
                        {
                            writeToDoc("telefon : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/div[1]/div[2]/div[3]/div[1]/div/ul/li/span[1]")).Text);
                        }
                        catch (Exception)
                        {
                            writeToDoc("telefon : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("firma detayına giremedi " + ex + (((i - 1) * 50) + j));

                        writeToDoc("satici : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        writeToDoc("telefon : " + (((i - 1) * 50) + j) + " detayına giremedi");
                    }

                    // Listeye geri döner.
                    driver.Navigate().GoToUrl("https://www.sahibinden.com/minivan-panelvan/sahibinden?pagingOffset=" + ((i - 1) * 50) + "&pagingSize=50&sorting=date_desc");
                    System.Threading.Thread.Sleep(2000);

                }

            }


        }


        public bool checkExistsByXPath(string xpath)
        {
            try
            {
                // driver.FindElement(By.XPath(xpath));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}
