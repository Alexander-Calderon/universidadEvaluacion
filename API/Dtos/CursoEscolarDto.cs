using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class CursoEscolarDto
{
    public int Id {get; set;}
    public short AnyoInicio { get; set; }
    public short AnyoFin { get; set; }
}
