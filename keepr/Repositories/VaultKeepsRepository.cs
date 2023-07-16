namespace keepr.Repositories;

public class VaultKeepsRepository{
   private readonly IDbConnection _db;

   public VaultKeepsRepository(IDbConnection db){
      _db = db;
   }

   // internal List<VaultKeep> getAllKeeps(){
   //    string sql =@"
   //    SELECT vk.*,
   //    creator.*

   //    FROM vaultkeeps vk
   //    JOIN accounts creator on vk.creatorId = creator.id";
   //    List<Keep> keeps = _db.Query<Keep, Account, Keep>
   //    (sql, (keep, creator) => {
   //          keep.Creator = creator;
   //          return keep;
   //    }).ToList();
   //    return keeps;
   // }

   internal VaultKeep createVaultKeep(VaultKeep vaultKeepData){
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, keepId, creatorId)
      VALUES
      (@vaultId, @keepId, @creatorId);

      SELECT * FROM vaultkeeps WHERE id = LAST_INSERT_ID()
      ;";

      VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
      return vaultKeep;
   }

   internal VaultKeep getById(int vaultKeepId)
   {
      string sql = @"
      SELECT vk.*
      FROM vaultkeeps vk 
      WHERE vk.id = @vaultKeepId;
      ";
      VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepId).FirstOrDefault();
      return vaultKeep;
   }
}

