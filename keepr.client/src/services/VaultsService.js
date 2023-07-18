import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "../models/Vault.js";
import { VaultKeep } from "../models/VaultKeep.js"
import { Keep } from "../models/Keep.js";

class VaultsService{

   async getVaultById(vaultId){
      const res = await api.get('/api/vaults/' + vaultId);
      AppState.activeVault = new Vault(res.data);
      // logger.log(AppState.activeVault);
   }
   async getAllVaults(){
      const res = await api.get('api/vaults');
      AppState.vaults = res.data.map(v => new Vault(v));
      logger.log("Res.Data Vaults", res.data);
      logger.log("AppState Vaults",AppState.vaults);
   }

   async editVault(vaultId, vaultData){
      const res = await api.put('api/vaults/' + vaultId, vaultData)
   }

   async deleteVault(vaultId){
      const res = await api.delete('api/vaults' + vaultId)
   }

   async getVaultKeeps(vaultId){
      const res = await api.get('api/vaults/'+ vaultId + '/keeps')
      logger.log(res.data)
      AppState.activeVaultKeeps = res.data.map(k => new Keep(k));
      logger.log(AppState.activeVaultKeeps)
   }

   async createVault(vaultData){
      const res = await api.post('api/vaults', vaultData);
      AppState.vaults.push(new Vault(res.data));
      logger.log("Creating Vault", vaultData);
   }
   
}

export const vaultsService = new VaultsService();