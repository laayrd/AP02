using System.Reflection.Metadata;

namespace ConsoleApp.Modelos;

public class ConfiguracaoReserva {
        public DateTime DataMinima { get; private set; }
        public DateTime DataMaxima { get; private set; }
        public TimeSpan HoraMinima { get; private set; }
        public TimeSpan HoraMaxima { get; private set; }

    public ConfiguracaoReserva(DateTime dataMinima, DateTime dataMaxima, TimeSpan horaMinima, TimeSpan horaMaxima) {
        if (dataMaxima <= dataMinima) {
            throw new ArgumentException("Data mínima deve ser menor que a data máxima");
        }
        if (horaMaxima <= horaMinima) {
            throw new ArgumentException("Hora mínima deve ser menor que a hora máxima");
        }

        DataMinima = dataMinima;
        DataMaxima = dataMaxima;
        HoraMinima = horaMinima;
        HoraMaxima = horaMaxima;
    }
    public override string ToString() {
        return $"Datas Permitidas: {DataMinima: dd/MM/yyyy} até {DataMaxima:dd/MM/yyyy}\nHorários permitidos: {HoraMinima:hh\\:mm} até {HoraMaxima:hh\\:mm}";

    }
}
