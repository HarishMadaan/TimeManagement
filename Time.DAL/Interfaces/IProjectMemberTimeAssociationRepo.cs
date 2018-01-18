using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.DAL.Interfaces
{
    public interface IProjectMemberTimeAssociationRepo : IDisposable
    {

        OperationStatus AddNewProjectMemberTimeAssociation(ProjectMemberTimeAssociationCustomModel model);
    }
}
