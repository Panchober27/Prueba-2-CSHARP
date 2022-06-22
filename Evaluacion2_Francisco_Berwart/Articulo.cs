using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2_Francisco_Berwart {
    class Articulo {

        // propiedaddes.
        // id, descripcion,nombre, valorAproximado, [3 referencias].

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double ValorAproximado { get; set; }
        public string FechaIngreso { get; set; }
        public int PersonaId { get; set; }
        public bool Disponible { get; set; }


        // 3 preferencias a otros articulos.
        // public List<Articulo> Preferencias { get; set; }

        // constructor.
        public Articulo(int id, string nombre, string descripcion, double valorAproximado, string fechaIngreso, int personaId, bool disponible) {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            ValorAproximado = valorAproximado;
            FechaIngreso = fechaIngreso;
            PersonaId = personaId;
            Disponible = disponible;
        }


        // metodos.
        // toString.
        public override string ToString() {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", Id, Nombre, Descripcion, ValorAproximado, FechaIngreso, PersonaId, Disponible);
        }




    }
}
