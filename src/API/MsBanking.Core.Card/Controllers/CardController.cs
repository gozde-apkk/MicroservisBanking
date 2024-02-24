using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MsBanking.Core.Card.Domain.Dto;
using MsBanking.Core.Card.Services;

namespace MsBanking.Core.Card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ICardService _cardService;
        private readonly ILogger<CardController> _logger;

        public CardController(ICardService cardService, ILogger<CardController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cards = await _cardService.GetCards();
                return Ok(cards);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetCards");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var card = await _cardService.GetCard(id);
                return Ok(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetCard");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CardRequestDto card)
        {
            try
            {
                var newCard = await _cardService.AddCard(card);
                return Ok(newCard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddCard");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CardRequestDto card)
        {
            try
            {
                var updatedCard = await _cardService.UpdateCard(id, card);
                return Ok(updatedCard);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateCard");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cardService.DeleteCard(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteCard");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
