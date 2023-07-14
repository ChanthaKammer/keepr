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

   internal Keep getById(int keepId){
      Keep keep = _repo.getById(keepId);
      if(keep == null) throw new Exception($"No keep found with id: {keepId}");
      keep.Views++;
      _repo.addView(keep);
      return keep;
   }

   internal Keep updateKeep(Keep updateData, string userId){
      Keep original = getById(updateData.Id);
      if(original.CreatorId != userId){
         throw new Exception($"You are not allowed to delete recipe: {updateData.Id}");
      }
      original.Name = updateData.Name != null ? updateData.Name : original.Name;
      original.Description = updateData.Description != null ? updateData.Description : original.Description;
      original.Img = updateData.Img != null ? updateData.Img : original.Img;
      if(original.Views > 0){
         original.Views--;
      } 
      _repo.editKeep(original);
      return original;
   }

   internal Keep DeleteKeep(int keepId, string userId){
      Keep keep = getById(keepId);
      if(keep.CreatorId != userId){
         throw new Exception($"You are not allowed to delete keep: {keepId}");
      }
      int rows = _repo.DeleteKeep(keepId);
      if(rows > 1) throw new Exception("Too many rows deleted, check db.");
      return keep;
   }
}