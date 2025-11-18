using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<Todo> _lista = new List<Todo>();
        private static int _id = 1;

        [HttpGet]
        public IActionResult Listar() => Ok(_lista);

        [HttpPost]
        public IActionResult Adicionar(Todo t)
        {
            t.Id = _id++;
            t.Concluida = false;
            _lista.Add(t);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var item = _lista.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();

            _lista.Remove(item);
            return Ok();
        }
    }
}
