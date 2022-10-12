using Microsoft.AspNetCore.Mvc;
using Stack_Overflow.API.BisinessModels;
using Stack_Overflow.API.Services;

namespace Stack_Overflow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public QuestionController(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _questionService.Add(question);
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion([FromBody] Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _questionService.Remove(question);
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        }
        [HttpPut]
        public async Task<IActionResult> PutQuestion([FromBody] Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _questionService.Update(question);
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        } 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            try
            {
                if (id != 0)
                {
                   var result =  await _questionService.Get(id);
                    return Ok(result);
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            try
            {
                return Ok(await _questionService.GetAll());
            
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        }

    }
}
