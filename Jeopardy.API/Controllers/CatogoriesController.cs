using System.Text.Json;
using AutoMapper;
using Jeopardy.API.Dto;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;
using Jeopardy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Jeopardy.API.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository, IMapper mapper) : Controller
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
    public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoriesWithMetaData = await _categoryRepository.GetCategoriesAsync(categoryParameters, trackChanges: false);
        var categories = _mapper.Map<List<CategoryDto>>(categoriesWithMetaData);

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(categoriesWithMetaData.MetaData));
        return Ok(categories);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(CategoryDto))]
    [Route("{id:int}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var exists = await _categoryRepository.CategoryExists(id);
        if(!exists)
            return NotFound();
            
        var result = await _categoryRepository.GetCategoryAsync(id, trackChanges: false);
        var category = _mapper.Map<CategoryDto>(result);

        return Ok(category);
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ClueDto))]
    [Route("{id:int}/random")]
    public async Task<IActionResult> GetRandomClue(int id, [FromQuery] RandomClueParameters randomClueParameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
 
        var cluesWithMetaData = await _categoryRepository.GetRandomClueAsync(id, randomClueParameters,trackChanges: false);

        var clues = _mapper.Map<List<ClueDto>>(cluesWithMetaData);

        Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(cluesWithMetaData.MetaData));
        return Ok(clues);
    }
}
