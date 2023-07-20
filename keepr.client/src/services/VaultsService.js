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
   
   async togglePrivate(vaultId){
      // const res = await api.put('api/vaults' + vaultId, {params: {}})
      const vault = AppState.activeVault;
      const res = await api.put('api/vaults/' + vaultId, vault)
      logger.log("toggling private",vault);
   }

   async deleteVault(vaultId){
      const res = await api.delete('api/vaults/' + vaultId)
   }

   async getVaultKeeps(vaultId){
      const res = await api.get('api/vaults/'+ vaultId + '/keeps')
      logger.log("getvaultkeep",res.data)
      AppState.activeVaultKeeps = res.data.map(k => new Keep(k));
      logger.log("Active Vault Keeps", AppState.activeVaultKeeps)
   }

   async createVault(vaultData){
      const res = await api.post('api/vaults', vaultData);
      AppState.vaults.push(new Vault(res.data));
      logger.log("Creating Vault", vaultData);
   }
   
}

export const vaultsService = new VaultsService();