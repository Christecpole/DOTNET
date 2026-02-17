-- Creation de la base de données:
CREATE DATABASE IF NOT EXISTS music_stream;
USE music_stream;

-- Création de la table "Utilisateurs"
CREATE TABLE utilisateurs (
    id_utilisateur INT PRIMARY KEY,
    nom_utilisateur VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE,
    date_inscription TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    pays VARCHAR(255)
);


-- Création de la table "Chansons"
CREATE TABLE chansons (
    id_chanson INT PRIMARY KEY,
    titre VARCHAR(255),
    artiste VARCHAR(255),
    album VARCHAR(255),
    duree TIME,
    genre VARCHAR(255),
    annee_sortie YEAR
);

-- Création de la table "Playlists"
CREATE TABLE playlists (
    id_playlist INT PRIMARY KEY,
    nom_playlist VARCHAR(255),
    id_utilisateur INT,
    date_creation TIMESTAMP DEFAULT NOW(),
    FOREIGN KEY (id_utilisateur) REFERENCES utilisateurs(id_utilisateur)
);


