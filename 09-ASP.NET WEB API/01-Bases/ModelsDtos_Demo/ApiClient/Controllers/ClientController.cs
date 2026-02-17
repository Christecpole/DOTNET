using ApiClient.Dtos;
using ApiClient.Extensions;
using ApiClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private static readonly List<Client> _clients = new()
        {
            new() { Id = 1, Nom = "Dupont", Email = "dupont@example.com", DateInscription = DateTime.UtcNow.AddDays(-10) },
            new() { Id = 2, Nom = "Martin", Email = "martin@example.com", DateInscription = DateTime.UtcNow.AddDays(-5) }
        };

        [HttpPost]
        public IActionResult Creer([FromBody] ClientDtoCreation dto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState); // 400
            }

            var id = _clients.Count == 0 ? 1 : _clients.Max(client => client.Id) + 1;
            var client = new Client
            {
                Id = id,
                Nom = dto.Nom,
                Email = dto.Email,
                DateInscription = dto.DateInscription ?? DateTime.Now,
            };

            _clients.Add(client);

            return StatusCode(201, client.VersDtoDetail());
        }

        [HttpGet]
        public IActionResult ObtenirListe()
        {
            //var dtosListe= _clients.Select(client => new ClientDtoListe
            //{
            //    Id= client.Id,
            //    Nom = client.Nom,
            //    Email = client.Email,
            //    DateInscription= client.DateInscription
            //}).ToList();
            var dtos = _clients.Select(c => c.VersDtoListe()).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenirParId(int id)
        {
            var client = _clients.FirstOrDefault(x => x.Id == id);
            if(client == null) return NotFound();
            //var clientDto = ExtensionMappingClient.VersDtoListe(client);
            return Ok(client.VersDtoDetail());
        }


    }
}
