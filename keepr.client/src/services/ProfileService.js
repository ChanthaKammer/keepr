import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Profile } from "../models/Profile.js";
class ProfileService{
   async getProfileById(profileId){
      const res = await api.get(`api/profiles/${profileId}`);
      logger.log("Getting profile", profileId)
   }

   async getProfileKeeps(profileId){
      const res = await api.get(`api/profiles/${profileId}/keeps`);
      logger.log("Getting profile keeps", profileId)
   }
   async getProfileVaults(profileId){
      const res = await api.get(`api/profiles/${profileId}/vaults`);
      logger.log("Getting profile vaults", profileId)
   }
}

export const profileService = new ProfileService();