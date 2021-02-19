<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcalculomarco
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcalculomarco))
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtcostofinal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.listaservicios = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.stxtnombre = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button69 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stxtcostofinal = New System.Windows.Forms.TextBox()
        Me.stxtmililitrosusados = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stxtcostomililitros = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stxtmililitros = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stxtclave = New System.Windows.Forms.TextBox()
        Me.stxtcosto = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.grilla2 = New System.Windows.Forms.DataGridView()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mililitros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precioxml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mlusados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costof = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.a1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbmensaje = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txttemporal = New System.Windows.Forms.TextBox()
        Me.txtclavemarco = New System.Windows.Forms.Button()
        Me.txtnombremarco = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.bgrilla = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnactualizar = New System.Windows.Forms.Button()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.bgrilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox26
        '
        Me.GroupBox26.BackColor = System.Drawing.Color.White
        Me.GroupBox26.Controls.Add(Me.Button2)
        Me.GroupBox26.Controls.Add(Me.txtcostofinal)
        Me.GroupBox26.Controls.Add(Me.Label9)
        Me.GroupBox26.Controls.Add(Me.listaservicios)
        Me.GroupBox26.Controls.Add(Me.Label10)
        Me.GroupBox26.Controls.Add(Me.stxtnombre)
        Me.GroupBox26.Controls.Add(Me.Label91)
        Me.GroupBox26.Controls.Add(Me.Label7)
        Me.GroupBox26.Controls.Add(Me.Button69)
        Me.GroupBox26.Controls.Add(Me.Label6)
        Me.GroupBox26.Controls.Add(Me.Label5)
        Me.GroupBox26.Controls.Add(Me.stxtcostofinal)
        Me.GroupBox26.Controls.Add(Me.stxtmililitrosusados)
        Me.GroupBox26.Controls.Add(Me.Label4)
        Me.GroupBox26.Controls.Add(Me.Label3)
        Me.GroupBox26.Controls.Add(Me.stxtcostomililitros)
        Me.GroupBox26.Controls.Add(Me.Label2)
        Me.GroupBox26.Controls.Add(Me.stxtmililitros)
        Me.GroupBox26.Controls.Add(Me.Label1)
        Me.GroupBox26.Controls.Add(Me.stxtclave)
        Me.GroupBox26.Controls.Add(Me.stxtcosto)
        Me.GroupBox26.Controls.Add(Me.Label90)
        Me.GroupBox26.Controls.Add(Me.Label92)
        Me.GroupBox26.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(354, 523)
        Me.GroupBox26.TabIndex = 10
        Me.GroupBox26.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(276, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 34)
        Me.Button2.TabIndex = 67
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtcostofinal
        '
        Me.txtcostofinal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcostofinal.BackColor = System.Drawing.Color.White
        Me.txtcostofinal.Enabled = False
        Me.txtcostofinal.Font = New System.Drawing.Font("Arial", 38.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostofinal.Location = New System.Drawing.Point(64, 440)
        Me.txtcostofinal.Name = "txtcostofinal"
        Me.txtcostofinal.Size = New System.Drawing.Size(224, 66)
        Me.txtcostofinal.TabIndex = 54
        '
        'Label9
        '
        Me.Label9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 38.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(20, 444)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 58)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "$"
        '
        'listaservicios
        '
        Me.listaservicios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listaservicios.FormattingEnabled = True
        Me.listaservicios.Location = New System.Drawing.Point(19, 123)
        Me.listaservicios.Name = "listaservicios"
        Me.listaservicios.Size = New System.Drawing.Size(328, 108)
        Me.listaservicios.TabIndex = 66
        '
        'Label10
        '
        Me.Label10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(61, 419)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 18)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Costo Final del marco"
        '
        'stxtnombre
        '
        Me.stxtnombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtnombre.BackColor = System.Drawing.Color.White
        Me.stxtnombre.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtnombre.Location = New System.Drawing.Point(19, 94)
        Me.stxtnombre.Multiline = True
        Me.stxtnombre.Name = "stxtnombre"
        Me.stxtnombre.Size = New System.Drawing.Size(329, 30)
        Me.stxtnombre.TabIndex = 65
        '
        'Label91
        '
        Me.Label91.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label91.Location = New System.Drawing.Point(18, 71)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(67, 17)
        Me.Label91.TabIndex = 64
        Me.Label91.Text = "Producto"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(20, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 27)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "$"
        '
        'Button69
        '
        Me.Button69.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Button69.FlatAppearance.BorderSize = 0
        Me.Button69.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button69.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button69.Image = CType(resources.GetObject("Button69.Image"), System.Drawing.Image)
        Me.Button69.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button69.Location = New System.Drawing.Point(30, 346)
        Me.Button69.Name = "Button69"
        Me.Button69.Size = New System.Drawing.Size(279, 68)
        Me.Button69.TabIndex = 7
        Me.Button69.Text = "Agregar a la lista"
        Me.Button69.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(19, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 27)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "$"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 38.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 275)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 58)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "$"
        '
        'stxtcostofinal
        '
        Me.stxtcostofinal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcostofinal.BackColor = System.Drawing.Color.White
        Me.stxtcostofinal.Font = New System.Drawing.Font("Arial", 38.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcostofinal.Location = New System.Drawing.Point(65, 272)
        Me.stxtcostofinal.Name = "stxtcostofinal"
        Me.stxtcostofinal.Size = New System.Drawing.Size(223, 66)
        Me.stxtcostofinal.TabIndex = 6
        '
        'stxtmililitrosusados
        '
        Me.stxtmililitrosusados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtmililitrosusados.BackColor = System.Drawing.Color.White
        Me.stxtmililitrosusados.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtmililitrosusados.Location = New System.Drawing.Point(192, 210)
        Me.stxtmililitrosusados.Name = "stxtmililitrosusados"
        Me.stxtmililitrosusados.Size = New System.Drawing.Size(142, 35)
        Me.stxtmililitrosusados.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(61, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Costo Final"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(193, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Cantidad Utilizada"
        '
        'stxtcostomililitros
        '
        Me.stxtcostomililitros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcostomililitros.BackColor = System.Drawing.Color.White
        Me.stxtcostomililitros.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcostomililitros.Location = New System.Drawing.Point(46, 210)
        Me.stxtcostomililitros.Name = "stxtcostomililitros"
        Me.stxtcostomililitros.Size = New System.Drawing.Size(141, 35)
        Me.stxtcostomililitros.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(46, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Precio por Unidad"
        '
        'stxtmililitros
        '
        Me.stxtmililitros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtmililitros.BackColor = System.Drawing.Color.White
        Me.stxtmililitros.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtmililitros.Location = New System.Drawing.Point(192, 147)
        Me.stxtmililitros.Name = "stxtmililitros"
        Me.stxtmililitros.Size = New System.Drawing.Size(142, 35)
        Me.stxtmililitros.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(189, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Cantidad Total"
        '
        'stxtclave
        '
        Me.stxtclave.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtclave.BackColor = System.Drawing.Color.White
        Me.stxtclave.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtclave.Location = New System.Drawing.Point(19, 30)
        Me.stxtclave.Name = "stxtclave"
        Me.stxtclave.Size = New System.Drawing.Size(251, 35)
        Me.stxtclave.TabIndex = 1
        '
        'stxtcosto
        '
        Me.stxtcosto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcosto.BackColor = System.Drawing.Color.White
        Me.stxtcosto.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcosto.Location = New System.Drawing.Point(46, 147)
        Me.stxtcosto.Name = "stxtcosto"
        Me.stxtcosto.Size = New System.Drawing.Size(140, 35)
        Me.stxtcosto.TabIndex = 2
        '
        'Label90
        '
        Me.Label90.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label90.Location = New System.Drawing.Point(46, 127)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(45, 16)
        Me.Label90.TabIndex = 14
        Me.Label90.Text = "Costo"
        '
        'Label92
        '
        Me.Label92.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label92.Location = New System.Drawing.Point(22, 10)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(106, 17)
        Me.Label92.TabIndex = 12
        Me.Label92.Text = "Clave producto"
        '
        'GroupBox28
        '
        Me.GroupBox28.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox28.Controls.Add(Me.grilla2)
        Me.GroupBox28.Controls.Add(Me.grilla)
        Me.GroupBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox28.Location = New System.Drawing.Point(372, 123)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(719, 270)
        Me.GroupBox28.TabIndex = 65
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Productos que pertenencen la Marco"
        '
        'grilla2
        '
        Me.grilla2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c1, Me.cla, Me.pro, Me.costo, Me.Mililitros, Me.Precioxml, Me.mlusados, Me.costof})
        Me.grilla2.Location = New System.Drawing.Point(6, 20)
        Me.grilla2.Name = "grilla2"
        Me.grilla2.RowTemplate.Height = 32
        Me.grilla2.Size = New System.Drawing.Size(699, 234)
        Me.grilla2.TabIndex = 1
        '
        'c1
        '
        Me.c1.HeaderText = "ID"
        Me.c1.Name = "c1"
        '
        'cla
        '
        Me.cla.HeaderText = "Clave"
        Me.cla.Name = "cla"
        '
        'pro
        '
        Me.pro.HeaderText = "Producto"
        Me.pro.Name = "pro"
        '
        'costo
        '
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        '
        'Mililitros
        '
        Me.Mililitros.HeaderText = "Mililitros"
        Me.Mililitros.Name = "Mililitros"
        '
        'Precioxml
        '
        Me.Precioxml.HeaderText = "Precio X Ml"
        Me.Precioxml.Name = "Precioxml"
        '
        'mlusados
        '
        Me.mlusados.HeaderText = "Ml Usados"
        Me.mlusados.Name = "mlusados"
        '
        'costof
        '
        Me.costof.HeaderText = "Costo Final"
        Me.costof.Name = "costof"
        '
        'grilla
        '
        Me.grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.a1, Me.c2, Me.c3, Me.c4, Me.c5, Me.c6, Me.c7, Me.c8})
        Me.grilla.Location = New System.Drawing.Point(6, 20)
        Me.grilla.Name = "grilla"
        Me.grilla.RowTemplate.Height = 32
        Me.grilla.Size = New System.Drawing.Size(699, 234)
        Me.grilla.TabIndex = 0
        '
        'a1
        '
        Me.a1.HeaderText = "N/P"
        Me.a1.Name = "a1"
        Me.a1.Width = 50
        '
        'c2
        '
        Me.c2.HeaderText = "Clave"
        Me.c2.Name = "c2"
        '
        'c3
        '
        Me.c3.HeaderText = "Producto"
        Me.c3.Name = "c3"
        Me.c3.Width = 120
        '
        'c4
        '
        Me.c4.HeaderText = "Costo"
        Me.c4.Name = "c4"
        '
        'c5
        '
        Me.c5.HeaderText = "Mililitros"
        Me.c5.Name = "c5"
        '
        'c6
        '
        Me.c6.HeaderText = "Precio X Ml"
        Me.c6.Name = "c6"
        '
        'c7
        '
        Me.c7.HeaderText = "Ml Usados"
        Me.c7.Name = "c7"
        '
        'c8
        '
        Me.c8.HeaderText = "Costo Final"
        Me.c8.Name = "c8"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbmensaje)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txttemporal)
        Me.GroupBox2.Controls.Add(Me.txtclavemarco)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(372, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(719, 102)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        '
        'lbmensaje
        '
        Me.lbmensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbmensaje.AutoSize = True
        Me.lbmensaje.BackColor = System.Drawing.Color.Red
        Me.lbmensaje.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmensaje.ForeColor = System.Drawing.Color.White
        Me.lbmensaje.Location = New System.Drawing.Point(159, 70)
        Me.lbmensaje.Name = "lbmensaje"
        Me.lbmensaje.Size = New System.Drawing.Size(306, 16)
        Me.lbmensaje.TabIndex = 92
        Me.lbmensaje.Text = "NOTA: La modificación se hace en el momento."
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(9, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 16)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Folio Consultado"
        '
        'txttemporal
        '
        Me.txttemporal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttemporal.BackColor = System.Drawing.Color.White
        Me.txttemporal.Enabled = False
        Me.txttemporal.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttemporal.Location = New System.Drawing.Point(12, 42)
        Me.txttemporal.Name = "txttemporal"
        Me.txttemporal.Size = New System.Drawing.Size(141, 44)
        Me.txttemporal.TabIndex = 90
        '
        'txtclavemarco
        '
        Me.txtclavemarco.BackColor = System.Drawing.Color.White
        Me.txtclavemarco.FlatAppearance.BorderSize = 0
        Me.txtclavemarco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtclavemarco.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclavemarco.ForeColor = System.Drawing.Color.White
        Me.txtclavemarco.Image = CType(resources.GetObject("txtclavemarco.Image"), System.Drawing.Image)
        Me.txtclavemarco.Location = New System.Drawing.Point(500, 19)
        Me.txtclavemarco.Name = "txtclavemarco"
        Me.txtclavemarco.Size = New System.Drawing.Size(209, 77)
        Me.txtclavemarco.TabIndex = 89
        Me.txtclavemarco.TabStop = False
        Me.txtclavemarco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtclavemarco.UseVisualStyleBackColor = False
        '
        'txtnombremarco
        '
        Me.txtnombremarco.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtnombremarco.BackColor = System.Drawing.Color.White
        Me.txtnombremarco.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombremarco.Location = New System.Drawing.Point(6, 33)
        Me.txtnombremarco.Name = "txtnombremarco"
        Me.txtnombremarco.Size = New System.Drawing.Size(342, 35)
        Me.txtnombremarco.TabIndex = 65
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(3, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(184, 16)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Nombre y medida del marco"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.bgrilla)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(368, 399)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(723, 221)
        Me.GroupBox4.TabIndex = 69
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Marcos Existentes"
        '
        'bgrilla
        '
        Me.bgrilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bgrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.bgrilla.Location = New System.Drawing.Point(14, 24)
        Me.bgrilla.Name = "bgrilla"
        Me.bgrilla.RowTemplate.Height = 32
        Me.bgrilla.Size = New System.Drawing.Size(703, 191)
        Me.bgrilla.TabIndex = 0
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FlowLayoutPanel3.Controls.Add(Me.btnguardar)
        Me.FlowLayoutPanel3.Controls.Add(Me.btnactualizar)
        Me.FlowLayoutPanel3.Controls.Add(Me.btneliminar)
        Me.FlowLayoutPanel3.Controls.Add(Me.Button8)
        Me.FlowLayoutPanel3.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(1107, 0)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(121, 630)
        Me.FlowLayoutPanel3.TabIndex = 73
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnguardar.FlatAppearance.BorderSize = 0
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.ForeColor = System.Drawing.Color.White
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.Location = New System.Drawing.Point(3, 3)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(118, 76)
        Me.btnguardar.TabIndex = 180
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'btnactualizar
        '
        Me.btnactualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnactualizar.FlatAppearance.BorderSize = 0
        Me.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnactualizar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnactualizar.ForeColor = System.Drawing.Color.White
        Me.btnactualizar.Image = CType(resources.GetObject("btnactualizar.Image"), System.Drawing.Image)
        Me.btnactualizar.Location = New System.Drawing.Point(3, 85)
        Me.btnactualizar.Name = "btnactualizar"
        Me.btnactualizar.Size = New System.Drawing.Size(118, 76)
        Me.btnactualizar.TabIndex = 182
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
        Me.btneliminar.Location = New System.Drawing.Point(3, 167)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(118, 74)
        Me.btneliminar.TabIndex = 181
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
        Me.Button8.Location = New System.Drawing.Point(3, 247)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(118, 76)
        Me.Button8.TabIndex = 183
        Me.Button8.Text = "Cancelar"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(3, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 74)
        Me.Button1.TabIndex = 184
        Me.Button1.Text = "Limpiar (F4)"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtnombremarco)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 84)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'frmcalculomarco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1228, 630)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox28)
        Me.Controls.Add(Me.GroupBox26)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmcalculomarco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular costo del marco"
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.bgrilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox26 As GroupBox
    Friend WithEvents stxtclave As TextBox
    Friend WithEvents Button69 As Button
    Friend WithEvents stxtcosto As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents stxtmililitros As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox28 As GroupBox
    Friend WithEvents grilla As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents stxtcostofinal As TextBox
    Friend WithEvents stxtmililitrosusados As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents stxtcostomililitros As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcostofinal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents listaservicios As ListBox
    Friend WithEvents stxtnombre As TextBox
    Friend WithEvents Label91 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtnombremarco As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtclavemarco As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents bgrilla As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents btnguardar As Button
    Friend WithEvents btnactualizar As Button
    Friend WithEvents btneliminar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grilla2 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents txttemporal As TextBox
    Friend WithEvents c1 As DataGridViewTextBoxColumn
    Friend WithEvents cla As DataGridViewTextBoxColumn
    Friend WithEvents pro As DataGridViewTextBoxColumn
    Friend WithEvents costo As DataGridViewTextBoxColumn
    Friend WithEvents Mililitros As DataGridViewTextBoxColumn
    Friend WithEvents Precioxml As DataGridViewTextBoxColumn
    Friend WithEvents mlusados As DataGridViewTextBoxColumn
    Friend WithEvents costof As DataGridViewTextBoxColumn
    Friend WithEvents a1 As DataGridViewTextBoxColumn
    Friend WithEvents c2 As DataGridViewTextBoxColumn
    Friend WithEvents c3 As DataGridViewTextBoxColumn
    Friend WithEvents c4 As DataGridViewTextBoxColumn
    Friend WithEvents c5 As DataGridViewTextBoxColumn
    Friend WithEvents c6 As DataGridViewTextBoxColumn
    Friend WithEvents c7 As DataGridViewTextBoxColumn
    Friend WithEvents c8 As DataGridViewTextBoxColumn
    Friend WithEvents lbmensaje As Label
    Friend WithEvents Label8 As Label
End Class
