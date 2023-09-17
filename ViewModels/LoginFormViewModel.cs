using Fitness.Models;
using Fitness.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.ViewModels
{
    public class LoginFormViewModel : BaseViewModel
    {
        public LoginFormViewModel(INavigationService navigationService, LoginFormModel loginFormModel) : base(navigationService)
        {
            LoginFormModel = loginFormModel;
        }

        /// <summary>
        /// Gets or sets the login form model.
        /// </summary>
        public LoginFormModel LoginFormModel { get; set; }
    }
}
