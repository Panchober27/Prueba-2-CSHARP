using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2_Francisco_Berwart {
    class Funciones {

        // Archivo con las funciones para operar en el sistema.




        // Funcion para sobreEscribir el archivo .csv de las personas, recibe listado de personas y articulos.
        public static void EscribirArchivoPersonas(List<Persona> personas, List<Articulo> articulos) {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaPersonas.csv";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            int i = 0;
            foreach (Persona p in personas) {
                if (i == 0) {
                    string line_ = "ID,NOMBRE,DESCRIPCION,$APROX,FECHA INGRESO,PERSONA,ESTADO";
                    exit.AppendLine(string.Join(separator, line_));
                }
                // escribir una linea por cada art
                string line = p.Id + "," + p.Rut + "," + p.Nombres + "," + p.Apellidos + "," + p.Telefono;
                exit.AppendLine(string.Join(separator, line));
            }

            // escribir el archivo.
            File.WriteAllText(path, exit.ToString());
            Console.WriteLine("Archivo Personas creado correctamente.");
        }



        // Funcion para sobreEscribir el archivo .csv de los articulos, recibe listado de personas y articulos.
        public static void EscribirArchivoArticulos(List<Persona> personas, List<Articulo> articulos) {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaArticulos.csv";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            int i = 0;
            foreach (Articulo a in articulos) {
                if (i == 0) {
                    string line_ = "ID,NOMBRE,DESCRIPCION,$APROX,FECHA INGRESO,PERSONA,ESTADO";
                    exit.AppendLine(string.Join(separator, line_));
                }
                // escribir una linea por cada art
                string line = a.Id + "," + a.Nombre + "," + a.Descripcion + "," + a.ValorAproximado + "," + a.FechaIngreso + "," + a.PersonaId + "," + a.Disponible;
                exit.AppendLine(string.Join(separator, line));

                i++;

            }
            
            // escribir el archivo.
            File.WriteAllText(path, exit.ToString());
            Console.WriteLine("Archivo Articulos creado con exito.");

        }





        // Funcion para sobreEscribir el archivo de historial, donde registro movimientos de articulos.
        public static void EscribirArchivoHistorial(List<Persona> personas, List<Articulo> articulos) {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\historial.txt";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            // Revisar que datos y de que forma se guardara el historial.
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            // escrbir una linea

            // Crear nueva fecha
            DateTime fecha = DateTime.Now;
            string line = "Esta es una linea desde la nueva funcion!" + "," + fecha;
            exit.AppendLine(string.Join(separator, line));
            File.WriteAllText(path, exit.ToString());
        }
    }
}
