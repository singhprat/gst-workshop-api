--create a table called book

CREATE TABLE Book
(
    BookID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    PublishedYear INT,
    ISBN NVARCHAR(20),
    Genre NVARCHAR(100)
);


--Insert data into table book

INSERT INTO Book (Title, Author, PublishedYear, ISBN, Genre)
VALUES
('To Kill a Mockingbird', 'Harper Lee', 1960, '978-0-06-112008-4', 'Fiction'),

('1984', 'George Orwell', 1949, '978-0-452-28423-4', 'Dystopian Fiction'),

('Pride and Prejudice', 'Jane Austen', 1813, '978-1-59308-201-1', 'Classic Romance');