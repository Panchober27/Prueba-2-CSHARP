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


            // Cargar datos en memoria, esto lo hare leyendo los valores en los .csv para cargarlos a listas de objetos.
            List<Persona> personas = new List<Persona>();
            List<Articulo> articulos = new List<Articulo>();
            string personasPath = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaPersonas.csv";
            string articulosPath = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\listaArticulos.csv";


            // crear listado de personas en base al archivo.
            StreamReader personasFile = new StreamReader(personasPath);
            string linea;
            try { 
                int i= 0;
                while ((linea = personasFile.ReadLine()) != null) {
                    string[] split = linea.Split(',');
                    if (i != 0) {
                        personas.Add(new Persona(Int16.Parse(split[0]), split[1], split[2], split[3], split[3]));
                    }
                    i++;
                }
                personasFile.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }

            // Revisar Valores de Lista Persona.
            try {
                var x = personas[0];
                Console.WriteLine(x);
            } catch (Exception e) {
                Console.WriteLine("Error leer personasList: " + e.Message);
            }

            // crear listado de articulos en base al archivo.
            StreamReader articulosFile = new StreamReader(articulosPath);
            try { 
                int i= 0;
                while ((linea = articulosFile.ReadLine()) != null) {
                    string[] split = linea.Split(',');
                    if (i != 0) {
                        bool estado = split[6] == "DISPONIBLE" ? true : false;
                        articulos.Add(new Articulo(Int16.Parse(split[0]), split[1], split[2], double.Parse(split[3]), split[4], Int16.Parse(split[5]), estado));
                    }
                    i++;
                }
                articulosFile.Close();
            } catch (Exception e) {
                Console.WriteLine("Error: " + e.Message);
            }

            // Revisar Valores de Lista Articulo.
            try {
                var x = articulos[0];
                Console.WriteLine(x);
                if(articulos.Count > 0) {
                    Console.WriteLine("Articulos cargados en memoria");
                } else {
                    Console.WriteLine("No hay articulos cargados en memoria");
                }


            } catch (Exception e) {
                Console.WriteLine("Error leer articulosList: " + e.Message);
            }


            // Menu principal.
            // renderMenu(personas, articulos);

            // Escribir history debe ser dinamico y revisar para escribir siemrpe una nueva linea
            writeHistory();



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
            // articulos.Add(new Articulo(1, "Laptop", "Dell", 12500, 1, true, "20-06-2022"));
            articulos.Add(new Articulo(1,"articulo 1","Descripocion articulo 1",250000,"22/06/2022",1,true));
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
                    line = "ID,NOMBRE,DESCRIPCION,$APROX,FECHA INGRESO,PERSONA,ESTADO";
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
                    + art.Descripcion
                    + ","
                    + art.ValorAproximado
                    + ","
                    + art.FechaIngreso
                    + ","
                    + art.PersonaId
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



        // Funcion para escribir el archivo de historial.
        static void writeHistory() {
            String path = @"E:\INACAP-RESPALDOS\Evaluacion2_Francisco_Berwart\Evaluacion2_Francisco_Berwart\Files\historial.txt";
            String separator = ",";
            StringBuilder exit = new StringBuilder();
            // Revisar que datos y de que forma se guardara el historial.
            //String line = id + "," + descripcion + "," + nombre + "," + valorAproximado;
            // crear lista con los articulos creados.
            // escrbir una linea

            // Crear nueva fecha
            DateTime fecha = DateTime.Now;
            string line = "Esta es una linea de prueba en el archivo historial" + "," + fecha;
            exit.AppendLine(string.Join(separator, line));
            File.WriteAllText(path, exit.ToString());
        }






        static void renderMenu(List<Persona> personas, List<Articulo> articulos) {
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
                    renderArticulos(personas, articulos);
                    break;
                case "2":
                    renderPersonas(personas, articulos);
                    break;
                case "3":
                    renderTrueque(personas, articulos);
                    break;
                case "4":
                    Console.WriteLine("Saliendo del Sistema.");
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }




        static void renderArticulos(List<Persona> personas, List<Articulo> articulos){
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
                    renderMenu(personas, articulos);
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }
        
        // Esta funcion recibe la lista de personas y articulos.
        static void renderPersonas(List<Persona> personas, List<Articulo> articulos) {
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
                    renderMenu(personas, articulos);
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }

        static void renderTrueque(List<Persona> personas, List<Articulo> articulos){
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
                    renderMenu(personas, articulos);
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }
        }





    }
}
