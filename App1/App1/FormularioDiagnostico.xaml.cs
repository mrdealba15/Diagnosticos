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
    public partial class FormularioDiagnostico : ContentPage
    {
        public event EventHandler DiagnosticCreated;
        public string Diagnostic;

        public FormularioDiagnostico(Paciente paciente, string diagnostico = null, bool edit = false)
        {
            Title = paciente.NombreCompleto;
            InitializeComponent();
            if (diagnostico != null)
            {
                DiagnosticoT.Text = diagnostico;
               
            }
        }

        private void Crear(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DiagnosticoT.Text))
            {
                DisplayAlert("Error!", "Ha olvidado ingresar el diagnóstico", "Aceptar");
                return;
            }

            Diagnostic = DiagnosticoT.Text;
            DiagnosticCreated?.Invoke(this, EventArgs.Empty);
            Navigation.PopModalAsync(true);
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}