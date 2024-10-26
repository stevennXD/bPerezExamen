namespace bPerezExamen.Views;

public partial class Registro : ContentPage
{
    int costoUPS = 300;
    string currentUser = "";
    double pagoTotal = 0;

	public Registro()
	{
		InitializeComponent();
    }
    public Registro(string user)
    {
        InitializeComponent();

        if (!string.IsNullOrEmpty(user)) {
            currentUser = user;
            
            lblUsuarioConectado.Text = "Bienvenido: " + user;
        }
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtMontoInicial.Text) == true
            || string.IsNullOrEmpty(txtCoutaMensual.Text) == true)
        {
            DisplayAlert("Error", "Debe realizar el proceso de selección de UPS", "Cerrar");

            return;
        }

        Navigation.PushAsync(new Views.Resumen(txtUsuario.Text, txtApellido.Text, pickerVoltiamperios.SelectedItem.ToString(), fechaPicker.Date, pickerCiudad.SelectedItem.ToString(), txtMontoInicial.Text, txtCoutaMensual.Text, pagoTotal.ToString(), currentUser));

    }

    private void btnCalcularPagoMensual_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtUsuario.Text) == true
            || string.IsNullOrEmpty(txtApellido.Text) == true
            || pickerVoltiamperios.SelectedIndex == -1
            || fechaPicker.Date == DateTime.MinValue
            || pickerCiudad.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Debe ingresar todo los datos", "Cerrar");

            return;
        }

        double montoInicialUPS = costoUPS * 0.15;
        double saldoUPS = costoUPS - montoInicialUPS;

        double costoCuota = saldoUPS / 3;
        double ivaCouta = costoCuota * 0.05;

        double costoCuotaTotal = costoCuota + ivaCouta;

        pagoTotal = costoCuotaTotal * 3;

        txtMontoInicial.Text = montoInicialUPS.ToString();
        txtCoutaMensual.Text = costoCuotaTotal.ToString();
    }
}
