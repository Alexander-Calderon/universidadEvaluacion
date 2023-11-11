using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class CursoEscolarDto
{
    public int Id {get; set;}
    public short AnioInicio { get; set; }
    public short AnioFin { get; set; }
}
