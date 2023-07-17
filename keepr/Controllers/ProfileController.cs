namespace keepr.Controllers;

[ApiController]
[Route("api/profiles")]
public class ProfileController : ControllerBase
{
   private readonly ProfileService _profileService;
   private readonly Auth0Provider _auth0Provider;

   public ProfileController(ProfileService profileService, Auth0Provider auth0Provider)
   {
      _profileService = profileService;
      _auth0Provider = auth0Provider;
   }

   [HttpGet("{profileId}")]
   public async Task<ActionResult<Profile>> getProfileByID(string profileId)
   {
      try
      {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_profileService.getProfileById(profileId));
      }
      catch (Exception e)
      {
      return BadRequest(e.Message);
      }
   }
   [HttpGet("{profileId}/keeps")]
   public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId){
      try {
         List<Keep> keeps = _profileService.getKeepsByProfileId(profileId);
         return Ok(keeps);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpGet("{profileId}/vaults")]
   public ActionResult<List<Vault>> GetVaultsByProfileId(string profileId){
      try{
         List<Vault> vaults = _profileService.getVaultsByProfileId(profileId);
         return Ok(vaults);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}
