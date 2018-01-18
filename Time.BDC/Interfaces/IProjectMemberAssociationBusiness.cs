using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.BDC.Interfaces
{
    public interface IProjectMemberAssociationBusiness : IDisposable
    {
        object GetMyProjectList(int MemberId);
        OperationStatus AddNewProjectMemberAssociation(ProjectMemberAssociationCustomModel objProjectMemberModel);
        OperationStatus DeleteProjectAssociation(int ProjectId);
    }
}
