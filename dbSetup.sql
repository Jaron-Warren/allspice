CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE recipes(
  id int AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title varchar(255) COMMENT 'recipe title',
  description VARCHAR(255) COMMENT 'description of recipe',
  cookTime int COMMENT 'cooking time',
  prepTime int COMMENT 'preparation time',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account id of creator',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8;
CREATE TABLE steps (
  id int AUTO_INCREMENT NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  body varchar(255) COMMENT 'body of the step',
  recipeId int NOT NULL COMMENT 'cooking time',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account id of creator',
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8;
INSERT INTO
  recipes (
    Title,
    Description,
    CookTime,
    PrepTime
  )
VALUES
  (
    "cookies",
    "This has everything on it",
    20,
    30
  );
DROP TABLE accounts