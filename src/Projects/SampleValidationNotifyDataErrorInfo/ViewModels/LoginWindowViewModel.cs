using SampleValidation.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleValidation.ViewModels
{
    public class LoginWindowViewModel : INotifyDataErrorInfo
    {
        private readonly SampleAppService m_sampleAppService;

        public LoginWindowViewModel(SampleAppService service)
        {
            m_sampleAppService = service;
        }

        public string Email { get; set; } = "";
        public string Password { get; set; } = ""; 

        public bool HasErrors { get; set; } = false;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !HasErrors)
                return null;

            return new List<string> { "Invalid values" };
        }

        public bool CheckAuthentication()
        {
            HasErrors = !m_sampleAppService.Login(Email, Password);

            if (HasErrors)
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Email"));
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs("Password"));

                return false;
            }

            return true;
        }
    }
}
