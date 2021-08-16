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
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet(ApiRoutes.Type.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeService.GetTypeAsync());
        }

        [HttpPut(ApiRoutes.Type.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid typeId, [FromBody] UpdateTypeRequest request)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(programId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/

            var type1 = await _typeService.GetTypeByIdAsync(typeId);
            type1.TypeName = request.TypeName;
      

            var updated = await _typeService.UpdateTypeAsync(type1);

            if(updated)
                return Ok(type1);

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Type.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid typeId)
        {
            /*var userOwnsProgram = await _programService.UserOwnsProgramAsync(ProgramId, HttpContext.GetUserId());

            if (!userOwnsProgram)
            {
                return BadRequest(new {error = "You do not own this Program"});
            }*/
            
            var deleted = await _typeService.DeleteTypeAsync(typeId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Type.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid typeId)
        {
            var type1 = await _typeService.GetTypeByIdAsync(typeId);

            if (type1 == null)
                return NotFound();

            return Ok(type1);
        }

        [HttpPost(ApiRoutes.Type.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTypeRequest typeRequest)
        {
            var newId = Guid.NewGuid();
            var type1 = new Types
            {
                TypeID = newId   ,
                TypeName = typeRequest.TypeName
            };
            
            await _typeService.CreateTypeAsync(type1);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Type.Get.Replace("{typeId}", type1.TypeID.ToString());

            var response = new CommonResponse { Id = type1.TypeID};
            return Created(locationUri, response);
        }
    }
}