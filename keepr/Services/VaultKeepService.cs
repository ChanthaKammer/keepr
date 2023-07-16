namespace keepr.Services;

public class VaultKeepService{
   private readonly VaultKeepsRepository  _repo;

   public VaultKeepService(VaultKeepsRepository repo){
      _repo = repo;
   }

   internal VaultKeep getById(int vaultKeepId){
      VaultKeep vaultKeep = _repo.getById(vaultKeepId);
      if(vaultKeep == null) throw new Exception($"No VaultKeep found with id: ${vaultKeepId}");
      return vaultKeep;
   }

   internal VaultKeep createVaultKeep(VaultKeep vaultKeepData){
      VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
      return vaultKeep;
   }

   internal VaultKeep DeleteVaultKeep(int vaultKeepId, string userId)
   {
      VaultKeep vaultKeep = getById(vaultKeepId);
      if(vaultKeep.CreatorId != userId){
         throw new Exception($"You are not allowed to delete VaultKeep: ${vaultKeepId}");
      }
      int rows = _repo.DeleteVaultKeep(vaultKeepId);
      if(rows > 1) throw new Exception("Too many rows deleted, check db.");
      return vaultKeep;
   }

   // internal Vault getById(int vaultId, string userId){
   //    Vault vault = _repo.getById(vaultId);
   //    if(vault == null) throw new Exception($"No vault found with id: {vaultId}");
   //    if(vault.CreatorId != userId && vault.isPrivate){
   //       throw new Exception($"You are not allowed to access this vault.");
   //    } else {
   //       return vault;
   //    } 
   // }
}

//PUBLIC AND PRIVATE CAN BE HANDLED IN ONE FUNCTION HERE LOGIC STAYS IN THE SERVICE