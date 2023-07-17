namespace keepr.Repositories;

public class VaultsRepository{
   private readonly IDbConnection _db;

   public VaultsRepository(IDbConnection db){
      _db = db;
   }

   internal Vault createVault(Vault vaultData){
      string sql = @"
      INSERT INTO vaults
      (name, description, img, isPrivate, creatorId)
      VALUES 
      (@name, @description, @img, @isPrivate, @creatorId);

      SELECT vault.*,
      creator.*

      FROM vaults vault
      JOIN accounts creator ON vault.creatorId = creator.id
      WHERE vault.id = LAST_INSERT_ID()
      ;";

      Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) => {
         vault.Creator = creator;
         return vault;
      }, vaultData).FirstOrDefault();
      return vault;
   }

   internal int deleteVault(int vaultId)
   {
      string sql = @"
      DELETE FROM vaults WHERE id = @vaultId LIMIT 1;
      ";
      int rows = _db.Execute(sql, new {vaultId});
      return rows;
   }

   internal void editVault(Vault vault)
   {
      string sql = @"
      UPDATE vaults
      SET
      name = @name,
      description = @description,
      img = @img,
      isPrivate = @isPrivate
      WHERE id = @id
      ";
      _db.Execute(sql, vault);
   }

   internal Vault getById(int vaultId){
      string sql = @"
      SELECT vault.*,
      creator.*

      FROM vaults vault
      JOIN accounts creator ON vault.creatorId = creator.Id
      WHERE vault.id = @vaultId
      ";
      Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) => {
         vault.Creator = creator;
         return vault;
      }, new {vaultId}).FirstOrDefault();
      return vault;
   }

   internal List<KeepInVault> getVaultKeepsByVaultId(int vaultId)
   {
      var sql = @"
      SELECT
      vk.*,
      keep.*,
      acc.*
      FROM keeps keep
      JOIN vaultkeeps vk ON vk.keepId = keep.Id
      JOIN accounts acc ON keep.creatorId = acc.Id
      WHERE vk.vaultId = @vaultId
      ;";

      List<KeepInVault> vaultKeeps = _db.Query<VaultKeep, KeepInVault, Account, KeepInVault>(sql,(vaultKeep, keep, acc) =>
      {
         keep.Id = vaultKeep.KeepId;
         keep.Creator = acc;
         keep.VaultKeepId = vaultKeep.Id;
         return keep;
      }, new {vaultId}).ToList();
      return vaultKeeps;
   }
}

//   public int Id { get; set; }
//    public string CreatorId{get;set;}
//    public string Name {get; set;}
//    public string Description {get; set;}
//    public string Img {get; set;}
//    public bool isPrivate {get;set;}
//    public Account Creator{get;set;}