SELECT DISTINCT job
FROM Users
WHERE birth_location = 'New York';

SELECT * 
FROM Users
WHERE birth_location IN ('Rome','Berlin','Tokyo');

SELECT *
FROM Users
WHERE birth_date BETWEEN '1985-01-01' AND '1990-01-01';

SELECT id,first_name,job,age,salary
FROM Users
ORDER BY age ASC,salary DESC;

SELECT id,first_name AS  nom ,job,salary
FROM Users
ORDER BY Salary DESC
LIMIT 5 OFFSET 3;

SELECT SUM(salary) AS developeur_sum_salary
FROM Users
WHERE job ='Developer';

SELECT birth_location,AVG(salary) as moyenne_salaire
FROM Users
GROUP BY birth_location
HAVING AVG(age) > 38
ORDER BY moyenne_salaire DESC;

SELECT *
FROM Users
WHERE birth_location LIKE 'T%';

SELECT *
FROM Users
WHERE age < (SELECT AVG(age) FROM Users);

