using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Airport.Models.Connection
{
    class SqlServerConnection
    {
        #region attributes
        private string _connectionString;
        private SqlConnection _connection;
        private bool _opened;
        #endregion

        #region statics
        public static SqlServerConnection Local
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["local"].ToString();
                return new SqlServerConnection(connectionString);
            }
        }
        #endregion

        #region constructors

        public SqlServerConnection(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            Open();
        }
        #endregion

        #region methods
        public bool Open()
        {
            if (!_opened)
            {
                try
                {
                    _connection.Open();
                    _opened = true;
                }
                catch (Exception e) { }
            }
            return _opened;
        }

        public bool Close()
        {
            if (_opened)
            {
                try
                {
                    _connection.Close();
                    _opened = false;
                }
                catch (SqlException e) { }
            }

            return _opened;
        }

        public DataTable GetDataTable(string query, params object [] arguments)
        {
            DataTable table = new DataTable();
            string q = String.Format(query, arguments);
            SqlCommand command = new SqlCommand(q, _connection);
            SqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            return table;
        }


        #endregion
    }
}
