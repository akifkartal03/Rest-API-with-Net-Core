using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netflixAPI.Contracts.V1;
using netflixAPI.Contracts.V1.Requests;
using netflixAPI.Contracts.V1.Responses;
using netflixAPI.Domain;
using netflixAPI.Extensions;
using netflixAPI.Services;

namespace netflixAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProgramTypeController : Controller
    {
        private readonly IProgramTypeService _prgTypeService;

        public ProgramTypeController(IProgramTypeService prgTypeService)
        {
            _prgTypeService = prgTypeService;
        }

        [HttpGet(ApiRoutes.ProgramType.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _prgTypeService.GetProgramTypeAsync());
        }

        [HttpPut(ApiRoutes.ProgramType.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid prgTypeId, [FromBody] CreateProgramTypeRequest request)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(programId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/

            var prgType1 = await _prgTypeService.GetProgramTypeByIdAsync(prgTypeId);
            prgType1.PrgId = request.PrgID;
            prgType1.TypeID = request.TypeId;
      

            var updated = await _prgTypeService.UpdateProgramTypeAsync(prgType1);

            if(updated)
                return Ok(prgType1);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.ProgramType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid prgTypeId)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(ProgramId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/
            
            var deleted = await _prgTypeService.DeleteProgramTypeAsync(prgTypeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.ProgramType.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid prgTypeId)
        {
            var prgType1 = await _prgTypeService.GetProgramTypeByIdAsync(prgTypeId);

            if (prgType1 == null)
                return NotFound();

            return Ok(prgType1);
        }

        [HttpPost(ApiRoutes.ProgramType.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProgramTypeRequest prgTypeRequest)
        {
            var newId = Guid.NewGuid();
            var prgType1 = new ProgramTypeTable
            {

                PrgTypeId = newId,
                PrgId = prgTypeRequest.PrgID,
                TypeID = prgTypeRequest.TypeId
                
            };
            
            await _prgTypeService.CreateProgramTypeAsync(prgType1);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.ProgramType.Get.Replace("{prgTypeId}", prgType1.PrgTypeId.ToString());

            var response = new CommonResponse { Id = prgType1.TypeID};
            return Created(locationUri, response);
        }
    }
}