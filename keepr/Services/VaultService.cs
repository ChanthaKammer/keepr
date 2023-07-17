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

   internal Vault updateVault(Vault vaultData, string userId){
      Vault original = getById(vaultData.Id, userId);
      if(original.CreatorId != userId){
         throw new Exception($"You are not allowed to edit the vault: {vaultData.Id}");
      }
      original.Name = vaultData.Name != null ? vaultData.Name : original.Name;
      original.Description = vaultData.Description != null ? vaultData.Description : original.Description;
      original.Img = vaultData.Img != null ? vaultData.Img : original.Img;
      original.isPrivate = vaultData.isPrivate;
      _repo.editVault(original);
      return original;
   }

   internal Vault deleteVault(int vaultId, string userId){
      Vault vault = getById(vaultId, userId);
      if(vault.CreatorId != userId){
         throw new Exception($"You are not allowed to delete vault: {vaultId}");
      }
      int rows = _repo.deleteVault(vaultId);
      if(rows > 1) throw new Exception("Too many rows deleted, check db");
      return vault;
   }
}

//PUBLIC AND PRIVATE CAN BE HANDLED IN ONE FUNCTION HERE LOGIC STAYS IN THE SERVICE