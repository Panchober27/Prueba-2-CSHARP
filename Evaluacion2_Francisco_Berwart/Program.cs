using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2_Francisco_Berwart {
    class Program {
        static void Main(string[] args) {

            // Saludar.
            Console.WriteLine("Inicio del Sistema");

            // 1. crear listados.
            // Ejecutando creador de csv de Articulos y Personas.
            writeCSVPersonas();
            writeCSVArticulos();


            // 2. 





            Console.ReadLine();
        }

        // funcion para ....
        // static void writeCSVArticulos(int id, string descripcion, string nombre, double valorAproximado, List<Articulo> preferencias) {
        static void writeCSVArticulos() {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaArticulos.csv";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            List<Articulo> articulos = new List<Articulo>();
            articulos.Add(new Articulo(1, "Laptop", "Dell", 12500, 1, true, "20-06-2022"));
            articulos.Add(new Articulo(2, "PC SD", "Toyota", 58000, 1, true, "20-06-2022"));
            articulos.Add(new Articulo(3, "SSH SD", "PackardBll", 20000, 1, true, "18-06-2022"));
            articulos.Add(new Articulo(4, "Suzuki", "Moto RB", 20000, 2, false, "15-06-2022"));

            foreach (Articulo art in articulos) {
                // escribir una linea por cada art
                // OJO CON EL ORDEN DE LAS PROPIEDADES.
                string line = art.Id + ","
                    + art.Nombre
                    + ","
                    + art.ValorAproximado
                    + ","
                    + art.PersonaId
                    + ","
                    + art.Descripcion
                    + ","
                    + art.FechaIngreso;
                exit.AppendLine(string.Join(separator, line));
            }

            // escribir el archivo.
            File.WriteAllText(path, exit.ToString());
        }



        // Funcion para crear listado de personas, por defecto.        
        static void writeCSVPersonas() {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaPersonas.csv";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona(1, "19243198-0", "Fancisco Ignacio", "Berwart Ramirez", "933836519"));
            personas.Add(new Persona(2, "10235555-5", "Ximena Paola", "Ramirez Ruiz", "9892778"));


            foreach (Persona p in personas) {
                // escribir una linea por cada art
                string line = p.Id + "," + p.Rut + "," + p.Nombres + "," + p.Apellidos + "," + p.Telefono;
                exit.AppendLine(string.Join(separator, line));
            }

            // escribir el archivo.
            File.WriteAllText(path, exit.ToString());
        }




    }
}
