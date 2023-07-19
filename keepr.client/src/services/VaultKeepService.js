import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { VaultKeep } from "../models/VaultKeep.js";

class VaultKeepService{
   async createVaultKeep(vaultId, keepId){
      // const res = await api.post('api/vaultkeeps', vaultKeepData);
      logger.log("Vault ", vaultId + "Keep", keepId)
      const res = await api.post('api/vaultkeeps', {
         "vaultId": vaultId,
         "keepId": keepId
      })
      logger.log(res.data)
   }
   async deleteVaultKeep(vaultKeepId){
      const res = await api.delete('api/vaultkeeps/' + vaultKeepId);
      // logger.log("Deleting Vaultkeep", vaultKeepId)
   }
}

export const vaultKeepService = new VaultKeepService();