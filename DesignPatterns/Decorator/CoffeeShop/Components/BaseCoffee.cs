using CoffeeShop.Interfaces;

namespace CoffeeShop.Components;

public abstract class BaseCoffee(string description, decimal baseCost, int baseCalories, string size) : ICoffee
{
  protected string _description = description;
  protected decimal _baseCost = baseCost;
  protected int _baseCalories = baseCalories;
  protected string _size = size;
  // TODO: Replace with your ingredient class/record
  protected List<string> _baseIngredients = [description];

  public virtual string GetDescription() => _description;
  public virtual decimal GetCost() => _baseCost;
  public virtual int GetCalories() => _baseCalories;
  public virtual string GetSize() => _size;
  public virtual List<string> GetIngredients() => [.. _baseIngredients];
}