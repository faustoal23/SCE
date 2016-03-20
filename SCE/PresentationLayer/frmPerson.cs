using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmPerson : Form
    {
        private bool IsNew = false;
        private bool IsEdit = false;


        public frmPerson()
        {
            InitializeComponent();
            this.ttMessage.SetToolTip(this.txtFirstName, "Ingrese el nombre de la persona");
            this.ttMessage.SetToolTip(this.txtSurname, "Ingrese el segundo nombre de la persona");
            this.ttMessage.SetToolTip(this.txtLastName, "Ingrese el apellido de la persona");
            this.ttMessage.SetToolTip(this.txtDocumentType, "Ingrese el tipo de documento. Ej. Cedula, Pasaporte.");
            this.ttMessage.SetToolTip(this.txtDocumentNumber, "Ingrese el numero de documento.");
            this.ttMessage.SetToolTip(this.txtAddress, "Ingrese la direccion.");
            this.ttMessage.SetToolTip(this.txtSex, "Ingrese el sexo de la persona. Ej. M o F");
        }

        // Mostrar mensaje de confirmacion
        private void OkMessage(string message)
        {
            MessageBox.Show(message,"Sistema de Control Empresarial",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        // Mostrar mensaje de error
        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Sistema de Control Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Limpiar todos los controles del formulario
        private void Clean()
        {
            this.txtFirstName.Text = String.Empty;
            this.txtSurname.Text = String.Empty;
            this.txtLastName.Text = String.Empty;
            this.txtDocumentType.Text = String.Empty;
            this.txtDocumentNumber.Text = String.Empty;
            this.txtAddress.Text = String.Empty;
            this.txtSex.Text = String.Empty;
            this.txtId.Text = String.Empty;
        }

        // Habilitar los controles
        private void Enable(bool value)
        {
            this.txtFirstName.ReadOnly = !value;
            this.txtSurname.ReadOnly = !value;
            this.txtLastName.ReadOnly = !value;
            this.txtDocumentType.ReadOnly = !value;
            this.txtDocumentNumber.ReadOnly = !value;
            this.txtAddress.ReadOnly = !value;
            this.txtSex.ReadOnly = !value;
            this.txtId.ReadOnly = !value;
        }

        // Habilitar los botones
        private void Buttons()
        {
            if(this.IsNew || this.IsEdit)
            {
                this.Enable(true);
                this.btnNew.Enabled = false;
                this.btnSave.Enabled = true;
                this.btnEdit.Enabled = false;
                this.btnCancel.Enabled = true;
            }
            else
            {
                this.Enable(false);
                this.btnNew.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnEdit.Enabled = true;
                this.btnCancel.Enabled = false;
            }
        }

        // Metodo para ocultar columnas
        private void HideColumns()
        {
            this.dataList.Columns[0].Visible = false;
            this.dataList.Columns[1].Visible = false;
        }

        // Metodo mostrar
        private void Show()
        {
            this.dataList.DataSource = BPerson.Show();
            this.HideColumns();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataList.Rows.Count);
        }

        // Metodo Buscar por Nombre
        private void SearchByName()
        {
            this.dataList.DataSource = BPerson.SearchByName(this.txtNameSearch.Text);
            this.HideColumns();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataList.Rows.Count);
        }

        // Metodo Buscar por Apellido
        private void SearchByLastName()
        {
            this.dataList.DataSource = BPerson.SearchByLastName(this.txtLastNameSearch.Text);
            this.HideColumns();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataList.Rows.Count);
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Show();
            this.Enable(false);
            this.Buttons();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchByName();
            //this.SearchByLastName();
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            this.SearchByName();
        }

        private void txtLastNameSearch_TextChanged(object sender, EventArgs e)
        {
            this.SearchByLastName();
        }
    }
}
