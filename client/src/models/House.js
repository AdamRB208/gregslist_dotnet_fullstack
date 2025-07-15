export class House {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.sqft = data.sqft
    this.bedrooms = data.bedrooms
    this.bathrooms = data.bathrooms
    this.imgUrl = data.imgUrl
    this.description = data.description
    this.price = data.price
    this.year = data.year
    this.levels = data.levels
  }
}