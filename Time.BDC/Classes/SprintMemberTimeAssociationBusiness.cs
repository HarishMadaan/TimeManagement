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
    public class SprintMemberTimeAssociationBusiness : ISprintMemberTimeAssociationBusiness
    {
        ISprintMemberTimeAssociationRepo _ISprintMemberTimeRepo;

        /// <summary>
        /// this method is used to add new sprint member time association
        /// </summary>
        /// <returns></returns>
        public OperationStatus AddNewSprintMemberTimeAssociation(SprintMemberTimeAssociationCustomModel model)
        {
            using (_ISprintMemberTimeRepo = new SprintMemberTimeAssociationRepo())
            {
                return _ISprintMemberTimeRepo.AddNewSprintMemberTimeAssociation(model);
            }
        }

        public void Dispose()
        {
            _ISprintMemberTimeRepo.Dispose();
            GC.SuppressFinalize(this);
            // throw new NotImplementedException();
        }

    }
}
