using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;
using Time.DAL.Interfaces;

namespace Time.DAL.Repositories
{
    public class ProjectMemberTimeAssociationRepo : IProjectMemberTimeAssociationRepo
    {
        TimeManagementEntities dbcontext = null;
        Response response;

        public OperationStatus AddNewProjectMemberTimeAssociation(ProjectMemberTimeAssociationCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (model.TimeId == 0)
                    {
                        tblProjectMemberTimeAssociation _addProjectList = new tblProjectMemberTimeAssociation
                        {
                            ProjectId = model.ProjectId,
                            MemberId = model.MemberId,
                            TimeSpend = model.TimeSpend,
                            DDate = model.DDate,                            
                            Description = model.Description,

                            IsActive = true,
                            IsDeleted = false,
                            CreatedBy = model.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = model.ModifiedBy,
                            ModifiedDate = DateTime.Now,
                        };
                        dbcontext.tblProjectMemberTimeAssociations.Add(_addProjectList);
                        dbcontext.SaveChanges();

                        status = OperationStatus.Success;
                    }
                    else
                    {
                        var rs = dbcontext.tblProjectMemberTimeAssociations.FirstOrDefault(x => x.TimeId == model.TimeId);
                        if (rs != null)
                        {
                            rs.MemberId = model.MemberId;
                            rs.ProjectId = model.ProjectId;
                            rs.TimeSpend = model.TimeSpend;
                            rs.DDate = model.DDate;
                            rs.Description = model.Description;

                            rs.ModifiedDate = DateTime.Now;
                            rs.ModifiedBy = model.ModifiedBy;
                            
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }

            return status;
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }

    }
}
