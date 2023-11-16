using Microsoft.AspNetCore.Mvc;
using sentenceapp_backend.Models;

namespace sentenceapp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentenceController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WordsController> _logger;

        public SentenceController(ApplicationDbContext context, ILogger<WordsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("getAllSentences")]
        public IActionResult GetAllSentences()
        {
            try
            {
                _logger.LogInformation("GetAllWords function is called");
                var sentences = _context.Set<Sentence>().Select(n => n.SentenceValue).ToArray();

                _logger.LogInformation("GetAllWords function is finished no error");
                return Ok(sentences);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return BadRequest(ex);
            }

        }
        [HttpPost("addSentence")]
        public IActionResult AddSentence([FromBody] SentenceDTO sentenceDto)
        {
            try 
            {
                if (_context.Set<Sentence>().Any(e => e.SentenceValue == sentenceDto.Sentence))
                {
                    return NotFound($"Sentence '{sentenceDto.Sentence}' already exists");
                }

                var sentence = new Sentence {  SentenceValue = sentenceDto.Sentence };
                _context.Set<Sentence>().Add(sentence);
                _context.SaveChanges();
                var sentences = _context.Set<Sentence>().Select(n => n.SentenceValue).ToArray();

                return Ok(sentences);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return BadRequest(ex);
            }
        }
        
    }
}
