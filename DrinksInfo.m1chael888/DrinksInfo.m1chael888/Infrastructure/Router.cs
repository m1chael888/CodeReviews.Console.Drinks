using DrinksInfo.m1chael888.Controllers;

namespace DrinksInfo.m1chael888.Infrastructure;

public interface IRouter
{
    void Route(DrinksController drinksController);
}
public class Router : IRouter
{
    public void Route(DrinksController drinksController)
    {
        while (true)
        {
            drinksController.HandleMainMenu();
        }
    }
}
