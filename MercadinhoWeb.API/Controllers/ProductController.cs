using MediatR;
using MercadinhoWeb.Application.Commands.Requests;
using MercadinhoWeb.Application.Queries.Requests;
using MercadinhoWeb.Infra.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MercadinhoWeb.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] string searchTerm = "", [FromQuery] string categoryId = "", [FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var query = new GetProductsQuery
        {
            SearchTerm = searchTerm,
            CategoryId = categoryId,    
            Skip = skip,
            Take = take
        };

        try
        {
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar obter produtos.");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:Guid}", Name = "GetById")]
    public async Task<ActionResult> GetById(Guid id)
    {
        try
        {
            var productResponse = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(productResponse);

        }catch(ResourceNotFoundException ex)
        {
            return NotFound();

        }catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar obter produto por id.");
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateProductRequest comando)
    {
        try
        {
            var productResponse = await _mediator.Send(comando);
            return new CreatedAtRouteResult("GetById", new { id = productResponse.Id }, productResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar registrar produto.");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteProductRequest() { Id = id });
            return NoContent();
        }
        catch(ResourceNotFoundException ex)
        {
            return NotFound();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar deletar produto.");
            return BadRequest(ex.Message);
        }
    }
}
