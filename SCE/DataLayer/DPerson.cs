using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DPerson
    {
        private int _IdPerson;
        private string _FirstName;
        private string _SurName;
        private string _LastName;
        private string _Sex;
        private string _DocumentType;
        private string _DocumentNumber;
        private string _Address;

        private string _SearchText;

        public int IdPerson
        {
            get { return _IdPerson; }
            set { _IdPerson = value;  }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string SurName
        {
            get { return _SurName; }
            set { _SurName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        public string DocumentType
        {
            get { return _DocumentType; }
            set { _DocumentType = value; }
        }

        public string DocumentNumber
        {
            get { return _DocumentNumber; }
            set { _DocumentNumber = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string SearchText
        {
            get { return _SearchText;  }
            set { _SearchText = value;  }
        }

        // Constructor Vacio
        public DPerson()
        {

        }

        //Constructor con parametros
        public DPerson(int idperson, string firstname, string surname, 
            string lastname, string sex, string documenttype, 
            string documentnumber, string address, string searchtext)
        {
            this.IdPerson = idperson;
            this.FirstName = firstname;
            this.SurName = surname;
            this.LastName = lastname;
            this.Sex = sex;
            this.DocumentType = documenttype;
            this.DocumentNumber = documentnumber;
            this.Address = address;
            this.SearchText = searchtext;
        }

        
        // Metodo Insertar
        public string Insert(DPerson Person)
        {
            string answer = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Connection.Cn;
                SqlCon.Open();
                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsert_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerson = new SqlParameter();
                ParIdPerson.ParameterName = "@id_persona";
                ParIdPerson.SqlDbType = SqlDbType.Int;
                ParIdPerson.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPerson);

                SqlParameter ParFirstName = new SqlParameter();
                ParFirstName.ParameterName = "@primer_nombre";
                ParFirstName.SqlDbType = SqlDbType.NVarChar;
                ParFirstName.Size = 30;
                ParFirstName.Value = Person.FirstName;
                SqlCmd.Parameters.Add(ParFirstName);

                SqlParameter ParSurName = new SqlParameter();
                ParSurName.ParameterName = "@segundo_nombre";
                ParSurName.SqlDbType = SqlDbType.NVarChar;
                ParSurName.Size = 30;
                ParSurName.Value = Person.SurName;
                SqlCmd.Parameters.Add(ParSurName);

                SqlParameter ParLastName = new SqlParameter();
                ParLastName.ParameterName = "@apellidos";
                ParLastName.SqlDbType = SqlDbType.NVarChar;
                ParLastName.Size = 50;
                ParLastName.Value = Person.LastName;
                SqlCmd.Parameters.Add(ParLastName);

                SqlParameter ParSex = new SqlParameter();
                ParSex.ParameterName = "@sexo";
                ParSex.SqlDbType = SqlDbType.NVarChar;
                ParSex.Size = 1;
                ParSex.Value = Person.Sex;
                SqlCmd.Parameters.Add(ParSex);

                SqlParameter ParDocumentType = new SqlParameter();
                ParDocumentType.ParameterName = "@tipo_documento";
                ParDocumentType.SqlDbType = SqlDbType.NVarChar;
                ParDocumentType.Size = 20;
                ParDocumentType.Value = Person.DocumentType;
                SqlCmd.Parameters.Add(ParDocumentType);

                SqlParameter ParDocumentNumber = new SqlParameter();
                ParDocumentNumber.ParameterName = "@num_documento";
                ParDocumentNumber.SqlDbType = SqlDbType.NVarChar;
                ParDocumentNumber.Size = 15;
                ParDocumentNumber.Value = Person.DocumentNumber;
                SqlCmd.Parameters.Add(ParDocumentNumber);

                SqlParameter ParAddress = new SqlParameter();
                ParAddress.ParameterName = "@direccion";
                ParAddress.SqlDbType = SqlDbType.NVarChar;
                ParAddress.Size = 256;
                ParAddress.Value = Person.Address;
                SqlCmd.Parameters.Add(ParAddress);

                // Ejecutar comando
                answer = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Not inserted";
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return answer;
        }

        // Metodo Editar
        public string Edit(DPerson Person)
        {
            string answer = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Connection.Cn;
                SqlCon.Open();
                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spedit_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerson = new SqlParameter();
                ParIdPerson.ParameterName = "@id_persona";
                ParIdPerson.SqlDbType = SqlDbType.Int;
                ParIdPerson.Value = Person.IdPerson;
                SqlCmd.Parameters.Add(ParIdPerson);

                SqlParameter ParFirstName = new SqlParameter();
                ParFirstName.ParameterName = "@primer_nombre";
                ParFirstName.SqlDbType = SqlDbType.NVarChar;
                ParFirstName.Size = 30;
                ParFirstName.Value = Person.FirstName;
                SqlCmd.Parameters.Add(ParFirstName);

                SqlParameter ParSurName = new SqlParameter();
                ParSurName.ParameterName = "@segundo_nombre";
                ParSurName.SqlDbType = SqlDbType.NVarChar;
                ParSurName.Size = 30;
                ParSurName.Value = Person.SurName;
                SqlCmd.Parameters.Add(ParSurName);

                SqlParameter ParLastName = new SqlParameter();
                ParLastName.ParameterName = "@apellidos";
                ParLastName.SqlDbType = SqlDbType.NVarChar;
                ParLastName.Size = 50;
                ParLastName.Value = Person.LastName;
                SqlCmd.Parameters.Add(ParLastName);

                SqlParameter ParSex = new SqlParameter();
                ParSex.ParameterName = "@sexo";
                ParSex.SqlDbType = SqlDbType.NVarChar;
                ParSex.Size = 1;
                ParSex.Value = Person.Sex;
                SqlCmd.Parameters.Add(ParSex);

                SqlParameter ParDocumentType = new SqlParameter();
                ParDocumentType.ParameterName = "@tipo_documento";
                ParDocumentType.SqlDbType = SqlDbType.NVarChar;
                ParDocumentType.Size = 20;
                ParDocumentType.Value = Person.DocumentType;
                SqlCmd.Parameters.Add(ParDocumentType);

                SqlParameter ParDocumentNumber = new SqlParameter();
                ParDocumentNumber.ParameterName = "@num_documento";
                ParDocumentNumber.SqlDbType = SqlDbType.NVarChar;
                ParDocumentNumber.Size = 15;
                ParDocumentNumber.Value = Person.DocumentNumber;
                SqlCmd.Parameters.Add(ParDocumentNumber);

                SqlParameter ParAddress = new SqlParameter();
                ParAddress.ParameterName = "@direccion";
                ParAddress.SqlDbType = SqlDbType.NVarChar;
                ParAddress.Size = 256;
                ParAddress.Value = Person.Address;
                SqlCmd.Parameters.Add(ParAddress);

                // Ejecutar comando
                answer = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Not updated";
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return answer;

        }

        // Metodo Eliminar
        public string Delete(DPerson Person)
        {
            string answer = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Connection.Cn;
                SqlCon.Open();
                // Establecer comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdelete_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPerson = new SqlParameter();
                ParIdPerson.ParameterName = "@id_persona";
                ParIdPerson.SqlDbType = SqlDbType.Int;
                ParIdPerson.Value = Person.IdPerson;
                SqlCmd.Parameters.Add(ParIdPerson);

                // Ejecutar comando
                answer = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Not deleted";
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return answer;
        }

        // Metodo para mostrar todos los registros
        public DataTable Show()
        {
            DataTable DtResult = new DataTable("Persona");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Connection.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spshow_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResult);
            }
            catch (Exception ex)
            {
                DtResult = null;
            }
            return DtResult;
        }

        // Metodo buscar por nombre
        public DataTable SearchByName(DPerson Person)
        {
            DataTable DtResult = new DataTable("Persona");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Connection.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearch_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParSearchText = new SqlParameter();
                ParSearchText.ParameterName = "@textobuscar";
                ParSearchText.SqlDbType = SqlDbType.NVarChar;
                ParSearchText.Size = 50;
                ParSearchText.Value = Person.SearchText;
                SqlCmd.Parameters.Add(ParSearchText);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResult);
            }
            catch (Exception ex)
            {
                DtResult = null;
            }
            return DtResult;
        }

        // Metodo buscar por apellido
        public DataTable SearchByLastName(DPerson Person)
        {
            DataTable DtResult = new DataTable("Persona");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Connection.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spsearchlastn_persona";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParSearchText = new SqlParameter();
                ParSearchText.ParameterName = "@textobuscar";
                ParSearchText.SqlDbType = SqlDbType.NVarChar;
                ParSearchText.Size = 50;
                ParSearchText.Value = Person.SearchText;
                SqlCmd.Parameters.Add(ParSearchText);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResult);
            }
            catch (Exception ex)
            {
                DtResult = null;
            }
            return DtResult;
        }
 
    }
}
