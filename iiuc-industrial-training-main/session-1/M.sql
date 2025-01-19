CREATE DATABASE studentdb;

USE studentdb;

CREATE TABLE students (
    StudentID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Gender VARCHAR(10),
    Course VARCHAR(50)
);

INSERT INTO students (FirstName, LastName, Age, Gender, Course)
VALUES
('John', 'Doe', 20, 'Male', 'Computer Science'),
('Jane', 'Smith', 22, 'Female', 'Mathematics');
