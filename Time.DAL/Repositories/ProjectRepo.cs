using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time.Shared.CustomModels;
using Time.DAL.Interfaces;

namespace Time.DAL.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        TimeManagementEntities dbcontext = null;
        Response response;

        public object GetProjectListing(ProjectCustomModel objProjectModel)
        {
            List<ProjectCustomModel> ProjectListModel = new List<ProjectCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        ProjectListModel = dbcontext.tblProjects.Where(x => x.IsDeleted == false)
                            .Select(x => new ProjectCustomModel
                            {
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                Documents = x.Documents,
                                Image = x.Image,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                AlliasName = x.AlliasName,
                                ProjectType = x.ProjectType,
                                MemberList = x.tblProjectMemberAssociations.Where(s => s.ProjectId == x.ProjectId).Select(s => new ProjectMembers { MemberName = s.tblMember != null ? s.tblMember.FName +" " +s.tblMember.LName: "" }).ToList(),

                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.ProjectId).ToList();

                        return ProjectListModel;

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

        public object GetProjectDetail(int ProjectId)
        {
            using (response = new Response())
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    try
                    {
                        response.success = true;
                        var rs = dbcontext.tblProjects.Where(x => x.IsDeleted == false && x.ProjectId == ProjectId)
                            .Select(x => new ProjectCustomModel
                            {
                                ProjectId = x.ProjectId,
                                Title = x.Title,
                                Description = x.Description,
                                Documents = x.Documents,
                                Image = x.Image,
                                StartDate = x.StartDate,
                                EndDate = x.EndDate,
                                AlliasName = x.AlliasName,
                                ProjectType = x.ProjectType,
                                MemberList = x.tblProjectMemberAssociations.Where(s => s.ProjectId == x.ProjectId).Select(s => new ProjectMembers { MemberName = s.tblMember != null ? s.tblMember.FName +" "+s.tblMember.LName : "" }).ToList(),

                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.ProjectId).ToList();

                        return rs;

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

        public OperationStatus AddNewProject(ProjectCustomModel objProjectModel)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (objProjectModel.ProjectId == 0)
                    {
                        var rs = dbcontext.tblProjects.FirstOrDefault(x => x.Title == objProjectModel.Title && x.IsDeleted == false);
                        if (rs == null)
                        {
                            tblProject _addProject = new tblProject
                            {
                                Title = objProjectModel.Title,
                                Description = objProjectModel.Description,
                                Documents = objProjectModel.Documents,
                                Image = objProjectModel.Image,
                                StartDate = objProjectModel.StartDate,
                                EndDate = objProjectModel.EndDate,
                                AlliasName = objProjectModel.AlliasName,
                                ProjectType = objProjectModel.ProjectType,

                                IsActive = true,
                                IsDeleted = false,
                                CreatedDate = DateTime.Now,
                                CreatedBy = objProjectModel.CreatedBy,
                                ModifiedDate = DateTime.Now,
                                ModifiedBy = objProjectModel.ModifiedBy,

                            };
                            dbcontext.tblProjects.Add(_addProject);
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
                        var rs = dbcontext.tblProjects.FirstOrDefault(x => x.ProjectId == objProjectModel.ProjectId && x.IsDeleted == false);
                        if (rs != null)
                        {
                            rs.Title = objProjectModel.Title;
                            rs.Description = objProjectModel.Description;
                            rs.Documents = objProjectModel.Documents;
                            rs.Image = objProjectModel.Image;
                            rs.StartDate = objProjectModel.StartDate;
                            rs.EndDate = objProjectModel.EndDate;
                            rs.AlliasName = objProjectModel.AlliasName;
                            rs.ProjectType = objProjectModel.ProjectType;
                            rs.ModifiedDate = DateTime.Now;

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

        public OperationStatus DeleteProject(int ProjectId)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new TimeManagementEntities())
                {
                    if (ProjectId != 0)
                    {
                        var rs = dbcontext.tblProjects.FirstOrDefault(x => x.ProjectId == ProjectId);
                        if (rs != null)
                        {
                            dbcontext.tblProjects.Remove(rs);
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

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
