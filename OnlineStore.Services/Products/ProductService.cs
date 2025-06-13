using OnlineStore.Core.Common;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Interfaces;
using OnlineStore.Core.Models;
using Type = OnlineStore.Core.Models.Type;

namespace OnlineStore.Services.Products;

public class ProductService : IProductService
{
    private readonly IBrandRepository _brandRepository;
    private readonly ITypeRepository _typeRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IProductsRepository _productsRepository;
    private readonly IUserRepository _userRepository;

    public ProductService(
        IBrandRepository brandRepository,
        ITypeRepository typeRepository,
        ICountryRepository countryRepository,
        IProductsRepository productsRepository,
        IUserRepository userRepository)
    {
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _countryRepository = countryRepository;
        _productsRepository = productsRepository;
        _userRepository = userRepository;
    }

    #region Brand Operations
    
    public async Task<OperationResult> AddBrand(Brand brand, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _brandRepository.AddBrand(brand, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateBrand(int id, Brand brand, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _brandRepository.UpdateBrand(id, brand, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteBrand(int id, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _brandRepository.DeleteBrand(id, CancellationToken.None);
    }

    public async Task<OperationResult<List<Brand>>> GetBrands(User currentUser)
    {
        // Все пользователи могут просматривать бренды
        return await _brandRepository.GetBrands(CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Brand>>> SearchBrands(
        SearchRequest<string> request, User currentUser)
    {
        // Все пользователи могут искать бренды
        return await _brandRepository.SearchBrand(request, CancellationToken.None);
    }
    
    #endregion

    #region Type Operations
    
    public async Task<OperationResult> AddType(Type type, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _typeRepository.AddType(type, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateType(int updateId, Type updateTo, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _typeRepository.UpdateType(updateId, updateTo, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteType(Type type, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _typeRepository.DeleteType(type, CancellationToken.None);
    }

    public async Task<OperationResult<List<Core.Models.Type>>> GetTypes(User currentUser)
    {
        // Все пользователи могут просматривать типы
        return await _typeRepository.GetTypes(CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Type>>> SearchTypes(
        SearchRequest<string> request, User currentUser)
    {
        // Все пользователи могут искать типы
        return await _typeRepository.SearchTypes(request, CancellationToken.None);
    }
    
    #endregion

    #region Country Operations
    
    public async Task<OperationResult> AddCountry(Country country, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _countryRepository.AddCountry(country, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateCountry(int id, Country country, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _countryRepository.UpdateCountry(id, country, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteCountry(int? id, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _countryRepository.DeleteCountry(id, CancellationToken.None);
    }

    public async Task<OperationResult<List<Country>>> GetCountries(User currentUser)
    {
        // Все пользователи могут просматривать страны
        return await _countryRepository.GetCountries(CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Country>>> SearchCountries(
        SearchRequest<string> request, User currentUser)
    {
        // Все пользователи могут искать страны
        return await _countryRepository.SearchTypes(request, CancellationToken.None);
    }
    
    #endregion

    #region Product Operations
    
    public async Task<OperationResult> AddProduct(Product product, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _productsRepository.AddProduct(product, CancellationToken.None);
    }

    public async Task<OperationResult> UpdateProduct(Product product, User currentUser)
    {
        if (!IsAdmin(currentUser) && !IsManager(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _productsRepository.UpdateProduct(product, CancellationToken.None);
    }

    public async Task<OperationResult> DeleteProduct(Product product, User currentUser)
    {
        if (!IsAdmin(currentUser))
            return OperationResult.Fail("Недостаточно прав для выполнения операции");

        return await _productsRepository.DeleteProduct(product, CancellationToken.None);
    }

    public async Task<OperationResult<PaginatedResult<Product>>> SearchProducts(
        SearchRequest<ProductsParamets> request, User currentUser)
    {
        // Все пользователи могут искать продукты
        return await _productsRepository.SearchProducts(request, CancellationToken.None);
    }
    
    #endregion

    #region Helper Methods
    
    private bool IsAdmin(User user)
    {
        return user?.Role?.Name?.ToLower() == "админ";
    }

    private bool IsManager(User user)
    {
        return user?.Role?.Name?.ToLower() == "менеджер";
    }

    private bool IsClient(User user)
    {
        return user?.Role?.Name?.ToLower() == "клиент";
    }
    
    #endregion
}