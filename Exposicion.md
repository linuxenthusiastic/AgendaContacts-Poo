# 📚 EXPOSICIÓN - Agenda de Contactos

### Puntos clave a mencionar:
- ✅ La lista de contactos está **completamente encapsulada**
- ✅ Modelos de datos bien implementados
- ✅ Multiplataforma

---

## 🔒 **PARTE 1: ENCAPSULAMIENTO**


```csharp
public class Agenda
{
    private List<Contact> contacts;
    
    public Agenda()
    {
        contacts = new List<Contact>();
    }
```

```csharp
public bool AgregarContacto(Contact contact)
{
    if (contact == null || string.IsNullOrWhiteSpace(contact.Name))
        return false;
        
    contacts.Add(contact);
    return true;
}

public Contact? BuscarContacto(string name)
{
    return contacts.FirstOrDefault(c => 
        c.Name.ToLower().Contains(name.ToLower()));
}

public List<Contact> MostrarContactos()
{
    return new List<Contact>(contacts);
}
```

---

## 💻 **PARTE 2: MODELO DE DATOS**

```csharp
public class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }
}
```

---

## 🎨 **PARTE 3: INTERFAZ GRÁFICA**

```csharp
public partial class MainWindow : Window
{
    private readonly Agenda agenda;
    private ObservableCollection<Contact> contactosVisibles;

    public MainWindow()
    {
        InitializeComponent();

        agenda = new Agenda();
        contactosVisibles = new ObservableCollection<Contact>();
    }
```

```csharp
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

    var nuevoContacto = new Contact(nombre, telefono, email);
    
    if (agenda.AgregarContacto(nuevoContacto))
    {
        ActualizarLista();
        LimpiarCampos();
    }
}
```

---

## 🚀 **PARTE 4: DEMOSTRACIÓN EN VIVO**

## 🚨 **PARTES MÁS IMPORTANTES A RESALTAR**

1. ⭐ **`private List<Contact> contacts;`** - El corazón del encapsulamiento
2. ⭐ **`return new List<Contact>(contacts);`** - Retornar copia, no original
3. ⭐ **Validación en `AgregarContacto()`** - Protección de datos
4. ⭐ **Métodos públicos** - Los únicos puntos de acceso

---

## ⏱️ **TIEMPO ESTIMADO TOTAL: 10-12 MINUTOS**

¡Mucho éxito en tu exposición! 💪
