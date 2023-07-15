namespace keepr.Models;

public class VaultKeep{
   public int Id {get;set;}
   public string CreatorId {get;set;}
   public int VaultId {get;set;}
   public int KeepId {get;set;}
}

// CREATE TABLE IF NOT EXISTS vaultkeeps(
//   id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
//   creatorId VARCHAR(255) COMMENT 'Creator Id',
//   vaultId INT NOT NULL,
//   keepId INT NOT NULL,
//   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
//   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
//   FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
//   FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
//   FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
// ) default charset utf8 COMMENT '';

// public class Vault{
//    public int Id { get; set; }
//    public string CreatorId{get;set;}
//    public string Name {get; set;}
//    public string Description {get; set;}
//    public string Img {get; set;}
//    public bool isPrivate {get;set;}
//    public Account Creator{get;set;}
// }