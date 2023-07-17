namespace keepr.Controllers;

[ApiController]
[Route("api/vaultkeeps")]

public class VaultKeepsController : ControllerBase{
   private readonly Auth0Provider _auth0;
   private readonly VaultKeepService _vaultKeepService;

   public VaultKeepsController(Auth0Provider auth0, VaultKeepService vaultKeepService){
      _auth0 = auth0;
      _vaultKeepService = vaultKeepService;
   }

   [HttpPost]
   [Authorize]
   public async Task<ActionResult<VaultKeep>> createVaultKeep([FromBody] VaultKeep vaultKeepData){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         vaultKeepData.CreatorId = userInfo.Id;
         VaultKeep vaultKeep = _vaultKeepService.createVaultKeep(vaultKeepData, userInfo.Id);
         return Ok(vaultKeep);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
   [HttpDelete("{vaultKeepId}")]
   [Authorize]
   public async Task<ActionResult<VaultKeep>> DeleteVaultKeep(int vaultKeepId){
      try {
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         VaultKeep vaultKeep = _vaultKeepService.DeleteVaultKeep(vaultKeepId, userInfo.Id);
         return Ok(vaultKeep);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }
}