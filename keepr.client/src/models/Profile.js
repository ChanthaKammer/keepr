export class Profile {
   constructor(data) {
      this.id = data.id
      this.email = data.email
      this.picture = data.picture 
      this.name = data.name
      this.coverImg = data.coverImg || 'https://hips.hearstapps.com/hmg-prod/images/2023-maza-mx-5-miata-102-1669758443.jpg';
   }
}
