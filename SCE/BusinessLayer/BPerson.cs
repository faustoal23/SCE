using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class BPerson
    {
        // Metodo Insert, llama al metodo Insert de la capa de datos
        public static string Insert(string firstname, string surname, string lastname, string sex, string documenttype, string documentnumber, string address)
        {
            DPerson Obj = new DPerson();
            Obj.FirstName = firstname;
            Obj.SurName = surname;
            Obj.LastName = lastname;
            Obj.Sex = sex;
            Obj.DocumentType = documenttype;
            Obj.DocumentNumber = documentnumber;
            Obj.Address = address;

            return Obj.Insert(Obj);
        }

        // Metodo Editar
        public static string Edit(int idperson, string firstname, string surname, string lastname, string sex, string documenttype, string documentnumber, string address)
        {
            DPerson Obj = new DPerson();
            Obj.IdPerson = idperson;
            Obj.FirstName = firstname;
            Obj.SurName = surname;
            Obj.LastName = lastname;
            Obj.Sex = sex;
            Obj.DocumentType = documenttype;
            Obj.DocumentNumber = documentnumber;
            Obj.Address = address;

            return Obj.Edit(Obj);
        }

        // Metodo Eliminar
        public static string Delete(int idperson, string firstname, string surname, string lastname, string sex, string documenttype, string documentnumber, string address)
        {
            DPerson Obj = new DPerson();
            Obj.IdPerson = idperson;

            return Obj.Delete(Obj);
        }

        // Metodo mostrar
        public static DataTable Show()
        {
            return new DPerson().Show();
        }

        // Metodo buscarnombre
        public static DataTable SearchByName(string searchtext)
        {
            DPerson Obj = new DPerson();
            Obj.SearchText = searchtext;

            return Obj.SearchByName(Obj);
        }

        // Metodo buscar apellido
        public static DataTable SearchByLastName(string searchtext)
        {
            DPerson Obj = new DPerson();
            Obj.SearchText = searchtext;

            return Obj.SearchByLastName(Obj);
        }

    }
}
