﻿namespace MercadinhoWeb.Application.Queries.Responses;

public class GetProductByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
    public GetCategoryReponse Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
