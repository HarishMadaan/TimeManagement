using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;
using Time.DAL.Interfaces;

namespace Time.DAL.Repositories
{
    public class SprintRepo : ISprintRepo
    {
        TimeManagementEntities dbcontext = null;
        Response response;

        public object GetProjectSprintListing(int ProjectId)
        {
            List<SprintCustomModel> SprintListModel = new List<SprintCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        SprintListModel = dbcontext.tblProjectSprints.Where(x => x.ProjectId == ProjectId)
                            .Select(x => new SprintCustomModel
                            {
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                SprintNo = x.SprintNo,
                                Status = x.Status,
                                SprintId = x.SprintId,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.SprintId).ToList();

                        return SprintListModel;

                    }
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public OperationStatus AddNewSprint(SprintCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (model.SprintId == 0)
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.Title == model.Title && x.ProjectId == model.ProjectId);
                        if (rs == null)
                        {
                            tblProjectSprint _addSprint = new tblProjectSprint
                            {
                                ProjectId = model.ProjectId,
                                Title = model.Title,
                                Description = model.Description,
                                SprintNo = model.SprintNo,
                                Status = model.Status,
                                StartDate = model.StartDate,
                                EndDate = model.EndDate,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = model.CreatedBy,
                                ModifiedDate = DateTime.Now,
                                ModifiedBy = model.ModifiedBy,

                            };
                            dbcontext.tblProjectSprints.Add(_addSprint);
                            dbcontext.SaveChanges();

                            status = OperationStatus.Success;
                        }
                        else
                        {
                            status = OperationStatus.Duplicate;
                        }
                    }
                    else
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.SprintId == model.SprintId);
                        if (rs != null)
                        {
                            rs.Title = model.Title;
                            rs.Description = model.Description;
                            rs.SprintNo = model.SprintNo;
                            rs.Status = model.Status;
                            rs.StartDate = model.StartDate;
                            rs.EndDate = model.EndDate;

                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                        else
                        {
                            status = OperationStatus.Duplicate;
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

        public OperationStatus UpdateSprintStatus(int SprintId, string SprintStatus)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (SprintId != 0)
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.SprintId == SprintId);
                        if (rs != null)
                        {
                            rs.Status = SprintStatus;
                            
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                    }
                    else
                    {
                        status = OperationStatus.Error;
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

        public OperationStatus DeleteSprint(int SprintId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (SprintId != 0)
                    {
                        var rs = dbcontext.tblProjectSprints.FirstOrDefault(x => x.SprintId == SprintId);
                        if (rs != null)
                        {
                            dbcontext.tblProjectSprints.Remove(rs);
                            dbcontext.SaveChanges();
                            status = OperationStatus.Success;
                        }
                    }
                    else
                    {
                        status = OperationStatus.Error;
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

        public object GetSprintListing(int SprintId)
        {
            List<SprintCustomModel> SprintListModel = new List<SprintCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        SprintListModel = dbcontext.tblProjectSprints.Where(x => x.SprintId == SprintId)
                            .Select(x => new SprintCustomModel
                            {
                                SprintId = x.SprintId,
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                SprintNo = x.SprintNo,
                                Status = x.Status,                                
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                MemberList = x.tblSprintMemberAssociations.Where(s => s.SprintId == x.SprintId).Select(s => new SprintMembers { MemberId = s.MemberId, MemberName = s.tblMember != null ? s.tblMember.FName + " " + s.tblMember.LName : "", TotalTimeSpent = (dbcontext.tblSprintMemberTimeAssociations.Where(y => y.SprintId == x.SprintId && y.MemberId == s.tblMember.MemberId).Sum(v => v.TimeSpend)) }).ToList(),
                                //TotalTimeSpent = (dbcontext.tblSprintMemberTimeAssociations.Where(y => y.SprintId == x.SprintId && y.MemberId == x.MemberId).Sum(v => v.TimeSpend))

                            }).OrderByDescending(x => x.SprintId).ToList();

                        return SprintListModel;

                    }
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}