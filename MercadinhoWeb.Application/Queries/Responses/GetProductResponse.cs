using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MercadinhoWeb.Application.Queries.Responses;

public class GetProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
    public GetCategoryReponse Category { get; set; }
}
