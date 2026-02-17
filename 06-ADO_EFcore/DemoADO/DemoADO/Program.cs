
using DemoADO.Classes;
using MySql.Data.MySqlClient;

string connectionString = "Server=localhost;Database=demo_ado ;User ID=root;Password=Root";

void AjouterPersonne()
{
    Console.WriteLine("--- Ajouter une personne ---");
    Console.WriteLine("Nom :");
    var nom = Console.ReadLine();
    Console.WriteLine("Prenom :");
    var prenom = Console.ReadLine();
    Console.WriteLine("Age :");
    var age = int.Parse(Console.ReadLine());
    Console.WriteLine("Email :");
    var email = Console.ReadLine();


    //mise en place de notre object qui nous servira a interagir avec la BDD
    MySqlConnection connection = new MySqlConnection(connectionString);

    try
    {
        //Ouverture de la connection vers la basse de donnée
        connection.Open();

        //requete a effectué sur la base de donnée avec les valeur passée via des parametre pour eviter tout probleme d'injections sql
        string query = "INSERT INTO Personne (nom,prenom,age,email) VALUES (@nom,@prenom,@age,@email)";

        //on va crée un object commande qui va contenir la requete a effectué et la connection a la base de donnée
        MySqlCommand cmd = new MySqlCommand(query, connection);

        //On viens remplacer les differents parametres qui etait present dans notre requete definit precedament
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@email", email);

        // On viens exxecuter la requete sur la basse de donnée et recuperer le nombre de ligne modiffié
        int rowAffected = cmd.ExecuteNonQuery();
        if(rowAffected > 0)
        {
            Console.WriteLine("Personne ajouté avec succès :!");
        }
        //string query = $"INSERT INTO Personne (nom,prenom,age,email) VALUES ({nom},{prenom},{age},{email})";

    }
    catch(Exception ex)
    {
        Console.WriteLine("Erreur : "+ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

void AfficherToutesLesPersonnes()
{
    Console.WriteLine("--- Liste des personnes ---");
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        //Mise en place de la requete de recuperation des personnes
        string query = "SELECT * FROM Personne";
        //Creation de la commande pour interagir avec la base de donnée
        MySqlCommand cmd = new MySqlCommand(query, connection);

        //Execution de la requete de recuperation des personnes et stockage des donnée dans l'object DataReader
        MySqlDataReader reader = cmd.ExecuteReader();

        //vereification si on a bien au moins une ligne recuperé
        if (reader.HasRows)
        {

            //Pour chaque ligne recuperé on va donc crée un object personne
            while (reader.Read())
            {
                Personne p = new Personne(
                    //recuperation de la valeur a la colone "id" dans une variable de type int
                    reader.GetInt32("id"),
                    //recuperation de la valeur a la colone "nom" dans une variable de type String
                    reader.GetString("nom"),
                    //recuperation de la valeur a la colone "prenom" dans une variable de type String
                    reader.GetString("prenom"),
                    //recuperation de la valeur a la colone "age" dans une variable de type int
                    reader.GetInt32("age"),
                    //recuperation de la valeur a la colone "email" dans une variable de type String
                    reader.GetString("email")
                    );

                Console.WriteLine(p);
           
            }
        }
        else
        {
            Console.WriteLine("Aucune persoone dans la base de donnée");
        }
        reader.Close();

    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    //Utilisation du finaly (block au passage obligatoire pour fermer la connection a la bdd
    finally
    {
        connection.Close();
    }
}

void RechercherPersonneParId()
{
    Console.WriteLine("--- Recherche Par Id ---");
    Console.WriteLine("Id de la personne Recherché :");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection (connectionString);
    try
    {
        connection.Open();

        string query = "SELECT * FROM Personne WHERE id = @id";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Personne p = new Personne(
                    //recuperation de la valeur a la colone "id" dans une variable de type int
                    reader.GetInt32("id"),
                    //recuperation de la valeur a la colone "nom" dans une variable de type String
                    reader.GetString("nom"),
                    //recuperation de la valeur a la colone "prenom" dans une variable de type String
                    reader.GetString("prenom"),
                    //recuperation de la valeur a la colone "age" dans une variable de type int
                    reader.GetInt32("age"),
                    //recuperation de la valeur a la colone "email" dans une variable de type String
                    reader.GetString("email")
                    );

            Console.WriteLine("Personne trouvé : "+p);
        }
        else
        {
            Console.WriteLine("Aucune personne trouvée avec cet ID ");
        }

        reader.Close();
    }catch(Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
    finally
    {
        connection.Close(); 
    }
}

void UpdatePersonne()
{
    Console.WriteLine("--- Modifier une personne ---");
    Console.WriteLine("Id de la personne a modifier :");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection ( connectionString);
    try
    {
        connection.Open();

        //Verification si la personne avec cet id existe bien
        string queryCheck = "SELECT COUNT(*) FROM Personne WHERE id = @id";
        MySqlCommand cmdCheck = new MySqlCommand(queryCheck, connection);
        cmdCheck.Parameters.AddWithValue("@id", id);
        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

        if (count == 0)
        {
            Console.WriteLine("Aucune personne trouvée avec cet Id");
            return;
        }

        Console.WriteLine("Nouveau Nom :");
        var nom = Console.ReadLine();
        Console.WriteLine("Nouveau Prenom :");
        var prenom = Console.ReadLine();
        Console.WriteLine("nouvel Age :");
        var age = int.Parse(Console.ReadLine());
        Console.WriteLine("Nouvel Email :");
        var email = Console.ReadLine();


        string query = "UPDATE Personne SET nom = @nom , prenom = @prenom , age = @age , email = @email WHERE id = @id";

        //string query = "UPDATE Personne SET ";
        //if(nom != null)
        //{
        //    query += "nom = @nom";
        //}if(prenom != null)
        //{
        //    query += ",prenom= @prenom ";
        //}

        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nom", nom);
        cmd.Parameters.AddWithValue("@prenom", prenom);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@email", email);

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Personne modifié avec succès");
        }

    }
    catch (Exception ex) 
    {
        Console.WriteLine("Erreur : "+ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

void DeletePersonne()
{
    Console.WriteLine("--- Supprimer une personne ---");
    Console.WriteLine("Id de la personne a supprimer :");
    int id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = "DELETE FROM Personne WHERE id = @id";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);

        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            Console.WriteLine("Personne supprimé avec succès");
        }
        else
        {
            Console.WriteLine("Aucune personne trouvée a cet ID");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur :"+ex.Message);
    }
    finally
    {
        connection.Close();
    }
}

AjouterPersonne();
AfficherToutesLesPersonnes();
RechercherPersonneParId();
UpdatePersonne();
DeletePersonne();