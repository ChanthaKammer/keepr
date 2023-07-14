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
}

//   public int Id { get; set; }
//    public string CreatorId{get;set;}
//    public string Name {get; set;}
//    public string Description {get; set;}
//    public string Img {get; set;}
//    public bool isPrivate {get;set;}
//    public Account Creator{get;set;}