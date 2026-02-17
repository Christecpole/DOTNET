-- Création de la BDD "films_bdd"
CREATE DATABASE IF NOT EXISTS films_bdd;
USE films_bdd;

-- Création de la table "Films"
CREATE TABLE Films (
    id INT PRIMARY KEY,
    titre VARCHAR(100),
    annee_sortie INT
);

-- Création de la table "Acteurs"
CREATE TABLE Acteurs (
    id INT PRIMARY KEY,
    nom VARCHAR(50),
    film_id INT,
    FOREIGN KEY (film_id) REFERENCES Films(id)
);

-- Insertion de données dans la table "Films"
INSERT INTO Films (id, titre, annee_sortie)
VALUES
    (1, 'Film A', 2010),
    (2, 'Film B', 2015),
    (3, 'Film C', 2020);

-- Insertion de données dans la table "Acteurs"
INSERT INTO Acteurs (id, nom, film_id)
VALUES
    (1, 'Acteur 1', 1),
    (2, 'Acteur 2', 1),
    (3, 'Acteur 3', 2),
    (4, 'Acteur 4', 2),
    (5, 'Acteur 5', 3);
    
    -- Requête pour récupérer les noms des acteurs associés à chaque film
SELECT f.titre AS Film, a.nom AS Acteur
FROM Films f
JOIN Acteurs a ON f.id = a.film_id;


