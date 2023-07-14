namespace keepr.Repositories;

public class KeepsRepository{
   private readonly IDbConnection _db;

   public KeepsRepository(IDbConnection db){
      _db = db;
   }

   internal List<Keep> getAllKeeps(){
      string sql =@"
      SELECT keep.*,
      creator.*

      FROM keeps keep
      JOIN accounts creator on keep.creatorId = creator.id";
      List<Keep> keeps = _db.Query<Keep, Account, Keep>
      (sql, (keep, creator) => {
            keep.Creator = creator;
            return keep;
      }).ToList();
      return keeps;
   }

   internal Keep createKeep(Keep keepData){
      string sql = @"
      INSERT INTO keeps
      (name, description, img, creatorId)
      VALUES
      (@name, @description, @img, @creatorId);

      SELECT keep.*,
      creator.*

      FROM keeps keep
      JOIN accounts creator ON keep.creatorId = creator.id
      WHERE keep.id = LAST_INSERT_ID()
      ;";

      Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) => {
         keep.Creator = creator;
         return keep;
      }, keepData).FirstOrDefault();
      return keep;
   }

   internal void editKeep(Keep keep){
      string sql = @"
      UPDATE keeps
      SET
      name = @name,
      description = @description,
      img = @img,
      views = @views
      WHERE id = @id
      ";
      _db.Execute(sql, keep);
   }

   internal Keep getById(int keepId){
      string sql = @"
      SELECT keep.*,
      creator.*

      FROM keeps keep
      JOIN accounts creator ON keep.creatorId = creator.Id
      WHERE keep.id = @keepId;
      ";
      Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) => {
         keep.Creator = creator;
         return keep;
      }, new { keepId }).FirstOrDefault();
      return keep;
   }

   internal void addView(Keep keep){
      string sql = @"
         UPDATE keeps
         SET views = @views
         WHERE id = @id;
      ";

      _db.Execute(sql, keep);
   }

   internal int DeleteKeep(int keepId)
   {
      string sql = @"DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
      int rows = _db.Execute(sql, new {keepId});
      return rows;
   }
}

