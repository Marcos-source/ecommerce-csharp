using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
namespace C_.Controllers;




[ApiController]
[Route("api/")]
public class HelloWorldController : ControllerBase
{
    C_.Connection connection = new C_.Connection();
    
    [HttpGet("")] //aca va la URL o la ruta del endpoint
    public string Get()
    {
        return "hello";
    }

    //por params
    [HttpGet("hola/{id}")]
    public JsonResult Get(int id)
    {
        try
        {
            NpgsqlDataReader myReader;
       DataTable table = new DataTable();
       using(NpgsqlConnection db = connection.connect()){
           using(NpgsqlCommand myCommand = new NpgsqlCommand(@"select * from users;", db)){
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
           }
       }
       return new JsonResult(table);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.ToString());
            return new JsonResult("{}");
        }
       
    }
    
    //por query
    public string Post(int id)
    {
        return $"asdasd{id}";
    }

    [HttpPost("crear")]
    public JsonResult Post(PerfilDto perfilDto)
    {
        return new JsonResult(perfilDto);
    }

    public class PerfilDto{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
