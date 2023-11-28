using Clase7.Domain.Entities;
using Clase7.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Clase7
{
    internal class Program
    {
        //public delegate int OperacionMatematica(int param1, int param2);

        static void Main(string[] args)
        {

            #region delegados
            //OperacionMatematica operacion = Sumar;
            ////Logica de negocio


            //int resultado = operacion(2, 2);

            //operacion = Restar;
            //int resultado2 = operacion(4, 2);

            //Delegados mas comunes

            //Action
            //Func
            //Predicate

            //Loggear("Se produjo una excepcion por motivo desconocido", mensaje => Console.WriteLine($"Log Custom: {mensaje}") );
            #endregion

            #region LINQ
            //var lstPersona = new List<Persona>()
            //{
            //    new Persona () {Id = 1, Apellido ="Jara", Nombre = "Alejandro" },
            //    new Persona () {Id = 1, Apellido ="Amaro", Nombre = "Santi" },
            //    new Persona () {Id = 2, Apellido ="Bravo", Nombre = "Carla" },
            //};


            //bool flag = lstPersona.All( a => !string.IsNullOrEmpty(a.Nombre) );



            //var result = lstPersona.GroupBy(g => g.Id)
            //                        .Select(s =>  new { IdKey = s.Key , Values = s.ToList() }  )
            //                        .ToList();



            //var personaId3 = lstPersona.Where(persona => persona.Id > 1)
            //                           .Select(s => new { Usuario = s.Nombre, Codigo = s.Id }    )
            //                           .ToList();


            //Console.WriteLine(JsonSerializer.Serialize(personaId3));
            //if (personaId3 is  null)
            //{
            //    Console.WriteLine("No se encontraron datos para el ID 4");
            //}
            //else 
            //{
            //    Console.WriteLine(JsonSerializer.Serialize(personaId3));
            //}

            #endregion


            string stringConnection = @"Data Source=localhost\SQL2022;Initial Catalog=Pruebas;Integrated Security=True;Trust Server Certificate=True";

            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(stringConnection).Options;

            var context = new DatabaseContext(options);

            //Select * from Usuario
            //var resultData = context.Usuario.Where(w => w.Id == 3).FirstOrDefault();

            //Console.WriteLine(JsonSerializer.Serialize(resultData)); 

            //var newPersona = new Persona()
            //{
            //    Domicilio = "Domicilio 3",
            //    Nombre = "Fer"
            //};
           

            //context.Persona.Add(newPersona);
          

            //context.SaveChanges(); 
            //var listaPersonas = context.Persona.ToList();

            //Change Tracker 
            var usuarioFer = context.Persona.Where(w => w.Id == 2).FirstOrDefault();

            if( usuarioFer != null ) 
            {
                usuarioFer.Domicilio = "Nuevo domicilio de Fer...";
            }
          
            context.SaveChanges();
        }

        //public class Persona 
        //{
        //    public int Id { get; set; }
        //    public string Nombre { get; set; }
        //    public string Apellido { get; set; }

        //}

        //public static void LogCustom(string param1) 
        //{
        //    Console.WriteLine($"Log Custom: {param1}");
        //}
        //public static void Loggear(string dataException, Action<string> logCustomImplementacion ) 
        //{
        //    //Logica negocia
        //    string newMensaje = dataException.ToUpper();
        //    logCustomImplementacion.Invoke(newMensaje);

        //}

        //public static int Sumar(int num1, int num2) { return  num1 + num2; }

        //public static int Restar(int num1, int num2) { return num1 - num2; }
    }
}