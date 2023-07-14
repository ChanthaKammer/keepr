namespace keepr.Controllers;

[ApiController]
[Route("api/vaults")]

public class VaultsController : ControllerBase
{
   private readonly Auth0Provider _auth0;
   private readonly VaultService _vaultService;

   public VaultsController(Auth0Provider auth0, VaultService vaultService){
      _auth0 = auth0;
      _vaultService = vaultService;
   }

   [HttpGet("{vaultId}")]

   public async Task<ActionResult<Vault>> getVaultById(int vaultId){
      try{
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         Vault vault = _vaultService.getById(vaultId, userInfo?.Id);
         return Ok(vault);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

   [HttpPost]
   [Authorize]
   public async Task<ActionResult<Vault>> createVault([FromBody] Vault vaultData){
      try{
         Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
         vaultData.CreatorId = userInfo.Id;
         Vault vault = _vaultService.createVault(vaultData);
         return Ok(vault);
      } catch (Exception e){
         return BadRequest(e.Message);
      }
   }

}