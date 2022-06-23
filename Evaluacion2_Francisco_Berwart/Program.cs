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


            // Menu principal.
            renderMenu(personas, articulos);

            // Escribir history debe ser dinamico y revisar para escribir siemrpe una nueva linea
            //writeHistory();
            // usar funcion EscribirArchivoHistorial de la clase Funciones
            Funciones.EscribirArchivoHistorial(personas, articulos);

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
            articulos.Add(new Articulo(1,"articulo 1","Descripocion articulo 1",34000,"20/06/2022",1,true));
            articulos.Add(new Articulo(2,"articulo 2","Descripocion articulo 2",250000,"20/06/2022",1,true));
            articulos.Add(new Articulo(3,"articulo 3","Descripocion articulo 3",45000,"17/06/2022",2,true));
            articulos.Add(new Articulo(4,"articulo 4","Descripocion articulo 4",50000,"22/06/2022",2,true));
            string line = "";

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

            int i = 0;
            foreach (Persona p in personas) {
                if (i == 0) {
                    string line_ = "ID,NOMBRE,DESCRIPCION,$APROX,FECHA INGRESO,PERSONA,ESTADO";
                    exit.AppendLine(string.Join(separator, line_));
                }
                // escribir una linea por cada art
                string line = p.Id + "," + p.Rut + "," + p.Nombres + "," + p.Apellidos + "," + p.Telefono;
                exit.AppendLine(string.Join(separator, line));
                i++;
            }
            // escribir el archivo.
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
            bool flag = true; // variable para realizar un bucle dentro de este menu.
            do {
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
                        getArticulosDisponibles(articulos);
                        Console.ReadLine();
                        break;
                    case "2":
                        addArticulo(personas, articulos);
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Opcion no lista");
                        break;
                    case "4":
                        Console.WriteLine("Opcion no lista");
                        break;
                    case "5": 
                        renderMenu(personas, articulos);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

            } while (flag);
            
        }
        
        // Esta funcion recibe la lista de personas y articulos.
        static void renderPersonas(List<Persona> personas, List<Articulo> articulos) {
            bool flag = true; // variable para realizar un bucle dentro de este menu.
            do {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Opciones Personas:");
                Console.WriteLine("");
                Console.WriteLine("1. Ver Personas.");
                Console.WriteLine("2. Agregar Persona.");
                Console.WriteLine("3. Editar Persona."); // asignar,eliminar articulos.
                Console.WriteLine("4. Eliminar Persona.");
                Console.WriteLine("5. Volver.");
                string input = Console.ReadLine();
                switch (input) {
                    case "1":
                        //Console.WriteLine("Opcion no lista.");
                        getPersonas(personas);
                        Console.ReadLine();
                        break;
                    case "2":
                        registrarPersona(personas,articulos);
                        break;
                    case "3":
                        Console.WriteLine("Opcion no lista");
                        break;
                    case "4":
                        Console.WriteLine("Opcion no lista");
                        break;
                    case "5":
                        renderMenu(personas, articulos);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            } while(flag);


            
        }

        static void renderTrueque(List<Persona> personas, List<Articulo> articulos){
            bool flag = true; // variable para realizar un bucle dentro de este menu.
            do {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Opciones Trueque:");
                Console.WriteLine("");
                Console.WriteLine("1. Realizar Trueque.");
                Console.WriteLine("2. Volver.");
                string input = Console.ReadLine();
                switch (input) {
                    case "1":
                        // obtner por inputs de usuario.
                        // el usuario da el rut de las personas y los ids de los articulos.
                        // se pasan por parametros a la funcion hacerTrueque de Funciones.cs
                        Console.Clear();
                        Console.WriteLine("Generar Trueque.");
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese el rut de la persona 1:");
                        string rut1 = Console.ReadLine();
                        Console.WriteLine("Ingrese el rut de la persona 2:");
                        string rut2 = Console.ReadLine();
                        Console.WriteLine("Ingrese el id del articulo 1:");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el id del articulo 2:");
                        int id2 = int.Parse(Console.ReadLine());
                        // llamar a la funcion hacerTrueque de Funciones.cs
                        // armar arreglo con los ids de articulos y personas para pasarlos por parametros a a la funcion
                        int[] ids = new int[2];
                        ids[0] = id1;
                        ids[1] = id2;
                        string[] ruts = new string[2];
                        ruts[0] = rut1;
                        ruts[1] = rut2;
                        var resp = Funciones.hacerTrueque(personas, articulos, ids, ruts);
                        if(resp){
                            Console.WriteLine("Trueque realizado.");
                        } else {
                            Console.WriteLine("Trueque no realizado.");
                        }
                        break;
                    case "2":
                        renderMenu(personas, articulos);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            } while(flag);
        }




        // Funcion para registrar una nueva persona, recibe la lista de personas.
        static void registrarPersona(List<Persona> personas, List<Articulo> articulos) {
            try {
                int newId = personas.Count + 1;
                Console.Clear();
                Console.WriteLine("Registrar Persona:");
                Console.WriteLine("");
                Console.WriteLine("Ingrese rut:");
                string rut = Console.ReadLine();
                Console.WriteLine("Ingrese nombres:");
                string nombres = Console.ReadLine();
                Console.WriteLine("Ingrese apellidos:");
                string apellidos = Console.ReadLine();
                Console.WriteLine("Ingrese Telefono:");
                string telefono = Console.ReadLine();
                Persona persona = new Persona(newId, rut, nombres, apellidos, telefono);
                personas.Add(persona);
                Console.WriteLine("Persona registrada.");
                Console.WriteLine("");
                Console.ReadLine();    
                addArticuloToPersona(newId, personas,articulos);

                // crear articulos asociados a esta nueva persona.
                // llamar a funcion addArticulo.
            }
            catch (Exception e) {
                Console.WriteLine("Error al crear Persona: " + e.Message);                
            }
            // funcion para reescribir archivo de personas.
        }


        // Funcion que retorna el listado de Articulos disponibles utilizando linq.
        static void getArticulosDisponibles(List<Articulo> articulos) {
            Console.Clear();
            var articulosDisponibles = from articulo in articulos
                                      where articulo.Disponible == true
                                      select articulo;
                                    articulosDisponibles.ToList();
            foreach (Articulo articulo in articulosDisponibles) {
                Console.WriteLine(articulo.ToString());
            }
        }


        // Funcion para mostrar por consola listado de personas en sistema.
        // usando linq para ordenar por rut.
        static void getPersonas(List<Persona> personas) {
            Console.Clear();
            var personasOrdenadas = from persona in personas
                                    orderby persona.Id
                                    select persona;
            personasOrdenadas.ToList();
            foreach (Persona persona in personasOrdenadas) {
                Console.WriteLine(persona.ToString());
            }
        }



        // Funcion para crear un articulo (debe estar asociado a una persona).
        static void addArticulo(List<Persona> personas, List<Articulo> articulos) {
            bool flag = true; // variable para realizar un bucle dentro de este menu.
            do {

                try {
                    Console.Clear();
                    Console.WriteLine("Registrar Articulo:");
                    Console.WriteLine("");
                    Console.WriteLine("Ingrese nombre:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese descripcion:");
                    string descripcion = Console.ReadLine();
                    Console.WriteLine("Ingrese precio:");
                    double precio = Convert.ToDouble(Console.ReadLine());

                    // Para manejar disponible.
                    // dar opcion de seleccion a usuario u en base a la seleccion asignar [true,flase]

                    Console.WriteLine("Ingrese estado: [true,false] EN MINUSCULAS!");
                    bool disponible = Convert.ToBoolean(Console.ReadLine());

                    // LOGICA PARA AÑADIR UN ARTICULO A UNA PERSONA EXISTENTE!!!!.
                    Console.WriteLine("Ingrese id de persona:");
                    int idPersona = Convert.ToInt32(Console.ReadLine());
                    Persona persona = personas.Find(x => x.Id == idPersona);
                    //FrutaBase fruta = (FrutaBase)combobox.SelectedItem
                    if (persona != null) {
                        string fechaIng = DateTime.Now.ToString();
                        Articulo articulo = new Articulo(1, nombre, descripcion, precio, fechaIng, idPersona, disponible);
                        articulos.Add(articulo);
                        Console.WriteLine("Articulo registrado.");
                        
                        Console.WriteLine("");
                        Console.WriteLine("Desea registrar otro articulo?");
                        Console.WriteLine("1. Si");
                        Console.WriteLine("2. No");
                        string input = Console.ReadLine();
                        switch (input) {
                            case "1":
                                addArticulo(personas, articulos);
                                flag = false;
                                break;
                            case "2":
                                renderArticulos(personas, articulos);
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Opcion no valida.");
                                break;
                        }
                    } else {
                        Console.WriteLine("El id ingresado no pertenece a una persona registrada");
                        // reiniciar bucle.
                        break;
                    }
                    Console.WriteLine("");
                    Console.ReadLine();

                } catch (Exception e) {
                    Console.WriteLine("Error al crear Articulo: " + e.Message);
                }

            } while(flag);
            // funcion para reescribir archivo de articulos.
        }




        // Funcion para agregar un articulo a una persona recien creada.
        static void addArticuloToPersona(int idPersona, List<Persona> personas,List<Articulo> articulos) {
            Console.Clear();
            Console.WriteLine("Registrar Articulo:");
            Console.WriteLine("");
            Console.WriteLine("Ingrese nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese descripcion:");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Ingrese precio:");
            double precio = Convert.ToDouble(Console.ReadLine());

            // Para manejar disponible.
            // dar opcion de seleccion a usuario u en base a la seleccion asignar [true,flase]

            Console.WriteLine("Ingrese estado: [true,false] EN MINUSCULAS!");
            bool disponible = Convert.ToBoolean(Console.ReadLine());

            // LOGICA PARA AÑADIR UN ARTICULO A UNA PERSONA EXISTENTE!!!!.
            Console.WriteLine("Ingrese id de persona:");
            //FrutaBase fruta = (FrutaBase)combobox.SelectedItem
                string fechaIng = DateTime.Now.ToString();
                Articulo articulo = new Articulo(1, nombre, descripcion, precio, fechaIng, idPersona, disponible);
                articulos.Add(articulo);
                Console.WriteLine("Articulo registrado.");
                
                Console.WriteLine("");
                Console.WriteLine("Desea registrar otro articulo?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");
                // reiniciar bucle.
                string input = Console.ReadLine();
                switch (input) {
                    case "1":
                        addArticuloToPersona(idPersona,personas, articulos);
                        break;
                    case "2":
                        renderPersonas(personas,articulos);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            
            Console.WriteLine("");
            Console.ReadLine();
        }

    }
}
