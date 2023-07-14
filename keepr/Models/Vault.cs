namespace keepr.Models;

public class Vault{
   public int Id { get; set; }
   public string CreatorId{get;set;}
   public string Name {get; set;}
   public string Description {get; set;}
   public string Img {get; set;}
   public bool isPrivate {get;set;}
   public Account Creator{get;set;}
}




// CREATE TABLE IF NOT EXISTS vaults(
//   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
//   creatorId VARCHAR(255) COMMENT 'Creator Id',
//   name VarCHAR(500) COMMENT 'Name',
//   description TEXT COMMENT 'Description',
//   img VARCHAR(500) Comment 'Img',
//   isPrivate BOOLEAN DEFAULT false Comment 'Is Private',
//   FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
// ) default charset utf8 COMMENT '';