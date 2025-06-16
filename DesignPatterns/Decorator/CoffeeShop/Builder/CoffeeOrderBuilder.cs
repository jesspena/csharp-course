using CoffeeShop.Decorator;
using CoffeeShop.Interfaces;

namespace CoffeeShop.Builder;

// Order Builder: demonstrates complex decorator combinations
// This will func as a reduced director
public class CoffeeOrderBuilder(ICoffee baseCoffee)
{
  private ICoffee _coffee = baseCoffee ?? throw new ArgumentNullException(nameof(baseCoffee));

  public CoffeeOrderBuilder WithSize(string size)
  {
    //_coffee = new SizeDecorator(_cofee, size);

    return this;
  }

  public CoffeeOrderBuilder WithMilk(string milkType = "Rugular")
  {
    _coffee = new MilkDecorator(_coffee, milkType);

    return this;
  }

  public CoffeeOrderBuilder WithSugar(int packets = 1, string sugarType = "White")
  {
    _coffee = new SugarDecorator(_coffee, packets, sugarType);

    return this;
  }

  public ICoffee Build() => _coffee;
}