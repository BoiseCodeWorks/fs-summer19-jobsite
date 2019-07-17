USE jobsite;

-- CREATE TABLE contractors (
--     id INT AUTO_INCREMENT NOT NULL,
--     name VARCHAR(50) NOT NULL,
--     pricePerHour INT NOT NULL,
--     basePrice INT NOT NULL,
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE jobs (
--     id INT AUTO_INCREMENT NOT NULL,
--     type ENUM('yard/landscape', 'carpentry', 'mechanic', 'plumbing', 'other') NOT NULL,
--     createdAt DATE NOT NULL,
--     PRIMARY KEY (id)
-- );

-- ALTER TABLE jobs
-- ADD COLUMN location VARCHAR(150);

-- ALTER TABLE jobs CHANGE createdAt createdAt DATETIME;

-- INSERT INTO contractors (name, pricePerHour, basePrice)
--     VALUES ("Darryl", 75, 50),
--            ("Mark", 75, 50),
--            ("Jake", 75, 50),
--            ("Brooklyn", 85, 75);