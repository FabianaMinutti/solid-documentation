#region Código com violação de ISP-DIP
//Aqui, SimplePrinter precisa implementar Scan(), mesmo sem suporte para isso.

public interface IPrinter
{
    void Print();
    void Scan();
}

public class SimplePrinter : IPrinter
{
    public void Print() => Console.WriteLine("Imprimindo...");

    public void Scan()
    {
        throw new NotImplementedException(); // Não deveria existir aqui!
    }
}

#endregion

#region Pós ajuste
//Agora, IPrinter e IScanner são interfaces separadas.

public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public class SimplePrinter : IPrinter
{
    public void Print() => Console.WriteLine("Imprimindo...");
}

public class MultifunctionPrinter : IPrinter, IScanner
{
    public void Print() => Console.WriteLine("Imprimindo...");
    public void Scan() => Console.WriteLine("Escaneando...");
}

#endregion