using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class ProfesorDto
{    
    
    public PersonaDto Profesor { get; set; }
    public DepartamentoDto IdDepartamentoNavigation { get; set; }
}
