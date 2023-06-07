using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Enter recipe details");
            Console.WriteLine("2. Display recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset quantities");
            Console.WriteLine("5. Clear recipe");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    recipe.EnterDetails();
                    break;
                case "2":
                    recipe.Display();
                    break;
                case "3":
                    recipe.Scale();
                    break;
                case "4":
                    recipe.ResetQuantities();
                    break;
                case "5":
                    recipe.Clear();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

class Recipe
{
    private List<Ingredient> ingredients;
    private List<string> steps;

    public Recipe()
    {
        ingredients = new List<Ingredient>();
        steps = new List<string>();
    }

    public void EnterDetails()
    {
        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Ingredient {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity (without unit of measurment: ");
            double quantity = double.Parse(Console.ReadLine());
            Console.Write("Unit of measurement: ");
            string unit = Console.ReadLine();

            Ingredient ingredient = new Ingredient(name, quantity, unit);
            ingredients.Add(ingredient);
        }

        Console.Write("Enter the number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());

        for (int i = 0; i < numSteps; i++)
        {
            Console.WriteLine($"Step {i + 1}:");
            Console.Write("Description: ");
            string description = Console.ReadLine();

            steps.Add(description);
        }
    }

    public void Display()
    {
        Console.WriteLine("Recipe:");
        Console.WriteLine("Ingredients:");
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    public void Scale()
    {
        Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
        double scalingFactor = double.Parse(Console.ReadLine());

        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.ScaleQuantity(scalingFactor);
        }
    }

    public void ResetQuantities()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            ingredient.ResetQuantity();
        }
    }

    public void Clear()
    {
        ingredients.Clear();
        steps.Clear();
    }
}

class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }

    private double originalQuantity;

    public Ingredient(string name, double quantity, string unit)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        originalQuantity = quantity;
    }

    public void ScaleQuantity(double scalingFactor)
    {
        Quantity = originalQuantity * scalingFactor;
    }

    public void ResetQuantity()
    {
        Quantity = originalQuantity;
    }
}
