-- Creation de la base de données:
CREATE DATABASE IF NOT EXISTS bibliotheque;
USE bibliotheque;

-- Creation de la table Livres:
CREATE TABLE livres (
    id_livre INT PRIMARY KEY,
    titre TEXT,
    auteur TEXT,
    annee_publication INT,
    genre TEXT,
    exemplaires_disponibles INT
);

-- Creation de la table Membres:
CREATE TABLE membres (
    id_membre INT PRIMARY KEY,
    nom TEXT,
    prenom TEXT,
    date_naissance DATE,
    adresse TEXT,
    email TEXT,
    telephone TEXT
);
