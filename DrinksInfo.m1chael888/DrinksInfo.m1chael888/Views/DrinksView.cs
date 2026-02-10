using Spectre.Console;
using DrinksInfo.m1chael888.Models;
using static DrinksInfo.m1chael888.Enums.Extensions;
using static DrinksInfo.m1chael888.Enums.MainMenuEnums;

namespace DrinksInfo.m1chael888.Views
{
    public interface IDrinksView
    {
        Category ShowCategoryPrompt(List<Category> categories);
        Drink ShowDrinkPrompt(List<Drink> drinks);
        void ShowDrinkInfo(Drink drink);
        MainMenuOption ShowMainMenu();
        void ShowAccessError(string msg);
    }
    public class DrinksView : IDrinksView
    {
        public MainMenuOption ShowMainMenu()
        {
            Console.Clear();
            return AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOption>()
                .Title("[cyan]Main Menu::[/]")
                .AddChoices(Enum.GetValues<MainMenuOption>())
                .UseConverter(x => $"[grey74]{GetDescription(x)}[/]")
                .HighlightStyle("DarkOrange")
                .WrapAround());
        }

        public Category ShowCategoryPrompt(List<Category> categories)
        {
            Console.Clear();
            return AnsiConsole.Prompt(
                new SelectionPrompt<Category>()
                .Title("[cyan]Choose a category to view::[/]")
                .AddChoices(categories)
                .UseConverter(x => $"[grey74]{x.strCategory}[/]")
                .HighlightStyle("DarkOrange")
                .PageSize(categories.Count)
                .WrapAround());
        }

        public Drink ShowDrinkPrompt(List<Drink> drinks)
        {
            Console.Clear();
            return AnsiConsole.Prompt(
                new SelectionPrompt<Drink>()
                .Title("[cyan]Choose a drink::[/]")
                .AddChoices(drinks)
                .UseConverter(x => $"[grey74]{x.strDrink}[/]")
                .HighlightStyle("DarkOrange")
                .PageSize(25)
                .WrapAround());
        }

        public void ShowDrinkInfo(Drink drink)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[cyan]Drink info::[/]\n");
            AnsiConsole.MarkupLine($" [darkorange]Name -[/] [grey74]{drink.strDrink}[/]");
            AnsiConsole.MarkupLine($"   [darkorange]Id -[/] [grey74]{drink.idDrink}[/]");
            AnsiConsole.MarkupLine($"[darkorange]Image -[/] [grey74]{drink.strDrinkThumb}[/]\n");
            ReturnToMenu();
        }

        public void ShowAccessError(string msg)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[cyan]Error: {msg}[/]");
            ReturnToMenu();
        }

        private void ReturnToMenu()
        {
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Point)
                .SpinnerStyle("grey74")
                .Start("[grey74]Press any key to return to menu[/]", x =>
                {
                    Console.ReadKey();
                });
        }
    }
}