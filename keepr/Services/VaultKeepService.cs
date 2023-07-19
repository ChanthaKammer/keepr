namespace keepr.Services;

public class VaultKeepService{
   private readonly VaultKeepsRepository  _repo;
   private readonly VaultService _vaultService;

   private readonly KeepService _keepService;

   public VaultKeepService(VaultKeepsRepository repo, VaultService vaultService, KeepService keepService){
      _repo = repo;
      _vaultService = vaultService;
      _keepService = keepService;
   }

   internal VaultKeep getById(int vaultKeepId){
      VaultKeep vaultKeep = _repo.getById(vaultKeepId);
      if(vaultKeep == null) throw new Exception($"No VaultKeep found with id: ${vaultKeepId}");
      return vaultKeep;
   }

   internal VaultKeep createVaultKeep(VaultKeep vaultKeepData, string userId){
      if(userId == null){
         throw new Exception("You are not allowed to create a vaultkeep!");
      }
      Vault vault = _vaultService.getById(vaultKeepData.VaultId, userId);
      if(vault.CreatorId != userId){
         throw new Exception("You are not allowed to create a vaultkeep in this vault");
      }
      VaultKeep vaultKeep = _repo.createVaultKeep(vaultKeepData);
      // Keep keep = _keepService.getById(vaultKeep.KeepId);
      // keep.Kept++;
      // _keepService.updateKeep(keep, userId);
      return vaultKeep;
   }

   internal VaultKeep DeleteVaultKeep(int vaultKeepId, string userId)
   {
      VaultKeep vaultKeep = getById(vaultKeepId);
      if(vaultKeep.CreatorId != userId){
         throw new Exception($"You are not allowed to delete VaultKeep: {vaultKeepId}");
      }
      int rows = _repo.DeleteVaultKeep(vaultKeepId);
      if(rows > 1) throw new Exception("Too many rows deleted, check db.");
      return vaultKeep;
   }
}