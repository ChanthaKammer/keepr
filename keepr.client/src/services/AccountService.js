import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { Vault } from '../models/Vault.js'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async editAccount(editable){
    const res =  await api.put('/account', editable)
    logger.log(editable)
    AppState.account = new Account(res.data)
  }
  async getAccountVaults(){
    const res = await api.get('/account/vaults')
    AppState.myVaults = res.data.map(v => new Vault(v));
    logger.log("Getting account vaults")
  }
}

export const accountService = new AccountService()
