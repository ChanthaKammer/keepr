export class Keep{
   constructor(data){
      this.id = data.id;
      this.name = data.name;
      this.description = data.description;
      this.img = data.img;
      this.views = data.views;
      this.creatorId = data.creatorId;
      this.kept = data.kept;
      this.creator = data.creator;
   }
}


// public class Keep {
//    public int Id { get; set; }
//    public string CreatorId{get;set;}
//    public string Name {get; set;}
//    public string Description {get; set;}
//    public string Img {get; set;}
//    public int Views {get;set;}

//    public int Kept {get; set;}
//    public Account Creator{get;set;}
// }

// public int Id {get;set;}
// public string Title {get;set;}
// public string Instructions {get;set;}
// public string Img {get;set;}
// public string Category {get;set;}

// public bool Archived {get;set;}
// public string CreatorId {get;set;}
// public Account Creator {get;set;}