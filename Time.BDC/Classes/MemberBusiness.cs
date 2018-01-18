using System;
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
    public class MemberBusiness : IMemberRepo
    {
        IMemberRepo _IMemberRepo;

        /// <summary>
        /// This method is used to list all members
        /// </summary>
        /// <returns></returns>
        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            using (_IMemberRepo = new MemberRepo())
            {
                return _IMemberRepo.GetApplicationMemberList(objMemberModel);
            }
        }

        public object GetMemberDetail(int MemberId)
        {
            using (_IMemberRepo = new MemberRepo())
            {
                return _IMemberRepo.GetMemberDetail(MemberId);
            }
        }

        /// <summary>
        /// This method is used to list one members profile
        /// </summary>
        /// <returns></returns>
        public object GetMemberProfile(int MemberId)
        {
            using (_IMemberRepo = new MemberRepo())
            {
                return _IMemberRepo.GetMemberProfile(MemberId);
            }
        }

        public OperationStatus ForgotPassword(ForgotPasswordCustomModel model)
        {
            using (_IMemberRepo = new MemberRepo())
            {
                return _IMemberRepo.ForgotPassword(model);
            }
        }

        public void Dispose()
        {
            _IMemberRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }
    }
}
