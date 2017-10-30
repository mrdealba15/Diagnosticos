using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioPaciente : ContentPage
    {
        public event EventHandler CreatedPatient;
        public Paciente Paciente;

        public FormularioPaciente(Paciente paciente = null)
        {
            InitializeComponent();
            if (paciente != null)
            {
                NombreT.Text = paciente.Nombre;
                ApellidoT.Text = paciente.Apellido;
            }
        }

        private void Crear(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreT.Text) || string.IsNullOrWhiteSpace(ApellidoT.Text))
            {
                DisplayAlert("Error!", "Datos faltantes!", "Aceptar");
                return;
            }

            Paciente = new Paciente()
            {
                Nombre = NombreT.Text,
                Apellido = ApellidoT.Text
            };

            CreatedPatient?.Invoke(this, EventArgs.Empty);
            Navigation.PopModalAsync(true);
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}