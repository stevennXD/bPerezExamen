using Microsoft.Maui.Controls.Shapes;

namespace bPerezExamen.Views;

public partial class Login : ContentPage
{
    string[,] usuarios = {
            { "estudiante2024", "uisrael2024" },
            { "examen1", "parcial1" },
            { "NombreEstudiante", "2024" }
        };

    public Login()
	{
		InitializeComponent();

        txtUsuario.Text = "";
        txtPassword.Text = "";
	}

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        bool encontrado = BuscarUsuario(usuarios, txtUsuario.Text, txtPassword.Text);

        if (encontrado)
        {
            Navigation.PushAsync(new Views.Registro(txtUsuario.Text));
        }
        else
        {
            DisplayAlert("Error", "Credenciales no validas", "Cerrar");
            Console.WriteLine("Usuario o contraseña incorrectos.");
        }

    }

    private void btnAcerca_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Acerca de", "Examen Desarrollo para aplicaciones móviles.\nDesarrollado por: Bryan Steven Perez.\n2024", "Cerrar");

    }
    private bool BuscarUsuario(string[,] usuarios, string usuario, string contraseña)
    {
        int filas = usuarios.GetLength(0);

        for (int i = 0; i < filas; i++)
        {
            if (usuarios[i, 0] == usuario && usuarios[i, 1] == contraseña)
            {
                return true;
            }
        }

        return false;
    }
}