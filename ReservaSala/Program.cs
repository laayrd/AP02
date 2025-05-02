using System.Globalization;

using ConsoleApp.Modelos;

CultureInfo culturaBrasileira = new("pt-BR");

Console.WriteLine("Vamos Configurar a Reserva");

DateTime? dataMinima = null;
DateTime? dataMaxima = null;
TimeSpan? horaMinima = null;
TimeSpan? horaMaxima = null;

while (dataMinima == null) {
    Console.Write("Informe data mínima para reserva (dd/MM/yyyy): ");
    var entrada = Console.ReadLine();
    try {
        dataMinima = DateTime.ParseExact(entrada, "dd/MM/yyyy", culturaBrasileira);
    }
    catch {
        Console.WriteLine("Data inválida");
    }
}

while (dataMaxima == null) {
    Console.Write("Informe data máxima para reserva (dd/MM/yyyy): ");
    var entrada = Console.ReadLine();
    try {
        var data = DateTime.ParseExact(entrada, "dd/MM/yyyy", culturaBrasileira);
        if (data <= dataMinima)
            Console.WriteLine("Data máxima deve ser maior que a mínima.");
        else
            dataMaxima = data;
    }
    catch {
        Console.WriteLine("Data inválida");
    }
}

while (horaMinima == null) {
    Console.Write("Informe hora mínima para reserva (HH:mm): ");
    var entrada = Console.ReadLine();
    try {
        horaMinima = TimeSpan.ParseExact(entrada, "hh\\:mm", CultureInfo.InvariantCulture);
    }
    catch {
        Console.WriteLine("Hora inválida");
    }
}

while (horaMaxima == null) {
    Console.Write("Informe hora máxima para reserva (HH:mm): ");
    var entrada = Console.ReadLine();
    try {
        var hora = TimeSpan.ParseExact(entrada, "hh\\:mm", CultureInfo.InvariantCulture);
        if (hora <= horaMinima)
            Console.WriteLine("Hora máxima deve ser maior que a mínima.");
        else
            horaMaxima = hora;
    }
    catch {
        Console.WriteLine("Hora inválida");
    }
}

ConfiguracaoReserva configuracao;

try {
    configuracao = new ConfiguracaoReserva((DateTime)dataMinima, (DateTime)dataMaxima, (TimeSpan)horaMinima, (TimeSpan)horaMaxima);
    Console.WriteLine("\nConfiguração criada com sucesso!\n");
    Console.WriteLine(configuracao);
}
catch (ArgumentException e) {
    Console.WriteLine("Erro na configuração: " + e.Message);
    return;
}

