import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  keeps: [],
  activeKeep: null,
  vaults: [],
  myVaults: [],
  activeVault: {},
  activeVaultKeeps: [],
  activeProfile: {},
  activeProfileKeeps: [],
  activeVaultKeepId: 0,
  activeProfileVaults: [],
  fakeVaults: ['Sports', 'Food', 'Art', 'Space', 'Gaming', 'Golf', 'Climbing', 'Astronomy', 'Tennis']
})
