import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Car.js').Car []} user info from the database*/
  cars: [],
  /** @type {import('./models/Car.js').Car []} user info from the database*/
  activeCar: null,
  /** @type {import('./models/House.js').House []} user info from the database*/
  houses: [],
  /** @type {import('./models/House.js').House []} user info from the database*/
  activeHouse: null,
})

