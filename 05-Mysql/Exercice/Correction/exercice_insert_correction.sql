-- Création de la base de données
CREATE DATABASE students_bdd;
USE students_bdd;

-- Création de la table "Students"
CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    date_of_birth DATE,
    email VARCHAR(100)
);

-- Création de la table "Courses"
CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(100),
    instructor VARCHAR(100),
    start_date DATE,
    end_date DATE
);

-- Insertion de données dans la table "Students"
INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email)
VALUES
    (1, 'John', 'Doe', '1995-05-12', 'john.doe@example.com'),
    (2, 'Alice', 'Smith', '1998-09-28', 'alice.smith@example.com'),
    (3, 'Michael', 'Johnson', '1990-02-05', 'michael.johnson@example.com');

-- Insertion de données dans la table "Courses"
INSERT INTO Courses (course_id, course_name, instructor, start_date, end_date)
VALUES
    (1, 'Mathematics 101', 'Prof. Brown', '2023-09-01', '2023-12-15'),
    (2, 'History 202', 'Prof. White', '2023-08-15', '2023-11-30');

-- Visualisation des résultats
SELECT *
FROM Students;

SELECT *
FROM Courses;
