CREATE DATABASE IF NOT EXISTS tabletoptreasure_database;

USE tabletoptreasure_database;

CREATE TABLE Clients (
ID INT PRIMARY KEY AUTO_INCREMENT,
Nom VARCHAR(100) NOT NULL,
Prenom VARCHAR(100) NOT NULL,
Adresse_mail VARCHAR(100) NOT NULL,
Adresse_de_livraison VARCHAR(150),
Telephone VARCHAR(15)
);

CREATE TABLE Categories(
ID INT PRIMARY KEY AUTO_INCREMENT,
Nom  VARCHAR(100) NOT NULL
);

CREATE TABLE Jeux (
ID INT PRIMARY KEY AUTO_INCREMENT,
Nom VARCHAR(100) NOT NULL,
Description TEXT,
Prix DECIMAL(10,2)NOT NULL,
ID_Categorie INT,
FOREIGN KEY (ID_Categorie) REFERENCES Categories(ID)
);

CREATE TABLE Commandes (
ID INT PRIMARY KEY AUTO_INCREMENT,
ID_Client INT NOT NULL,
Date_de_commande DATE NOT NULL ,
Adresse_de_livraison VARCHAR(100) NOT NULL,
Statut VARCHAR(50),
FOREIGN KEY (ID_Client) REFERENCES Clients(ID)
);

INSERT INTO Categories (Nom)
VALUES
('Stratégie'),
('Familial'),
('Aventure');

INSERT INTO Jeux (Nom,Description,Prix,ID_Categorie)
VALUES
('Catan', 'Jeu de stratégie et de développement de colonies', 30, 1),
('Dixit', 'Jeu d''association d''images', 25, 2),
('Les Aventuriers', 'Jeu de plateau d''aventure', 40, 3),
('Carcassonne', 'Jeu de placement de tuiles', 28, 1),
('Codenames', 'Jeu de mots et d''indices', 20, 2),
('Pandemic', 'Jeu de coopération pour sauver le monde', 35, 3),
('7 Wonders', 'Jeu de cartes et de civilisations', 29, 1),
('Splendor', 'Jeu de développement économique', 27, 2),
('Horreur à Arkham', 'Jeu d''enquête et d''horreur', 45, 3),
('Risk', 'Jeu de conquête mondiale', 22, 1),
('Citadelles', 'Jeu de rôles et de bluff', 23, 2),
('Terraforming Mars', 'Jeu de stratégie de colonisation de Mars', 55, 3),
('Small World', 'Jeu de civilisations fantastiques', 32, 1),
('7 Wonders Duel', 'Jeu de cartes pour 2 joueurs', 26, 2),
('Horreur à l''Outreterre', 'Jeu d''aventure horrifique', 38, 3);

INSERT INTO Clients (Nom,Prenom,Adresse_mail,Adresse_de_livraison,Telephone)
VALUES ('Dubois', 'Marie', 'marie.dubois@example.com', '123 Rue de la Libération, Ville', '+1234567890'),
('Lefebvre', 'Thomas', 'thomas.lefebvre@example.com', '456 Avenue des Roses, Ville', '+9876543210'),
('Martinez', 'Léa', 'lea.martinez@example.com', '789 Boulevard de la Paix, Ville', '+2345678901'),
('Dupuis', 'Antoine', 'antoine.dupuis@example.com', '567 Avenue de la Liberté, Ville', '+3456789012'),
('Morin', 'Camille', 'camille.morin@example.com', '890 Rue de l''Avenir, Ville', '+4567890123'),
('Girard', 'Lucas', 'lucas.girard@example.com', '234 Avenue des Champs, Ville', '+5678901234'),
('Petit', 'Emma', 'emma.petit@example.com', '123 Rue des Étoiles, Ville', '+6789012345'),
('Sanchez', 'Gabriel', 'gabriel.sanchez@example.com', '345 Boulevard du Bonheur, Ville', '+7890123456'),
('Rossi', 'Clara', 'clara.rossi@example.com', '678 Avenue de la Joie, Ville', '+8901234567'),
('Lemoine', 'Hugo', 'hugo.lemoine@example.com', '456 Rue de la Nature, Ville', '+9012345678'),
('Moreau', 'Eva', 'eva.moreau@example.com', '789 Avenue de la Créativité, Ville', '+1234567890'),
('Fournier', 'Noah', 'noah.fournier@example.com', '234 Rue de la Découverte, Ville', '+2345678901'),
('Leroy', 'Léa', 'lea.leroy@example.com', '567 Avenue de l''Imagination, Ville', '+3456789012'),
('Robin', 'Lucas', 'lucas.robin@example.com', '890 Rue de la Création, Ville', '+4567890123'),
('Marchand', 'Anna', 'anna.marchand@example.com', '123 Boulevard de l''Innovation, Ville', '+5678901234');

