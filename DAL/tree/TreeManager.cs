using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public static class TreeManager
    {
        public static List<ElementShort> GetAllElements()
        {
            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    String query = "select * from data";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        DataSet ds = new DataSet();
                        SQLiteDataAdapter ret = new SQLiteDataAdapter();
                        ret.SelectCommand = command;
                        ret.Fill(ds);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                            return (from rows in ds.Tables[0].AsEnumerable()
                                    select new ElementShort()
                                    {
                                        Id = (long)rows["id"],
                                        ParentId = rows.Field<long?>("parent_id"),
                                        Name = rows["name"].ToString()
                                    }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<ElementShort>();
            }
            return new List<ElementShort>();
        }


        public static bool DeleteElement(long elementId, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"delete from data where Id=@elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool AddNewElement(ElementShort element, out string error)
        {
            error = String.Empty;
            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = String.Format(@"insert 
                                                   into data(parent_id, name)
                                                    values(@parent_id, @name);  select last_insert_rowid();");
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {

                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = element.ParentId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", DbType = DbType.AnsiString, Value = element.Name });
                        element.Id = (long)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

            return true;

        }

        public static bool UpdateElementName(long elementId, string elementName, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [name] = @name
                                        WHERE id = @elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@name", DbType = DbType.AnsiString, Value = elementName });
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool UpdateElementData(long elementId, Byte[] data, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [data] = @data
                                        WHERE id = @elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });


                        SQLiteParameter paramRTF =
                                     new SQLiteParameter("@data",
                                     DbType.Binary,
                                     data.Length,
                                     ParameterDirection.Input,
                                     false,
                                     0, 0, null,
                                     DataRowVersion.Current,
                                     data);
                        command.Parameters.Add(paramRTF);


                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool GetTextData(long elementId, out string rtf , out string error)
        {
            error = String.Empty;
            rtf = null;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"select [data] from data where Id=@elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows && !reader.IsDBNull(0))
                            {
                               Byte[] data = new Byte[Convert.ToInt32((reader.GetBytes(0, 0, null, 0, Int32.MaxValue)))];
                               long bytesReceived = reader.GetBytes(0, 0, data, 0, data.Length);
                               ASCIIEncoding encoding = new ASCIIEncoding();
                               rtf = encoding.GetString(data, 0, Convert.ToInt32(bytesReceived));
                            }
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
