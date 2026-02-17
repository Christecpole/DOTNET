use test_bdd;

CREATE TABLE Clients (
id INT PRIMARY KEY AUTO_INCREMENT,
first_name VARCHAR(100),
last_name VARCHAR(100),
city VARCHAR(100),
age INT
);

CREATE TABLE Abonnements (
id INT PRIMARY KEY AUTO_INCREMENT,
abonnement_type VARCHAR(100),
client_id INT,
FOREIGN KEY (client_id) REFERENCES Clients(id)
);

INSERT INTO Clients (first_name,last_name,city,age)
VALUES 
("CLient1","lastname1","Paris",28),
("CLient2","lastname2","Paris",28),
("CLient3","lastname3","Londre",28),
("CLient4","lastname4","New York",28),
("CLient5","lastname5","Rome",28),
("CLient6","lastname6","Paris",28),
("CLient7","lastname7","Paris",28);

INSERT INTO Abonnements (abonnement_type)
VALUES 
("Vip"),
("Standard"),
("Premium");


SELECT c.first_name, c.last_name,c.city,a.abonnement_type
FROM Clients as c
INNER JOIN Abonnements as a
ON c.id = a.client_id;

SELECT c.first_name, c.last_name,c.city,a.abonnement_type
FROM Clients as c
LEFT JOIN Abonnements as a
On c.id = a.client_id

UNION

SELECT c.first_name, c.last_name,c.city,a.abonnement_type
FROM Clients as c
RIGHT JOIN Abonnements as a
On c.id = a.client_id;