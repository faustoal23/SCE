using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataLayer
{
    public class DCategory
    {
        //Ten en cuenta que los atributos empiezan con minuscula
        private int idCategory;
        private string name;
        private string description;
        private string sText;

        //Y los metodos con mayuscula. Cambialo si quieres.

        /// <summary>
        /// Getters y Setters
        /// </summary>
        /// 
        public int IdCategory
        {
            get{ return idCategory; }
            set { idCategory = value; }         
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string SText
        {
            get { return sText; }
            set { sText = value; }
        }
        

        /// <summary>
        /// El constructor llama la funcion del objeto y usa el metodo get o set del cual se
        /// haga referencia para asignar o recuperar los atributos
        /// </summary>
        /// <param name="_idCategory"></param>
        /// <param name="_name"></param>
        /// <param name="_description"></param>
        /// <param name="_sText"></param>
        public DCategory(int _idCategory, string _name, string _description, string _sText)     //Para los parametros pongo "_" delante del nombre del atributo que se modificara
        {
            this.IdCategory = _idCategory;
            this.Name = _name;
            this.Description = _description;
            this.SText = _sText;
        }

        public DCategory()
        {
        }

        /// <summary>
        /// Método insertar
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public string Insert(DCategory _category)
        {
            return null;
        }

        /// <summary>
        /// Método editar
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public string Edit(DCategory _category)
        {
            return null;
        }

        /// <summary>
        /// Método remover
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public string remove(DCategory _category)
        {
            return null;
        }

        public DataTable Show()
        {
            return null;
        }

        public DataTable SearchName(DCategory _category)
        {
            return null;
        }

    }
}
