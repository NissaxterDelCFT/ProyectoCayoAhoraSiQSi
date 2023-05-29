using System;
using System.Collections.Generic;

namespace ProyectoCayoAhoraSiQSi.Models;

public partial class AsignaturasAsiganada
{
    public int Id { get; set; }

    public int EstudianteId { get; set; }

    public int AsignaturaId { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public virtual Asignatura Asignatura { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
