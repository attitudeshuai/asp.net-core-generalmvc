using General.Domian.Dto;
using General.Domian.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework.Security
{
    public interface IAdminAuthService
    {
        void SignIn(string token,string name);
        SessionUser GetCurrentUser();
    }
}
