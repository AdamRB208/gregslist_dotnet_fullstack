export class Account {
  /**
   * @typedef AccountData
   * @property {string} id
   * @property {string} createdAt
   * @property {string} updatedAt
   * @property {string} email
   * @property {string} name
   * @property {string} picture
   * 
   * @param {AccountData} data
   */
  constructor(data) {
    this.id = data.id
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.email = data.email
    this.name = data.name
    this.picture = data.picture
    // TODO add additional properties if needed
  }
}
