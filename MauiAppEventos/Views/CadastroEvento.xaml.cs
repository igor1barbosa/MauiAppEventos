using System.Globalization;
using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEvento : ContentPage
{
    public CadastroEvento()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_nome.Text))
                throw new Exception("Informe o nome do evento.");

            if (string.IsNullOrWhiteSpace(txt_local.Text))
                throw new Exception("Informe o local do evento.");

            // No .NET 10 o DatePicker.Date é DateTime? (pode ser vazio); usamos hoje como padrão.
            DateTime inicio = dtpck_inicio.Date ?? DateTime.Today;
            DateTime fim = dtpck_fim.Date ?? DateTime.Today;

            if (fim < inicio)
                throw new Exception("A data de término não pode ser anterior à data de início.");

            if (!int.TryParse(txt_participantes.Text, NumberStyles.None, CultureInfo.InvariantCulture, out int participantes)
                || participantes <= 0)
                throw new Exception("Informe um número de participantes maior que zero.");

            if (!TentarLerCusto(txt_custo.Text, out double custo) || custo < 0)
                throw new Exception("Informe um custo por participante válido (ex.: 50.00).");

            Evento evento = new Evento
            {
                Nome = txt_nome.Text.Trim(),
                DataInicio = inicio,
                DataFim = fim,
                NumParticipantes = participantes,
                Local = txt_local.Text.Trim(),
                CustoPorParticipante = custo,
            };

            await Navigation.PushAsync(new ResumoEvento
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    // Com vírgula ("12,50" ou "1.250,50") lê como pt-BR; sem vírgula ("12.50" ou "12") lê como invariante.
    private static bool TentarLerCusto(string? texto, out double valor)
    {
        valor = 0;
        if (string.IsNullOrWhiteSpace(texto))
            return false;

        texto = texto.Trim();
        CultureInfo cultura = texto.Contains(',')
            ? CultureInfo.GetCultureInfo("pt-BR")
            : CultureInfo.InvariantCulture;

        return double.TryParse(texto, NumberStyles.Number, cultura, out valor)
            && double.IsFinite(valor);
    }
}
