using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.DAL.Interfaces
{
    public interface IMemberRepo : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);
        object GetMemberDetail(int MemberId);
        object GetMemberProfile(int MemberId);
        OperationStatus ForgotPassword(ForgotPasswordCustomModel model);
    }
}
