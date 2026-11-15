namespace MauiAppEventos.Models;

public class Evento
{
    public string Nome { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int NumParticipantes { get; set; }
    public string Local { get; set; } = string.Empty;
    public double CustoPorParticipante { get; set; }

    // DateTime - DateTime resulta em TimeSpan (como em Hospedagem.Estadia na Agenda 15).
    public TimeSpan Duracao => DataFim.Subtract(DataInicio);

    public int DuracaoDias => Duracao.Days;

    public double CustoTotal => NumParticipantes * CustoPorParticipante;
}
