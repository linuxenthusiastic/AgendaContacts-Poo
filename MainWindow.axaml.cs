using Avalonia.Controls;
using Avalonia.Interactivity;
using ContactsAgenda.Models;
using ContactsAgenda.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContactsAgenda.Views;

public partial class MainWindow : Window
{
    private readonly Agenda agenda;
    private ObservableCollection<Contact> contactosVisibles;

    public MainWindow()
    {
        InitializeComponent();
        agenda = new Agenda();
        contactosVisibles = new ObservableCollection<Contact>();
        
        lstContactos.ItemsSource = contactosVisibles;
        
        AgregarContactosEjemplo();
        ActualizarLista();
    }

    private void AgregarContactosEjemplo()
    {
        agenda.AgregarContacto(new Contact("Tuto Quiroga", "555-1234", "tuto@email.com"));
        agenda.AgregarContacto(new Contact("Maria Galindo", "555-5678", "maria@email.com"));
        agenda.AgregarContacto(new Contact("Juan el mecanico", "555-9012", "susanabb@email.com"));
    }

    private void OnAgregarClick(object sender, RoutedEventArgs e)
    {
        var nombre = txtNombre.Text;
        var telefono = txtTelefono.Text;
        var email = txtEmail.Text;

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarMensaje("Por favor ingrese un nombre");
            return;
        }

        if (string.IsNullOrWhiteSpace(telefono))
        {
            MostrarMensaje("Por favor ingrese un teléfono");
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            MostrarMensaje("Por favor ingrese un email");
            return;
        }

        var nuevoContacto = new Contact(nombre, telefono, email);
        
        if (agenda.AgregarContacto(nuevoContacto))
        {
            ActualizarLista();
            LimpiarCampos();
            MostrarMensaje($"Contacto '{nombre}' agregado exitosamente");
        }
    }

    private void OnBuscarClick(object sender, RoutedEventArgs e)
    {
        var busqueda = txtBuscar.Text;
        
        if (string.IsNullOrWhiteSpace(busqueda))
        {
            ActualizarLista();
            return;
        }

        contactosVisibles.Clear();
        
        var contactoPorNombre = agenda.BuscarContacto(busqueda);
        if (contactoPorNombre != null)
        {
            contactosVisibles.Add(contactoPorNombre);
        }
        
        var contactoPorTelefono = agenda.BuscarPorNumero(busqueda);
        if (contactoPorTelefono != null && contactoPorTelefono != contactoPorNombre)
        {
            contactosVisibles.Add(contactoPorTelefono);
        }

        if (contactosVisibles.Count == 0)
        {
            MostrarMensaje($"No se encontraron contactos con '{busqueda}'");
        }
        
        ActualizarContador();
    }

    private void OnEliminarClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var nombreContacto = button?.CommandParameter as string;
        
        if (!string.IsNullOrEmpty(nombreContacto))
        {
            if (agenda.EliminarContacto(nombreContacto))
            {
                ActualizarLista();
                MostrarMensaje($"Contacto '{nombreContacto}' eliminado");
            }
        }
    }

    private void OnMostrarTodosClick(object sender, RoutedEventArgs e)
    {
        ActualizarLista();
        txtBuscar.Text = string.Empty;
    }

    private void OnLimpiarBusquedaClick(object sender, RoutedEventArgs e)
    {
        txtBuscar.Text = string.Empty;
        ActualizarLista();
    }

    private void OnLimpiarCamposClick(object sender, RoutedEventArgs e)
    {
        LimpiarCampos();
    }

    private void ActualizarLista()
    {
        contactosVisibles.Clear();
        var todosLosContactos = agenda.MostrarContactos();
        
        foreach (var contacto in todosLosContactos)
        {
            contactosVisibles.Add(contacto);
        }
        
        ActualizarContador();
    }

    private void ActualizarContador()
    {
        lblContador.Text = $"Total: {contactosVisibles.Count}";
    }

    private void LimpiarCampos()
    {
        txtNombre.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtEmail.Text = string.Empty;
    }

    private async void MostrarMensaje(string mensaje)
    {
        var messageBox = new Window
        {
            Title = "Información",
            Width = 300,
            Height = 120,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(20),
                Children =
                {
                    new TextBlock 
                    { 
                        Text = mensaje,
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                        Margin = new Avalonia.Thickness(0, 0, 0, 15)
                    },
                    new Button 
                    { 
                        Content = "OK",
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                        Padding = new Avalonia.Thickness(20, 5)
                    }
                }
            }
        };

        var button = (messageBox.Content as StackPanel)?.Children[1] as Button;
        if (button != null)
        {
            button.Click += (s, e) => messageBox.Close();
        }

        await messageBox.ShowDialog(this);
    }
}