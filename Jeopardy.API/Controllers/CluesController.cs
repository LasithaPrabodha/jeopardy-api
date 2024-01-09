using System.Text.Json;
using AutoMapper;
using Jeopardy.API.Dto;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;
using Jeopardy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Jeopardy.API.Controllers;

[Route("api/clues")]
[ApiController]
public class CluesController(IClueRepository clueRepository, IMapper mapper) : Controller
{
    private readonly IClueRepository _clueRepository = clueRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ClueDto>))]
    public async Task<IActionResult> GetClues([FromQuery] ClueParameters clueParameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cluesWithMetaData = await _clueRepository.GetCluesAsync(clueParameters, trackChanges: false);
        var clues = _mapper.Map<List<ClueDto>>(cluesWithMetaData);

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(cluesWithMetaData.MetaData));
        return Ok(clues);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ClueDto))]
    [Route("{id:int}")]
    public async Task<IActionResult> GetClue(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exists = await _clueRepository.ClueExists(id);
        if(!exists)
            return NotFound();
            
        var result = await _clueRepository.GetClueAsync(id, trackChanges: false);
        var clue = _mapper.Map<ClueDto>(result);

        return Ok(clue);
    }


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ClueDto))]
    [Route("random")]
    public async Task<IActionResult> GetRandomClue([FromQuery] RandomClueParameters randomClueParameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
 
        var result = await _clueRepository.GetRandomClueAsync(randomClueParameters,trackChanges: false);
        var clue = _mapper.Map<ClueDto>(result);

        return Ok(clue);
    }
}
