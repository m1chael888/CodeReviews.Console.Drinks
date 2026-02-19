using DrinksInfo.m1chael888.Views;
using DrinksInfo.m1chael888.Services;
using DrinksInfo.m1chael888.Models;
using static DrinksInfo.m1chael888.Enums.MainMenuEnums;
using Spectre.Console;

namespace DrinksInfo.m1chael888.Controllers;

public class DrinksController
{
    private readonly IDrinksView _drinksView;
    private readonly IDrinksService _drinksService;
    public DrinksController(IDrinksView tableView, IDrinksService drinksService)
    {
        _drinksView = tableView;
        _drinksService = drinksService;
    }

    public void HandleMainMenu()
    {
        var choice = _drinksView.ShowMainMenu();

        switch (choice)
        {
            case MainMenuOption.ViewCategories:
                try
                {
                    HandleCategoryChoice();
                }
                catch (Exception ex)
                {
                    _drinksView.ShowAccessError(ex.Message);
                }
                break;
            case MainMenuOption.Exit:
                Environment.Exit(0);
                break;
        }
    }

    private void HandleCategoryChoice()
    {
        var categories = _drinksService.GetCategories();
        if (categories.Count == 0)
        {
            ReturnStatus("Drinks menu currently unnavailable");
        }
        else
        {
            var categoryChoice = _drinksView.ShowCategoryPrompt(categories);
            try
            {
                HandleDrinkChoice(categoryChoice);
            }
            catch (Exception ex)
            {
                _drinksView.ShowAccessError(ex.Message);
            }
        }
    }

    private void HandleDrinkChoice(Category categoryChoice)
    {
        var drinks = _drinksService.GetDrinks(categoryChoice.strCategory);
        if (drinks.Count == 0)
        {
            ReturnStatus("Drinks menu currently unnavailable");
        }
        else
        {
            var drinkChoice = _drinksView.ShowDrinkPrompt(drinks);
            _drinksView.ShowDrinkInfo(drinkChoice);
        }
        
    }

    private void ReturnStatus(string msg)
    {
        AnsiConsole.MarkupLine($"[cyan]{msg}[/]");
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Point)
            .SpinnerStyle("white")
            .Start($"[grey74]Press any key to return[/]", x =>
            {
                Console.ReadKey();
            });
    }
}