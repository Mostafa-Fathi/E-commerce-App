using E_commerce_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_App.Services
{
    public class ServerRequests
{
    HttpClient httpClient = new HttpClient();
    public async Task<ObservableCollection<string>> GetCategories()
    {
        const string CtegoryAPI = "https://fakestoreapi.com/products/categories";
        ObservableCollection<string> categories;
        string categoriesAsString = await httpClient.GetStringAsync(CtegoryAPI);
        categories = JsonConvert.DeserializeObject<ObservableCollection<string>>(categoriesAsString);
        return categories;
    }

    // Only used for get all products or products belong to specific category
    
     public async Task<ObservableCollection<Product>> GetProducts(string url="")
    {
        string ProductAPI = $"https://fakestoreapi.com/products/{url}";
        ObservableCollection<Product> products;
        string productsAsString = await httpClient.GetStringAsync(ProductAPI);
        products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(productsAsString);
        return products;
    }
    public async Task<Product> GetSelectedProduct(string url = "")
        {
            string ProductAPI = $"https://fakestoreapi.com/products/{url}";
            Product product;
            string productsAsString = await httpClient.GetStringAsync(ProductAPI);
            product = JsonConvert.DeserializeObject<Product>(productsAsString);
            return product;
        }

    }
}
