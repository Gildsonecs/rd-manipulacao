using MediatR;
using Microsoft.AspNetCore.Mvc;
using RdManipulation.Application.Services.Commands;
using RdManipulation.Application.Services.Queries;
using RdManipulation.Infra.Service;

namespace RdManipulation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController(IMediator mediator, YouTubeApiService youTubeApiService) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly YouTubeApiService _youTubeApiService = youTubeApiService;

        [HttpGet("search")]
        public async Task<IActionResult> GetYouTubeVideos([FromQuery] string search)
        {
            return Ok(await _mediator.Send(new AddYouTubeVideosCommand { Query = search }));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetVideosQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVideoCommand command)
        {
            await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { title = command.Title }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVideoCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteVideoCommand(id));

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
