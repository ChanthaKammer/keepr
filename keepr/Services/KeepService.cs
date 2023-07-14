namespace keepr.Services;

public class KeepService{
   private readonly KeepsRepository _repo;

   public KeepService(KeepsRepository repo){
      _repo = repo;
   }

   internal List<Keep> getAllKeeps(){
      List<Keep> keeps = _repo.getAllKeeps();
      return keeps;
   }

   internal Keep createKeep(Keep keepData){
      Keep keep = _repo.createKeep(keepData);
      return keep;
   }
}