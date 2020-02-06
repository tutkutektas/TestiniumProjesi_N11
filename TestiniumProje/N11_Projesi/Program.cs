using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static N11_Projesi.Helpers;

namespace N11_Projesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Helpers helpers = new Helpers();
            string browsername = helpers.CurrentPcDefaultBrowserName();
            ReturnModel isSuccess = new ReturnModel();

            switch (browsername)
            {
                case "None":
                    break;
              
             
                case "Firefox":
                    isSuccess = helpers.TestStartFirefox();
                    break;

                case "Chrome":
                    isSuccess = helpers.TestStartChrome();
                    break;

            }
            Console.WriteLine(" ");
            if (isSuccess.IsSuccess == true)
            {
                Console.WriteLine("Test Başarılı");
            }
            else
            {
                Console.WriteLine(isSuccess.ErrorMessage);
            }
            Console.ReadLine();
        }
    }
}

