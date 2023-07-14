import { AppState } from "../AppState.js";
import { Account } from "../models/Account.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Keep } from "../models/Keep.js";

class KeepsService{

   async getAllKeeps(){
      const res = await api.get('api/keeps');
      AppState.keeps = res.data.map(k => new Keep(k));
      logger.log("Res.Data Keeps", res.data);
      logger.log("AppState Keeps",AppState.keeps);
   }

   async createKeep(keepData){
      const res = await api.post('api/keeps', keepData);
      AppState.keeps.push(new Keep(res.data));
      logger.log("Creating keep", keepData);
   }

   // async createRecipe(recipeData){
   //    const res = await api.post('api/recipes', recipeData);
   //    AppState.recipes.push(new Recipe(res.data));
   //    logger.log("Creating recipe", recipeData);
   // }
}

export const keepsService = new KeepsService();