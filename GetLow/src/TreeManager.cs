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
                                        Name = rows["name"].ToString(),
                                        Position = (long)rows["position"]
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

        public static bool IsLoaded(string site_id, string parent_site_id)
        {
            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    String query;

                    if (parent_site_id == null)
                        query = String.Format(@"select d.id from data d where d.site_id = {0} 
                            and d.parent_site_id is null
                            and d.is_loaded = 1", site_id);
                    else
                        query = String.Format(@"select d.id from data d where d.site_id = {0} 
                            and d.parent_site_id = {1} 
                            and d.is_loaded = 1", site_id, parent_site_id);
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {

                        var c = command.ExecuteScalar();
                        if (c != null && c is long && (long)c > 0)
                            return true;
                        return false;

                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static long GetId(string site_id, string parent_site_id, long parent_id)
        {
            //var d_indb = context.data.Where(t => t.site_id == n.site_id && t.parent_site_id == n.parent_site_id && t.parent_id == n.parent_id).FirstOrDefault();
            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    String query = String.Format(@"select d.id from data d where d.site_id = {0} 
                            and d.parent_site_id = {1} 
                            and d.parent_id = {2}", site_id, parent_site_id, parent_id);
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        DataSet ds = new DataSet();
                        SQLiteDataAdapter ret = new SQLiteDataAdapter();
                        ret.SelectCommand = command;
                        ret.Fill(ds);
                        return (ds != null && ds.Tables[0].Rows.Count > 0 ? (long)ds.Tables[0].Rows[0][0] : -1);

                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public static List<ElementShort> Find(string text)
        {
            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    String queryf = @"select * from data d
                                     where d.[name] like '%{0}%' or d.[data_text] like '%{0}%'";

                    String query = String.Format(queryf, text);

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
                                        Name = rows["name"].ToString(),
                                        Position = (long)rows["position"],
                                        DataText = rows["data_text"].ToString()
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

                    sqlConn.Open();
                    long position = 1;
                    string maxPosition = "select max(position) from data where parent_id = @parent_id";

                    if (element.ParentId == null)
                        maxPosition = "select max(position) from data where parent_id is null";

                    using (SQLiteCommand command = new SQLiteCommand(maxPosition, sqlConn))
                    {

                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = element.ParentId });
                        var max = command.ExecuteScalar();
                        try
                        {
                            position = (long)max + 1;
                        }
                        catch { }

                    }



                    string query = String.Format(@"insert 
                                                   into data(parent_id, name, position)
                                                    values(@parent_id, @name, @position);  select last_insert_rowid();");

                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {

                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = element.ParentId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@position", DbType = DbType.Int64, Value = position });
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


        public static bool UpdateElementPosition(long elementId, long elementPosition, long? elementParentId, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [position] = @position,
                                          [parent_id] = @parent_id 
                                        WHERE id = @elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@position", DbType = DbType.Int64, Value = elementPosition });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = elementParentId });
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

        public static bool UpdateElementPositionMuveUp(long elementPosition, long? elementParentId, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [position] =[position] + 1
                                        WHERE parent_id = @parent_id and position >= @position";

                    if (elementParentId == null)
                        query = @"update data SET
                                          [position] =[position] + 1
                                        WHERE parent_id is null and position >= @position";

                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@position", DbType = DbType.Int64, Value = elementPosition });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = elementParentId });
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

        public static bool UpdateElementPositionMuveDown(long elementPosition, long? elementParentId, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [position] =[position] - 1
                                        WHERE parent_id = @parent_id and position <= @position";

                    if (elementParentId == null)

                        query = @"update data SET
                                          [position] =[position] - 1
                                        WHERE parent_id is null and position <= @position";

                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@position", DbType = DbType.Int64, Value = elementPosition });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@parent_id", DbType = DbType.Int64, Value = elementParentId });
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

        public static bool UpdateElementData(long elementId, Byte[] data, string dataText, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [data] = @data,
                                          [data_text] = @dataText
                                        WHERE id = @elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@dataText", DbType = DbType.AnsiString, Value = dataText });
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

        public static bool UpdateElementData(long elementId, string dataRtf, string dataText, out string error)
        {
            error = String.Empty;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"update data SET
                                          [data_rtf] = @dataRtf,
                                          [data_text] = @dataText
                                        WHERE id = @elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@dataRtf", DbType = DbType.AnsiString, Value = dataRtf });
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@dataText", DbType = DbType.AnsiString, Value = dataText });
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

        public static bool GetTextData(long elementId, out string rtf, out string error)
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
                                long bytes = reader.GetBytes(0, 0, null, 0, Int32.MaxValue);
                                Int32 d = Convert.ToInt32(bytes);
                                Byte[] data = new Byte[d];
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


        public static bool GetDataRtf(long elementId, out string rtf, out string error)
        {
            error = String.Empty;
            rtf = null;

            try
            {
                using (SQLiteConnection sqlConn = new SQLiteConnection(ConnectionManager.ConnectionStringSQLite))
                {
                    string query = @"select [data_rtf] from data where Id=@elementId";
                    sqlConn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, sqlConn))
                    {
                        command.Parameters.Add(new SQLiteParameter() { ParameterName = "@elementId", DbType = DbType.Int64, Value = elementId });

                        DataSet ds = new DataSet();
                        SQLiteDataAdapter ret = new SQLiteDataAdapter();
                        ret.SelectCommand = command;
                        ret.Fill(ds);

                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            rtf = ds.Tables[0].Rows[0][0].ToString();
                        }

                        //using (SQLiteDataReader reader = command.ExecuteReader())
                        //{
                        //    reader.Read();
                        //    if (reader.HasRows && !reader.IsDBNull(0))
                        //    {

                        //        rtf = reader.Get
                        //    }
                        //    return true;
                        //}
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
