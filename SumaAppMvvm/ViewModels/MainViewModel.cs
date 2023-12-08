
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SumaAppMvvm.ViewModels
{
    internal partial class MainViewModel: ObservableObject 
    {
        [ObservableProperty]
        private String? dato1;
        
        [ObservableProperty]
        private String? dato2;
        
        [ObservableProperty]
        private String? respuesta;

        [RelayCommand]
        public void Sumar()
        {
            if (Dato1 == null || !int.TryParse(Dato1, out int n1))
            {
                Respuesta = "Problema Dato 1";
                return;
            }
            if (Dato2 == null || !int.TryParse(Dato2, out int n2))
            {
                Respuesta = "Problema Dato 2";
                return;
            }
            Respuesta = (n1 + n2) + "";
        }

        [RelayCommand]
        public void LimpiarDatos()
        {
            Dato1 = "";
            Dato2 = "";
            Respuesta = "";
            MostrarNotificacion("Datos borrados");
        }

               private void MostrarNotificacion(string mensaje)
       {

           MainThread.BeginInvokeOnMainThread(async () =>
           {
               await App.Current.MainPage.DisplayAlert("Notificación", mensaje, "OK");
           });
       }

    }
}
