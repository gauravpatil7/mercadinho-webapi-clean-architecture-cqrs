﻿namespace MercadinhoWeb.Application.Commands.Responses
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
    }
}
