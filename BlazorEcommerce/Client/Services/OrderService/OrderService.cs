﻿using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace BlazorEcommerce.Client.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly NavigationManager _navigationManager;

    public OrderService(HttpClient httpClient, AuthenticationStateProvider autStateProvider, NavigationManager navigationManager)
    {
        this._httpClient = httpClient;
        _authStateProvider = autStateProvider;
        _navigationManager = navigationManager;
    }

    public async Task<string> PlaceOrder()
    {
        if (await IsUserAuthenticated())
        {
           var result = await _httpClient.PostAsync("api/payment/checkout", null);
           var url = await result.Content.ReadAsStringAsync();
           return url;
        }
        else
        {
            return "login";
        }
    }

    public async Task<List<OrderOverviewResponse>> GetOrders()
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
        return result.Data;
    }

    public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/Order/{orderId}");

        return result.Data;
    }


    public async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }
}