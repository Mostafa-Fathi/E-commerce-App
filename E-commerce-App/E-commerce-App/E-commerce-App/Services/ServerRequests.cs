﻿using E_commerce_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace E_commerce_App.Services
{
    public class ServerRequests
{
    const string BaseURL= "https://803b-102-189-69-174.eu.ngrok.io";
    HttpClient httpClient = new HttpClient();
    public async Task<ObservableCollection<Category>> GetCategories(){
        // fake api 
        // const string CtegoryAPI = "https://fakestoreapi.com/products/categories";
        // ngrok api
        string CtegoryAPI = $"{BaseURL}/category";
        ObservableCollection<Category> categories;
        string categoriesAsString = await httpClient.GetStringAsync(CtegoryAPI);
        // await Application.Current.MainPage.DisplayAlert("AA", "categoriesAsString, "Ok");
        categories = JsonConvert.DeserializeObject<ObservableCollection<Category>>(categoriesAsString);
        return categories;
        }

    // Only used for get all products or products belong to specific category  
    public async Task<ObservableCollection<Product>> GetProducts(string url="")
    {
            // https://fakestoreapi.com/products/{url}
            //string ProductAPI = $"http://localhost:3000/products";
            string ProductAPI = $"{BaseURL}/products";
            ObservableCollection<Product> products;
        string productsAsString = await httpClient.GetStringAsync(ProductAPI);
        products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(productsAsString);
        return products;
    }
    public async Task<Product> GetSelectedProduct(string id = "")
        {
            // fake api => https://fakestoreapi.com/products/{id}
            //string ProductAPI = $"http://localhost:3000/products/{id}";
            string ProductAPI = $"{BaseURL}/products/{id}";
            Product product;
            string productsAsString = await httpClient.GetStringAsync(ProductAPI);
            product = JsonConvert.DeserializeObject<Product>(productsAsString);
            return product;
        }

    public async Task<User> Login(string userName="Defualt")
        {
            //string LoginAPI = $"http://localhost:3000/users?username={userName}";
            string LoginAPI = $"{BaseURL}/users?username={userName}";
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
