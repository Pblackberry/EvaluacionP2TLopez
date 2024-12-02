using EvaluacionP2TLopez.ModelsTLopez;
using Newtonsoft.Json;

namespace EvaluacionP2TLopez.ViewsTomasLopez;

public partial class TLopezUsuarioView : ContentPage
{
    TLopezUsuario usuario = new TLopezUsuario();
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "LopezTomas.txt");
    public TLopezUsuarioView()
    {
        InitializeComponent();
        usuario = Devuelve_Usuario();

        BindingContext = usuario;
    }

    private async void Tlopez_GuardarUsuario_Clicked(object sender, EventArgs e)
    {
        TLopezUsuario usuario = new TLopezUsuario()
        {
            Numero = Tlopez_EditorNum.Text,
            Nombre = Tlopez_EditorName.Text
        };
        bool guardar_usuario=Crear_Archivo_Usuario(usuario);
        if (guardar_usuario)
        {
            await DisplayAlert("Alerta", "Numero guardado con exito", "ok");
        }
        else
        {
            await DisplayAlert("Alerta", "Error al guardar", "ok");
        }


    }
    public bool Crear_Archivo_Usuario(TLopezUsuario usuario) {
        
        try
        {
            string jsonData = JsonConvert.SerializeObject(usuario);
            File.WriteAllText(_fileName, jsonData);
            return true;
        }
        catch (Exception)
        {
            throw;
        }
        
    }
    public TLopezUsuario Devuelve_Usuario()
    {
        TLopezUsuario usuario = new TLopezUsuario();
        if (File.Exists(_fileName))
        {
            string json_data = File.ReadAllText(_fileName);
            usuario = JsonConvert.DeserializeObject<TLopezUsuario>(json_data);
        }
        return usuario;
    }
    
        
}

    





    