INSERT INTO Commandes (Id_Client,Date_de_commande,Adresse_de_livraison,Statut)
VALUES
(1, '2023-08-10', '123 Rue A', 'En cours'),
(2, '2023-08-11', '456 Rue B', 'En cours'),
(2, '2023-08-01', '789 Rue C', 'Terminée');

UPDATE Jeux 
SET Prix = 35.00
WHERE ID =3;

DELETE FROM Jeux WHERE ID = 2;

#Table Categories
-- 1
SELECT DISTINCT Nom  FROM Categories; 

-- 2
SELECT * FROM Categories
WHERE Nom LIKE 'A%' OR Nom LIKE 'S%';

-- 3
SELECT * FROM Categories 
WHERE ID BETWEEN 2 AND 5;

-- 4
SELECT COUNT(*) As Nombre_de_categories FROM Categories;

-- 5
SELECT Nom FROM Categories 
ORDER BY length(Nom) DESC
LIMIT 1;

-- 6
SELECT c.Nom, COUNT(j.ID) as Nombre_de_jeux



FROM Categories as c
LEFT JOIN Jeux as j 
ON c.ID = j.ID_categorie
GROUP BY c.Nom;

SELECT Nom FROM Categories ORDER BY Nom DESC;

#Jeux

-- 1
SELECT DISTINCT Nom FROM Jeux;

-- 2
SELECT * FROM Jeux
WHERE prix BETWEEN 25.00 AND 40.00;

-- 3
SELECT Nom FROM Jeux
WHERE ID_categorie = 3;

-- 4
SELECT COUNT(*) AS Nombre_de_jeux_aventure
FROM Jeux
WHERE Description LIKE '%aventure%';

-- 5
SELECT Nom,Prix
FROM Jeux 
ORDER BY Prix ASC
LIMIT 1;

 -- 6
SELECT SUM(prix) AS Somme_totale_des_prix FROM Jeux;

-- 7
SELECT Nom FROM Jeux
ORDER BY Nom ASC
LIMIT 5;

# CLient

-- 1
SELECT DISTINCT Prenom FROM Clients;

-- 2
SELECT * FROM CLients
WHERE Adresse_de_livraison LIKE '%Rue%' AND Telephone LIKE '+1%';

-- 3
SELECT * FROM Clients
WHERE Nom LIKE 'M%' OR Nom LIKE 'R%';

-- 4
SELECT COUNT(*) AS Nombre_de_client_avec_email FROM Clients
WHERE Adresse_mail LIKE '%@%';

-- 5
Select Prenom FROM CLients 
ORDER BY length(Prenom) ASC 
LIMIT 1;

-- 6 
Select COUNT(*) AS Nombre_total_de_clients FROM Clients;

-- 7 
SELECT * FROM Clients
ORDER BY Nom ASC,Prenom ASC
LIMIT 100 OFFSET 3;


# Alter Commande 
ALTER TABLE Commandes
ADD COLUMN ID_Jeux INT,
ADD CONSTRAINT FK_Commandes_Jeux FOREIGN KEY (ID_Jeux) REFERENCES Jeux(ID);

UPDATE Commandes
SET ID_Jeux = 1
WHERE ID = 1;

UPDATE Commandes
SET ID_Jeux = 1
WHERE ID = 2;

UPDATE Commandes
SET ID_Jeux = 3
WHERE ID = 3;


-- 1
SELECT c.Nom AS Nom_Client, j.Nom AS Nom_jeu, co.Date_de_commande
FROM Commandes AS co
JOIN Clients AS c ON co.ID_Client = c.ID
JOIN Jeux AS j On co.ID_Jeux = j.ID;

-- 2
SELECT c.Nom, c.Prenom,SUM(j.Prix) AS Montant_total_depense
FROM Commandes AS co
JOIN Clients AS c ON co.ID_Client = c.ID
JOIN Jeux AS j On co.ID_Jeux = j.ID
GROUP BY c.ID
ORDER By Montant_total_depense DESC;

-- 3 
SELECT j.Nom AS Nom_Jeu, c.Nom AS Nom_Categorie, j.prix
FROM Jeux AS j
JOIN Categories AS c On j.ID_Categorie = c.ID;

-- 4
SELECT c.Nom AS Nom_Client,c.Prenom AS Prenom_Client, j.Nom AS Nom_jeu, co.Date_de_commande
FROM Commandes AS co
JOIN Clients AS c ON co.ID_Client = c.ID
JOIN Jeux AS j On co.ID_Jeux = j.ID;

-- 5

SELECT c.Nom, c.Prenom, COUNT(co.ID)AS Nombre_Total_de_commande, SUM(j.Prix)AS Montant_total
FROM Clients AS c
JOIN Commandes AS co ON c.ID = co.ID_Client
JOIN Jeux AS j ON co.ID_Jeux = j.ID
GROUP BY c.ID
HAVING  Nombre_Total_de_commande>=1
