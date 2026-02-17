Use test_bdd;

-- Partie 1
SELECT first_name, last_name, job
FROM Users
WHERE birth_location = 'New York';

SELECT first_name, last_name
FROM Users
WHERE salary > 2500 AND (job = 'Developer' OR job = 'Engineer');

SELECT first_name, last_name
FROM Users
WHERE job = 'Designer' AND salary BETWEEN 1500 AND 3000;

-- Partie 2

SELECT AVG(salary) AS AverageSalary
FROM Users;

SELECT birth_location, COUNT(*) AS UserCount
FROM Users
WHERE age >= 30
GROUP BY birth_location;

SELECT birth_location, COUNT(*) AS UserCount
FROM Users
WHERE salary > (SELECT AVG(salary) FROM Users)
GROUP BY birth_location;

-- Partie 3

SELECT first_name, last_name, age
FROM Users
WHERE last_name = 'Smith' AND (job = 'Developer' OR job = 'Engineer');

SELECT *
FROM Users
WHERE job IN ('Teacher', 'Designer', 'Doctor') AND age > 30;

SELECT *
FROM Users
WHERE (job = 'Engineer' OR job = 'Developer') AND salary > 2000 AND (first_name LIKE 'J%' OR first_name LIKE 'S%');

-- Partie 4

SELECT first_name, last_name
FROM Users
WHERE job LIKE '%Engineer%'
ORDER BY last_name ASC;


SELECT first_name, last_name
FROM Users
WHERE birth_date > '1990-01-01' AND last_name LIKE '%son'
ORDER BY age ASC;

-- Partie 5

SELECT DISTINCT job, COUNT(*) AS UserCount
FROM Users
WHERE salary > 2000
GROUP BY job;


SELECT birth_location, AVG(age) AS AvgAge
FROM Users
GROUP BY birth_location
HAVING COUNT(*) > 2 AND AVG(age) < 35;


SELECT birth_location, SUM(salary) AS TotalSalary
FROM Users
WHERE job IN ('Developer', 'Designer', 'Engineer') AND birth_location = 'London'
GROUP BY birth_location;

-- Partie 6


SELECT first_name, last_name
FROM Users
WHERE salary > (SELECT AVG(salary) FROM Users WHERE job = Users.job);


SELECT first_name, last_name
FROM Users
WHERE job = (SELECT job FROM Users WHERE first_name = 'Alice' AND last_name = 'Smith')
AND NOT (first_name = 'Alice' AND last_name = 'Smith');