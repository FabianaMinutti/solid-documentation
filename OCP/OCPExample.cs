#region Código com violação de OCP
//Aqui, a classe CheckoutService precisa ser modificada toda vez que um novo desconto for adicionado.

public class CheckoutService
{
    public decimal CalculateTotal(decimal amount, string discountType)
    {
        if (discountType == "STANDARD")
            return amount * 0.9m;
        else if (discountType == "VIP")
            return amount * 0.8m;

        return amount;
    }
}

class Program
{
    static void Main()
    {
        var checkout = new CheckoutService();
        decimal total = checkout.CalculateTotal(100, "VIP");
        Console.WriteLine($"Total: {total}");
    }
}

#endregion

#region Pós ajuste
//Agora, novos descontos podem ser adicionados sem modificar CheckoutService.

public abstract class Discount
{
    public abstract decimal ApplyDiscount(decimal amount);
}

public class StandardDiscount : Discount
{
    public override decimal ApplyDiscount(decimal amount) => amount * 0.9m;
}

public class VipDiscount : Discount
{
    public override decimal ApplyDiscount(decimal amount) => amount * 0.8m;
}

public class CheckoutService
{
    public decimal CalculateTotal(decimal amount, Discount discount)
    {
        return discount.ApplyDiscount(amount);
    }
}

class Program
{
    static void Main()
    {
        var checkout = new CheckoutService();
        decimal total = checkout.CalculateTotal(100, new VipDiscount());
        Console.WriteLine($"Total com desconto VIP: {total}");
    }
}

#endregion