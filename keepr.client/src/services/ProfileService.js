import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Profile } from "../models/Profile.js";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { Vault } from "../models/Vault.js";

class ProfileService{
   async getProfileById(profileId){
      const res = await api.get(`api/profiles/${profileId}`);
      AppState.activeProfile = new Profile(res.data);
      logger.log("Getting profile", profileId)
   }

   async getProfileKeeps(profileId){
      debugger
      const res = await api.get(`api/profiles/${profileId}/keeps`);
      AppState.activeProfileKeeps = res.data.map(k => new Keep(k))
      logger.log("Getting profile keeps", res.data)
   }
   async getProfileVaults(profileId){
      const res = await api.get(`api/profiles/${profileId}/vaults`);
      AppState.activeProfileVaults = res.data.map(v => new Vault(v))
      logger.log("Getting profile vaults", profileId)
   }
}

export const profileService = new ProfileService();