using JwtDemo.DTOs.ProductDtos;

namespace JwtDemo.Service.Abstract;

public interface IProductService
{
    Task<List<ProductListDto>> GetAllAsync();
    Task<ProductUpdateDto> GetByIdAsync(int id);
    Task<ProductAddedDto> AddAsync(ProductAddDto dto);
    void Update(ProductUpdateDto dto);
    Task Delete(int id);
}
