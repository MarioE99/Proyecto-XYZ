using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Proyecto_Empleados_MarioE.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }
 
}
