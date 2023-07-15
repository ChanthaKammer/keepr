import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
import { Vault } from "../models/Vault.js";

class VaultsService{

   async getAllVaults(){
      const res = await api.get('api/vaults');
      AppState.vaults = res.data.map(v => new Vault(v));
      logger.log("Res.Data Vaults", res.data);
      logger.log("AppState Vaults",AppState.vaults);
   }

   async createVault(vaultData){
      const res = await api.post('api/vaults', vaultData);
      AppState.vaults.push(new Vault(res.data));
      logger.log("Creating Vault", vaultData);
   }
   
}

export const vaultsService = new VaultsService();