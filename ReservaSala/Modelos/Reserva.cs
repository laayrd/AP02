using System.Reflection.Metadata;

namespace ConsoleApp.Modelos;

public class Reserva {
    private DateTime _data;
    private TimeSpan _hora;
    private int _capacidade;
    
    public DateTime Data { get {
        return _data;
    } }
    public TimeSpan Hora {get {
        return _hora;
    } }
    public string? DescricaoDaSala {get; }
    public int CapacidadeDaSala {get {
        return _capacidade;
    } }
    public List<string> ErrosDeValidacao = [];
    private readonly ConfiguracaoReserva configuracao;

    public Reserva(ConfiguracaoReserva configuracao, DateTime data, TimeSpan hora, string descricao, int capacidade) {
        this.configuracao = configuracao;
        DescricaoDaSala = descricao;
        RegistrarData(data);
        RegistrarHora(hora);
        RegistrarCapacidade(capacidade);

        if(!ValidarReserva()) {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }

    public void RegistrarData(DateTime data) {
        _data = data;
    }

    public void RegistrarHora(TimeSpan hora) {
        _hora = hora;
    }

    public void RegistrarCapacidade(int capacidade) {
        _capacidade = capacidade;
    }

    public bool ValidarReserva() {
        if (_data < configuracao.DataMinima) {
            ErrosDeValidacao.Add($"Data {_data.ToString("dd/MM/yyyy")} precisa ser no mínimo {configuracao.DataMinima.ToString("dd/MM/yyyy")}");
        }
        if (_data > configuracao.DataMaxima) {
            ErrosDeValidacao.Add($"Data {_data.ToString("dd/MM/yyyy")} precisa ser no máximo {configuracao.DataMaxima.ToString("dd/MM/yyyy")}");
        }
        if (_hora < configuracao.HoraMinima) {
            ErrosDeValidacao.Add($"Hora {_hora} deve ser no mínimo {configuracao.HoraMinima.ToString(@"hh\:mm")}");
        }
        if (_hora > configuracao.HoraMaxima) {
            ErrosDeValidacao.Add($"Hora {_hora} deve ser no máximo {configuracao.HoraMaxima.ToString(@"hh\:mm")}");
        }
        if (_capacidade <= 0) {
            ErrosDeValidacao.Add($"Capacide {_capacidade} inválida, valor precisa ser positivo");
        }
        if (_capacidade > 40) {
            ErrosDeValidacao.Add($"Capacidade {_capacidade} excede o limite máximo de 40 alunos");
        }
        if (string.IsNullOrWhiteSpace(DescricaoDaSala)) {
            ErrosDeValidacao.Add("Descrição da Sala é obrigatória.");
        }
        return ErrosDeValidacao.Count == 0;
    }
    public override string ToString() {
        return $"Sala: {DescricaoDaSala}\n Data: {_data:dd/MM/yyyy}\n Hora: {_hora:hh\\:mm}\n Capacidade: {CapacidadeDaSala} aluno(s)";
    }
}
