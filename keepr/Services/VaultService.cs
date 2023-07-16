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
      if(vaultData.CreatorId != userId){
         throw new Exception($"You are not allowed to delete the vault: ${vaultData.Id}");
      }
      original.Name = vaultData.Name != null ? vaultData.Name : original.Name;
      original.Description = vaultData.Description != null ? vaultData.Description : original.Description;
      original.Img = vaultData.Img != null ? vaultData.Img : original.Img;
      original.isPrivate = vaultData.isPrivate != null ? vaultData.isPrivate : original.isPrivate;
      _repo.editVault(original);
      return original;
   }
}

//PUBLIC AND PRIVATE CAN BE HANDLED IN ONE FUNCTION HERE LOGIC STAYS IN THE SERVICE