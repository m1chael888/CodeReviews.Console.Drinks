using DrinksInfo.m1chael888.Views;
using DrinksInfo.m1chael888.Services;
using DrinksInfo.m1chael888.Models;
using static DrinksInfo.m1chael888.Enums.MainMenuEnums;

namespace DrinksInfo.m1chael888.Controllers
{
    public class DrinksController
    {
        private IDrinksView _drinksView;
        private IDrinksService _drinksService;
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

        private void HandleDrinkChoice(Category categoryChoice)
        {
            var drinks = _drinksService.GetDrinks(categoryChoice.strCategory);
            var drinkChoice = _drinksView.ShowDrinkPrompt(drinks);
            _drinksView.ShowDrinkInfo(drinkChoice);
        }
    }
}