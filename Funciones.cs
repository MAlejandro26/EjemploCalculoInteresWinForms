using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALC_INTERES
{
	class Funciones
	{

		public static void ListarCombo(ComboBox combo, string sentencia, string columna1, string columna2)
		{
			try
			{
				DataTable dt = new DataTable();
				string valor = dt.Columns.Add(columna1).ToString();
				string vista = dt.Columns.Add(columna2).ToString();

				dt = StaticData.oCnn.ExecuteDatatable(sentencia);

                combo.DataSource = dt;
                combo.DisplayMember = columna2;
                combo.ValueMember = columna1;

				//for (int i = 0; i < dt.Rows.Count; i++)
				//{
				//	combo.Items.Add(dt.Rows[i][1].ToString()).ToString();
				//	//combo.Items.Add(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString()).ToString();
				//}

				combo.SelectedIndex = -1;


			}
			catch (Exception ex)
			{
				StaticData.oCnn.Close();
				MessageBox.Show(ex.Message);
			}
		}

        public static decimal GetTipoCambio(String fecha)
        {
            
            var cambio = new decimal();
            //buscamos el tipo de cambio

            try
            {
                string sql = string.Format("SELECT MONTO FROM {0}.TIPO_CAMBIO_HIST WHERE TIPO_CAMBIO='OFIC' AND CONVERT(DATE, FECHA) = '{1}'", StaticData.oCnn.CompaniaActual, fecha);
                DataTable tabla = StaticData.oCnn.ExecuteDatatable(sql);
                if (tabla.Rows.Count > 0)
                {
                    cambio =Convert.ToDecimal(tabla.Rows[0]["MONTO"]);
                }
                else
                {
                    cambio = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                                   
            return cambio;
        }
        public static string Dato(string val, string tabla, string where)
        {
            string str = "";
            string sql = string.Format("SELECT {0} VAL FROM {1}.{2} {3}", (object)val, (object)StaticData.oCnn.CompaniaActual, (object)tabla, (object)where);
            foreach (DataRow row in (InternalDataCollectionBase)StaticData.oCnn.ExecuteDatatable(sql).Rows)
                str = (string)row["VAL"];
            return str;
        }
    }
}
