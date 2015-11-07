using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class LoginHelper : ILoginHelper
    {
        private IClientRepository _clientRepository { get; set; }

        public LoginHelper(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        IEnumerable<Domain.Entities.clients> ILoginHelper.Clients
        {
            get
            {
                return _clientRepository.Clients;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        bool ILoginHelper.IfExists(Models.Client.LoginModel loginModel)
        {
            var tableModel = (from clients c in _clientRepository.Clients
                             where c.Email == loginModel.Login
                             select c).FirstOrDefault();

            if (tableModel != null)
            {
                if (tableModel.Email.Equals(loginModel.Login))
                {
                    var decryptedPassword = PasswordHelper.Decrypt(tableModel.Password);
                    var inputedPassword = loginModel.Password;

                    if (decryptedPassword.Equals(inputedPassword))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
                
            }
            else
                return false;
        }

        void ILoginHelper.ForgottenPassword(string email, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}