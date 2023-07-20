CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  coverImg VARCHAR(255) COMMENT 'Cover Image'
) default charset utf8 COMMENT '';


ALTER TABLE accounts
ADD coverImg VARCHAR (255) COMMENT 'Cover Image';
SELECT * FROM accounts;

CREATE TABLE IF NOT EXISTS keeps(
      id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
      creatorId VARCHAR(255) COMMENT 'Creator Id',
      name VarCHAR(500) COMMENT 'Name',
      description TEXT COMMENT 'Description',
      img VARCHAR(500) Comment 'Img',
      views INT NOT NULL DEFAULT 0,
      kept INT NOT NULL DEFAULT 0,
      createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
      updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
      FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SELECT * FROM keeps;

INSERT INTO keeps
(name, description, img, creatorId)
VALUES
("Mazda Miata", "I can't believe this is a car.", "https://i.ytimg.com/vi/Z71tcJtgfN8/maxresdefault.jpg", "64a76eae48f84949dfd6247a");

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) COMMENT 'Creator Id',
  name VarCHAR(500) COMMENT 'Name',
  description TEXT COMMENT 'Description',
  img VARCHAR(500) Comment 'Img',
  isPrivate BOOLEAN DEFAULT false Comment 'Is Private',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaultkeeps(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) COMMENT 'Creator Id',
  vaultId INT NOT NULL,
  keepId INT NOT NULL,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SHOW ENGINE INNODB STATUS;


SELECT *
FROM keeps keep
WHERE keep.creatorId = '64a76eae48f84949dfd6247a';


SELECT 
keep.*,
COUNT(vk.keepId) AS kept,
creator.*
FROM keeps keep
LEFT JOIN vaultkeeps vk ON vk.KeepId = keep.id
JOIN accounts creator on keep.creatorId = creator.id
GROUP BY (keep.Id);

SELECT 
keep.*,
COUNT(vk.keepId) AS kept,
creator.*
FROM keeps keep
LEFT JOIN vaultkeeps vk ON vk.KeepId = keep.id
JOIN accounts creator ON keep.creatorId = creator.Id
WHERE keep.id = 265
GROUP BY (keep.Id);


-- VK GetById
SELECT vk.*,
COUNT(vk.keepId) AS kept
FROM vaultkeeps vk
LEFT JOIN keeps keep ON keep.Id = vk.KeepId
WHERE vk.id = 316
GROUP BY(vk.Id);

SELECT
vk.*,
COUNT(vk.keepId) AS kept,
keep.*,
acc.*
FROM keeps keep
LEFT JOIN vaultkeeps vk ON vk.keepId = keep.Id
JOIN accounts acc ON keep.creatorId = acc.Id
WHERE vk.vaultId = 313
GROUP BY(vk.Id)
