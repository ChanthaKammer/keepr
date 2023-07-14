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
   // string sql = @"
   //    INSERT INTO recipes
   //    (title, instructions, img, category, archived, creatorId)
   //    VALUES
   //    (@title, @instructions, @img, @category, @archived, @creatorId);

   //    SELECT rcp.*,
   //    creator.*

   //    FROM recipes rcp
   //    JOIN accounts creator ON rcp.creatorId = creator.id
   //    WHERE rcp.id = LAST_INSERT_ID();
   //    ";

}

   // internal List<Recipe> getAllRecipes()
   // {
   //    string sql = @"
   //    SELECT rcp.*,
   //    creator.*

   //    FROM recipes rcp
   //    JOIN accounts creator ON rcp.creatorId = creator.id";
   //    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) => {
   //       recipe.Creator = creator;
   //       return recipe;
   //    }).ToList();
   //    return recipes;
   // }