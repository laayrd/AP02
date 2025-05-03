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
        Console.WriteLine($"{entrada} não é uma data válida");
    }
}

while (dataMaxima == null) {
    Console.Write("Informe data máxima para reserva (dd/MM/yyyy): ");
    var entrada = Console.ReadLine();
    try {
        var data = DateTime.ParseExact(entrada, "dd/MM/yyyy", culturaBrasileira);
        dataMaxima = data;
    }
    catch {
        Console.WriteLine($"{entrada} não é uma data válida");
    }
}

while (horaMinima == null) {
    Console.Write("Informe hora mínima para reserva (HH:mm): ");
    var entrada = Console.ReadLine();
    try {
        horaMinima = TimeSpan.ParseExact(entrada, "hh\\:mm", culturaBrasileira);
    }
    catch {
        Console.WriteLine($"{entrada} não é uma hora válida");
    }
}

while (horaMaxima == null) {
    Console.Write("Informe hora máxima para reserva (HH:mm): ");
    var entrada = Console.ReadLine();
    try {
        var hora = TimeSpan.ParseExact(entrada, "hh\\:mm", culturaBrasileira);
        horaMaxima = hora;
    }
    catch {
        Console.WriteLine($"{entrada} não é uma hora válida");
    }
}

ConfiguracaoReserva configuracao;

try {
    configuracao = new ((DateTime)dataMinima, (DateTime)dataMaxima, (TimeSpan)horaMinima, (TimeSpan)horaMaxima);
    Console.WriteLine("\nConfiguração criada com sucesso!\n");
    Console.WriteLine(configuracao);
}
catch (ArgumentException e) {
    Console.WriteLine("Erro na configuração: \n" + e.Message);
    return;
}

Console.WriteLine("\nVamos fazer uma reserva");

DateTime?  dataReserva = null;
TimeSpan?  horaReserva = null;
string? descricaoSalaReserva = null;
int capacidadeReserva = 0;

while (dataReserva == null) {
    Console.Write("Informe data para reserva (dd/MM/yyyy): ");
    var dataDigitada = Console.ReadLine();
    try {
        var data = DateTime.ParseExact(dataDigitada, "dd/MM/yyyy", culturaBrasileira);
        dataReserva = data;
    } catch (FormatException) {
        Console.WriteLine($"{dataDigitada} não é uma data válida");
    }
}

while (horaReserva == null) {
    Console.Write("Informe hora para a reserva (HH:mm): ");
    var horaDigitada = Console.ReadLine();
    try {
        var hora = TimeSpan.ParseExact(horaDigitada, "hh\\:mm", culturaBrasileira);
        horaReserva = hora;
    }
    catch {
        Console.WriteLine($"{horaDigitada} não é uma hora válida");
    }
}

while (descricaoSalaReserva == null) {
    Console.Write("Informe a descrição da sala para reserva: ");
    descricaoSalaReserva = Console.ReadLine();
}

while (true) {
    Console.Write("Informe a capacidade para a reserva: ");
    var entrada = Console.ReadLine();
    if (int.TryParse(entrada, out capacidadeReserva)) {
        break;
    }
    Console.WriteLine($"{entrada} não é uma capacidade válida");
}

try {
    Reserva reserva = new(configuracao, (DateTime)dataReserva, (TimeSpan)horaReserva, descricaoSalaReserva, capacidadeReserva);
    Console.WriteLine("Reserva criada com sucesso!\n");
    Console.WriteLine(reserva);
}
catch (ArgumentException e) {
    Console.WriteLine("Erro na reserva: \n" + e.Message);
    return;
}


