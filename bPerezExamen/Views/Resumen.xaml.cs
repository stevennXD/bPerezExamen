namespace bPerezExamen.Views;

public partial class Resumen : ContentPage
{
	public Resumen()
	{
		InitializeComponent();
    }
    public Resumen(string Nombre, string Apellido, string VA, DateTime Fecha, string Ciudad, string MontoInicial, string CoutaMensual, string PagoTotal, string user)
    {
        InitializeComponent();

        txtNombre.Text = Nombre;
        txtApellido.Text = Apellido;
        txtVA.Text = VA;
        txtFecha.Text = Fecha.ToShortDateString();
        txtCiudad.Text = Ciudad;
        txtMontoInicial.Text = MontoInicial;
        txtCoutaMensual.Text = CoutaMensual;
        txtPagoTotal.Text = PagoTotal;

        lblUsuarioConectado.Text = "Bienvenido: " + user;
    }

    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.Login());


    }
}