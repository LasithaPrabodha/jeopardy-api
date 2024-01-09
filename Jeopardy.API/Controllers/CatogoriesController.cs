using System.Text.Json;
using AutoMapper;
using Jeopardy.API.DTO;
using Jeopardy.API.Interfaces;
using Jeopardy.API.Models;
using Jeopardy.API.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Jeopardy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _categoryRepository.GetCategoriesAsync(categoryParameters, trackChanges: false);
        var categories = _mapper.Map<List<CategoryDto>>(result);

        return Ok(categories);
    }
} 
