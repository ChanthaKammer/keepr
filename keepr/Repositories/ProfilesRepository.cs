namespace keepr.Repositories;

public class ProfileRepository
{
   private readonly IDbConnection _db;

   public ProfileRepository(IDbConnection db){
      _db = db;
   }

   internal List<Keep> getKeepsByProfileId(string profileId)
   {
      string sql = @"
         SELECT *
         FROM keeps keep
         JOIN accounts acc on acc.id = keep.creatorId
         WHERE keep.creatorId = @profileId;";
      List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
         keep.CreatorId = profile.Id;
         return keep;
      }, new {profileId}).ToList();
      return keeps;
   }

   internal List<Vault> getVaultsByProfileId(string profileId){
      string sql = @"
      SELECT *
      FROM vaults vault
      JOIN accounts acc on acc.id = vault.creatorId
      WHERE vault.creatorId = @profileId;";
      List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => {
         vault.CreatorId = profile.Id;
         return vault;
      }, new {profileId}).ToList();
      return vaults;
   }

   internal Profile getProfileById(string profileId)
   {
      string sql = @"
         SELECT * FROM accounts WHERE id = @profileId
      ";
      return _db.QueryFirstOrDefault<Profile>(sql, new {profileId});
   }
}