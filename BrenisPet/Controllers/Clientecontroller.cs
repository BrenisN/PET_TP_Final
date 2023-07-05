using BrenisPet.Properties.NewFolder2;
using Microsoft.AspNetCore.Mvc;

namespace BrenisPet.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class Clientecontroller : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult listarCliente()
        {

            List<cliente> clientes = new List<cliente>
            { 
                new cliente
                {
                    id = "1",
                    correo = "google@gmail.com",
                    edad = "19",
                    nombre = "Bernardo"
                },

                 new cliente
                {
                    id = "2",
                    correo = "brenis@gmail.com",
                    edad = "19",
                    nombre = "nahuel"
                 }

            };
            return Ok( clientes); 
         

        }

        [HttpGet]
        [Route("listarxid")]
        public IActionResult listarClientexid(int codigo)
        {
            //obtienes el cliente de la db

            return Ok( new cliente
            {
                id = codigo.ToString(),
                correo = "google@gmail.com",
                edad = "19",
                nombre = "Bernardo"
            });


        }


        [HttpPost]
        [Route("guardar")]
        public IActionResult guardarCliente(cliente cliente)
        {
            //guardar en la db y le da un id
            cliente.id = "3";
            return Ok(new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            });
        }

        [HttpPost]
        [Route("eliminar")]
        public IActionResult eliminarCliente(cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key =="Autorization").FirstOrDefault().Value;

            //elimina un cliente la db

            if (token != "marco123.")
            {
                return Ok(new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                });
            }

            return Ok( new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            });
        }
    }
}
