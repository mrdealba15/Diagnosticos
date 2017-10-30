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
    public partial class DetallePaciente: ContentPage
    {
        public event EventHandler<DetailArgs> UpdatedPatient;
        private int pos;
        private Paciente paciente;

        public DetallePaciente(Paciente paciente, int pos)
        {
            Title = paciente.NombreCompleto;
            InitializeComponent();
            this.paciente = paciente;
            this.pos = pos;
            BindingContext = this.paciente.Diagnosticos;
        }

        private void AgregarDiagnostico(object sender, EventArgs e)
        {
            FormularioDiagnostico form = new FormularioDiagnostico(paciente);
            form.DiagnosticCreated += GuardarDiagnostico;
            Navigation.PushModalAsync(form, true);
        }

        private void GuardarDiagnostico(object sender, EventArgs eventArgs)
        {
            if (sender is FormularioDiagnostico form) paciente.AgregarDiagnostico(form.Diagnostic);
        }

      

        private void EliminarDiagnostico(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            string diagnostico = item.CommandParameter as string;

            if (paciente.UltimoDiagnostico != diagnostico)
            {
                DisplayAlert("Error", "Solo se puede eliminar el último diagnostico!", "OK");
                return;
            }

            paciente.DeleteDiagnostico(diagnostico);
        }

        
        protected override void OnDisappearing()
        {
            UpdatedPatient?.Invoke(this, new DetailArgs() { Paciente = paciente, Pos = pos });
            base.OnDisappearing();
        }

        public class DetailArgs : EventArgs
        {
            public Paciente Paciente { get; set; }
            public int Pos { get; set; }
        }
    }
}