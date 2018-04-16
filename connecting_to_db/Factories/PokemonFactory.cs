using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using connecting_to_db.Models;
using Dapper;
using System.Linq;

namespace connecting_to_db.Factories
{
    public class PokemonFactory
    {
        static string server = "localhost";
        static string db = "myDatabase"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        public List<Pokemon> GetAllPokemon()
        {
            using (IDbConnection dbConnection = Connection)
            {
                using (IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = "SELECT * FROM pokemons";
                    dbConnection.Open();
                    return dbConnection.Query<Pokemon>(query).ToList();
                }
            }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO pokemons (name, type, created_at, updated_at) VALUES (@name, @type, NOW(), NOW())";
                dbConnection.Open(); 
                dbConnection.Execute(query, pokemon);

            }
        }
    }
}