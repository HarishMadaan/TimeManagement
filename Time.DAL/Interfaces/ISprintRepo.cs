using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;

namespace Time.DAL.Interfaces
{
    public interface ISprintRepo : IDisposable
    {
        object GetProjectSprintListing(int ProjectId);
        OperationStatus AddNewSprint(SprintCustomModel model);
        OperationStatus DeleteSprint(int SprintId);

        object GetSprintListing(int SprintId);

        OperationStatus UpdateSprintStatus(int SprintId, string SprintStatus);
    }
}
