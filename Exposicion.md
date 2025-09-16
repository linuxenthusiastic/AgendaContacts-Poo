# 📚 EXPOSICIÓN - Agenda de Contactos

### Puntos clave a mencionar:
- ✅ La lista de contactos está **completamente encapsulada**
- 

---

## 🔒 **PARTE 1: ENCAPSULAMIENTO**

### 📌 **Mostrar el archivo: `Services/Agenda.cs`**

```csharp
public class Agenda
{
    // 🔴 PUNTO CLAVE #1: Lista PRIVADA
    private List<Contact> contacts;  // ← RESALTAR ESTO
    
    public Agenda()
    {
        contacts = new List<Contact>();
    }
```

```csharp
// 🔴 PUNTO CLAVE #2: Métodos PÚBLICOS para acceder
public bool AgregarContacto(Contact contact)
{
    if (contact == null || string.IsNullOrWhiteSpace(contact.Name))
        return false;  // ← Validación de datos
        
    contacts.Add(contact);
    return true;
}

public Contact? BuscarContacto(string name)
{
    // Búsqueda controlada
    return contacts.FirstOrDefault(c => 
        c.Name.ToLower().Contains(name.ToLower()));
}

public List<Contact> MostrarContactos()
{
    // 🔴 PUNTO CLAVE #3: Retorna una COPIA
    return new List<Contact>(contacts);  // ← IMPORTANTE
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
    // 🔴 PUNTO CLAVE #4: Usamos la clase Agenda
    private readonly Agenda agenda;
    private ObservableCollection<Contact> contactosVisibles;

    public MainWindow()
    {
        InitializeComponent();
        
        // Crear instancia de Agenda (encapsulada)
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

    // 🔴 PUNTO CLAVE #5: Validación antes de agregar
    if (string.IsNullOrWhiteSpace(nombre))
    {
        MostrarMensaje("Por favor ingrese un nombre");
        return;
    }

    var nuevoContacto = new Contact(nombre, telefono, email);
    
    // 🔴 PUNTO CLAVE #6: Usamos el método público
    if (agenda.AgregarContacto(nuevoContacto))  // ← ENCAPSULAMIENTO
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
5. ⭐ **Multiplataforma** - Mismo código en Windows y Linux

---

## ⏱️ **TIEMPO ESTIMADO TOTAL: 10-12 MINUTOS**

¡Mucho éxito en tu exposición! 💪
