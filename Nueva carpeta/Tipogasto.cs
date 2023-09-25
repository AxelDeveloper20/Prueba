using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Tipogasto
	{
	

		public short Id_tipogasto { get; set; }
	    public double Servicio { get; set; } 
    	public double Valor { get; set; }
		public string Descripcion { get; set; }
        public Boolean Check { get; set; }
        public Boolean editable { get; set; }
        public Boolean Calculable { get; set; }
        public string Calculable_ { get; set; }
        public string Cargo_Servicio { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public Int16 Id_proveedor { get; set; }
        
	}
}