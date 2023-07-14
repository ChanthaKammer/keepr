namespace keepr.Services;

public class VaultService{
   private readonly VaultsRepository _repo;

   public VaultService(VaultsRepository repo){
      _repo = repo;
   }

   internal Vault createVault(Vault vaultData){
      Vault vault = _repo.createVault(vaultData);
      return vault;
   }

   internal Vault getById(int vaultId, string userId){
      Vault vault = _repo.getById(vaultId);
      if(vault == null) throw new Exception($"No vault found with id: {vaultId}");
      if(vault.CreatorId != userId && vault.isPrivate){
         throw new Exception($"You are not allowed to access this vault.");
      } else {
         return vault;
      } 
   }
}

//PUBLIC AND PRIVATE CAN BE HANDLED IN ONE FUNCTION HERE LOGIC STAYS IN THE SERVICE