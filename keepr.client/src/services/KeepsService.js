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

   
   async getKeepById(keepId){
      const res = await api.get('api/keeps/' + keepId);
      AppState.activeKeep = new Keep(res.data);
      logger.log(AppState.activeKeep);
   }

   async editKeep(keepId, keepData){
      const res = await api.put(`api/keeps/${keepId}` + keepData)
   }
   async deleteKeep(keepId){
      const res = await api.delete('api/keeps/' + keepId)
      console.log("Deleted keep", keepId)
      AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
   }
}

export const keepsService = new KeepsService();