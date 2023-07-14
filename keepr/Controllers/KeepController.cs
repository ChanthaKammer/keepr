namespace keepr.Controllers;

[ApiController]
[Route("api/keeps")]

public class KeepController : ControllerBase
{
   private readonly Auth0Provider _auth0;
   private readonly KeepService _keepService;

   public KeepController(Auth0Provider auth0,KeepService keepservice){
      _auth0 = auth0;
      _keepService = keepservice;
   }

   [HttpGet]
   public ActionResult<List<Keep>> GetAllKeeps(){
      try {
         List<Keep> keeps = _keepService.getAllKeeps();
         return Ok(keeps);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpGet("{keepId}")]
   public ActionResult<Keep> GetById(int keepId){
      try {
         Keep keep = _keepService.getById(keepId);
         return Ok(keep);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }


   [HttpPost]
   [Authorize]
   public async Task<ActionResult<Keep>> createKeep([FromBody] Keep keepData){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         keepData.CreatorId = userInfo.Id;
         Keep keep = _keepService.createKeep(keepData);
         return Ok(keep);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   } 

   [HttpPut("{keepId}")]
   [Authorize]
   public async Task<ActionResult<Keep>> updateKeep(int keepId, [FromBody] Keep updateData){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         updateData.Id = keepId;
         Keep keep = _keepService.updateKeep(updateData, userInfo.Id);
         return Ok(keep);
      } catch (Exception e) {
         return BadRequest(e.Message);
      }
   }

   [HttpDelete("{keepId}")]
   [Authorize]
   public async Task<ActionResult<Keep>> DeleteKeep(int keepId){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         Keep keep = _keepService.DeleteKeep(keepId, userInfo.Id);
         return Ok(keep);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}

