export class Account {
  constructor(data) {
    this.id = data.id
    this.email = data.email
    this.name = data.name
    this.picture = data.picture
    // TODO add additional properties if needed
    this.coverImg = data.coverImg || 'https://hips.hearstapps.com/hmg-prod/images/2023-maza-mx-5-miata-102-1669758443.jpg';
  }
}
