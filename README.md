# API Universidad

## Asignatura

### GET /Api/Asignatura/C5GetAsignaturasPrimerCuatrimestreTercerCurso
Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.

### GET /Api/Asignatura/C7GetAsignaturasPorNombreGrado  
Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`

### GET /Api/Asignatura/C9GetInfoCursoAlumno
Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`

### GET /Api/Asignatura/C15GetAsignaturasSinProfesor
Devuelve un listado con las asignaturas que no tienen un profesor asignado.

### GET /Api/Asignatura/C30GetAsignaturasSinProfesor  
Devuelve un listado con las asignaturas que no tienen un profesor asignado

## Departamento  

### GET /Api/Departamento/C10GetDepartamentosConAsignaturasEnGradoInformatica
Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`  

### GET /Api/Departamento/C16GetDepartamentosConAsignaturasNoImpartidas  
Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar.

### GET /Api/Departamento/C19GetCantidadProfesoresPorDepartamento
Calcula cuántos profesores hay en cada departamento.

### GET /Api/Departamento/C20GetTodosDepartamentosConProfesores
Devuelve un listado con todos los departamentos y el número de profesores en cada uno.

### GET /Api/Departamento/C28GetDepartamentosSinProfesores
Devuelve un listado con los departamentos que no tienen profesores asociados  

### GET /Api/Departamento/C31GetDepartamentosSinAsignaturas
Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

## Grado

### GET /Api/Grado/C21GetTodosGradosConAsignaturas  
Devuelve un listado con el nombre de todos los grados y el número de asignaturas en cada uno.

### GET /Api/Grado/C22GetGradosConMasDe40Asignaturas
Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de 40 asignaturas asociadas.

### GET /Api/Grado/C23GetSumaCreditosPorTipoAsignatura
Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de créditos.

## Persona

### GET /Api/Persona/C1GetAllAlumnosOrderedByName  
Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.  

### GET /Api/Persona/C2GetAllAlumnosWithoutPhone
Averigua el nombre y los dos apellidos de los alumnos que no han dado de alta su número de teléfono en la base de datos.

### GET /Api/Persona/C3GetAllAlumnosBornIn1999  
Devuelve el listado de los alumnos que nacieron en 1999.  

### GET /Api/Persona/C6GetAllAlumnasMatriculadasEnInformatica
Devuelve un listado con los datos de todas las alumnas que se han matriculado alguna vez en el Grado en Ingeniería Informática (Plan 2015).

### GET /Api/Persona/C11GetAllAlumnosMatriculadosEnCurso20182019  
Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.  

### GET /Api/Persona/C17GetTotalAlumnas  
Devuelve el número total de alumnas que hay.

### GET /Api/Persona/C18GetTotalAlumnosNacidosEn1999  
Calcula cuántos alumnos nacieron en 1999  

### GET /Api/Persona/C24GetTotalAlumnosMatriculadosPorCurso
Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados  

### GET /Api/Persona/C26GetAlumnoMasJoven  
Devuelve todos los datos del alumno más joven  

### GET /Api/Persona/C4GetProfesoresSinTelefonoYNifK  
Devuelve el listado de profesores que no han dado de alta su número de teléfono en la base de datos y además su nif termina en K.  

### GET /Api/Persona/C8GetProfesoresConDepartamento  
Devuelve un listado de los profesores junto con el nombre del departamento al que están vinculados. El listado debe devolver cuatro columnas, primer apellido, segundo apellido, nombre y nombre del departamento. El resultado estará ordenado alfabéticamente de menor a mayor por los apellidos y el nombre.  

### GET /Api/Persona/C12GetProfesoresConDepartamento  
Devuelve un listado con los nombres de todos los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.  

### GET /Api/Persona/C13GetProfesoresYDepartamentosSinAsociar  
Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados.  

### GET /Api/Persona/C14GetProfesoresSinAsignaturas  
Devuelve un listado con los profesores que no imparten ninguna asignatura.  

### GET /Api/Persona/C25GetNumeroAsignaturasPorProfesor   
Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.  

### GET /Api/Persona/C27GetProfesoresSinDepartamento  
Devuelve un listado con los profesores que no están asociados a un departamento.  

### GET /Api/Persona/C29GetProfesoresSinAsignaturasEnDepartamento
Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura

