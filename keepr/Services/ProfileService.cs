namespace keepr.Services;

public class ProfileService
{
   private readonly ProfileRepository _repo;
   public ProfileService(ProfileRepository repo)
   {
      _repo = repo;
   }

   internal List<Keep> getKeepsByProfileId(string profileId)
   {
      List<Keep> keeps = _repo.getKeepsByProfileId(profileId);
      return keeps;
   }

   internal object getProfileById(string profileId)
   {
      return _repo.getProfileById(profileId);
   }
}

