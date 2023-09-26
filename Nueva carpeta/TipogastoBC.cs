using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;


namespace CNEGOCIO
{
    public class TipogastoBC
    {


      

		public Tipogasto Gettipogasto(Int16 id_tipogasto)
        {
            Tipogasto mtipo = new TipogastoDAC().getTipogasto(id_tipogasto);
            return mtipo;

        
        }

        public string add_tipogasto(Int16 id_tipogasto, double valor, string descripcion, Boolean calculable)

        {

            string add = new TipogastoDAC().add_Tipogasto(id_tipogasto,
                                                        valor,
                                                        descripcion, calculable);

            return add;
            
        }

        public string add_TipogastoProducto(Int16 id_tipogasto, string codigo, Byte opcion)
        {

            string add = new TipogastoDAC().add_TipogastoProducto(id_tipogasto,
                                                        codigo,
                                                        opcion);

            return add;

        }


        public string add_TipogastoOperacion(Int16 id_tipogasto, Int32 id_solicitud, Int32 valor, string cuenta_usuario, string cargo_servicio, Int16 id_proveedor, byte opcion, byte ingreso = 1)
        {

            string add = new TipogastoDAC().add_TipogastoOperacion(id_tipogasto,id_solicitud,valor,
                                                        cuenta_usuario,
                                                        cargo_servicio,id_proveedor,
                                                        opcion,
                                                        ingreso);

            return add;

        }


        public string add_TipogastoCliente(Int16 id_tipogasto, Int16 id_cliente,  string cargo_servicio, string tipo_servicio, Boolean facturable)
        {

            string add = new TipogastoDAC().add_TipogastoCliente(id_tipogasto,
                                                        id_cliente,
                                                        cargo_servicio,
                                                        tipo_servicio,
                                                        facturable
                                                        );

            return add;

        }


        public string Del_TipogastoCliente(Int16 id_tipogasto, Int16 id_cliente, string tipo_servicio)
        {
            return new TipogastoDAC().Del_TipogastoCliente(id_tipogasto, id_cliente, tipo_servicio);

        }

        public List<Tipogasto> getalltipogasto()

        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getallTipogasto();

            return ltipogasto;

        }


        public List<Tipogasto> getallTipogastoProducto(string codigo)
        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getallTipogastoProducto(codigo);

            return ltipogasto;

        }

        public List<Tipogasto> getallTipogastoOperacion(Int32 id_solicitud, string codigo)
        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getallTipogastoOperacion(id_solicitud, codigo);

            return ltipogasto;

        }


        public List<Tipogasto> getallTipogastoClienteServicio(Int16 id_cliente, string codigo_servicio)
        {

            return new TipogastoDAC().getallTipogastoClienteServicio(id_cliente, codigo_servicio); 
        }

        public List<Tipogasto> getallTipogastoCliente(Int16 id_cliente)
        {

            List<Tipogasto> ltipogasto = new TipogastoDAC().getallTipogastoCliente(id_cliente);

            return ltipogasto;

        }


        


    }
}
