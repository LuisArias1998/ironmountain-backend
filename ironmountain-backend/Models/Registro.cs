using System;
using System.Collections.Generic;

namespace ironmountain_backend.Models;

public partial class Registro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal Telefono { get; set; }

    public string Curp { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
