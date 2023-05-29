using System;
using System.Collections.Generic;

namespace ProyectoCayoAhoraSiQSi.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Edad { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<AsignaturasAsiganada> Asignaturaasignada { get; set; } = new List<AsignaturasAsiganada>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
