using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
   
    public partial class MainPage : ContentPage
	{
        
        private IList<Paciente> pacientes = new ObservableCollection<Paciente>();

        public MainPage()
		{
            Title = "Pacientes";
            InitializeComponent();
            BindingContext = pacientes;
        }

        private void AgregarPaciente(object sender, EventArgs e)
        {
            FormularioPaciente form = new FormularioPaciente();
            form.CreatedPatient += GuardarPaciente;
            Navigation.PushModalAsync(form, true);
        }

        private void GuardarPaciente(object sender, EventArgs e)
        {
            if (sender is FormularioPaciente form) pacientes.Add(form.Paciente);
        }


        private async void IraVistaPaciente(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Paciente paciente = e.SelectedItem as Paciente;
                DetallePaciente detail = new DetallePaciente(paciente, pacientes.IndexOf(paciente));
                detail.UpdatedPatient += ActualizarPaciente;
                await Navigation.PushAsync(detail, true);

                ((ListView)sender).SelectedItem = null;
            }
        }

        private void ActualizarPaciente(object sender, DetallePaciente.DetailArgs e)
        {
            pacientes[e.Pos] = e.Paciente;
        }


    }
}
