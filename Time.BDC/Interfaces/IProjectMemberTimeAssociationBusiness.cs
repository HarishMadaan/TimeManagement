using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.BDC.Interfaces
{
    public interface IProjectMemberTimeAssociationBusiness : IDisposable
    {
        OperationStatus AddNewProjectMemberTimeAssociation(ProjectMemberTimeAssociationCustomModel model);
    }
}
