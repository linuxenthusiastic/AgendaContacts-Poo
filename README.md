# 📒 Agenda de Contactos

**Proyecto de Programación Orientada a Objetos** implementando **Encapsulamiento** con C# y Avalonia UI.

## 🚀 Cómo Ejecutar el Proyecto

### 🐧 En Arch Linux

```bash
# 1. Instalar .NET (solo la primera vez)
sudo pacman -S dotnet-sdk dotnet-runtime

# 2. Clonar el proyecto
git clone https://github.com/TU_USUARIO/ContactsAgenda.git
cd ContactsAgenda

# 3. Ejecutar la aplicación
dotnet run
```

### 🪟 En Windows

```powershell
# 1. Instalar .NET 8.0 SDK desde:
# https://dotnet.microsoft.com/download/dotnet/8.0

# 2. Abrir PowerShell o CMD y clonar el proyecto
git clone https://github.com/TU_USUARIO/ContactsAgenda.git
cd ContactsAgenda

# 3. Ejecutar la aplicación
dotnet run
```

## 📁 Estructura del Proyecto

```
ContactsAgenda/
├── Models/
│   └── Contact.cs          # Modelo de datos
├── Services/
│   └── Agenda.cs          # Lógica con ENCAPSULAMIENTO
├── Views/
│   ├── MainWindow.axaml   # Interfaz gráfica
│   └── MainWindow.axaml.cs # Lógica de la ventana
├── App.axaml              # Configuración de la app
├── Program.cs             # Punto de entrada
└── ContactsAgenda.csproj  # Archivo del proyecto
```

## 🔒 Principio de Encapsulamiento Implementado

La clase `Agenda` protege completamente la lista de contactos:

- ❌ **NO** se puede acceder directamente a la lista
- ✅ **SÍ** se puede usar mediante métodos públicos:
  - `AgregarContacto()`
  - `BuscarContacto()`
  - `MostrarContactos()`
  - `EliminarContacto()`

## 👨‍💻 Autores

- Santiago Abuawad y Benjamin Oliva
- Universidad Catolica Sede Santa Cruz
- Programacion 2