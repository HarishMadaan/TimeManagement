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
    public class SprintMemberTimeAssociationAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private ISprintMemberTimeAssociationBusiness SprintMemberService;
        #endregion

        public SprintMemberTimeAssociationAPIController()
        {

        }

        public SprintMemberTimeAssociationAPIController(SprintMemberTimeAssociationBusiness _SprintMemberService)
        {
            this.SprintMemberService = _SprintMemberService;
        }

        /// <summary>
        /// This method is used to add new Project Member Time Association
        /// </summary>
        /// <returns>List of Project Member Time Association</returns>
        [HttpPost]
        [Route("API/SprintMemberTimeAssociationAPI/AddNewAssociation")]
        public Response AddNewAssociation(SprintMemberTimeAssociationCustomModel model)
        {
            _response = new Response();
            try
            {
                ISprintMemberTimeAssociationBusiness SprintMemberService = new SprintMemberTimeAssociationBusiness();
                _response.responseData = SprintMemberService.AddNewSprintMemberTimeAssociation(model);
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
                SprintMemberService = null;
            }
            return _response;
        }

    }
}
