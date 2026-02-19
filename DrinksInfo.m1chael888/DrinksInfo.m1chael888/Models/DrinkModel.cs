using Newtonsoft.Json;

namespace DrinksInfo.m1chael888.Models;

public class Drink
{
    public string strDrink { get; set; } = string.Empty;
    public int idDrink { get; set; }
    public string strDrinkThumb { get; set; } = string.Empty;
}

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink> DrinkList { get; set; }
}
