﻿using System.Net.Http;
using System.Runtime.InteropServices;

namespace BlazorEcommerce.Client.Services.ProductTypeService;

public class ProductTypeService : IProductTypeService
{
    private readonly HttpClient _httpClient;

    public ProductTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public event Action OnChange;
    public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();


    public async Task GetProductTypes()
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<ProductType>>>("api/ProductType");
        ProductTypes = result.Data;
    }

    public async Task AddProductType(ProductType productType)
    {
        var response = await _httpClient.PostAsJsonAsync("api/producttype", productType);
        ProductTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>()).Data;
        OnChange.Invoke();
    }

    public async Task UpdateProductType(ProductType productType)
    {
        var response = await _httpClient.PutAsJsonAsync("api/producttype", productType);
        ProductTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>()).Data;
        OnChange.Invoke();
    }

    public ProductType CreateProductType()
    {
        var newProductType = new ProductType() { IsNew = true, Editing = true };

        ProductTypes.Add(newProductType);
        OnChange.Invoke();
        return newProductType;
    }
}