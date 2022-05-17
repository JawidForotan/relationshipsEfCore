using Microsoft.AspNetCore.Mvc;
using RelationShipsEfCore.Models;

namespace relationShipsEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly RelationDataContext _context;
        public CharacterController(RelationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters(int userId)
        {
              
            var AllCharacters = await _context.characters
                .Where(c => c.UserId == userId)
                .Include(c => c.Weapon)
                .ToListAsync();
            return AllCharacters;

        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> PostCharacter(CharacterDTO request)
        {
            var user = await _context.users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();
            var newCharacter = new Character
            {
               
                Name = request.Name,
                Color = request.Color,
                User = user
            };
           
            _context.characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await GetCharacters(newCharacter.UserId);

        }

    }
}
