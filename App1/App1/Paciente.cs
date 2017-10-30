using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace App1
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IList<string> Diagnosticos { get; } = new ObservableCollection<string>();

        public string NombreCompleto => Nombre + " " + Apellido;

        public string UltimoDiagnostico => string.IsNullOrEmpty(Diagnosticos.LastOrDefault())
            ? "Sin diagnósticos"
            : Diagnosticos.LastOrDefault();

        public void AgregarDiagnostico(string diagnostico)
        {
            Diagnosticos.Add(diagnostico);
        }

       
        public bool DeleteDiagnostico(string diagnostico)
        {
            return Diagnosticos.Remove(diagnostico);
        }
    }
}