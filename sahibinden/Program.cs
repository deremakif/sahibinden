using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.IO;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace sahibinden
{
    public class Program
    {
        public static void yaz(string a)
        {
            // masaüstünde bir txt dosyası oluşturabilirsin.
            string path = @"/users/deremakif/Desktop/sahibinden.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(a);
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
           

            IWebDriver driver = new FirefoxDriver(); // @"/users/deremakif/Downloads/", options
            //IWebDriver driver = new ChromeDriver(); // @"/users/deremakif/Downloads/", options

            for (int i = 1; i < 21; i++)
            {
                // listeye git : önce en yeniler ... 1000 tane
                driver.Navigate().GoToUrl("https://www.sahibinden.com/minivan-panelvan/sahibinden?pagingOffset=" + ((i - 1) * 50) + "&pagingSize=50&sorting=date_desc");

                System.Threading.Thread.Sleep(2000);


                for (int j = 1; j < 51; j++)
                {
                    try
                    {
                        yaz("------------------------------------------ " + (((i - 1) * 50) + j));

                        // marka
                        yaz("marka : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[2]")).Text);

                        // seri
                        yaz("seri : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[3]")).Text);

                        // model
                        yaz("model : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[4]")).Text);

                        // yil
                        yaz("yil : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[6]")).Text);

                        // km
                        yaz("km : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[7]")).Text);

                        // kasa tipi
                        yaz("kasa tipi : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[8]")).Text);

                        // fiyat
                        yaz("fiyat : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[9]")).Text);

                        // ilan tarihi  + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[10]")).Text
                        yaz("ilan tarihi : " );

                        // il ilce
                        string konum = driver.FindElement(By.XPath("/html/body/div[4]/div[4]/form/div/div[3]/table/tbody/tr[" + j + "]/td[11]")).Text;
                        if(konum.Contains("\n"))
                        {
                            konum = konum.Replace("\n", " - " );
                        }
                        yaz("il ilce : " + konum);

                    }
                    catch (Exception)
                    {
                        yaz("marka : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("seri : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("model : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("yil : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("km : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("kasa tipi : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("fiyat : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("ilan tarihi : " + (((i - 1) * 50) + j) + " listede bulamadı");
                        yaz("il ilce : " + (((i - 1) * 50) + j) + " listede bulamadı");

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
                            yaz("satici : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/div[1]/div[2]/div[3]/div[1]/div/div[1]/h5")).Text);
                        }
                        catch (Exception)
                        {
                            yaz("satici : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        }

                        // telefon
                        try
                        {
                            yaz("telefon : " + driver.FindElement(By.XPath("/html/body/div[4]/div[4]/div[1]/div[2]/div[3]/div[1]/div/ul/li/span[1]")).Text);
                        }
                        catch (Exception)
                        {
                            yaz("telefon : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("firma detayına giremedi " + ex + (((i - 1) * 50) + j));

                        yaz("satici : " + (((i - 1) * 50) + j) + " detayına giremedi");
                        yaz("telefon : " + (((i - 1) * 50) + j) + " detayına giremedi");
                    }

                    // Listeye geri döner.
                    driver.Navigate().GoToUrl("https://www.sahibinden.com/minivan-panelvan/sahibinden?pagingOffset=" + ((i - 1) * 50) + "&pagingSize=50&sorting=date_desc");
                    System.Threading.Thread.Sleep(2000);

                }

            }


        }

        public bool check_exists_by_xpath(string xpath)
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
