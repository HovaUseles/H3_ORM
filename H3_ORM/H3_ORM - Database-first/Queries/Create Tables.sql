DROP TABLE IF EXISTS Books;
DROP TABLE IF EXISTS EBooks;
DROP TABLE IF EXISTS Authors;
DROP TABLE IF EXISTS Patrons;
DROP TABLE IF EXISTS Persons;

CREATE TABLE Persons (
    PersonID INT IDENTITY,
    Age INT NOT NULL,
    Name NVARCHAR(75) NOT NULL,
    CONSTRAINT PK_Persons PRIMARY KEY (PersonId)
);

CREATE TABLE Patrons (
    PersonId INT NOT NULL,
    MembershipExpiryDate DATE,
    PhoneNumber INT NOT NULL,
    Address NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_Patrons PRIMARY KEY (PersonId),
    CONSTRAINT FK_Patrons_Persons FOREIGN KEY (PersonId) REFERENCES Persons(PersonId) ON DELETE CASCADE
);

CREATE TABLE Authors (
    PersonId INT NOT NULL,
    Genre NVARCHAR(25) NOT NULL,
    Biography NVARCHAR(500),
    CONSTRAINT PK_Authors PRIMARY KEY (PersonId),
    CONSTRAINT FK_Authors_Persons FOREIGN KEY (PersonId) REFERENCES Persons(PersonId) ON DELETE CASCADE
);

CREATE TABLE Books (
    BookId INT IDENTITY,
    Title NVARCHAR(75),
    ReleaseDate DATE,
    Genre NVARCHAR(25),
    AuthorId INT,
    CONSTRAINT PK_Books PRIMARY KEY (BookId),
    CONSTRAINT FK_Books_Author FOREIGN KEY (AuthorId) REFERENCES Authors(PersonId)
);

CREATE TABLE EBooks (
    BookId INT NOT NULL,
    Version NVARCHAR(5),
    DownloadLink NVARCHAR(200),
    CONSTRAINT PK_EBooks PRIMARY KEY (BookId),
    CONSTRAINT FK_EBooks_Books FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE CASCADE
);