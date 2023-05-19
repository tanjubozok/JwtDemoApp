using AutoMapper;
using JwtDemo.DTOs.ProductDtos;
using JwtDemo.Entities.Concrete;
using JwtDemo.Repository.Abstract;
using JwtDemo.Service.Abstract;

namespace JwtDemo.Service.Manager;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductAddedDto> AddAsync(ProductAddDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        var result = await _productRepository.AddAsync(product);
        _ = await _unitOfWork.SaveChangesAsync();
        var productDto = _mapper.Map<ProductAddedDto>(result);
        return productDto;
    }

    public async Task Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is not null)
        {
            _productRepository.Delete(product);
            _ = _unitOfWork.SaveChanges();
        }
    }

    public async Task<List<ProductListDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var dto = _mapper.Map<List<ProductListDto>>(products);
        return dto;
    }

    public async Task<ProductUpdateDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        var dto = _mapper.Map<ProductUpdateDto>(product);
        return dto;
    }

    public void Update(ProductUpdateDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        if (product is not null)
        {
            _productRepository.Update(product);
            _ = _unitOfWork.SaveChanges();
        }
    }
}
