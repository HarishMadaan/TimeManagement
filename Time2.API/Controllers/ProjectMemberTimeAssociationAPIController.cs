using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Time.Shared.CustomModels;
using Time.BDC.Interfaces;
using Time.BDC.Classes;

namespace Time2.API.Controllers
{
    public class ProjectMemberTimeAssociationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IProjectMemberTimeAssociationBusiness projectMemberService;
        #endregion

        public ProjectMemberTimeAssociationAPIController()
        {

        }

        public ProjectMemberTimeAssociationAPIController(ProjectMemberTimeAssociationBusiness _projectMemberService)
        {
            this.projectMemberService = _projectMemberService;
        }

        /// <summary>
        /// This method is used to fetch Project list
        /// </summary>
        /// <returns>List of Projects</returns>
        [HttpGet]
        [Route("API/ProjectMemberTimeAssociationAPI/GetMyProjectList/{MemberId}")]
        public Response GetMyProjectList(int MemberId)
        {
            _response = new Response();
            try
            {
                IProjectMemberAssociationBusiness projectMemberService = new ProjectMemberAssociationBusiness();
                _response.responseData = projectMemberService.GetMyProjectList(MemberId);
                _response.message = "Record loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                projectMemberService = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to add new Project Member Time Association
        /// </summary>
        /// <returns>List of Project Member Time Association</returns>
        [HttpPost]
        [Route("API/ProjectMemberTimeAssociationAPI/AddNewAssociation")]
        public Response AddNewAssociation(ProjectMemberTimeAssociationCustomModel model)
        {
            _response = new Response();
            try
            {
                IProjectMemberTimeAssociationBusiness projectMemberService = new ProjectMemberTimeAssociationBusiness();
                _response.responseData = projectMemberService.AddNewProjectMemberTimeAssociation(model);
                _response.message = "Record saved successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                projectMemberService = null;
            }
            return _response;
        }
    }
}
