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
         SELECT * FROM keeps
         WHERE creatorId = @profileId";
      List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => {
         keep.Creator = profile;
         return keep;
      }).ToList();
      return keeps;
   }

   internal Profile getProfileById(string profileId)
   {
      string sql = @"
         SELECT * FROM accounts WHERE id = @profileId
      ";
      return _db.QueryFirstOrDefault<Profile>(sql, new {profileId});
   }
}