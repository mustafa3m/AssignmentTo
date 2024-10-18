-- 01_dbCreate.sql – Create the Database
CREATE DATABASE SuperheroesDb;


-- Switch to the SuperheroesDb database
USE SuperheroesDb;


-- 02_tableCreate.sql – Create Tables

-- Create the Superhero table
CREATE TABLE Superhero (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incremented primary key
    Name NVARCHAR(100) NOT NULL,       -- Name of the superhero
    Alias NVARCHAR(100),               -- Alias of the superhero
    Origin NVARCHAR(100)               -- Origin of the superhero
);


-- Create the Assistant table
CREATE TABLE Assistant (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incremented primary key
    Name NVARCHAR(100) NOT NULL        -- Name of the assistant
);


-- Create the Power table
CREATE TABLE Power (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incremented primary key
    Name NVARCHAR(100) NOT NULL,       -- Name of the power
    Description NVARCHAR(255)          -- Description of the power
);


-- 03_relationshipSuperheroAssistant.sql – Set up Superhero-Assistant Relationship

-- Add SuperheroId to the Assistant table and create the foreign key relationship
ALTER TABLE Assistant
ADD SuperheroId INT;

ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant_Superhero
FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id);


-- 04_relationshipSuperheroPower.sql – Set up Superhero-Power Many-to-Many Relationship

-- Create the linking table to associate Superheroes and Powers
CREATE TABLE SuperheroPower (
    SuperheroId INT,                   -- Foreign key to Superhero
    PowerId INT,                       -- Foreign key to Power
    PRIMARY KEY (SuperheroId, PowerId), -- Composite primary key
    CONSTRAINT FK_SuperheroPower_Superhero FOREIGN KEY (SuperheroId) REFERENCES Superhero(Id),
    CONSTRAINT FK_SuperheroPower_Power FOREIGN KEY (PowerId) REFERENCES Power(Id)
);


-- 05_insertSuperheroes.sql – Insert Superheroes

-- Insert superheroes into the Superhero table
INSERT INTO Superhero (Name, Alias, Origin)
VALUES 
('Clark Kent', 'Superman', 'Krypton'),
('Bruce Wayne', 'Batman', 'Gotham'),
('Diana Prince', 'Wonder Woman', 'Themyscira');


-- 06_insertAssistants.sql – Insert Assistants

-- Insert assistants into the Assistant table, linking them to Superheroes
INSERT INTO Assistant (Name, SuperheroId)
VALUES 
('Jimmy Olsen', 1),  -- Superman's assistant
('Alfred Pennyworth', 2),  -- Batman's assistant
('Etta Candy', 3);  -- Wonder Woman's assistant


-- 07_powers.sql – Insert Powers and Link to Superheroes

-- Insert powers into the Power table
INSERT INTO Power (Name, Description)
VALUES 
('Super Strength', 'Ability to exhibit great physical strength'),
('Flight', 'Ability to fly'),
('Genius Intellect', 'Extraordinary intelligence and problem-solving'),
('Combat Skills', 'Expert in hand-to-hand combat');


-- Associate powers with superheroes (many-to-many relationship)
INSERT INTO SuperheroPower (SuperheroId, PowerId)
VALUES 
(1, 1),  -- Superman has Super Strength
(1, 2),  -- Superman can Fly
(2, 3),  -- Batman has Genius Intellect
(3, 1),  -- Wonder Woman has Super Strength
(3, 4);  -- Wonder Woman has Combat Skills


-- 08_updateSuperhero.sql – Update a Superhero’s Name

-- Update the name of a superhero
UPDATE Superhero
SET Name = 'Kal-El'
WHERE Id = 1;  -- Update Superman's name to his Kryptonian name


-- 09_deleteAssistant.sql – Delete an Assistant

-- Delete an assistant by name
DELETE FROM Assistant
WHERE Name = 'Jimmy Olsen';  -- Remove Superman's assistant

