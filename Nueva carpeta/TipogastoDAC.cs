using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class TipogastoDAC : CACCESO.BaseDAC
    {
		public Tipogasto getTipogasto(Int16 id_tipogasto)
        {
          
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Tipogasto";
                    cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    Tipogasto mTipogasto = new Tipogasto();
                    if (reader.Read())
                    {

                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                      //  mTipogasto.Proveedores = new ProveedorDAC().getProveedorByTipoGasto(Convert.ToInt16(reader["id_tipogasto"].ToString())); 

                    }
                    else
                    {
                        mTipogasto = null;
                    }
                    return mTipogasto;
                }
          
        }

      

        public List<Tipogasto> getallTipogasto()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Tipogastos_clon";
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tipogasto> lTipogasto = new List<Tipogasto>();
                    while (reader.Read())
                    {
                        Tipogasto mTipogasto = new Tipogasto();
                       
                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        mTipogasto.Calculable_ = reader["calculable"].ToString();
                       
                        lTipogasto.Add(mTipogasto);
                        mTipogasto = null;
                    }
                    return lTipogasto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Tipogasto> getallTipogastoProducto(string codigo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_TipogastoProducto";
                    cmd.Parameters.AddWithValue("@codigo", codigo);                    

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tipogasto> lTipogasto = new List<Tipogasto>();
                    while (reader.Read())
                    {
                        Tipogasto mTipogasto = new Tipogasto();

                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        mTipogasto.Check = Convert.ToBoolean(reader["check"]);



                        lTipogasto.Add(mTipogasto);
                        mTipogasto = null;
                    }
                    return lTipogasto;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Tipogasto> getallTipogastoOperacion(Int32 id_solicitud, string codigo)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_TipogastoOperacion";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                SqlDataReader reader = cmd.ExecuteReader();
                List<Tipogasto> lTipogasto = new List<Tipogasto>();
                while (reader.Read())
                {
                    Tipogasto mTipogasto = new Tipogasto();

                    mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                    mTipogasto.Descripcion = reader["descripcion"].ToString();
                    mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                    mTipogasto.Check = Convert.ToBoolean(reader["check"]);
                    mTipogasto.Cargo_Servicio = reader["cargo_servicio"].ToString();
                    mTipogasto.Id_proveedor = Convert.ToInt16(reader["id_proveedor"].ToString());
                    //mTipogasto.Proveedores = new ProveedorDAC().getProveedorByTipoGasto(mTipogasto.Id_tipogasto);


                    lTipogasto.Add(mTipogasto);
                    mTipogasto = null;
                }
                sqlConn.Close();
                return lTipogasto;
            }
        }

        public List<Tipogasto> getallTipogastoCliente(Int16 id_cliente)
        {
           
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_TipogastoCliente";
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Tipogasto> lTipogasto = new List<Tipogasto>();
                    while (reader.Read())
                    {
                        Tipogasto mTipogasto = new Tipogasto();

                        mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                        mTipogasto.Descripcion = reader["descripcion"].ToString();
                        mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                        



                        lTipogasto.Add(mTipogasto);
                        mTipogasto = null;
                    }
                    sqlConn.Close();
                    return lTipogasto;
                }

           
        }


        public List<Tipogasto> getallTipogastoClienteServicio(Int16 id_cliente, string codigo_servicio)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_r_TipogastoClienteServicio";
                cmd.Parameters.AddWithValue("@codigo", codigo_servicio);

                SqlDataReader reader = cmd.ExecuteReader();
                List<Tipogasto> lTipogasto = new List<Tipogasto>();
                while (reader.Read())
                {
                    Tipogasto mTipogasto = new Tipogasto();

                    mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
                    mTipogasto.Descripcion = reader["descripcion"].ToString();
                    mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
                    mTipogasto.Check = Convert.ToBoolean(reader["check"]);
                    mTipogasto.editable = Convert.ToBoolean(reader["editable"]);

                    lTipogasto.Add(mTipogasto);
                    mTipogasto = null;
                }
                sqlConn.Close();
                return lTipogasto;
            }


        }

		public string add_Tipogasto(Int16 id_tipogasto, double valor, string descripcion, Boolean calculable)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Tipogasto_clon", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    oParam = Cmd.Parameters.AddWithValue("@calculable", calculable);
                    

					
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }


        public string add_TipogastoProducto(Int16 id_tipogasto, string codigo, Byte opcion)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_TipogastoProducto", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@tipo_gasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@opcion", opcion);
                    



                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }


        public string add_TipogastoCliente(Int16 id_tipogasto, Int16 id_cliente, string cargo_servicio, string tipo_servicio, Boolean facturable)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                    SqlCommand Cmd = new SqlCommand("sp_add_TipogastoCliente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@tipo_gasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    oParam = Cmd.Parameters.AddWithValue("@valor", cargo_servicio);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", tipo_servicio);
                    oParam = Cmd.Parameters.AddWithValue("@Facturable", facturable);
                Cmd.ExecuteNonQuery();
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
            }
            return "";
        }


        public string Del_TipogastoCliente(Int16 id_tipogasto, Int16 id_cliente, string tipo_servicio)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                SqlCommand Cmd = new SqlCommand("sp_del_TipogastoCliente", sqlConn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter oParam = Cmd.Parameters.AddWithValue("@tipo_gasto", id_tipogasto);
                oParam = Cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                oParam = Cmd.Parameters.AddWithValue("@codigo", tipo_servicio);
                Cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
            return "";
        }



        public string add_TipogastoOperacion(Int16 id_tipogasto, Int32 id_solicitud, 
                                            Int32 valor,  
                                            string cuenta_usuario, string cargo_servicio, Int16 id_proveedor, byte opcion, byte ingreso = 1)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Gastooperacion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@tipo_gasto", id_tipogasto);
                    oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@valor", valor);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@opcion", opcion);
                    oParam = Cmd.Parameters.AddWithValue("@ingreso", ingreso);
                    oParam = Cmd.Parameters.AddWithValue("@cargo_servicio", cargo_servicio);
                    oParam = Cmd.Parameters.AddWithValue("@id_proveedor", id_proveedor);



                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

    }
}