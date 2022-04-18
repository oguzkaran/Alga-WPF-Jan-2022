using SampleValidation.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SampleValidation.ViewModels
{
    public class LoginWindowViewModel : IDataErrorInfo
    {
        private readonly SampleAppService m_sampleAppService;

        private static bool isValidEmail(string email)
        {
            var status = false;

            try
            {
                new MailAddress(email);
                status = true;
            }
            catch (Exception)
            {

            }

            return status;
        }

        public LoginWindowViewModel(SampleAppService service)
        {
            m_sampleAppService = service;
        }

        public string this[string fieldName]
        {
            get
            {
                switch (fieldName)
                {
                    case "Email":
                        if (!isValidEmail(Email))
                            return "Invalid email vaue";
                        break;
                    //...
                }

                return ""; //string.Empty;
            }
        }

        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string Error { get; }

        public bool CheckAuthorization()
        {
            if (this["Email"] != "")
                return false;

            return m_sampleAppService.Login(Email, Password);
        }
    }
}
