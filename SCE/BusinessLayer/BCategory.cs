using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class BCategory
    {
        /// <summary>
        /// Este método llama al método insertar de la clase "DCategory" del proyecto DataLayer
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_description"></param>
        /// <returns>obj</returns>
        public static string Insert(string _name, string _description)
        {
            DCategory obj = new DCategory();
            obj.Name = _name;
            obj.Description = _description;
            return obj.Insert(obj);
        }

        /// <summary>
        /// Este método llama al método editar de la clase "DCategory" del proyecto DataLayer
        /// </summary>
        /// <param name="_idcategory"></param>
        /// <param name="_name"></param>
        /// <param name="_description"></param>
        /// <returns>obj</returns>
        public static string Edit(int _idcategory, string _name, string _description)
        {
            DCategory obj = new DCategory();
            obj.IdCategory = _idcategory; 
            obj.Name = _name;
            obj.Description = _description;
            return obj.Edit(obj);
        }

        /// <summary>
        /// Este método llama al método eliminar de la clase "DCategory" del proyecto DataLayer
        /// </summary>
        /// <param name="_idcategory"></param>
        /// <returns>obj</returns>
        public static string Remove(int _idcategory)
        {
            DCategory obj = new DCategory();
            obj.IdCategory = _idcategory;
            return obj.remove(obj);
        }

        /// <summary>
        /// Este método llama al método show de la clase "DCategory" del proyecto DataLayer
        /// </summary>
        /// <returns></returns>
        public static DataTable Show()
        {
            return new DCategory().Show();
        }

        public static DataTable SearchName(string _sText)
        {
            DCategory obj = new DCategory();
            obj.SText = _sText;
            return obj.SearchName(obj);
        }
    }
}
