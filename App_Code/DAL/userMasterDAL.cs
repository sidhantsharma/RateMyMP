using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

    public class userMasterDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter dap;
        string query;
        string[] str = new string[3];

        public bool checkPasscode(userMasterBO userMasterBO)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                query = "checkPasscode";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email",userMasterBO.email);
                SqlParameter result = cmd.Parameters.Add("@res",SqlDbType.Bit);
                result.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
               return(bool.Parse(result.Value.ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool updatePassword(userMasterBO userMasterBO)
        {

            try
            {
                 if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                 query = "passwordUpdate";
                 cmd = new SqlCommand(query,con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@email", userMasterBO.email);
                 cmd.Parameters.AddWithValue("@passcode", userMasterBO.passcode);
                 cmd.Parameters.AddWithValue("@password", userMasterBO.password);
                 SqlParameter result = cmd.Parameters.Add("@res",SqlDbType.Bit);
                 result.Direction = ParameterDirection.Output;
                 cmd.ExecuteNonQuery();
                 return (bool .Parse(result.Value.ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {
                 if(con.State==ConnectionState.Open)
                    {
                        con.Close();
                    }
            }
        }
        

        public bool insertPasscode(userMasterBO UserMasterBO)
        {
            try
            {

                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                query = "insertUpdatePasscode";
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@passcode", UserMasterBO.passcode);
                cmd.Parameters.AddWithValue("@email", UserMasterBO.email);
                SqlParameter result = cmd.Parameters.Add("@res",SqlDbType.Bit);
                result.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (bool.Parse(result.Value.ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {
                    if(con.State==ConnectionState.Open)
                    {
                        con.Close();
                    }
            }
        }
        public bool checkValidEmailToResetPassword(userMasterBO userMasterBO)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                query = "checkEmailToResetPassword";
                cmd = new SqlCommand(query,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", userMasterBO.email);
                SqlParameter result = cmd.Parameters.Add("@res", SqlDbType.Bit);
                result.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (bool.Parse(result.Value.ToString()));
                
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        public Int64 getGuid(userMasterBO userMasterBO)
        {
            try
            {
                query = "returnGuid";
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", userMasterBO.email);
                return (Int64 .Parse( cmd.ExecuteScalar().ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        public string[] checkUser(userMasterBO userMasterBO)
        {

            try
            {
                query = "localUserLogin";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query,con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email",userMasterBO.email);
                cmd.Parameters.AddWithValue("@password", userMasterBO.password);
                SqlParameter returnEmail = cmd.Parameters.Add("@returnEmail", SqlDbType.NVarChar,50);
                returnEmail.Direction = ParameterDirection.Output;
                SqlParameter returnGuid = cmd.Parameters.Add("@returnGuid", SqlDbType.BigInt);
                returnGuid.Direction = ParameterDirection.Output;
                SqlParameter returnFname = cmd.Parameters.Add("@returnFirstName", SqlDbType.NVarChar,50);
                returnFname.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str[0] = returnEmail.Value.ToString();
                str[1] = returnGuid.Value.ToString();
                str[2] = returnFname.Value.ToString();

                return str;
            }
            catch
            {
                throw;
            }
            finally
            { 
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }
        public string insertUser(userMasterBO userMasterBO)
        {
            try
            {

                query = "userMasterEntry";
                cmd = new SqlCommand(query,con);
                cmd.CommandType = CommandType.StoredProcedure;
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@email",userMasterBO.email);
                cmd.Parameters.AddWithValue("@password", userMasterBO.password);
                cmd.Parameters.AddWithValue("@fk_roleId", userMasterBO.roleId);
                cmd.Parameters.AddWithValue("@firstName", userMasterBO.firstName);
                cmd.Parameters.AddWithValue("@middleName", userMasterBO.middleName);
                cmd.Parameters.AddWithValue("@lastName", userMasterBO.lastName);
                cmd.Parameters.AddWithValue("@socialNetwork", userMasterBO.socialNetwork);
                cmd.Parameters.AddWithValue("@snTypeId", userMasterBO.snTypeId);
                cmd.Parameters.AddWithValue("@status", userMasterBO.status);
                cmd.Parameters.AddWithValue("@profilePicPath", userMasterBO.profilePicPath);
                SqlParameter message = cmd.Parameters.Add("@message", SqlDbType.VarChar, 500);
                message.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return message.Value.ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                con.Close();
                }
            }
        }
      
        public Int16 getSocialNetworkId(string socialType)
        {
            try
            {

                query = "returnSocialNetworkId";
               
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                //dap = new SqlDataAdapter(query,con);
                //dap.SelectCommand.CommandType = CommandType.StoredProcedure;
                //dap.SelectCommand.Parameters.AddWithValue("@socialType",socialType);
                //DataTable dt = new DataTable();
                //dap.Fill(dt);
                //return (Int16.Parse(dt.Rows[0]["snTypeId"].ToString()));

                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@socialType", socialType);
               return (Int16.Parse(cmd.ExecuteScalar().ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {   if(con.State==ConnectionState.Open)
                {
                con.Close();
                }
            }
           
        }
    }
