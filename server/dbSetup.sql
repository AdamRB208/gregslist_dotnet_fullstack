CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

SELECT * FROM accounts;

-- CARS SECTION STARTS HERE!!!!

CREATE TABLE cars (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    make TINYTEXT NOT NULL,
    model TINYTEXT NOT NULL,
    year INT UNSIGNED NOT NULL,
    color TINYTEXT NOT NULL,
    price MEDIUMINT UNSIGNED NOT NULL,
    mileage MEDIUMINT UNSIGNED NOT NULL,
    engine_type ENUM(
        '4 cylinder',
        'v6',
        'v8',
        'v10',
        'v12',
        'Diesel'
    ),
    img_url TEXT NOT NULL,
    has_clean_title BOOLEAN NOT NULL DEFAULT true,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO
    cars (
        make,
        model,
        year,
        color,
        price,
        mileage,
        engine_type,
        img_url,
        has_clean_title,
        creator_id
    )
VALUES (
        'porsche',
        '911 Turbo',
        '2024',
        'Black',
        '210000',
        '4000',
        'v8',
        'https://images.unsplash.com/photo-1580274455191-1c62238fa333?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8cG9yc2NoZXxlbnwwfHwwfHx8MA%3D%3D',
        true,
        '67e592b83f3192a0a5480d98'
    );

SELECT * FROM cars;

SELECT cars.*, accounts.*
FROM cars
    INNER JOIN accounts ON accounts.id = cars.creator_id;

SELECT cars.*, accounts.*
FROM cars
    INNER JOIN accounts ON accounts.id = cars.creator_id
WHERE
    cars.id = 1;

UPDATE cars
SET
    make = "porsche",
    model = "911 Turbo"
WHERE
    id = 1
LIMIT 1;
-- HOUSE SECTION STARTS HERE!!!!

CREATE TABLE houses (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    sqft INT NOT NULL,
    bedrooms INT NOT NULL,
    bathrooms DOUBLE NOT NULL,
    imgUrl VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    price INT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    year INT UNSIGNED NOT NULL,
    levels INT NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO
    houses (
        sqft,
        bedrooms,
        bathrooms,
        imgUrl,
        description,
        price,
        year,
        levels,
        creator_id
    )
VALUES (
        1650,
        3,
        2.5,
        "https://media.istockphoto.com/id/168532965/photo/exterior-of-modern-home.webp?a=1&b=1&s=612x612&w=0&k=20&c=yiQRWjQ1akQO-MJS0Wzx9X4TOE4Hz4mBxZDNOuB1wDg=",
        "A mid century home built in 1970",
        200000,
        1970,
        1,
        "67e592b83f3192a0a5480d98"
    );

SELECT * FROM houses;

SELECT houses.*, accounts.*
FROM houses
    JOIN accounts ON houses.creator_id = accounts.id;