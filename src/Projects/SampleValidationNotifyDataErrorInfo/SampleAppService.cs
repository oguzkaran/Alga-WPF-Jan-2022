using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleValidation.Services
{
    public class SampleAppService
    {
        public bool Login(string email, string password)
        {
            //Veritabanından kontrol edilecek
            var status = email == "oguzkaran@csystem.org" && password == "csd1993";

            //...
            return status;
        }
    }
}
