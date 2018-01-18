using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.DAL.Interfaces
{
    public interface ISprintMemberAssociationRepo : IDisposable
    {
        object GetMySprintList(int MemberId);

        OperationStatus AddNewSprintMemberAssociation(SprintMemberAssociationCustomModel objSprintMemberModel);

        OperationStatus UpdateSprintStatus(int SprintId, string Status);

        OperationStatus DeleteSprintAssociation(int SprintId);

    }
}
