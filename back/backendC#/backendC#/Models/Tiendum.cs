using System;
using System.Collections.Generic;

namespace backendC_.Models
{
    public partial class Tiendum
    {
        public int Id { get; set; }
        public string? NombreTienda { get; set; }
        public int? IdEmpleado { get; set; }

        public virtual Empleado? IdEmpleadoNavigation { get; set; }
    }
}
