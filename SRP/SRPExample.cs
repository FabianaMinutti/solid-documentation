#region Código com violação de SRP
//O problema aqui é que a classe ReportService tem duas responsabilidades: gerar o relatório e enviar e-mails

public class ReportService
{
    public string GenerateReport()
    {
        return "Relatório gerado com sucesso!";
    }

    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Enviando email para {email}: {message}");
    }
}

// Uso da classe
class Program
{
    static void Main()
    {
        var reportService = new ReportService();
        string report = reportService.GenerateReport();
        reportService.SendEmail("user@example.com", report);
    }
}

#endregion

#region Pós ajuste
//Agora, ReportGenerator cuida do relatório e EmailService cuida dos e-mails.
public class ReportGenerator
{
    public string GenerateReport()
    {
        return "Relatório gerado com sucesso!";
    }
}

public class EmailService
{
    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"Enviando email para {email}: {message}");
    }
}

class Program
{
    static void Main()
    {
        var reportGenerator = new ReportGenerator();
        var emailService = new EmailService();

        string report = reportGenerator.GenerateReport();
        emailService.SendEmail("user@example.com", report);
    }
}

#endregion