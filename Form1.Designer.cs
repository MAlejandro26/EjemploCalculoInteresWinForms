namespace CALC_INTERES
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpleados = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.EMPLEADO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PUESTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOMBRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MONEDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SALDO_ANTERIOR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PORCENTAJE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INTERES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SALDO_NUEVO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOCUMENTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SUBTIPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESC_CORTA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESC_LARGA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.cmbSubtipo = new MetroFramework.Controls.MetroComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdAprobar = new DevExpress.XtraEditors.SimpleButton();
            this.cmdImprimirReporte = new DevExpress.XtraEditors.SimpleButton();
            this.cmdSalir = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCalcular = new DevExpress.XtraEditors.SimpleButton();
            this.cmbAnio = new MetroFramework.Controls.MetroComboBox();
            this.cmbMes = new MetroFramework.Controls.MetroComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTSaldoActLoc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTInteresLoc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTSaldoAntLoc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTSaldoActDol = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTInteresDol = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTSaldoAntDol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(37, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "T/C:";
            // 
            // txtEmpleados
            // 
            this.txtEmpleados.Location = new System.Drawing.Point(134, 30);
            this.txtEmpleados.Multiline = true;
            this.txtEmpleados.Name = "txtEmpleados";
            this.txtEmpleados.ReadOnly = true;
            this.txtEmpleados.Size = new System.Drawing.Size(150, 30);
            this.txtEmpleados.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(37, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empleado:";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(20, 185);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1030, 607);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.EMPLEADO,
            this.PUESTO,
            this.NOMBRE,
            this.MONEDA,
            this.SALDO_ANTERIOR,
            this.PORCENTAJE,
            this.INTERES,
            this.SALDO_NUEVO,
            this.DOCUMENTO,
            this.SUBTIPO,
            this.TIPO,
            this.DESC_CORTA,
            this.DESC_LARGA});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // EMPLEADO
            // 
            this.EMPLEADO.AppearanceCell.Options.UseTextOptions = true;
            this.EMPLEADO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.EMPLEADO.Caption = "Empleado";
            this.EMPLEADO.FieldName = "EMPLEADO";
            this.EMPLEADO.Name = "EMPLEADO";
            this.EMPLEADO.OptionsColumn.ReadOnly = true;
            this.EMPLEADO.Visible = true;
            this.EMPLEADO.VisibleIndex = 0;
            this.EMPLEADO.Width = 85;
            // 
            // PUESTO
            // 
            this.PUESTO.Caption = "Grado";
            this.PUESTO.FieldName = "PUESTO";
            this.PUESTO.Name = "PUESTO";
            this.PUESTO.OptionsColumn.ReadOnly = true;
            this.PUESTO.Visible = true;
            this.PUESTO.VisibleIndex = 1;
            this.PUESTO.Width = 64;
            // 
            // NOMBRE
            // 
            this.NOMBRE.AppearanceCell.Options.UseTextOptions = true;
            this.NOMBRE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NOMBRE.Caption = "Nombre y Apellidos";
            this.NOMBRE.FieldName = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.OptionsColumn.ReadOnly = true;
            this.NOMBRE.Visible = true;
            this.NOMBRE.VisibleIndex = 2;
            this.NOMBRE.Width = 337;
            // 
            // MONEDA
            // 
            this.MONEDA.AppearanceCell.Options.UseTextOptions = true;
            this.MONEDA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.MONEDA.Caption = "Moneda";
            this.MONEDA.FieldName = "MONEDA";
            this.MONEDA.Name = "MONEDA";
            this.MONEDA.OptionsColumn.ReadOnly = true;
            this.MONEDA.Visible = true;
            this.MONEDA.VisibleIndex = 3;
            // 
            // SALDO_ANTERIOR
            // 
            this.SALDO_ANTERIOR.AppearanceCell.Options.UseTextOptions = true;
            this.SALDO_ANTERIOR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SALDO_ANTERIOR.Caption = "Saldo Anterior";
            this.SALDO_ANTERIOR.DisplayFormat.FormatString = "N";
            this.SALDO_ANTERIOR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SALDO_ANTERIOR.FieldName = "SALDO_ANTERIOR";
            this.SALDO_ANTERIOR.Name = "SALDO_ANTERIOR";
            this.SALDO_ANTERIOR.OptionsColumn.ReadOnly = true;
            this.SALDO_ANTERIOR.Visible = true;
            this.SALDO_ANTERIOR.VisibleIndex = 4;
            this.SALDO_ANTERIOR.Width = 88;
            // 
            // PORCENTAJE
            // 
            this.PORCENTAJE.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PORCENTAJE.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PORCENTAJE.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.PORCENTAJE.AppearanceCell.Options.UseBackColor = true;
            this.PORCENTAJE.AppearanceCell.Options.UseForeColor = true;
            this.PORCENTAJE.AppearanceCell.Options.UseTextOptions = true;
            this.PORCENTAJE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PORCENTAJE.Caption = "%";
            this.PORCENTAJE.DisplayFormat.FormatString = "N";
            this.PORCENTAJE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PORCENTAJE.FieldName = "PORCENTAJE";
            this.PORCENTAJE.Name = "PORCENTAJE";
            this.PORCENTAJE.OptionsColumn.ReadOnly = true;
            this.PORCENTAJE.Visible = true;
            this.PORCENTAJE.VisibleIndex = 5;
            this.PORCENTAJE.Width = 45;
            // 
            // INTERES
            // 
            this.INTERES.AppearanceCell.Options.UseTextOptions = true;
            this.INTERES.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.INTERES.Caption = "Interés";
            this.INTERES.DisplayFormat.FormatString = "N";
            this.INTERES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.INTERES.FieldName = "INTERES";
            this.INTERES.Name = "INTERES";
            this.INTERES.OptionsColumn.ReadOnly = true;
            this.INTERES.Visible = true;
            this.INTERES.VisibleIndex = 6;
            this.INTERES.Width = 80;
            // 
            // SALDO_NUEVO
            // 
            this.SALDO_NUEVO.Caption = "Saldo Actual";
            this.SALDO_NUEVO.DisplayFormat.FormatString = "N";
            this.SALDO_NUEVO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SALDO_NUEVO.FieldName = "SALDO_NUEVO";
            this.SALDO_NUEVO.Name = "SALDO_NUEVO";
            this.SALDO_NUEVO.OptionsColumn.ReadOnly = true;
            this.SALDO_NUEVO.Visible = true;
            this.SALDO_NUEVO.VisibleIndex = 7;
            this.SALDO_NUEVO.Width = 82;
            // 
            // DOCUMENTO
            // 
            this.DOCUMENTO.AppearanceCell.Options.UseTextOptions = true;
            this.DOCUMENTO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DOCUMENTO.Caption = "Documento";
            this.DOCUMENTO.FieldName = "DOCUMENTO";
            this.DOCUMENTO.Name = "DOCUMENTO";
            this.DOCUMENTO.OptionsColumn.ReadOnly = true;
            this.DOCUMENTO.Visible = true;
            this.DOCUMENTO.VisibleIndex = 8;
            this.DOCUMENTO.Width = 139;
            // 
            // SUBTIPO
            // 
            this.SUBTIPO.Caption = "SUBTIPO";
            this.SUBTIPO.FieldName = "SUBTIPO";
            this.SUBTIPO.Name = "SUBTIPO";
            this.SUBTIPO.OptionsColumn.ReadOnly = true;
            // 
            // TIPO
            // 
            this.TIPO.Caption = "TIPO";
            this.TIPO.FieldName = "TIPO";
            this.TIPO.Name = "TIPO";
            this.TIPO.OptionsColumn.ReadOnly = true;
            // 
            // DESC_CORTA
            // 
            this.DESC_CORTA.Caption = "DESC_CORTA";
            this.DESC_CORTA.FieldName = "DESC_CORTA";
            this.DESC_CORTA.Name = "DESC_CORTA";
            this.DESC_CORTA.OptionsColumn.ReadOnly = true;
            // 
            // DESC_LARGA
            // 
            this.DESC_LARGA.Caption = "DESC_LARGA";
            this.DESC_LARGA.FieldName = "DESC_LARGA";
            this.DESC_LARGA.Name = "DESC_LARGA";
            this.DESC_LARGA.OptionsColumn.ReadOnly = true;
            // 
            // txtTC
            // 
            this.txtTC.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTC.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTC.Location = new System.Drawing.Point(134, 66);
            this.txtTC.Multiline = true;
            this.txtTC.Name = "txtTC";
            this.txtTC.ReadOnly = true;
            this.txtTC.Size = new System.Drawing.Size(150, 30);
            this.txtTC.TabIndex = 7;
            // 
            // cmbSubtipo
            // 
            this.cmbSubtipo.FormattingEnabled = true;
            this.cmbSubtipo.ItemHeight = 23;
            this.cmbSubtipo.Location = new System.Drawing.Point(450, 31);
            this.cmbSubtipo.Name = "cmbSubtipo";
            this.cmbSubtipo.Size = new System.Drawing.Size(199, 29);
            this.cmbSubtipo.TabIndex = 29;
            this.cmbSubtipo.SelectedIndexChanged += new System.EventHandler(this.cmbSubtipo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(447, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Sub Tipo:";
            // 
            // cmdAprobar
            // 
            this.cmdAprobar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdAprobar.ImageOptions.Image")));
            this.cmdAprobar.Location = new System.Drawing.Point(85, 62);
            this.cmdAprobar.Name = "cmdAprobar";
            this.cmdAprobar.Size = new System.Drawing.Size(40, 40);
            this.cmdAprobar.TabIndex = 28;
            this.cmdAprobar.ToolTip = "Aprobar";
            this.cmdAprobar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmdAprobar.Click += new System.EventHandler(this.cmdAprobar_Click);
            // 
            // cmdImprimirReporte
            // 
            this.cmdImprimirReporte.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimirReporte.ImageOptions.Image")));
            this.cmdImprimirReporte.Location = new System.Drawing.Point(131, 62);
            this.cmdImprimirReporte.Name = "cmdImprimirReporte";
            this.cmdImprimirReporte.Size = new System.Drawing.Size(40, 40);
            this.cmdImprimirReporte.TabIndex = 27;
            this.cmdImprimirReporte.ToolTip = "Imprimir Reporte";
            this.cmdImprimirReporte.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmdImprimirReporte.Click += new System.EventHandler(this.cmdImprimirReporte_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.ImageOptions.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(177, 62);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(40, 40);
            this.cmdSalir.TabIndex = 26;
            this.cmdSalir.ToolTip = "Salir";
            this.cmdSalir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdCalcular
            // 
            this.cmdCalcular.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cmdCalcular.ImageOptions.Image")));
            this.cmdCalcular.Location = new System.Drawing.Point(39, 62);
            this.cmdCalcular.Name = "cmdCalcular";
            this.cmdCalcular.Size = new System.Drawing.Size(40, 40);
            this.cmdCalcular.TabIndex = 25;
            this.cmdCalcular.ToolTip = "Cálcular";
            this.cmdCalcular.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmdCalcular.Click += new System.EventHandler(this.cmdCalcular_Click);
            // 
            // cmbAnio
            // 
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.ItemHeight = 23;
            this.cmbAnio.Location = new System.Drawing.Point(245, 31);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(199, 29);
            this.cmbAnio.TabIndex = 22;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio_SelectedIndexChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.ItemHeight = 23;
            this.cmbMes.Location = new System.Drawing.Point(40, 30);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(199, 29);
            this.cmbMes.TabIndex = 21;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(242, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(39, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mes:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.cmbMes);
            this.panel1.Controls.Add(this.cmbSubtipo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmdImprimirReporte);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdSalir);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmdAprobar);
            this.panel1.Controls.Add(this.cmbAnio);
            this.panel1.Controls.Add(this.cmdCalcular);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 110);
            this.panel1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtEmpleados);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(712, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 110);
            this.panel2.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(20, 798);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1030, 126);
            this.panel3.TabIndex = 32;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txtTSaldoActLoc);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.txtTInteresLoc);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.txtTSaldoAntLoc);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(515, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(515, 126);
            this.panel5.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(118, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Saldo Actual:";
            // 
            // txtTSaldoActLoc
            // 
            this.txtTSaldoActLoc.Location = new System.Drawing.Point(231, 86);
            this.txtTSaldoActLoc.Multiline = true;
            this.txtTSaldoActLoc.Name = "txtTSaldoActLoc";
            this.txtTSaldoActLoc.ReadOnly = true;
            this.txtTSaldoActLoc.Size = new System.Drawing.Size(150, 30);
            this.txtTSaldoActLoc.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label12.Location = new System.Drawing.Point(118, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "Intereses:";
            // 
            // txtTInteresLoc
            // 
            this.txtTInteresLoc.Location = new System.Drawing.Point(231, 56);
            this.txtTInteresLoc.Multiline = true;
            this.txtTInteresLoc.Name = "txtTInteresLoc";
            this.txtTInteresLoc.ReadOnly = true;
            this.txtTInteresLoc.Size = new System.Drawing.Size(150, 30);
            this.txtTInteresLoc.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label13.Location = new System.Drawing.Point(118, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Saldo Anterior:";
            // 
            // txtTSaldoAntLoc
            // 
            this.txtTSaldoAntLoc.Location = new System.Drawing.Point(231, 27);
            this.txtTSaldoAntLoc.Multiline = true;
            this.txtTSaldoAntLoc.Name = "txtTSaldoAntLoc";
            this.txtTSaldoAntLoc.ReadOnly = true;
            this.txtTSaldoAntLoc.Size = new System.Drawing.Size(150, 30);
            this.txtTSaldoAntLoc.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label14.Location = new System.Drawing.Point(285, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 14);
            this.label14.TabIndex = 15;
            this.label14.Text = "Total C$";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtTSaldoActDol);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtTInteresDol);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtTSaldoAntDol);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(515, 126);
            this.panel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label11.Location = new System.Drawing.Point(82, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "Saldo Actual:";
            // 
            // txtTSaldoActDol
            // 
            this.txtTSaldoActDol.Location = new System.Drawing.Point(195, 86);
            this.txtTSaldoActDol.Multiline = true;
            this.txtTSaldoActDol.Name = "txtTSaldoActDol";
            this.txtTSaldoActDol.ReadOnly = true;
            this.txtTSaldoActDol.Size = new System.Drawing.Size(150, 30);
            this.txtTSaldoActDol.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(82, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Intereses:";
            // 
            // txtTInteresDol
            // 
            this.txtTInteresDol.Location = new System.Drawing.Point(195, 56);
            this.txtTInteresDol.Multiline = true;
            this.txtTInteresDol.Name = "txtTInteresDol";
            this.txtTInteresDol.ReadOnly = true;
            this.txtTInteresDol.Size = new System.Drawing.Size(150, 30);
            this.txtTInteresDol.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(82, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Saldo Anterior:";
            // 
            // txtTSaldoAntDol
            // 
            this.txtTSaldoAntDol.Location = new System.Drawing.Point(195, 27);
            this.txtTSaldoAntDol.Multiline = true;
            this.txtTSaldoAntDol.Name = "txtTSaldoAntDol";
            this.txtTSaldoAntDol.ReadOnly = true;
            this.txtTSaldoAntDol.Size = new System.Drawing.Size(150, 30);
            this.txtTSaldoAntDol.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(208, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total $";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(732, 24);
            this.txtTipo.Multiline = true;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(74, 30);
            this.txtTipo.TabIndex = 33;
            this.txtTipo.Visible = false;
            this.txtTipo.TextChanged += new System.EventHandler(this.txtTipo_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1070, 944);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1038, 944);
            this.Name = "Form1";
            this.Text = "Cálculo de Interés";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpleados;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn EMPLEADO;
        private DevExpress.XtraGrid.Columns.GridColumn NOMBRE;
        private DevExpress.XtraGrid.Columns.GridColumn MONEDA;
        private DevExpress.XtraGrid.Columns.GridColumn SALDO_ANTERIOR;
        private DevExpress.XtraGrid.Columns.GridColumn PORCENTAJE;
        private DevExpress.XtraGrid.Columns.GridColumn INTERES;
        private DevExpress.XtraGrid.Columns.GridColumn DOCUMENTO;
        private System.Windows.Forms.TextBox txtTC;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private MetroFramework.Controls.MetroComboBox cmbSubtipo;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton cmdAprobar;
        private DevExpress.XtraEditors.SimpleButton cmdImprimirReporte;
        private DevExpress.XtraEditors.SimpleButton cmdSalir;
        private DevExpress.XtraEditors.SimpleButton cmdCalcular;
        private MetroFramework.Controls.MetroComboBox cmbAnio;
        private MetroFramework.Controls.MetroComboBox cmbMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.Columns.GridColumn PUESTO;
        private DevExpress.XtraGrid.Columns.GridColumn SALDO_NUEVO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTSaldoActLoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTInteresLoc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTSaldoAntLoc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTSaldoActDol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTInteresDol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTSaldoAntDol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTipo;
        private DevExpress.XtraGrid.Columns.GridColumn SUBTIPO;
        private DevExpress.XtraGrid.Columns.GridColumn TIPO;
        private DevExpress.XtraGrid.Columns.GridColumn DESC_CORTA;
        private DevExpress.XtraGrid.Columns.GridColumn DESC_LARGA;
    }
}

