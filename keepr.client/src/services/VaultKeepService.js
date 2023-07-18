import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { VaultKeep } from "../models/VaultKeep.js";

class VaultKeepService{
   async createVaultKeep(vaultKeepData){
      const res = await api.post('api/vaultkeeps', vaultKeepData);
   }
   async deleteVaultKeep(vaultKeepId){
      const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`);
   }
}

export const vaultKeepService = new VaultKeepService();