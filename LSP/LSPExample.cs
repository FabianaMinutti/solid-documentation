#region Código com violação de LSP
//Aqui, Penguin herda de Bird, mas não pode voar. Isso quebra o comportamento esperado.
public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("O pássaro está voando.");
    }
}

public class Sparrow : Bird { }

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new Exception("Pinguins não podem voar!");
    }
}

class Program
{
    static void Main()
    {
        Bird bird = new Penguin();
        bird.Fly(); // Vai gerar erro!
    }
}

#endregion

#region Pós ajuste
//Agora, Bird não define Fly(), e FlyingBird separa pássaros que voam.
public abstract class Bird
{
    public abstract void Eat();
}

public abstract class FlyingBird : Bird
{
    public abstract void Fly();
}

public class Sparrow : FlyingBird
{
    public override void Fly() => Console.WriteLine("Pardal voando...");
    public override void Eat() => Console.WriteLine("Pardal comendo...");
}

public class Penguin : Bird
{
    public override void Eat() => Console.WriteLine("Pinguim comendo...");
}

class Program
{
    static void Main()
    {
        Bird penguin = new Penguin();
        penguin.Eat();

        FlyingBird sparrow = new Sparrow();
        sparrow.Fly();
    }
}

#endregion