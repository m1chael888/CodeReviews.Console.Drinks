using Newtonsoft.Json;

namespace DrinksInfo.m1chael888.Models;

public class Category
{
    public string strCategory {  get; set; } = string.Empty;
}
public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList {  get; set; }
}