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
    public class ProjectMemberTimeAssociationBusiness : IProjectMemberTimeAssociationBusiness
    {
        IProjectMemberTimeAssociationRepo _IProjectMemberTimeRepo;

        /// <summary>
        /// this method is used to add new projects member time association
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewProjectMemberTimeAssociation(ProjectMemberTimeAssociationCustomModel model)
        {
            using (_IProjectMemberTimeRepo = new ProjectMemberTimeAssociationRepo())
            {
                return _IProjectMemberTimeRepo.AddNewProjectMemberTimeAssociation(model);
            }
        }

        public void Dispose()
        {
            _IProjectMemberTimeRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }

    }
}
