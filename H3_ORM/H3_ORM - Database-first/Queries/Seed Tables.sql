-- Insert made-up persons into the "Persons" table
INSERT INTO Persons (Age, Name)
VALUES
    (40, 'Alice Green'),
    (35, 'Bob Smith'),
    (28, 'Catherine White'),
    (52, 'David Johnson'),
    (44, 'Ella Brown'),
    (29, 'Frank Davis'),
    (36, 'Grace Lee'),
    (47, 'Henry Wilson'),
    (33, 'Isabella Martinez'),
    (42, 'John Anderson'),
    (31, 'Kate Jackson'),
    (49, 'Leo Garcia');


-- Insert hardcoded authors into the "Authors" table
INSERT INTO Authors (PersonId, Genre, Biography)
VALUES
    (1, 'Romance', 'A passionate storyteller weaving tales of love and emotion.'),
    (2, 'Fiction', 'An imaginative author crafting stories that resonate with readers.'),
    (3, 'Science Fiction', 'A visionary writer exploring the frontiers of science and fiction.'),
    (4, 'Mystery', 'A master of suspense who keeps readers on the edge of their seats.'),
    (5, 'Fantasy', 'A creator of enchanting worlds filled with magic and adventure.'),
    (6, 'Adventure', 'An intrepid author taking readers on thrilling journeys to the unknown.'),
    (7, 'Thriller', 'A pulse-pounding writer of heart-stopping stories that grip the mind.'),
    (8, 'Romance', 'A believer in love, crafting heartwarming stories that inspire.'),
    (9, 'Mystery', 'A detective of words unraveling mysteries in every page.'),
    (10, 'Fiction', 'A wordsmith with the power to transport readers to new realities.'),
    (11, 'Science Fiction', 'An explorer of possibilities in the cosmos of science and fiction.'),
    (12, 'Fantasy', 'A conjurer of fantastical realms where anything is possible.');


-- Insert hardcoded books into the "Books" table with random genres and authors
INSERT INTO Books (Title, ReleaseDate, Genre, AuthorId)
VALUES
    ('The Enchanted Voyage', '2022-05-15', 'Fantasy', 5),
    ('Whispers in the Mist', '2021-11-22', 'Mystery', 4),
    ('Galactic Odyssey', '2020-07-10', 'Science Fiction', 11),
    ('Crimson Chronicles', '2019-03-05', 'Adventure', 6),
    ('Echoes of Eternity', '2018-09-18', 'Fantasy', 1),
    ('Shadows of Serenity', '2017-06-30', 'Thriller', 7),
    ('Forgotten Realms', '2016-02-12', 'Fantasy', 12),
    ('Voyage of the Stars', '2015-11-08', 'Science Fiction', 3),
    ('Sapphire Secrets', '2014-04-25', 'Romance', 8),
    ('The Midnight Mirage', '2013-08-03', 'Mystery', 9),
    ('Chronicles of Celestia', '2012-01-19', 'Fantasy', 2),
    ('Astral Whispers', '2011-07-07', 'Science Fiction', 10),
    ('Mysteries Unveiled', '2010-10-26', 'Mystery', 9),
    ('The Enigmatic Echo', '2009-07-01', 'Adventure', 6),
    ('Ethereal Dreams', '2008-05-17', 'Fantasy', 1),
    ('Crimson Quest', '2007-08-14', 'Adventure', 6),
    ('Winds of Destiny', '2006-02-03', 'Adventure', 6),
    ('Chronicles of Chaos', '2005-09-28', 'Fantasy', 2),
    ('The Great Adventure', '2004-11-11', 'Adventure', 6),
    ('Whispers of Winter', '2003-10-10', 'Mystery', 4),
    ('Eternal Echoes', '2002-03-03', 'Fantasy', 1),
    ('Silent Echoes', '2001-12-12', 'Mystery', 4),
    ('Starry Horizons', '2000-06-06', 'Science Fiction', 11),
    ('Mystic Legends', '1999-08-22', 'Fantasy', 1),
    ('Lost Realities', '1998-03-17', 'Science Fiction', 3),
    ('Secrets of the Abyss', '1997-09-05', 'Mystery', 4),
    ('Realm of Whispers', '1996-11-30', 'Fantasy', 5),
    ('Epic Encounters', '1995-04-14', 'Adventure', 6),
    ('Shadows of Destiny', '1994-12-25', 'Thriller', 7),
    ('Echoes of Hope', '1993-10-01', 'Romance', 8);

-- Create some ebooks
INSERT INTO EBooks (BookId, [Version], [DownloadLink])
VALUES
    (1, '1a', CONCAT('/', NEWID())),
    (12, '1c', CONCAT('/', NEWID())),
    (14, '2b', CONCAT('/', NEWID())),
    (23, '1d', CONCAT('/', NEWID())),
    (26, '1a', CONCAT('/', NEWID()));


-- Insert additional made-up persons into the "Persons" table
INSERT INTO Persons (Age, Name)
VALUES
    (28, 'Olivia Wilson'),
    (37, 'Michael Thompson'),
    (24, 'Sophia Davis'),
    (50, 'Liam Anderson'),
    (39, 'Emma Martinez'),
    (26, 'Noah Brown'),
    (43, 'Ava Miller'),
    (32, 'William Rodriguez'),
    (22, 'Isabella Harris'),
    (41, 'James Hall'),
    (30, 'Mia Martin'),
    (48, 'Ethan White'),
    (27, 'Charlotte Lewis'),
    (35, 'Alexander Clark'),
    (45, 'Amelia Adams');


-- Insert Patron data for each person into the "Patrons" table
INSERT INTO Patrons (PersonId, MembershipExpiryDate, PhoneNumber, Address)
VALUES
    (13, '2023-09-30', '5551234567', '123 Main St, Cityville'),
    (14, '2023-07-15', '5559876543', '456 Elm St, Townsville'),
    (15, '2022-12-20', '5553335555', '789 Oak St, Villageton'),
    (16, '2023-02-05', '5554446666', '101 Pine St, Countryside'),
    (17, '2023-06-30', '5555557777', '222 Maple Ave, Suburbia'),
    (18, '2023-11-22', '5556668888', '333 Cedar Rd, Urbanville'),
    (19, '2023-04-10', '5557779999', '444 Birch Ln, Metropolis'),
    (20, '2022-10-15', '5558880000', '555 Willow Rd, Citytown'),
    (21, '2023-03-25', '5559991111', '666 Spruce St, Townborough'),
    (22, '2022-11-01', '5552223333', '777 Fir Ave, Villagetown'),
    (23, '2023-07-12', '5553334444', '888 Pine Ln, Cityburg'),
    (24, '2023-01-28', '5554445555', '999 Oak Rd, Villageland'),
    (25, '2023-04-15', '5555556666', '111 Maple St, Suburbsville'),
    (26, '2024-02-10', '5556667777', '222 Cedar Ave, Metropia'),
    (27, '2022-10-05', '5557778888', '333 Birch Rd, Urbanburg');
