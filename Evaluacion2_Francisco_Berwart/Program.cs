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


            // Menu principal.
            renderMenu();



            // 2. 
            // listadoRealPersonas =  leer csv;
            // listadoRealArticulos =  leer csv;

            // 3.
            // Consultas.




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

            string line = "";

            string[] args;

            /**
            if () {
                string Header = "fecha,Rut, Nombre, Apellido, Ciudad, Comuna, Telefono, Preferencias1, Preferencias2, Preferencias3, valor, Descripcion, ObjetoIntercambio";
                File.WriteAllText(args[0], Header);
            }
            **/

            int i = 0;
            foreach (Articulo art in articulos) {
                if (i == 0) {
                    line = "ID,Nombre,ValorAproximado,PersonaId,Descripcion,FechaIngreso,ESTADO";
                    exit.AppendLine(string.Join(separator, line));

                }

                // escribir una linea por cada art
                // OJO CON EL ORDEN DE LAS PROPIEDADES.
                string disponiBleString = "";
                if (art.Disponible == true) {
                    disponiBleString = "DISPONIBLE";
                } else {
                    disponiBleString = "NO DISPONIBLE";
                }

                line = art.Id + ","
                    + art.Nombre
                    + ","
                    + art.ValorAproximado
                    + ","
                    + art.PersonaId
                    + ","
                    + art.Descripcion
                    + ","
                    + art.FechaIngreso
                    + ","
                    + disponiBleString;
                ;
                exit.AppendLine(string.Join(separator, line));

                i++;
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



        static void renderMenu() {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Ver Opciones Articulos.");
            Console.WriteLine("2. Ver Opciones Personas.");
            Console.WriteLine("3. Ver Realiza Trueque.");
            Console.WriteLine("4. Salir.");
            
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    renderArticulos();
                    break;
                case "2":
                    renderPersonas();
                    break;
                case "3":
                    renderTrueque();
                    break;
                case "4":
                    Console.WriteLine("Saliendo del Sistema.");
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }




        static void renderArticulos(){
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Opciones Articulos:");
            Console.WriteLine("");
            Console.WriteLine("1. Ver Articulos disponibles.");
            Console.WriteLine("2. Agregar Articulo.");
            Console.WriteLine("3. Editar Articulo.");
            Console.WriteLine("4. Eliminar Articulo.");
            Console.WriteLine("5. Volver.");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Opcion no lista.");
                    break;
                case "2":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "3":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "4":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "5": 
                    renderMenu();
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }
        
        static void renderPersonas(){
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Opciones Personas:");
            Console.WriteLine("");
            Console.WriteLine("1. Ver Personas.");
            Console.WriteLine("2. Agregar Persona.");
            Console.WriteLine("3. Editar Persona.");
            Console.WriteLine("4. Eliminar Persona.");
            Console.WriteLine("5. Volver.");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Opcion no lista.");
                    break;
                case "2":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "3":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "4":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "5":
                    renderMenu();
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }

        static void renderTrueque(){
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Opciones Trueque:");
            Console.WriteLine("");
            Console.WriteLine("1. Ver Trueque.");
            Console.WriteLine("2. Agregar Trueque.");
            Console.WriteLine("3. Editar Trueque.");
            Console.WriteLine("4. Eliminar Trueque.");
            Console.WriteLine("5. Volver.");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Opcion no lista.");
                    break;
                case "2":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "3":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "4":
                    Console.WriteLine("Opcion no lista");
                    break;
                case "5":
                    renderMenu();
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }





    }
}
