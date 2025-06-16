using System.Threading.Tasks;
using OnlineStore.Core.Common.Pagination;
using OnlineStore.Core.Models;
using OnlineStore.Services.Orders;
using OnlineStore.Services.Products;
using Presentation.Common;
using Presentation.NavigationService;
using Presentation.Views;

namespace Presentation.Presenters
{
    public class ProductPresenter : BasePresenter<IProductView, User>
    {
        private readonly INavigationService _navigationService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        
        private const int PageSize = 20;
        private int _currentPage = 1;
        private bool _isLoadingData = false;

        public ProductPresenter(
            IProductView view,
            INavigationService navigationService,
            IOrderService orderService,
            IProductService productService) : base(view)
        {
            _navigationService = navigationService;
            _orderService = orderService;
            _productService = productService;

            View.SearchProducts += async () => await SearchProducts();
            View.SearchTypes += async () => await SearchTypes();
            View.SearchBrands += async () => await SearchBrands();
            View.SearchCountries += async () => await SearchCountries();
            View.PurchaseProduct += async () => await PurchaseProduct();
            View.NextPage += async () => await NextPage();
            View.PrevPage += async () => await PrevPage();
            
            // Подписка на события изменения выбранного элемента
            View.TypeSelectedIndexChanged += async (sender, e) => await OnTypeSelectedIndexChanged();
            View.BrandSelectedIndexChanged += async (sender, e) => await OnBrandSelectedIndexChanged();
            View.CountrySelectedIndexChanged += async (sender, e) => await OnCountrySelectedIndexChanged();
            View.PurchaseProduct += async () => await PurchaseProduct();
        }

        public override void Run(User arg)
        {
            View.CurrentUser = arg;
            
            // Initialize search requests
            View.SearchTypesRequest = new SearchRequest<string>("", PageSize, 0);
            View.SearchBrandsRequest = new SearchRequest<string>("", PageSize, 0);
            View.SearchCountriesRequest = new SearchRequest<string>("", PageSize, 0);
            
            // Load initial data
            _ = SearchTypes();
            _ = SearchBrands();
            _ = SearchCountries();
            
            View.Show();
            SearchProducts().ConfigureAwait(false);
        }

        private async Task OnTypeSelectedIndexChanged()
        {
            // Если текст пустой, но был выбран элемент - оставляем выбор
            if (View.SelectedType != null || string.IsNullOrWhiteSpace(View.SearchParameters.ProductType?.Name))
            {
                View.SearchParameters.ProductType = View.SelectedType;
                await SearchProducts(1);
            }
        }

        private async Task OnBrandSelectedIndexChanged()
        {
            if (View.SelectedBrand != null || string.IsNullOrWhiteSpace(View.SearchParameters.Brand?.Name))
            {
                View.SearchParameters.Brand = View.SelectedBrand;
                await SearchProducts(1);
            }
        }

        private async Task OnCountrySelectedIndexChanged()
        {
            if (View.SelectedCountry != null || string.IsNullOrWhiteSpace(View.SearchParameters.Country?.Name))
            {
                View.SearchParameters.Country = View.SelectedCountry;
                await SearchProducts(1);
            }
        }

        private async Task SearchProducts(int page = 1)
        {
            try
            {
                _currentPage = page;
                int offset = (page - 1) * PageSize;

                var request = new SearchRequest<ProductsParamets>(
                    View.SearchParameters,
                    Limit: PageSize,
                    Offset: offset);

                var result = await _productService.SearchProducts(request, View.CurrentUser);

                if (result.IsSuccess)
                {
                    View.PaginatedProducts = result.Data;
                    View.UpdatePaginationControls(
                        canGoBack: _currentPage > 1,
                        canGoForward: result.Data?.Pagination?.HasMore ?? false,
                        currentPage: _currentPage);
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при поиске продуктов: {ex.Message}");
            }
        }

        private async Task SearchTypes()
        {
            if (_isLoadingData) return;
            
            try
            {
                _isLoadingData = true;
                var result = await _productService.SearchTypes(View.SearchTypesRequest, View.CurrentUser);
                
                if (result.IsSuccess)
                {
                    View.PaginatedTypes = result.Data;
                    View.UpdateSearchControls();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при поиске типов: {ex.Message}");
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private async Task SearchBrands()
        {
            if (_isLoadingData) return;
            
            try
            {
                _isLoadingData = true;
                var result = await _productService.SearchBrands(View.SearchBrandsRequest, View.CurrentUser);
                
                if (result.IsSuccess)
                {
                    View.PaginatedBrands = result.Data;
                    View.UpdateSearchControls();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при поиске брендов: {ex.Message}");
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private async Task SearchCountries()
        {
            if (_isLoadingData) return;
            
            try
            {
                _isLoadingData = true;
                var result = await _productService.SearchCountries(View.SearchCountriesRequest, View.CurrentUser);
                
                if (result.IsSuccess)
                {
                    View.PaginatedCountries = result.Data;
                    View.UpdateSearchControls();
                }
                else
                {
                    View.ShowError(result.Message);
                }
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при поиске стран: {ex.Message}");
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private async Task NextPage()
        {
            await SearchProducts(_currentPage + 1);
        }

        private async Task PrevPage()
        {
            if (_currentPage > 1)
            {
                await SearchProducts(_currentPage - 1);
            }
        }

        private async Task PurchaseProduct()
        {
            if (View.SelectedProduct == null)
            {
                View.ShowError("Выберите продукт для покупки");
                return;
            }

            try
            {
                // Используем NavigationService для открытия формы покупки
                _navigationService.NavigateToPurchase(new (View.SelectedProduct, View.CurrentUser));
        
                // Обновляем список продуктов после покупки
                await SearchProducts(_currentPage);
            }
            catch (Exception ex)
            {
                View.ShowError($"Ошибка при оформлении покупки: {ex.Message}");
            }
        }
    }
}