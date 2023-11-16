using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using sentenceapp_backend.Models;

namespace sentenceapp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WordsController> _logger;

        public WordsController(ApplicationDbContext context, ILogger<WordsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("getAll")]
        [EnableCors("AllowAll")]
        public IActionResult GetAllWords()
        {
            try 
            {
                _logger.LogInformation("GetAllWords function is called");
                var nouns = _context.Set<Noun>().Select(n => n.Value).ToArray();
                var verbs = _context.Set<Verb>().Select(v => v.Value).ToArray();
                var adverbs = _context.Set<Adverb>().Select(a => a.Value).ToArray();
                var adjectives = _context.Set<Adjective>().Select(a => a.Value).ToArray();
                var prepositions = _context.Set<Preposition>().Select(a => a.Value).ToArray();
                var conjunctions = _context.Set<Conjunction>().Select(a => a.Value).ToArray();
                var pronouns = _context.Set<Pronoun>().Select(a => a.Value).ToArray();
                var exclamations = _context.Set<Exclamation>().Select(a => a.Value).ToArray();
                var determiners = _context.Set<Determiner>().Select(a => a.Value).ToArray();


                var result = new
                {
                    noun = nouns,
                    verb = verbs,
                    adverb = adverbs,
                    adjective = adjectives,
                    preposition = prepositions,
                    conjunction = conjunctions,
                    pronoun = pronouns,
                    exclamation = exclamations,
                    determiner = determiners
                };
                _logger.LogInformation("GetAllWords function is finished no error");
                return Ok(result);
            } catch (Exception ex) 
            {
                _logger.LogError("Error: "+ ex.Message);
                return BadRequest(ex);
            }
           

            
        }


    }
}
