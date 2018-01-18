using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.BDC.Interfaces
{
    public interface IProjectBusiness
    {
        object GetProjectListing(ProjectCustomModel objProjectModel);
        object GetProjectDetail(int ProjectId);
        OperationStatus AddNewProject(ProjectCustomModel objProjectModel);
        OperationStatus DeleteProject(int ProjectId);
    }
}
