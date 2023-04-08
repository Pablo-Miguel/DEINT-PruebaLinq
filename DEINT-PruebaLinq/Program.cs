// See https://aka.ms/new-console-template for more information

using DEINT_PruebaLinq;

void mostrar(int[] lista)
{

    foreach (int i in lista)
    {
        Console.WriteLine(i);
    }

}

void mostrarPersonas(List<Persona> lista)
{

    foreach (Persona i in lista)
    {
        Console.WriteLine($"Persona -> Nombre: {i.nombre}, Edad: {i.edad}, Fecha ingr: {i.fechaIngreso}, Soltero: {i.soltero}");
    }

}

void mostrarString(List<String> lista)
{

    foreach (String i in lista)
    {
        Console.WriteLine($"{i}");
    }

}

void mostrarEnumerable(List<object> nombresYEdades)
{
    foreach (var i in nombresYEdades)
    {
        Console.WriteLine($"{i}");
    }
}

//Explicacion linq
int[] numeros = Enumerable.Range(1, 20).ToArray();

var numerosPares = numeros.Where(n => n % 2 == 0).ToArray();

var numerosPares2 = (
        
        from n in numeros
		
		where n % 2 == 0
		
		select n

	).ToArray();

var numerosImpares = numeros.Where(n => n <= 15 && n % 2 != 0).ToArray();

var numerosImpares2 = (
        
        from n in numeros

        where n % 2 != 0 && n <= 15
        
        select n

    ).ToArray();

mostrar(numerosImpares2);

Console.WriteLine();

//Ejemplo con objetos de la clase Persona
var personas = new List<Persona>();

personas.Add(new Persona {nombre = "Pablo Miguel del Castillo Barba", edad = 19, fechaIngreso = new DateTime(2003, 03, 20), soltero = false});
personas.Add(new Persona {nombre = "Marta Mariscal Velázquez", edad = 19, fechaIngreso = new DateTime(2003, 04, 25), soltero = false });
personas.Add(new Persona {nombre = "Manuel Jesus Curtido Rosado Barba Neira", edad = 20, fechaIngreso = new DateTime(2002, 02, 16), soltero = true });

var personasMenos25 = personas.Where(pers => pers.edad <= 25).ToList();

var personasSolteras = personas.Where(pers => pers.soltero).ToList();

mostrarPersonas(personasMenos25);

Console.WriteLine();

mostrarPersonas(personasSolteras);

Console.WriteLine();

//Funcion First y FirstOnDefault
var primeraPersona = personas.First();
var primeraPersonaMayorEdad = personas.First(pers => pers.edad >= 18);
var primeraPersonaMayorEdadV2 = personas.Where(pers => pers.edad >= 18).First();

Console.WriteLine($"Persona -> Nombre: {primeraPersona.nombre}, Edad: {primeraPersona.edad}, Fecha ingr: {primeraPersona.fechaIngreso}, Soltero: {primeraPersona.soltero}");
Console.WriteLine($"Persona -> Nombre: {primeraPersonaMayorEdad.nombre}, Edad: {primeraPersonaMayorEdad.edad}, Fecha ingr: {primeraPersonaMayorEdad.fechaIngreso}, Soltero: {primeraPersonaMayorEdad.soltero}");

Console.WriteLine();

//OrderBy
var personasOrdenadasEdadAsc = personas.OrderBy(pers => pers.edad).ToList();
var personasOrdenadasEdadDes = personas.OrderByDescending(pers => pers.edad).ToList();

mostrarPersonas(personasOrdenadasEdadAsc);
Console.WriteLine();
mostrarPersonas(personasOrdenadasEdadDes);

Console.WriteLine();

//OrdenarNumeros
var ordenarNumeros = numeros.OrderByDescending(num => num).ToArray();

mostrar(ordenarNumeros);

Console.WriteLine();

//Select

//1 propiedad
var nombres = personas.Select(p => p.nombre).ToList();
mostrarString(nombres);

Console.WriteLine();

//Varias propiedades -- Variables anonimas
var nombresYEdades = personas.Select(p => new { p.nombre, p.edad }).ToList();
//mostrarEnumerable(nombresYEdades);

Console.WriteLine();

//Select con operacion
var duplicados = numeros.Select(n => n * 2).ToArray();
mostrar(duplicados);

Console.WriteLine();

//Numeros duplicados mayores que 15
var duplicadosMayores15 = numeros.Select(n => n * 2).Where(n => n >= 15).OrderByDescending(n => n).ToArray();
var duplicadosMayores15V2 = numeros.Where(n => n >= 15).Select(n => n * 2).OrderByDescending(n => n).ToArray();

mostrar(duplicadosMayores15);
Console.WriteLine();
mostrar(duplicadosMayores15V2);

Console.WriteLine();

//Contar numero de perosonas mayores de edad
var contPers = personas.Count();
var persMayEdadCont = personas.Count(p => p.edad >= 18);

//Sumar edades
var sumarEdades = personas.Sum(p => p.edad);

//Min edad
var minEdad = personas.Min(p => p.edad);
var persMasJoven = personas.MinBy(p => p.edad);

//Max edad
var maxEdad = personas.Max(p => p.edad);
var persMaXJoven = personas.MaxBy(p => p.edad);

//Promedio edad
var mediaNumeros = personas.Average(p => p.edad);

//Cuantificaciones  universales: all, any, contains...

//ALL
var sonTodasPersMayorEdad = personas.All(p => p.edad >= 18);

//ANY
var hayAlgunMenorEdad = personas.Any(p => p.edad < 18);

//CONTAINS
var estaEl3 = numeros.Contains(3);

Console.WriteLine($"{sonTodasPersMayorEdad}, {hayAlgunMenorEdad}, {estaEl3}");

//TAKE y SKIP

var primeros10Numeros = numeros.Take(10).ToArray();
var ultimos10Numeros = numeros.TakeLast(10).ToArray();
// - Se rompe cuando no cumple la condicion
var numerosMay10YMen15 = numeros.TakeWhile(n => n <= 5).ToArray();

var salta10Primeros = numeros.Skip(10).ToArray();
var salta10Ultimos = numeros.SkipLast(10).ToArray();
// - Se rompe cuando no cumple la condicion
var saltaCuando = numeros.SkipWhile(n => n <= 5).ToArray();

Console.WriteLine();

//GroupBy
var agruparPorSolteria = personas.GroupBy(p => p.soltero).ToArray();

foreach (var group in agruparPorSolteria) {
    foreach (var pers in group) {
        Console.WriteLine($"{group.Count()}, {group.Key} -> {pers.nombre}");
    }
}

//DISTINCT y DISTINCT BY
int[] num = {1, 3, 4, 3, 8, 9};

var numerosSinRepeticion = num.Distinct();
var personasSinRepeticion = personas.DistinctBy(p => p.nombre);

//CHUNK
