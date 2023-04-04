using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MercadinhoWeb.Application.Queries.Responses;

public class GetCategoryReponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}