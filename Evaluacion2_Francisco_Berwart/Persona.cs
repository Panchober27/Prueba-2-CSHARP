using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2_Francisco_Berwart {
    class Persona {

        // propiedaddes.
        // id, rut, nombres, apellidos, telefono.

        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }

        // lista de articulos asociados al vnededor.
        private List<Articulo> listadoArticulos;


        // constructor.
        public Persona(int id, string rut, string nombres, string apellidos, string telefono) {
            Id = id;
            Rut = rut;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            // inicializar la lista de articulos.
            // listadoArticulos = new List<Articulo>();
        }

        // metodos.
        // toString.
        public override string ToString() {
            return string.Format("{0} {1} {2} {3} {4}", Id, Rut, Nombres, Apellidos, Telefono);
        }




    }
}
