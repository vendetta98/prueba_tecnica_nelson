using System;
using System.Collections.Generic;

namespace backendC_.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Tienda = new HashSet<Tiendum>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Dui { get; set; }
        public bool? Activo { get; set; }
        public int? IdTienda { get; set; }

        public virtual ICollection<Tiendum> Tienda { get; set; }
    }
}
