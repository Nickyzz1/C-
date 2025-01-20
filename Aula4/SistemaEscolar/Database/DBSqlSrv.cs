using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Markup;
using Microsoft.Data.SqlClient;

namespace DataBase;

public class DBSqlSrv<T> where T : DataBaseObject, new() // o new permite obejtos de T
{
    [System.Obsolete]
    private SqlConnection conn;

    [System.Obsolete]
    public DBSqlSrv(string dataSource, string database) {
        SqlConnectionStringBuilder s = new();
        s.DataSource = dataSource;
        s.InitialCatalog = database;
        s.IntegratedSecurity = true;
        s.TrustServerCertificate = true;
        string connection = s.ConnectionString;
        conn = new SqlConnection(connection); // fez a conecção
    }

    [System.Obsolete]
    public List<T> All {
        get{
            
            List<T> values = [];
            conn.Open();
            SqlCommand cdm = new($"SELECT * FROM {typeof(T).Name}");
            cdm.Connection = conn;
            var reader = cdm.ExecuteReader();
            DataTable dt = new();
            dt.Load(reader);

            for(int item = 0; item < dt.Rows.Count; item++) {
                T obj = new();
                obj.LoadFromSqlRow(dt.Rows[item]);
                values.Add(obj); 
            }

            conn.Close();
            return values;
        }
    }

    [System.Obsolete]
    public void Save(T obj) {
     
        string values = obj.SaveToSql();
        conn.Open();
        SqlCommand cmd = new(values){
            Connection = conn
        };
        cmd.Connection = conn;
        cmd.ExecuteNonQuery();
        conn.Close();
   
    }
}