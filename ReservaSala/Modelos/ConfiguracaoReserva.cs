using System.Reflection.Metadata;

namespace ConsoleApp.Modelos;

public class ConfiguracaoReserva {
    private DateTime _dataMinima;
    private DateTime _dataMaxima;
    private TimeSpan _horaMinima;
    private TimeSpan _horaMaxima;

    public DateTime DataMinima { get {
        return _dataMinima;
    }}
    public DateTime DataMaxima { get {
        return _dataMaxima;
    } }
    public TimeSpan HoraMinima { get {
        return _horaMinima;
    } }
    public TimeSpan HoraMaxima { get {
        return _horaMaxima;
    } }
    public List<string> ErrosDeValidacao = [];    

    public ConfiguracaoReserva(DateTime dataMinima, DateTime dataMaxima, TimeSpan horaMinima, TimeSpan horaMaxima) {
        _dataMinima = dataMinima;
        _dataMaxima = dataMaxima;
        _horaMinima = horaMinima;
        _horaMaxima = horaMaxima;
        if (!validarConfiguracao()) {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }

    public bool validarConfiguracao() {
        if (_dataMinima <= DateTime.Today) {
            ErrosDeValidacao.Add("A data mínima não pode ser anterior à data de hoje");
        }
        if (_dataMaxima <= _dataMinima) {
            ErrosDeValidacao.Add("Data mínima deve ser menor que a data máxima");
        }
        if (_horaMaxima <= _horaMinima) {
            ErrosDeValidacao.Add("Hora mínima deve ser menor que a hora máxima");
        }
        return ErrosDeValidacao.Count == 0;
    }
    public override string ToString() {
        return $"Datas Permitidas: {DataMinima: dd/MM/yyyy} até {DataMaxima:dd/MM/yyyy}\nHorários permitidos: {HoraMinima:hh\\:mm} até {HoraMaxima:hh\\:mm}";

    }
}
