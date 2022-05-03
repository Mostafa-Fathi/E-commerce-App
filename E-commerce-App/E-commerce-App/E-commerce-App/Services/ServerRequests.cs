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
    public async Task<ObservableCollection<string>> GetCategories(){
            // fake api => https://fakestoreapi.com/products/categories
            const string CtegoryAPI = "http://localhost:3000/category";
        ObservableCollection<string> categories;
        string categoriesAsString = await httpClient.GetStringAsync(CtegoryAPI);
        categories = JsonConvert.DeserializeObject<ObservableCollection<string>>(categoriesAsString);
        return categories;
        }

    // Only used for get all products or products belong to specific category  
    public async Task<ObservableCollection<Product>> GetProducts(string url="")
    {
            // https://fakestoreapi.com/products/{url}
        string ProductAPI = $"http://localhost:3000/products";
        ObservableCollection<Product> products;
        string productsAsString = await httpClient.GetStringAsync(ProductAPI);
        products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(productsAsString);
        return products;
    }
    public async Task<Product> GetSelectedProduct(string id = "")
        {
            // fake api => https://fakestoreapi.com/products/{id}
            string ProductAPI = $"http://localhost:3000/products/{id}";
            Product product;
            string productsAsString = await httpClient.GetStringAsync(ProductAPI);
            product = JsonConvert.DeserializeObject<Product>(productsAsString);
            return product;
        }

    public async Task<User> Login(string userName="Defualt")
        {
            string LoginAPI = $"http://localhost:3000/users?username={userName}";
            string response = await httpClient.GetStringAsync(LoginAPI);
            ObservableCollection<User> result = JsonConvert.DeserializeObject<ObservableCollection<User>>(response);
            if (result.Count>0)
            {
                return result[0];
            }
            return null;
        }
    }
    
}
