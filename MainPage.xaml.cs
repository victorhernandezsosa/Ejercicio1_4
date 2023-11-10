using Ejercicio1_4.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        byte[] imageToSave;

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            var photoOptions = new MediaPickerOptions
            {
                Title = "Seleccionar foto"
            };

            var photo = await MediaPicker.CapturePhotoAsync(photoOptions);

            if (photo != null)
            {
                using (var stream = await photo.OpenReadAsync())
                {
                    imageToSave = GetImageBytes(stream);
                    img.Source = ImageSource.FromStream(() => new MemoryStream(imageToSave));
                }
            }
        }

        private async void btnSQlite_Clicked(object sender, EventArgs e)
        {
            var empleado = new Empleados
            {
                nombres = txtnombre.Text,
                descripcion = txtdescripcion.Text,
                imagen = imageToSave
            };

            var resultado = await App.BaseDatos.EmpleSave(empleado);

            if (resultado != 0)
            {
                await DisplayAlert("Atencion", "Persona ingresada correctamente!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Atencion", "Upps ha ocurrido un error inesperado", "Ok");
            }

            await Navigation.PopAsync();
        }

        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }
    }
}
