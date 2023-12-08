namespace DemoTestAPI.DTOs
{
    public record struct CustomerCreateDto(string Name, OrderCreateDto Order, List<ProductCreateDto> Products, List<CourierCreateDto> Couriers);
}
