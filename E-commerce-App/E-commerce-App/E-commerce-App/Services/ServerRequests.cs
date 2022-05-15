using E_commerce_App.Models;
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


    const string BaseURL= "https://c0aa-84-233-75-84.eu.ngrok.io";
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
        public async Task<ObservableCollection<Product>> GetSelectedProducts(string categoryName = "")
        {
            //fake api => https://fakestoreapi.com/ 
            //string ProductAPI = $"http://localhost:3000/products/{id}";
            string ProductAPI = $"{BaseURL}/products?category={categoryName}";
            ObservableCollection<Product> products;
            string productsAsString = await httpClient.GetStringAsync(ProductAPI);
            products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(productsAsString);
            return products;
        }
        public async Task<bool> SignUp(User user)
        {
            // fake api => https://fakestoreapi.com/products/{id}
            //string ProductAPI = $"http://localhost:3000/products/{id}";
            string SginUpAPI = $"{BaseURL}/users/";
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var httpResponse = await httpClient.PostAsync(SginUpAPI,data);
            return httpResponse.IsSuccessStatusCode;
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
        public async Task<User> CheckEmail(string email = "Defualt")
        {
            string LoginAPI = $"{BaseURL}/users?email={email}";
            string response = await httpClient.GetStringAsync(LoginAPI);
            ObservableCollection<User> result = JsonConvert.DeserializeObject<ObservableCollection<User>>(response);
            if (result.Count > 0)
            {
                return result[0];
            }
            return null;
        }
        public async Task<int> addProductToCart(CartProductItem product )
        {
            //product.quantity = 1;
            string CartAPI = $"{BaseURL}/cart";
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync(CartAPI, data);
            return (int)httpResponse.StatusCode;
        }
        public async Task<bool> removeFromCart(int productId)
        {
            string CartAPI = $"{BaseURL}/cart/{productId}";
            var httpResponse = await httpClient.DeleteAsync(CartAPI);
            return httpResponse.IsSuccessStatusCode;
        }
        public async Task<ObservableCollection<CartProductItem>> getProductFromCart()
        {
            string CartAPI = $"{BaseURL}/cart";
            string cartAsString =await httpClient.GetStringAsync(CartAPI);
            ObservableCollection<CartProductItem> Cart;
            Cart = JsonConvert.DeserializeObject<ObservableCollection<CartProductItem>>(cartAsString);
            return Cart;
        }
        public async Task<bool> addRemoveFavourites(Product product)
        {
            string ProductAPI = $"{BaseURL}/products/{product.id}";
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PutAsync(ProductAPI,data);
            return httpResponse.IsSuccessStatusCode;
        }
        public async Task<ObservableCollection<Product>> GetFavProducts(string categoryName = "")
        {
            string ProductAPI = $"{BaseURL}/isFavourite?isFavourite={true}";
            ObservableCollection<Product> products;
            string productsAsString = await httpClient.GetStringAsync(ProductAPI);
            products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(productsAsString);
            return products;
        }

    }
    
}
