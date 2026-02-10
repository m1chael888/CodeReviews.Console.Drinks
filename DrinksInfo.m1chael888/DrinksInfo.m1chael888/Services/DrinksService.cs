using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.m1chael888.Models;

namespace DrinksInfo.m1chael888.Services
{
    public interface IDrinksService
    {
        List<Category> GetCategories();
        List<Drink> GetDrinks(string category);
    }
    public class DrinksService : IDrinksService
    {
        private readonly string _drinkClient = "https://www.thecocktaildb.com/api/json/v1/1/";
        public List<Category> GetCategories()
        {
            var client = new RestClient(_drinkClient);
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseString = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(responseString);

                List<Category> categories = serialize.CategoriesList;

                return categories;
            }
            return new List<Category> { };
        }

        public List<Drink> GetDrinks(string category)
        {
            var client = new RestClient(_drinkClient);
            var request = new RestRequest($"filter.php?c={category}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseString = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(responseString);

                List<Drink> drinks = serialize.DrinkList;

                return drinks;
            }
            return new List<Drink> { };
        }
    }
}