﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;
using Time.BDC.Interfaces;
using Time.DAL.Interfaces;
using Time.DAL.Repositories;

namespace Time.BDC.Classes
{
    public class ApplicationUserBusiness : IApplicationUserBusiness
    {
        IApplicationUserRepo _IApplicationUserRepo;

        /// <summary>
        /// method is used for validate application users
        /// </summary>
        /// <param name="Logininfo"></param>
        /// <returns></returns>
        public object GetLoginUser(LoginUserModel Logininfo)
        {
            using (_IApplicationUserRepo = new ApplicationUserRepo())
            {
                return _IApplicationUserRepo.GetLoginUser(Logininfo);
            }
        }

        /// <summary>
        /// This method is used to save new members
        /// </summary>
        /// <returns></returns>
        public OperationStatus SaveApplicationUser(ApplicationUserModel applicationUserModel)
        {
            using (_IApplicationUserRepo = new ApplicationUserRepo())
            {
                return _IApplicationUserRepo.SaveApplicationUser(applicationUserModel);
            }
        }

        public void Dispose()
        {
            _IApplicationUserRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }

    }
}
