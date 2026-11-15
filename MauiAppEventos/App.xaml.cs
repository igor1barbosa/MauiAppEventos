using System.Globalization;
using MauiAppEventos.Views;

namespace MauiAppEventos;

public partial class App : Application
{
    public App()
    {
        // Fixa pt-BR para que {0:C} e {0:dd/MM/yyyy} saiam como R$ 1.000,00 e 10/12/2026
        // mesmo se o emulador estiver configurado em outro idioma.
        var ptBR = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = ptBR;
        CultureInfo.DefaultThreadCurrentUICulture = ptBR;
        CultureInfo.CurrentCulture = ptBR;
        CultureInfo.CurrentUICulture = ptBR;

        InitializeComponent();
    }

    // Forma atual de definir a página inicial (MainPage está obsoleto no .NET 10).
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new CadastroEvento()));
    }
}
