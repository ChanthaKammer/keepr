CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

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

SHOW ENGINE INNODB STATUS;


