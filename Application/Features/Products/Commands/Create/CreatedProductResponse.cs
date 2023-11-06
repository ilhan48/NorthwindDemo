using Core.Application.Responses;

namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public short? SupplierId { get; set; }
    public short? CategoryId { get; set; }
    public string? QuantityPerUnit { get; set; }
    public float? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public int Discontinued { get; set; }
}