using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.DAL.Interfaces
{
    public interface IProjectRepo : IDisposable
    {
        object GetProjectListing(ProjectCustomModel objProjectModel);
        object GetProjectDetail(int ProjectId);
        OperationStatus AddNewProject(ProjectCustomModel objProjectModel);
        OperationStatus DeleteProject(int ProjectId);
    }
}
