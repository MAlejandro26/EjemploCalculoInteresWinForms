using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CALC_INTERES
{
	public partial class Form1 : MetroFramework.Forms.MetroForm
	{
        private int index;
        private string column;
        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Funciones.ListarCombo(cmbMes, "SET language spanish select MONTH(FECHA_FINAL) MESID  ,DATENAME(MONTH,FECHA_FINAL) MES from " + StaticData.oCnn.CompaniaActual+".PERIODO_CONTABLE group by DATENAME(MONTH, FECHA_FINAL), MONTH(FECHA_FINAL) order by MONTH(FECHA_FINAL)", "MESID", "MES");

			Funciones.ListarCombo(cmbAnio, "select  YEAR(FECHA_FINAL) ANIO, YEAR(FECHA_FINAL) ANIODESC from " + StaticData.oCnn.CompaniaActual +".PERIODO_CONTABLE group by YEAR(FECHA_FINAL) order by YEAR(FECHA_FINAL) DESC", "ANIO", "ANIODESC");

            Funciones.ListarCombo(cmbSubtipo, "SELECT a.SUBTIPO, DESCRIPCION, U_INTERES FROM "+ StaticData.oCnn.CompaniaActual + ".SUBTIPO_DOC_CP A INNER JOIN "+ StaticData.oCnn.CompaniaActual + ".CS_CONFIG_CALC_INTERES B ON A.SUBTIPO=B.SUBTIPO_PRINCIPAL AND A.TIPO=B.TIPO_PRINCIPAL GROUP BY a.SUBTIPO, DESCRIPCION, U_INTERES ", "SUBTIPO", "DESCRIPCION");
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = "";
            cmbSubtipo.SelectedIndex = -1;
            txtTC.Text = "0";
            txtEmpleados.Text = "0";
            txtTSaldoActDol.Text = "0";
            txtTInteresDol.Text = "0";
            txtTSaldoAntDol.Text = "0";
            txtTSaldoAntLoc.Text = "0";
            txtTInteresLoc.Text = "0";
            txtTSaldoActLoc.Text = "0";


        }
        public void LlenarGrid(string mes, string anio, string subtipo, string tipo)
        {
            gridControl1.DataSource = null;
            string sql = string.Format("SELECT A.MES  , A.ANIO , A.EMPLEADO , A.SALDO as SALDO_ANTERIOR, A.PORCENTAJE , A.INTERES ,A.SALDO + A.INTERES SALDO_NUEVO, A.DOCUMENTO , A.USUARIO , A.FECHA, B.NOMBRE,  B.MONEDA   , D.DESCRIPCION PUESTO, A.TIPO, A.SUBTIPO, (SELECT DESC_CORTA FROM {0}.CS_CONFIG_CALC_INTERES WHERE  SUBTIPO_INTERES=A.SUBTIPO AND TIPO_INTERES=A.TIPO AND SUBTIPO_PRINCIPAL=A.SUBTIPO_PRINCIPAL AND TIPO_PRINCIPAL=A.TIPO_PRINCIPAL)DESC_CORTA,(SELECT DESC_LARGA FROM {0}.CS_CONFIG_CALC_INTERES WHERE  SUBTIPO_INTERES = A.SUBTIPO AND TIPO_INTERES = A.TIPO AND SUBTIPO_PRINCIPAL = A.SUBTIPO_PRINCIPAL AND TIPO_PRINCIPAL = A.TIPO_PRINCIPAL)DESC_LARGA FROM {0}.CS_INTERES_AHORRO_CALCULO A   INNER JOIN {0}.PROVEEDOR B ON A.EMPLEADO = B.PROVEEDOR INNER JOIN {0}.EMPLEADO C ON B.PROVEEDOR = C.EMPLEADO INNER JOIN {0}.PUESTO D ON D.PUESTO = C.PUESTO where A.MES='{1}' AND A.ANIO='{2}' and A.SUBTIPO_PRINCIPAL='{3}' AND A.TIPO_PRINCIPAL='{4}'", StaticData.oCnn.CompaniaActual, mes, anio, subtipo, tipo);
            gridControl1.DataSource = StaticData.oCnn.ExecuteDatatable(sql);

        }
     
        private void cmdCalcular_Click(object sender, EventArgs e)
        {
       

            int  docto_p=0, docto_i=0;
            bool flag_borrar = false;
            string tipo_subtipo = "";
            string local = "NIO", extranjera = "USD";
            //SACAMOS EL ULTIMO DIA DEL MES QUE ESTA CORRIENDO
            string Ultima_Dias = "";

            try
            {
                if ((cmbMes.SelectedIndex == -1) || (cmbAnio.SelectedIndex == -1) || (cmbSubtipo.SelectedIndex==-1) || (string.IsNullOrEmpty(txtTipo.Text)))
                {
                    MessageBox.Show("Debe seleccionar el Mes,  Año y Subtipo de documento", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   
                    string mes = cmbMes.SelectedValue.ToString();
                    string anio = cmbAnio.SelectedValue.ToString();
                    string subtipo = cmbSubtipo.SelectedValue.ToString();

                  
                    int daysInFeb = System.DateTime.DaysInMonth(Convert.ToInt32(anio), Convert.ToInt32(mes));
                    Ultima_Dias = anio + "-" + mes + "-" + daysInFeb.ToString();

               
                    string sql = string.Format("SELECT A.MES  , A.ANIO , A.EMPLEADO , A.SALDO, A.PORCENTAJE , A.INTERES , A.DOCUMENTO , A.USUARIO , A.FECHA, B.NOMBRE,  B.MONEDA   FROM {0}.CS_INTERES_AHORRO_CALCULO A   INNER JOIN {0}.PROVEEDOR B ON A.EMPLEADO = B.PROVEEDOR inner join {0}.EMPLEADO C ON C.EMPLEADO=B.PROVEEDOR  where A.MES='{1}' AND A.ANIO='{2}' AND A.SUBTIPO_PRINCIPAL='{3}' AND A.TIPO_PRINCIPAL='{4}' AND A.DOCUMENTO IS NOT NULL", StaticData.oCnn.CompaniaActual, mes, anio,subtipo, txtTipo.Text);
                    DataTable tabla_bitacora = StaticData.oCnn.ExecuteDatatable(sql);
                    if (tabla_bitacora.Rows.Count > 0)
                    {
                        MessageBox.Show("Ya se ha aplicado el Cálculo de este mes para este subtipo de documento", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, SplashFormStartPosition.Default, new Point(0, 0), ParentFormState.Locked);

                        string sql_bitacora = string.Format("SELECT A.MES  , A.ANIO , A.EMPLEADO , A.SALDO, A.PORCENTAJE , A.INTERES , A.DOCUMENTO , A.USUARIO , A.FECHA, B.NOMBRE,  B.MONEDA   FROM {0}.CS_INTERES_AHORRO_CALCULO A   INNER JOIN {0}.PROVEEDOR B ON A.EMPLEADO = B.PROVEEDOR inner join {0}.EMPLEADO C ON C.EMPLEADO=B.PROVEEDOR where A.MES='{1}' AND A.ANIO='{2}' and A.SUBTIPO_PRINCIPAL='{3}' and A.TIPO_PRINCIPAL='{4}' ", StaticData.oCnn.CompaniaActual, mes, anio, subtipo, txtTipo.Text);
                        DataTable tabla_sql_bitacora = StaticData.oCnn.ExecuteDatatable(sql_bitacora);

                        if (tabla_sql_bitacora.Rows.Count > 0)
                        {
                            string delete_bitacora = string.Format(" delete {0}.CS_INTERES_AHORRO_CALCULO   where MES = '{1}' AND ANIO = '{2}' and SUBTIPO_PRINCIPAL='{3}' AND TIPO_PRINCIPAL='{4}'", StaticData.oCnn.CompaniaActual, mes, anio, subtipo, txtTipo.Text);
                            if (StaticData.oCnn.ExecuteNonQuery(delete_bitacora) > 0)
                            {
                                flag_borrar = true;
                            }
                        }
                        else
                        {
                            flag_borrar = true;
                        }
                        if (flag_borrar)
                        {
                            //Tabla para  sacar la info del subtipo de interes
                            string sql_interes_subtipo = string.Format("SELECT  isnull(U_INTERES, 0) U_INTERES , A.SUBTIPO, A.TIPO FROM {0}.SUBTIPO_DOC_CP A INNER JOIN {0}.CS_CONFIG_CALC_INTERES B ON A.SUBTIPO = B.SUBTIPO_INTERES AND A.TIPO = B.TIPO_INTERES WHERE B.SUBTIPO_PRINCIPAL = '{1}' AND B.TIPO_PRINCIPAL = '{2}' GROUP BY  A.SUBTIPO, A.TIPO, U_INTERES ", StaticData.oCnn.CompaniaActual, subtipo, txtTipo.Text);
                            DataTable tabla_sql_interes_subtipo = StaticData.oCnn.ExecuteDatatable(sql_interes_subtipo);
                                                       
                            if (tabla_sql_interes_subtipo.Rows.Count > 0)
                            {
                                //obtenemos los documentos configurados para este calculo
                           
                                docto_i = Convert.ToInt32(tabla_sql_interes_subtipo.Rows[0]["SUBTIPO"]);
                                tipo_subtipo = tabla_sql_interes_subtipo.Rows[0]["TIPO"].ToString();

                                //sacamos el listado de los documentos de principal
                                string lista_docto = string.Format("SELECT PROVEEDOR, TIPO,SUM(MONTO) MONTO, SUM(SALDO) SALDO, SUM(MONTO_LOCAL) MONTO_LOCAL, SUM(SALDO_LOCAL) SALDO_LOCAL, SUM(MONTO_DOLAR) MONTO_DOLAR, SUM(SALDO_DOLAR) SALDO_DOLAR, MONEDA, SUM(U_INTERES) U_INTERES FROM {0}.DOCUMENTOS_CP A INNER JOIN {0}.EMPLEADO B ON A.PROVEEDOR=B.EMPLEADO WHERE SUBTIPO = '{1}' AND TIPO='{2}' GROUP BY PROVEEDOR, TIPO, MONEDA", StaticData.oCnn.CompaniaActual, subtipo, txtTipo.Text);
                                DataTable tabla_lista_docto = StaticData.oCnn.ExecuteDatatable(lista_docto);
                                if (tabla_lista_docto.Rows.Count > 0)
                                {
                                    StaticData.oCnn.BeginTransaction();
                                    //recorremos los documentos
                                    foreach (DataRow data in tabla_lista_docto.Rows)
                                    {
                                        decimal SALDO_DOCUMENTO_LOCAL = 0, SALDO_DOCUMENTO_DOLAR = 0, SALDO_REAL = 0;

                                        //buscamos la moneda del proveedor, para generar los documentos

                                        string moneda_proveedor = string.Format("SELECT MONEDA FROM {0}.PROVEEDOR WHERE PROVEEDOR='{1}'", StaticData.oCnn.CompaniaActual, data["PROVEEDOR"]);
                                        DataTable tabla_moneda_proveedor = StaticData.oCnn.ExecuteDatatable(moneda_proveedor);

                                        string monedaproveedor = tabla_moneda_proveedor.Rows[0]["MONEDA"].ToString();
                                        string moneda_principal = data["MONEDA"].ToString();

                                        //VERIFICAMOS SI EL DOCUMENTO PRINCIPAL ESTA EN DOLAR O CORDOBAS
                                        string moneda_docto = "";
                                        decimal monto_moneda = 0;
                                        if (moneda_principal == local)
                                        {
                                            moneda_docto = local;
                                            SALDO_DOCUMENTO_LOCAL = Convert.ToDecimal(data["SALDO_LOCAL"]);
                                        }
                                        else if (moneda_principal == extranjera)
                                        {
                                            moneda_docto = extranjera;
                                            SALDO_DOCUMENTO_DOLAR = Convert.ToDecimal(data["SALDO_DOLAR"]);
                                        }


                                        //VERIFICAMOS SI EL DOCUMENTOS DE INTERES LO VAMOS A INSERTAR SEGUN LA MONEDA DEL CLIENTE
                                    
                                        string sql_interes_proveedor = string.Format("SELECT  CONDICION_PAGO FROM {0}.PROVEEDOR WHERE PROVEEDOR='{1}'", StaticData.oCnn.CompaniaActual, data["PROVEEDOR"]);
                                        DataTable tabla_sql_interes_proveedor = StaticData.oCnn.ExecuteDatatable(sql_interes_proveedor);

                                        //Sacamos el interes dependiendo si el documento de principal tiene interes si no lo sacamos del subtipo
                                        decimal interes_proveedo = 0;
                                        if (string.IsNullOrEmpty(data["U_INTERES"].ToString()) || Convert.ToDecimal(data["U_INTERES"])==0 )//INTERES DEL DOCUMENTO PRINCIPAL SI ESTA NULL O ES 0
                                        {
                                            interes_proveedo = Convert.ToDecimal(tabla_sql_interes_subtipo.Rows[0]["U_INTERES"]);
                                        }
                                        else
                                        {
                                            interes_proveedo = Convert.ToDecimal(data["U_INTERES"]);
                                        }

                                         
                                        string condicion_pago = tabla_sql_interes_proveedor.Rows[0]["CONDICION_PAGO"].ToString();
                                        //calculo del interes en base al saldo actual del documento principal de ahorro
                                        decimal calculo_dolar = 0, calculo_local = 0;

                                        calculo_local = SALDO_DOCUMENTO_LOCAL * (interes_proveedo / 100m);
                                        calculo_dolar = SALDO_DOCUMENTO_DOLAR * (interes_proveedo / 100m);

                                        if (monedaproveedor == local)
                                        {
                                            monto_moneda = calculo_local;
                                            SALDO_REAL = Convert.ToDecimal(data["SALDO_LOCAL"]);
                                        }
                                        else if (monedaproveedor == extranjera)
                                        {
                                            monto_moneda = calculo_dolar;
                                            SALDO_REAL = Convert.ToDecimal(data["SALDO_DOLAR"]);
                                        }

                                        //INSERTAMOS LOS CALCULOS EN LA TABLA

                                        string insert_calculo = string.Format("INSERT INTO {0}.CS_INTERES_AHORRO_CALCULO (MES,ANIO,EMPLEADO ,SALDO ,PORCENTAJE ,INTERES ,DOCUMENTO  ,USUARIO, FECHA,MONEDA, SUBTIPO, TIPO, SUBTIPO_PRINCIPAL, TIPO_PRINCIPAL) " +
                                            "VALUES ('{1}','{2}','{3}','{4}', '{5}','{6}', NULL,'{7}',GETDATE(),'{8}','{9}','{10}','{11}','{12}')", StaticData.oCnn.CompaniaActual, mes, anio, data["PROVEEDOR"], SALDO_REAL, interes_proveedo, monto_moneda, StaticData.oCnn.UsuarioActual, monedaproveedor,docto_i, tipo_subtipo, subtipo, txtTipo.Text);

                                        StaticData.oCnn.ExecuteNonQuery(insert_calculo);

                                  
                                    }
                                    StaticData.oCnn.Commit();

                                    LlenarGrid(mes.ToString(), anio,subtipo, txtTipo.Text);

                                    double templeado = 0, tintereses = 0, tinio = 0, tidolar = 0, tsaldoantdolar = 0, tsaldoactdolar = 0, tsaldoantlocal = 0, tsaldoactlocal = 0;



                                    string sql_totales = string.Format("SELECT D.NUM_EMPLEADO, D.INTERESES_DOLAR, D.INTERESES_LOCAL, D.SALDO_ANT_DOLAR, D.SALDO_ANT_LOCAL, D.SALDO_ANT_DOLAR + D.INTERESES_DOLAR SALDO_ACT_DOLAR, D.SALDO_ANT_LOCAL + D.INTERESES_LOCAL SALDO_ACT_LOCAL " +
                                        "FROM( SELECT Count(EMPLEADO) NUM_EMPLEADO, SUM(CASE WHEN MONEDA = 'NIO' THEN INTERES ELSE 0 END) INTERESES_LOCAL, SUM(CASE WHEN MONEDA = 'USD' THEN INTERES ELSE 0 END) INTERESES_DOLAR,SUM(CASE WHEN MONEDA = 'NIO' THEN SALDO ELSE 0 END) SALDO_ANT_LOCAL," +
                                        " SUM(CASE WHEN MONEDA = 'USD' THEN SALDO ELSE 0 END) SALDO_ANT_DOLAR FROM {0}.CS_INTERES_AHORRO_CALCULO WHERE MES = '{1}' AND ANIO = '{2}' AND SUBTIPO_PRINCIPAL='{3}' AND TIPO_PRINCIPAL='{4}') D", StaticData.oCnn.CompaniaActual, mes, anio, subtipo, txtTipo.Text);
                                    DataTable tabla = StaticData.oCnn.ExecuteDatatable(sql_totales);
                                    if (tabla.Rows.Count > 0)
                                    {
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["NUM_EMPLEADO"].ToString()))
                                        {
                                            templeado = Convert.ToDouble(tabla.Rows[0]["NUM_EMPLEADO"]);
                                            txtEmpleados.Text = string.Format("{0:N}", templeado);
                                        }

                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["INTERESES_LOCAL"].ToString()))
                                        {

                                            tinio = Convert.ToDouble(tabla.Rows[0]["INTERESES_LOCAL"]);

                                        }
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["INTERESES_DOLAR"].ToString()))
                                        {
                                            tidolar = Convert.ToDouble(tabla.Rows[0]["INTERESES_DOLAR"]);

                                        }
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ANT_DOLAR"].ToString()))
                                        {
                                            tsaldoantdolar = Convert.ToDouble(tabla.Rows[0]["SALDO_ANT_DOLAR"]);

                                        }
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ACT_DOLAR"].ToString()))
                                        {
                                            tsaldoactdolar = Convert.ToDouble(tabla.Rows[0]["SALDO_ACT_DOLAR"]);

                                        }
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ANT_LOCAL"].ToString()))
                                        {
                                            tsaldoantlocal = Convert.ToDouble(tabla.Rows[0]["SALDO_ANT_LOCAL"]);

                                        }
                                        if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ACT_LOCAL"].ToString()))
                                        {
                                            tsaldoactlocal = Convert.ToDouble(tabla.Rows[0]["SALDO_ACT_LOCAL"]) * Convert.ToDouble(txtTC.Text);

                                        }

                                        //realizamos las respectivas conversiones de dolar a cordoba y viceversa
                                        //dolares
                                        double tint_dol = 0, tsaldoant_dol=0,tsaldoact_dol=0 , tipo_cambio=0;
                                        //cordobas
                                        double tsaldoant_loc = 0, tint_loc, tsaldoact_loc = 0;
                                        //validamos el tipo de cambio para que no de error en la division en el caso que sea cero
                                        if (Convert.ToDouble(txtTC.Text) <= 0)
                                        {
                                            tipo_cambio = 1;
                                        }
                                        else { tipo_cambio = Convert.ToDouble(txtTC.Text); }

                                        tint_dol = tidolar + (tinio / tipo_cambio);
                                        tsaldoant_dol = tsaldoantdolar + (tsaldoantlocal / tipo_cambio);
                                        tsaldoact_dol = tsaldoactdolar + (tsaldoactlocal / tipo_cambio);

                                        tint_loc = tinio + (tidolar * tipo_cambio);
                                        tsaldoant_loc = tsaldoantlocal +( tsaldoantdolar * tipo_cambio);
                                        tsaldoact_loc = tsaldoactlocal +( tsaldoactdolar * tipo_cambio);


                                        // txtIntereses.Text = string.Format("{0:N}", tintereses);
                                        txtTSaldoActDol.Text = string.Format("{0:N}", tsaldoact_dol);
                                        txtTInteresDol.Text = string.Format("{0:N}", tint_dol);
                                        txtTSaldoAntDol.Text = string.Format("{0:N}", tsaldoant_dol);
                                        txtTSaldoAntLoc.Text = string.Format("{0:N}", tsaldoant_loc);
                                        txtTInteresLoc.Text = string.Format("{0:N}", tint_loc);
                                        txtTSaldoActLoc.Text = string.Format("{0:N}", tsaldoact_loc);
                                        SplashScreenManager.CloseForm();
                                    }
                                }
                                else
                                {
                                        SplashScreenManager.CloseForm();
                                        MessageBox.Show("No hay documentos con este Subtipo", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                    SplashScreenManager.CloseForm();
                                    MessageBox.Show("No hay documentos configurados para el cálculo", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                                SplashScreenManager.CloseForm();
                                MessageBox.Show("Hay datos de un Cálculo anterior", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                StaticData.oCnn.Rollback();
            }
            finally
            {
                if (StaticData.oCnn.IsInTransaction)
                {
                    StaticData.oCnn.Rollback();
                }
            }
        }

           
        private void cmdAprobar_Click(object sender, EventArgs e)
        {
            int docto_p = 0, docto_i = 0;
            string local = "NIO", extranjera = "USD";
            string tipo_subtipo = "";
            string Ultima_Dias = "";
            if (gridView1.RowCount > 0)
            {
                if ((cmbMes.SelectedIndex == -1) || (cmbAnio.SelectedIndex == -1) || (cmbSubtipo.SelectedIndex == -1) || (string.IsNullOrEmpty(txtTipo.Text)))
                {
                    MessageBox.Show("Debe seleccionar el Mes , Año y Subtipo de documento", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                                       
                        string mes = cmbMes.SelectedValue.ToString();
                        string anio = cmbAnio.SelectedValue.ToString();
                        string subtipo = cmbSubtipo.SelectedValue.ToString();


                        int daysInFeb = System.DateTime.DaysInMonth(Convert.ToInt32(anio), Convert.ToInt32(mes));
                        Ultima_Dias = anio + "-" + mes.ToString() + "-" + daysInFeb.ToString();

                        string sql = string.Format("SELECT A.MES  , A.ANIO , A.EMPLEADO , A.SALDO, A.PORCENTAJE , A.INTERES , A.DOCUMENTO , A.USUARIO , A.FECHA, B.NOMBRE,  B.MONEDA   FROM {0}.CS_INTERES_AHORRO_CALCULO A   INNER JOIN {0}.PROVEEDOR B ON A.EMPLEADO = B.PROVEEDOR where A.MES='{1}' AND A.ANIO='{2}' AND A.SUBTIPO_PRINCIPAL='{3}' AND A.TIPO_PRINCIPAL='{4}'  AND A.DOCUMENTO IS NOT NULL", StaticData.oCnn.CompaniaActual, mes, anio, subtipo, txtTipo.Text);
                        DataTable tabla_bitacora = StaticData.oCnn.ExecuteDatatable(sql);
                        if (tabla_bitacora.Rows.Count > 0)
                        {
                            MessageBox.Show("Ya se ha aplicado el Cálculo de este mes para este subtipo de documento", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Esta seguro de Aprobar el Cálculo de Interés?, Esto no se podra revertir!.", StaticData.oCnn.CompaniaActual, MessageBoxButtons.YesNoCancel,
       MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            SplashScreenManager.ShowForm(this, typeof(WaitAprobacion), true, true, SplashFormStartPosition.Default, new Point(0, 0), ParentFormState.Locked);

                            try
                            {
                                StaticData.oCnn.BeginTransaction();
                                for (int i = 0; i < gridView1.DataRowCount; i++)
                                {


                                    //obtenemos los documentos configurados para este calculo
                                    docto_i = Convert.ToInt32(gridView1.GetRowCellValue(i, "SUBTIPO"));
                                    tipo_subtipo = gridView1.GetRowCellValue(i, "TIPO").ToString();

                                    if (!string.IsNullOrEmpty(gridView1.GetRowCellValue(i, "INTERES").ToString()))
                                    {
                                        string documento = gridView1.GetRowCellValue(i, "DESC_CORTA").ToString()+" " + MesLetras(Convert.ToInt32(mes)).ToUpper() + " " + anio;
                                        string aplicacion = gridView1.GetRowCellValue(i, "DESC_LARGA").ToString() +" "+ MesLetras(Convert.ToInt32(mes)).ToUpper() + " DEL " + anio;
                                        string proveedor = gridView1.GetRowCellValue(i, "EMPLEADO").ToString();
                                        string moneda = gridView1.GetRowCellValue(i, "MONEDA").ToString();
                                        decimal porcent_interes = Convert.ToDecimal(gridView1.GetRowCellValue(i, "PORCENTAJE"));
                                        //VERIFICAMOS SI EL DOCUMENTOS DE INTERES LO VAMOS A INSERTAR SEGUN LA MONEDA DEL CLIENTE
                                        //SACAMOS EL INTERES DE AHORRO DEL CLIENTE
                                        string sql_interes_proveedor = string.Format("SELECT CONDICION_PAGO  FROM {0}.PROVEEDOR WHERE PROVEEDOR='{1}'", StaticData.oCnn.CompaniaActual, proveedor);
                                        DataTable tabla_sql_interes_proveedor = StaticData.oCnn.ExecuteDatatable(sql_interes_proveedor);

                                        string condicion_pago = tabla_sql_interes_proveedor.Rows[0]["CONDICION_PAGO"].ToString();

                                        //calculo del interes a base al saldo actual del documento principal de ahorro
                                        decimal calculo_dolar = 0, calculo_local = 0, calculo_documento = 0;

                                        if (moneda == "USD")
                                        {
                                            calculo_dolar = Convert.ToDecimal(gridView1.GetRowCellValue(i, "INTERES"));
                                            calculo_local = Convert.ToDecimal(gridView1.GetRowCellValue(i, "INTERES")) * Convert.ToDecimal(txtTC.Text);
                                            calculo_documento = calculo_dolar;
                                        }
                                        else if (moneda == "NIO")
                                        {
                                            calculo_dolar = Convert.ToDecimal(gridView1.GetRowCellValue(i, "INTERES")) / Convert.ToDecimal(txtTC.Text);
                                            calculo_local = Convert.ToDecimal(gridView1.GetRowCellValue(i, "INTERES"));
                                            calculo_documento = calculo_local;
                                        }


                                        string insert_cp = string.Format("INSERT INTO {0}.DOCUMENTOS_CP (PROVEEDOR,DOCUMENTO, TIPO, EMBARQUE_APROBADO, FECHA_DOCUMENTO, FECHA, TIPO_EMBARQUE,APLICACION, MONTO, " +
                                            "SALDO, MONTO_LOCAL, SALDO_LOCAL, MONTO_DOLAR, SALDO_DOLAR, TIPO_CAMBIO_MONEDA, TIPO_CAMBIO_DOLAR, FECHA_ULT_CREDITO, CHEQUE_IMPRESO, APROBADO, SELECCIONADO, " +
                                            "CONGELADO, MONTO_PROV, SALDO_PROV, TIPO_CAMBIO_PROV,   SUBTOTAL, DESCUENTO, IMPUESTO1, IMPUESTO2, RUBRO1, RUBRO2, FECHA_ULT_MOD, MONTO_RETENCION, SALDO_RETENCION, " +
                                            "DEPENDIENTE, ASIENTO, ASIENTO_PENDIENTE,NOTAS, TIPO_CAMB_ACT_LOC, TIPO_CAMB_ACT_DOL, TIPO_CAMB_ACT_PROV,    DOCUMENTO_EMBARQUE, USUARIO_ULT_MOD, CONDICION_PAGO," +
                                            " MONEDA, SUBTIPO,  FECHA_VENCE, ANULADO, CODIGO_IMPUESTO, BASE_IMPUESTO1, BASE_IMPUESTO2, DEPENDIENTE_GP, SALDO_TRANS, SALDO_TRANS_LOCAL, SALDO_TRANS_DOLAR, FECHA_PROYECTADA, " +
                                            "IMP1_ASUMIDO_DESC, IMP1_ASUMIDO_NODESC, IMP1_RETENIDO_DESC,  IMP1_RETENIDO_NODESC, TIPO_ASIENTO, PAQUETE, PARTICIPA_IETU, CLASE_DOCUMENTO,  PORC_INTCTE," +
                                            " NUM_PARCIALIDADES, GENERA_DOC_FE, U_INTERES) " +
                                            "VALUES('{1}', '{2}', '{14}', 'N','{3}','{3}','N' ,'{4}','{5}','{5}','{6}','{6}','{7}','{7}','{8}','{8}','1980-01-01','N','S','N'," +
                                            "'N','{5}','{5}','{8}','{5}',0,0,0,0,0,'{3}', 0,0" +
                                            ",'N',NULL,'S','Asiento generado automaticamente en el proceso de calculo de interes', '{8}','{8}','{8}','N','{9}', '{10}' " +
                                            ", '{11}', '{12}','{3}','N','ND',0,0 ,'N',0,0,0,'{3}'" +
                                            ",0,0,0,0,'CP','CP','N','N',0" +
                                            ",0,'N','{13}')",
                                            StaticData.oCnn.CompaniaActual, proveedor, documento, Ultima_Dias, aplicacion, calculo_documento,
                                            calculo_local, calculo_dolar, txtTC.Text, "ERPADMIN", condicion_pago, moneda, docto_i, porcent_interes, tipo_subtipo);
                                        if (StaticData.oCnn.ExecuteNonQuery(insert_cp) > 0)
                                        {
                                            string update_cal = string.Format("UPDATE {0}.CS_INTERES_AHORRO_CALCULO SET DOCUMENTO = '{1}', FECHA_CREACION=GETDATE(), USUARIO_CREACION='{2}' WHERE MES = '{3}' AND ANIO = '{4}' AND EMPLEADO = '{5}' and SUBTIPO_PRINCIPAL='{6}' AND TIPO_PRINCIPAL='{7}'",
                                                StaticData.oCnn.CompaniaActual, documento, StaticData.oCnn.UsuarioActual, mes, anio, proveedor,  subtipo, txtTipo.Text);
                                            StaticData.oCnn.ExecuteNonQuery(update_cal);
                                        }
                                    }


                                }

                                StaticData.oCnn.Commit();
                                LlenarGrid(mes, anio, subtipo, txtTipo.Text);
                                SplashScreenManager.CloseForm();
                                MessageBox.Show("Proceso Terminado", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                StaticData.oCnn.Rollback();
                                SplashScreenManager.CloseForm();
                                MessageBox.Show(ex.Message, StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                          


                        }
                    


                }
            }
            else
            { MessageBox.Show("No hay Datos que procesar", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void cmdImprimirReporte_Click(object sender, EventArgs e)
        {
            
            if ((cmbMes.SelectedIndex == -1) || (cmbAnio.SelectedIndex == -1) || (cmbSubtipo.SelectedIndex == -1) || (string.IsNullOrEmpty(txtTipo.Text)))
            {
                MessageBox.Show("Debe seleccionar el Mes, Año y Subtipo de documento", StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string mes = cmbMes.SelectedValue.ToString();
                string anio = cmbAnio.SelectedValue.ToString();
                string subtipo = cmbSubtipo.SelectedValue.ToString();
                

                rptCalculoInteres doc = new rptCalculoInteres();
                doc.Parameters["Mes"].Value = mes;
                doc.Parameters["Mes"].Visible = false;
                doc.Parameters["Anio"].Value = anio;
                doc.Parameters["Anio"].Visible = false;
                doc.Parameters["tc"].Value = txtTC.Text;
                doc.Parameters["tc"].Visible = false;
                doc.Parameters["subtipo"].Value = subtipo;
                doc.Parameters["subtipo"].Visible = false;
                doc.Parameters["tipo"].Value = txtTipo.Text;
                doc.Parameters["tipo"].Visible = false;
                doc.ShowRibbonPreviewDialog();
            }
                
        }

        private string MesLetras(int int_mes)
        {
            string valor = "";

            switch (int_mes)
            {
                case 1:
                    valor = "Enero";
                    break;
                case 2:
                    valor = "Febrero";
                    break;
                case 3:
                    valor = "Marzo";
                    break;
                case 4:
                    valor = "Abril";
                    break;
                case 5:
                    valor = "Mayo";
                    break;
                case 6:
                    valor = "Junio";
                    break;
                case 7:
                    valor = "Julio";
                    break;
                case 8:
                    valor = "Agosto";
                    break;
                case 9:
                    valor = "Septiembre";
                    break;
                case 10:
                    valor = "Octubre";
                    break;
                case 11 :
                    valor = "Noviembre";
                    break;
                case 12:
                    valor = "Diciembre";
                    break;
                default:
                    valor = "Sin mes";
                    break;
            }

            return valor;
        }
        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            gridControl1.DataSource = "";
            cmbAnio.SelectedIndex = -1;
            txtTC.Text = "0";
            txtEmpleados.Text = "0";
            txtTSaldoActDol.Text = "0";
            txtTInteresDol.Text = "0";
            txtTSaldoAntDol.Text = "0";
            txtTSaldoAntLoc.Text = "0";
            txtTInteresLoc.Text = "0";
            txtTSaldoActLoc.Text = "0";
        }

        private void cmbSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            double templeado = 0, tintereses = 0, tinio = 0, tidolar = 0, tsaldoantdolar=0, tsaldoactdolar=0, tsaldoantlocal=0, tsaldoactlocal=0;

            //SACAMOS EL ULTIMO DIA DEL MES QUE ESTA CORRIENDO
            string Ultima_Dias = "";

             
                if ((cmbMes.SelectedIndex != -1) && (cmbAnio.SelectedIndex != -1) && (cmbSubtipo.SelectedIndex != -1))
                {
                gridControl1.DataSource = "";
                txtEmpleados.Text = "0";
                txtTSaldoActDol.Text = "0";
                txtTInteresDol.Text = "0";
                txtTSaldoAntDol.Text = "0";
                txtTSaldoAntLoc.Text = "0";
                txtTInteresLoc.Text = "0";
                txtTSaldoActLoc.Text = "0";


                string mes = cmbMes.SelectedValue.ToString();
                    string anio = cmbAnio.SelectedValue.ToString();
                    string subtipo = cmbSubtipo.SelectedValue.ToString();

                    try
                    {
                    string SQL_TIPO = string.Format("SELECT a.SUBTIPO, DESCRIPCION, U_INTERES, a.TIPO FROM {0}.SUBTIPO_DOC_CP A INNER JOIN {0}.CS_CONFIG_CALC_INTERES B ON A.SUBTIPO = B.SUBTIPO_PRINCIPAL AND A.TIPO = B.TIPO_PRINCIPAL WHERE B.SUBTIPO_PRINCIPAL = '{1}' GROUP BY a.SUBTIPO, DESCRIPCION, U_INTERES, a.TIPO", StaticData.oCnn.CompaniaActual, subtipo);
                    DataTable tabla_SQL_TIPO=StaticData.oCnn.ExecuteDatatable(SQL_TIPO);
                    txtTipo.Text = tabla_SQL_TIPO.Rows[0]["TIPO"].ToString();

                                       

                        int daysInFeb = System.DateTime.DaysInMonth(Convert.ToInt32(anio), Convert.ToInt32(mes));
                        Ultima_Dias = anio + "-" + mes.ToString() + "-" + daysInFeb.ToString();

                        decimal tc = Funciones.GetTipoCambio(Ultima_Dias);

                        txtTC.Text = tc.ToString();
                        LlenarGrid(mes.ToString(), anio, subtipo, txtTipo.Text);

                    //calculamos los totales


                        string sql = string.Format("SELECT D.NUM_EMPLEADO, D.INTERESES_DOLAR, D.INTERESES_LOCAL, D.SALDO_ANT_DOLAR, D.SALDO_ANT_LOCAL, D.SALDO_ANT_DOLAR + D.INTERESES_DOLAR SALDO_ACT_DOLAR, D.SALDO_ANT_LOCAL + D.INTERESES_LOCAL SALDO_ACT_LOCAL " +
                            "FROM( SELECT Count(EMPLEADO) NUM_EMPLEADO, SUM(CASE WHEN MONEDA = 'NIO' THEN INTERES ELSE 0 END) INTERESES_LOCAL, SUM(CASE WHEN MONEDA = 'USD' THEN INTERES ELSE 0 END) INTERESES_DOLAR,SUM(CASE WHEN MONEDA = 'NIO' THEN SALDO ELSE 0 END) SALDO_ANT_LOCAL," +
                            " SUM(CASE WHEN MONEDA = 'USD' THEN SALDO ELSE 0 END) SALDO_ANT_DOLAR FROM {0}.CS_INTERES_AHORRO_CALCULO WHERE MES = '{1}' AND ANIO = '{2}' AND SUBTIPO_PRINCIPAL='{3}' AND TIPO_PRINCIPAL='{4}') D", StaticData.oCnn.CompaniaActual, mes, anio, subtipo,txtTipo.Text);
                        DataTable tabla = StaticData.oCnn.ExecuteDatatable(sql);
                        if (tabla.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["NUM_EMPLEADO"].ToString()))
                            {
                                templeado = Convert.ToDouble(tabla.Rows[0]["NUM_EMPLEADO"]);
                                txtEmpleados.Text = string.Format("{0:N}", templeado);
                            }

                            if (!string.IsNullOrEmpty(tabla.Rows[0]["INTERESES_LOCAL"].ToString()))
                            {

                                tinio = Convert.ToDouble(tabla.Rows[0]["INTERESES_LOCAL"]);

                            }
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["INTERESES_DOLAR"].ToString()))
                            {
                                tidolar = Convert.ToDouble(tabla.Rows[0]["INTERESES_DOLAR"]);

                            }
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ANT_DOLAR"].ToString()))
                            {
                                tsaldoantdolar = Convert.ToDouble(tabla.Rows[0]["SALDO_ANT_DOLAR"]);

                            }
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ACT_DOLAR"].ToString()))
                                {
                                    tsaldoactdolar = Convert.ToDouble(tabla.Rows[0]["SALDO_ACT_DOLAR"]) ;

                                }
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ANT_LOCAL"].ToString()))
                            {
                                tsaldoantlocal = Convert.ToDouble(tabla.Rows[0]["SALDO_ANT_LOCAL"]) ;

                            }
                            if (!string.IsNullOrEmpty(tabla.Rows[0]["SALDO_ACT_LOCAL"].ToString()))
                                {
                                    tsaldoactlocal = Convert.ToDouble(tabla.Rows[0]["SALDO_ACT_LOCAL"]) * Convert.ToDouble(txtTC.Text);

                                }


                        //realizamos las respectivas conversiones de dolar a cordoba y viceversa
                        //dolares
                        double tint_dol = 0, tsaldoant_dol = 0, tsaldoact_dol = 0, tipo_cambio = 0;
                        //cordobas
                        double tsaldoant_loc = 0, tint_loc, tsaldoact_loc = 0;
                        //validamos el tipo de cambio para que no de error en la division en el caso que sea cero
                        if (Convert.ToDouble(txtTC.Text) <= 0)
                        {
                            tipo_cambio = 1;
                        }
                        else { tipo_cambio = Convert.ToDouble(txtTC.Text); }

                        tint_dol = tidolar + (tinio / tipo_cambio);
                        tsaldoant_dol = tsaldoantdolar + (tsaldoantlocal / tipo_cambio);
                        tsaldoact_dol = tsaldoactdolar + (tsaldoactlocal / tipo_cambio);

                        tint_loc = tinio + (tidolar * tipo_cambio);
                        tsaldoant_loc = tsaldoantlocal + (tsaldoantdolar * tipo_cambio);
                        tsaldoact_loc = tsaldoactlocal + (tsaldoactdolar * tipo_cambio);


                        // txtIntereses.Text = string.Format("{0:N}", tintereses);
                        txtTSaldoActDol.Text = string.Format("{0:N}", tsaldoact_dol);
                        txtTInteresDol.Text = string.Format("{0:N}", tint_dol);
                        txtTSaldoAntDol.Text = string.Format("{0:N}", tsaldoant_dol);
                        txtTSaldoAntLoc.Text = string.Format("{0:N}", tsaldoant_loc);
                        txtTInteresLoc.Text = string.Format("{0:N}", tint_loc);
                        txtTSaldoActLoc.Text = string.Format("{0:N}", tsaldoact_loc);
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, StaticData.oCnn.CompaniaActual, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class GridNewRowHelper
    {

        private readonly GridView _View;
        public GridNewRowHelper(GridView view)
        {
            _View = view;
            _View.HiddenEditor += _View_HiddenEditor;
            view.GridControl.EditorKeyDown += GridControl_EditorKeyDown;
            view.GridControl.KeyDown += new KeyEventHandler(GridControl_KeyDown);
        }

        void _View_HiddenEditor(object sender, EventArgs e)
        {
        }

        void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = OnKeyDown(e.KeyCode, e.Modifiers);
        }

        void GridControl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = OnKeyDown(e.KeyCode, e.Modifiers);
        }
        private bool OnKeyDown(Keys keyCode, Keys modifiers)
        {
            if (modifiers == Keys.None & (keyCode == Keys.Enter || keyCode == Keys.Tab))
            {
                return CheckAddNewRow();
            }
            return false;
        }

        private bool CheckAddNewRow()
        {
            if (_View.FocusedColumn.VisibleIndex == _View.VisibleColumns.Count - 1)
            {
                if (_View.IsNewItemRow(_View.FocusedRowHandle))
                {
                    _View.PostEditor();
                    _View.UpdateCurrentRow();
                }
                if (_View.IsLastRow)
                    return AddNewRow();
            }
            return false;
        }

        private bool AddNewRow()
        {
            _View.AddNewRow();
            _View.FocusedColumn = _View.VisibleColumns[0];
            return true;
        }
    }
}
