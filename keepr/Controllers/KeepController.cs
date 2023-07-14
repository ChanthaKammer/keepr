namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

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
}