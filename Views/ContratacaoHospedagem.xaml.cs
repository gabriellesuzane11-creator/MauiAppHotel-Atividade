
namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();
    }

    private async void Avancar_Clicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem == null)
        {
            await DisplayAlert("Atenção",
                "Selecione uma acomodação.", "OK");
            return;
        }

        if (stp_adultos.Value < 1)
        {
            await DisplayAlert("Atenção",
                "Informe pelo menos um adulto.", "OK");
            return;
        }

        if (dtpck_checkout.Date <= dtpck_checkin.Date)
        {
            await DisplayAlert("Atenção",
                "O check-out deve ser depois do check-in.", "OK");
            return;
        }

        string resumo =
            $"Acomodação: {pck_quarto.SelectedItem}\n" +
            $"Adultos: {stp_adultos.Value:0}\n" +
            $"Crianças: {stp_criancas.Value:0}\n" +
            $"Check-in: {dtpck_checkin.Date:dd/MM/yyyy}\n" +
            $"Check-out: {dtpck_checkout.Date:dd/MM/yyyy}";

        await Navigation.PushAsync(
            new HospedagemContratada(resumo));
    }

    private async void Sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
