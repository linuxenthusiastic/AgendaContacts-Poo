using System.Collections.Generic;
using System.Linq;
using ContactsAgenda.Models;

namespace ContactsAgenda.Services;

public class Agenda
{
    private List<Contact> contacts;

    public Agenda()
    {
        contacts = new List<Contact>();
    }

    public bool AgregarContacto(Contact contact)
    {
        if (contact == null || string.IsNullOrWhiteSpace(contact.Name))
            return false;
            
        contacts.Add(contact);
        return true;
    }

    public bool EliminarContacto(string name)
    {
        var contact = BuscarContacto(name);
        if (contact != null)
        {
            contacts.Remove(contact);
            return true;
        }
        return false;
    }

    public Contact? BuscarContacto(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;
            
        return contacts.FirstOrDefault(c => 
            c.Name.ToLower().Contains(name.ToLower()));
    }

    public Contact? BuscarPorNumero(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return null;
            
        return contacts.FirstOrDefault(c => 
            c.Phone.Contains(phone));
    }

    public List<Contact> MostrarContactos()
    {
        return new List<Contact>(contacts);
    }

    public int ContarContactos()
    {
        return contacts.Count;
    }
}