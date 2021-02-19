<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmnuevovinil
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmnuevovinil))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtflete = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtdesperdicio = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtmobra = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtmantenimiento = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txttransfer = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtutilidad = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcantidadtotalvinil = New System.Windows.Forms.TextBox()
        Me.txtcostometro = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtprecioxmetro = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.vtxt3largocm = New System.Windows.Forms.TextBox()
        Me.vtxt10precioxcm = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.vtxt5cmdisponibles = New System.Windows.Forms.TextBox()
        Me.txtcostounitario = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vtxt4anchocm = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.vtxt8costoxcm = New System.Windows.Forms.TextBox()
        Me.vtxt1claveproducto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.vtxt2nombreproducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button78 = New System.Windows.Forms.Button()
        Me.btnactualizar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.grilla)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1047, 462)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'grilla
        '
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(592, 19)
        Me.grilla.Name = "grilla"
        Me.grilla.Size = New System.Drawing.Size(447, 429)
        Me.grilla.TabIndex = 172
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.vtxt1claveproducto)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.vtxt2nombreproducto)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(565, 429)
        Me.GroupBox4.TabIndex = 171
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Producto"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtflete)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.txtdesperdicio)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.txtmobra)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.txtmantenimiento)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.txttransfer)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtutilidad)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.txtiva)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.txtcantidadtotalvinil)
        Me.GroupBox5.Controls.Add(Me.txtcostometro)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Location = New System.Drawing.Point(19, 92)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(265, 329)
        Me.GroupBox5.TabIndex = 174
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = "3"
        Me.GroupBox5.Text = "Valores"
        '
        'txtflete
        '
        Me.txtflete.BackColor = System.Drawing.Color.White
        Me.txtflete.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtflete.Location = New System.Drawing.Point(11, 162)
        Me.txtflete.Name = "txtflete"
        Me.txtflete.Size = New System.Drawing.Size(101, 35)
        Me.txtflete.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(9, 143)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 16)
        Me.Label22.TabIndex = 174
        Me.Label22.Text = "Flete ($)"
        '
        'txtdesperdicio
        '
        Me.txtdesperdicio.BackColor = System.Drawing.Color.White
        Me.txtdesperdicio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdesperdicio.Location = New System.Drawing.Point(139, 220)
        Me.txtdesperdicio.Name = "txtdesperdicio"
        Me.txtdesperdicio.Size = New System.Drawing.Size(101, 35)
        Me.txtdesperdicio.TabIndex = 9
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(136, 201)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(105, 16)
        Me.Label21.TabIndex = 172
        Me.Label21.Text = "Desperdicio ($)"
        '
        'txtmobra
        '
        Me.txtmobra.BackColor = System.Drawing.Color.White
        Me.txtmobra.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobra.Location = New System.Drawing.Point(140, 162)
        Me.txtmobra.Name = "txtmobra"
        Me.txtmobra.Size = New System.Drawing.Size(101, 35)
        Me.txtmobra.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(137, 143)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 16)
        Me.Label20.TabIndex = 170
        Me.Label20.Text = "M/Obra ($)"
        '
        'txtmantenimiento
        '
        Me.txtmantenimiento.BackColor = System.Drawing.Color.White
        Me.txtmantenimiento.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmantenimiento.Location = New System.Drawing.Point(139, 105)
        Me.txtmantenimiento.Name = "txtmantenimiento"
        Me.txtmantenimiento.Size = New System.Drawing.Size(101, 35)
        Me.txtmantenimiento.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(136, 86)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 16)
        Me.Label19.TabIndex = 168
        Me.Label19.Text = "Mantenimiento ($)"
        '
        'txttransfer
        '
        Me.txttransfer.BackColor = System.Drawing.Color.White
        Me.txttransfer.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttransfer.Location = New System.Drawing.Point(140, 48)
        Me.txttransfer.Name = "txttransfer"
        Me.txttransfer.Size = New System.Drawing.Size(101, 35)
        Me.txttransfer.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(137, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 16)
        Me.Label18.TabIndex = 166
        Me.Label18.Text = "Transfer ($)"
        '
        'txtutilidad
        '
        Me.txtutilidad.BackColor = System.Drawing.Color.White
        Me.txtutilidad.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad.Location = New System.Drawing.Point(12, 278)
        Me.txtutilidad.Name = "txtutilidad"
        Me.txtutilidad.Size = New System.Drawing.Size(101, 35)
        Me.txtutilidad.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(9, 259)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 16)
        Me.Label14.TabIndex = 162
        Me.Label14.Text = "Utilidad ($)"
        '
        'txtiva
        '
        Me.txtiva.BackColor = System.Drawing.Color.White
        Me.txtiva.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtiva.Location = New System.Drawing.Point(11, 220)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(101, 35)
        Me.txtiva.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(9, 201)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 160
        Me.Label15.Text = "Iva ($)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(5, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 16)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Costo/Metro ($)"
        '
        'txtcantidadtotalvinil
        '
        Me.txtcantidadtotalvinil.BackColor = System.Drawing.Color.White
        Me.txtcantidadtotalvinil.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidadtotalvinil.Location = New System.Drawing.Point(8, 48)
        Me.txtcantidadtotalvinil.Name = "txtcantidadtotalvinil"
        Me.txtcantidadtotalvinil.Size = New System.Drawing.Size(105, 35)
        Me.txtcantidadtotalvinil.TabIndex = 1
        '
        'txtcostometro
        '
        Me.txtcostometro.BackColor = System.Drawing.Color.White
        Me.txtcostometro.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostometro.Location = New System.Drawing.Point(8, 105)
        Me.txtcostometro.Name = "txtcostometro"
        Me.txtcostometro.Size = New System.Drawing.Size(105, 35)
        Me.txtcostometro.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(5, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 16)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "Cantidad vinil (m)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtprecioxmetro)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.vtxt3largocm)
        Me.GroupBox3.Controls.Add(Me.vtxt10precioxcm)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.vtxt5cmdisponibles)
        Me.GroupBox3.Controls.Add(Me.txtcostounitario)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.vtxt4anchocm)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.vtxt8costoxcm)
        Me.GroupBox3.Location = New System.Drawing.Point(290, 92)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(269, 329)
        Me.GroupBox3.TabIndex = 173
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "4"
        Me.GroupBox3.Text = "Valores de "
        '
        'txtprecioxmetro
        '
        Me.txtprecioxmetro.BackColor = System.Drawing.Color.White
        Me.txtprecioxmetro.Enabled = False
        Me.txtprecioxmetro.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecioxmetro.Location = New System.Drawing.Point(19, 163)
        Me.txtprecioxmetro.Name = "txtprecioxmetro"
        Me.txtprecioxmetro.Size = New System.Drawing.Size(105, 35)
        Me.txtprecioxmetro.TabIndex = 165
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(16, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 16)
        Me.Label10.TabIndex = 166
        Me.Label10.Text = "Precio X m. ($)"
        '
        'vtxt3largocm
        '
        Me.vtxt3largocm.BackColor = System.Drawing.Color.White
        Me.vtxt3largocm.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt3largocm.Location = New System.Drawing.Point(19, 44)
        Me.vtxt3largocm.Name = "vtxt3largocm"
        Me.vtxt3largocm.Size = New System.Drawing.Size(106, 35)
        Me.vtxt3largocm.TabIndex = 100
        '
        'vtxt10precioxcm
        '
        Me.vtxt10precioxcm.BackColor = System.Drawing.Color.White
        Me.vtxt10precioxcm.Enabled = False
        Me.vtxt10precioxcm.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt10precioxcm.Location = New System.Drawing.Point(21, 220)
        Me.vtxt10precioxcm.Name = "vtxt10precioxcm"
        Me.vtxt10precioxcm.Size = New System.Drawing.Size(103, 35)
        Me.vtxt10precioxcm.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Largo (cm)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(16, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 16)
        Me.Label13.TabIndex = 160
        Me.Label13.Text = "Precio X cm. ($)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(16, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 16)
        Me.Label9.TabIndex = 147
        Me.Label9.Text = "cm2 disponibles"
        '
        'vtxt5cmdisponibles
        '
        Me.vtxt5cmdisponibles.BackColor = System.Drawing.Color.White
        Me.vtxt5cmdisponibles.Enabled = False
        Me.vtxt5cmdisponibles.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt5cmdisponibles.Location = New System.Drawing.Point(19, 105)
        Me.vtxt5cmdisponibles.Name = "vtxt5cmdisponibles"
        Me.vtxt5cmdisponibles.Size = New System.Drawing.Size(106, 35)
        Me.vtxt5cmdisponibles.TabIndex = 5
        '
        'txtcostounitario
        '
        Me.txtcostounitario.BackColor = System.Drawing.Color.White
        Me.txtcostounitario.Enabled = False
        Me.txtcostounitario.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostounitario.Location = New System.Drawing.Point(130, 106)
        Me.txtcostounitario.Name = "txtcostounitario"
        Me.txtcostounitario.Size = New System.Drawing.Size(106, 35)
        Me.txtcostounitario.TabIndex = 163
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(127, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 16)
        Me.Label17.TabIndex = 164
        Me.Label17.Text = "Costo unitario ($)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(133, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Ancho (cm)"
        '
        'vtxt4anchocm
        '
        Me.vtxt4anchocm.BackColor = System.Drawing.Color.White
        Me.vtxt4anchocm.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt4anchocm.Location = New System.Drawing.Point(136, 44)
        Me.vtxt4anchocm.Name = "vtxt4anchocm"
        Me.vtxt4anchocm.Size = New System.Drawing.Size(106, 35)
        Me.vtxt4anchocm.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(127, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Costo X cm. ($)"
        '
        'vtxt8costoxcm
        '
        Me.vtxt8costoxcm.BackColor = System.Drawing.Color.White
        Me.vtxt8costoxcm.Enabled = False
        Me.vtxt8costoxcm.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt8costoxcm.Location = New System.Drawing.Point(130, 163)
        Me.vtxt8costoxcm.Name = "vtxt8costoxcm"
        Me.vtxt8costoxcm.Size = New System.Drawing.Size(106, 35)
        Me.vtxt8costoxcm.TabIndex = 8
        '
        'vtxt1claveproducto
        '
        Me.vtxt1claveproducto.BackColor = System.Drawing.Color.White
        Me.vtxt1claveproducto.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt1claveproducto.Location = New System.Drawing.Point(19, 49)
        Me.vtxt1claveproducto.Name = "vtxt1claveproducto"
        Me.vtxt1claveproducto.Size = New System.Drawing.Size(124, 35)
        Me.vtxt1claveproducto.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.vtxt1claveproducto, "Clave del producto, puede ser cualquier valor numerica o texto")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(16, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 16)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Clave del producto"
        '
        'vtxt2nombreproducto
        '
        Me.vtxt2nombreproducto.BackColor = System.Drawing.Color.White
        Me.vtxt2nombreproducto.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vtxt2nombreproducto.Location = New System.Drawing.Point(158, 51)
        Me.vtxt2nombreproducto.Name = "vtxt2nombreproducto"
        Me.vtxt2nombreproducto.Size = New System.Drawing.Size(374, 35)
        Me.vtxt2nombreproducto.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(155, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 16)
        Me.Label6.TabIndex = 139
        Me.Label6.Text = "Nombre del producto"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlowLayoutPanel3.Controls.Add(Me.Button78)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnactualizar)
        Me.FlowLayoutPanel3.Controls.Add(Me.btneliminar)
        Me.FlowLayoutPanel3.Controls.Add(Me.Button8)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(1066, 0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(115, 482)
        Me.FlowLayoutPanel3.TabIndex = 183
        '
        'Button78
        '
        Me.Button78.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button78.FlatAppearance.BorderSize = 0
        Me.Button78.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button78.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button78.ForeColor = System.Drawing.Color.White
        Me.Button78.Image = CType(resources.GetObject("Button78.Image"), System.Drawing.Image)
        Me.Button78.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button78.Location = New System.Drawing.Point(3, 3)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(112, 76)
        Me.Button78.TabIndex = 14
        Me.Button78.Text = "Guardar"
        Me.Button78.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button78.UseVisualStyleBackColor = False
        '
        'btnactualizar
        '
        Me.btnactualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnactualizar.FlatAppearance.BorderSize = 0
        Me.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnactualizar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnactualizar.ForeColor = System.Drawing.Color.White
        Me.btnactualizar.Image = CType(resources.GetObject("btnactualizar.Image"), System.Drawing.Image)
        Me.btnactualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnactualizar.Location = New System.Drawing.Point(3, 85)
        Me.btnactualizar.Name = "btnactualizar"
        Me.btnactualizar.Size = New System.Drawing.Size(112, 76)
        Me.btnactualizar.TabIndex = 178
        Me.btnactualizar.Text = "Actualizar"
        Me.btnactualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnactualizar.UseVisualStyleBackColor = False
        '
        'btneliminar
        '
        Me.btneliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btneliminar.FlatAppearance.BorderSize = 0
        Me.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneliminar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneliminar.ForeColor = System.Drawing.Color.White
        Me.btneliminar.Image = CType(resources.GetObject("btneliminar.Image"), System.Drawing.Image)
        Me.btneliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btneliminar.Location = New System.Drawing.Point(3, 167)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(112, 74)
        Me.btneliminar.TabIndex = 176
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btneliminar.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(3, 247)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(112, 76)
        Me.Button8.TabIndex = 179
        Me.Button8.Text = "Cancelar"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'frmnuevovinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGreen
        Me.ClientSize = New System.Drawing.Size(1181, 482)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmnuevovinil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar nuevo vinil"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents vtxt5cmdisponibles As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcostometro As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents vtxt1claveproducto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents vtxt3largocm As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents vtxt2nombreproducto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents vtxt8costoxcm As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents vtxt4anchocm As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents Button78 As Button
    Friend WithEvents btneliminar As Button
    Friend WithEvents btnactualizar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents vtxt10precioxcm As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents grilla As DataGridView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtflete As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtdesperdicio As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtmobra As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtmantenimiento As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txttransfer As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtutilidad As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtiva As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtcantidadtotalvinil As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtcostounitario As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtprecioxmetro As TextBox
    Friend WithEvents Label10 As Label
End Class
