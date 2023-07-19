namespace keepr.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0;

  public AccountController(AccountService accountService, Auth0Provider auth0)
  {
    _accountService = accountService;
    _auth0 = auth0;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("vaults")]
  [Authorize]
  public async Task<ActionResult<List<Vault>>>getMyVaults(string userId){
    try{
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _accountService.getMyVaults(userInfo.Id);
      return Ok(vaults);
    } catch (Exception e){
      return BadRequest(e.Message);
    }
  }
  [HttpPut]
  [Authorize]
  public async Task<ActionResult<Account>> updateAccount([FromBody] Account updateData){
    try{
        Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
        Account account = _accountService.Edit(updateData, userInfo.Email);
        return Ok(account);
    } catch (Exception e){
        return BadRequest(e.Message);
    }
  }
}
