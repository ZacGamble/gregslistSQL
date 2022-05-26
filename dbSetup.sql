CREATE TABLE IF NOT EXISTS accounts(
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

/*NOTE This next code block creates a "cars" table, these are all I need here*/

CREATE TABLE IF NOT EXISTS cars(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    color TEXT,
    make TEXT,
    model TEXT,
    year INT,
    price INT,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8;

/* GET ALL */

SELECT * FROM accounts;

SELECT * FROM cars;

/* POST */

INSERT INTO
    accounts (id, name)
VALUES
    ("zg123", "ZacGamble");

/*Post*/

INSERT INTO
    cars (make, model, year, price, creatorId)
VALUES
    ("Ford", "Ranger", 2006, 5000, "zg123");

/*PUT*/

UPDATE cars SET 