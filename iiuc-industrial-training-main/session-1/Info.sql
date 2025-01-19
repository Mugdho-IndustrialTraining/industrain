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

CREATE TABLE courses (
    CourseID INT AUTO_INCREMENT PRIMARY KEY,
    CourseName VARCHAR(50) NOT NULL,
    Duration VARCHAR(20),
    Fee DECIMAL(10, 2)
);

INSERT INTO courses (CourseName, Duration, Fee) VALUES
('Computer Science', '4 Years', 10000),
('Mathematics', '3 Years', 8000),
('Physics', '3 Years', 8500);

INSERT INTO students (FirstName, LastName, Age, Gender, Course)
VALUES
('John', 'Doe', 20, 'Male', 'Computer Science'),
('Jane', 'Smith', 22, 'Female', 'Mathematics');
