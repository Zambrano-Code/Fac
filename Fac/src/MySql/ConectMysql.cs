﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funciones;
using MySql.Data.MySqlClient;



namespace Fac.src.MySql
{
    public class ConectMysql
    {
        private static ConfigJson config;

        private static bool isUsed = false;


        // Constructor privado, asegura que solo una instancia de la clase se puede crear.
        public ConectMysql()
        {
            // Configuración de la clase para manejar la conexión a la base de datos.
            config = new ConfigJson();

            PruebaDeConexion();
        }


        // Método que devuelve la conexión a la base de datos, o null si hay un error.
        public MySqlConnection Connection()
        {
            if (!isUsed) return Error();
            return new MySqlConnection(config.GetStringBuilder());
        }


        // Método que realiza una prueba de conexión durante la creación del singleton.
        private void PruebaDeConexion()
        {
            if (isUsed) return;
            try
            {
                // Crea una nueva instancia de MySqlConnection con la cadena de conexión configurada.
                using (var cn = new MySqlConnection(config.GetStringBuilder()))
                {

                    // Abre la conexión asincrónicamente y espera a que la operación se complete.
                    cn.OpenAsync().Wait();

                    isUsed = true;
                    // Imprime un mensaje indicando que la conexión fue exitosa.
                    Console.WriteLine("\n");
                    StyleConsole.PrintConsoleContainer("Conexión a la DB exitosa.");

                }
            }
            catch (MySqlException ex)
            {
                // En caso de un error, imprime un mensaje y la información del error.
                Console.WriteLine("\n");
                StyleConsole.PrintConsoleContainer("Error en la conexión a la DB.");
                Console.WriteLine($"Texto del error:\n{ex.Message}");
            }
        }

        // Método que devuelve null e imprime un mensaje de error en la conexión.
        private MySqlConnection Error()
        {
            StyleConsole.PrintConsoleContainer("Error en la conexión a la DB.");
            return null;
        }
    }


}
