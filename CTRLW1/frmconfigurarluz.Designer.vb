<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconfigurarluz
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmconfigurarluz))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button78 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdiasusado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcostohorasusado = New System.Windows.Forms.TextBox()
        Me.txtcostofinal = New System.Windows.Forms.TextBox()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.txtcostobimestral = New System.Windows.Forms.TextBox()
        Me.txtcostodiasusado = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button78)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtdiasusado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtcostohorasusado)
        Me.GroupBox1.Controls.Add(Me.txtcostofinal)
        Me.GroupBox1.Controls.Add(Me.Label133)
        Me.GroupBox1.Controls.Add(Me.Label125)
        Me.GroupBox1.Controls.Add(Me.Label124)
        Me.GroupBox1.Controls.Add(Me.Label137)
        Me.GroupBox1.Controls.Add(Me.Label138)
        Me.GroupBox1.Controls.Add(Me.txtcostobimestral)
        Me.GroupBox1.Controls.Add(Me.txtcostodiasusado)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(337, 369)
        Me.GroupBox1.TabIndex = 152
        Me.GroupBox1.TabStop = False
        '
        'Button78
        '
        Me.Button78.BackColor = System.Drawing.Color.Transparent
        Me.Button78.FlatAppearance.BorderSize = 0
        Me.Button78.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button78.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button78.Image = CType(resources.GetObject("Button78.Image"), System.Drawing.Image)
        Me.Button78.Location = New System.Drawing.Point(247, 252)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(62, 44)
        Me.Button78.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.Button78, "Da clic para actualizar la información")
        Me.Button78.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(143, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 27)
        Me.Label7.TabIndex = 158
        Me.Label7.Text = "$"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(44, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Dias usado"
        '
        'txtdiasusado
        '
        Me.txtdiasusado.BackColor = System.Drawing.Color.White
        Me.txtdiasusado.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiasusado.Location = New System.Drawing.Point(42, 114)
        Me.txtdiasusado.Name = "txtdiasusado"
        Me.txtdiasusado.Size = New System.Drawing.Size(93, 35)
        Me.txtdiasusado.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(47, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 16)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Horas trabajadas"
        '
        'txtcostohorasusado
        '
        Me.txtcostohorasusado.BackColor = System.Drawing.Color.White
        Me.txtcostohorasusado.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostohorasusado.Location = New System.Drawing.Point(42, 179)
        Me.txtcostohorasusado.Name = "txtcostohorasusado"
        Me.txtcostohorasusado.Size = New System.Drawing.Size(135, 35)
        Me.txtcostohorasusado.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtcostohorasusado, "Presiona ESC para salir")
        '
        'txtcostofinal
        '
        Me.txtcostofinal.BackColor = System.Drawing.Color.White
        Me.txtcostofinal.Enabled = False
        Me.txtcostofinal.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostofinal.Location = New System.Drawing.Point(42, 252)
        Me.txtcostofinal.Name = "txtcostofinal"
        Me.txtcostofinal.Size = New System.Drawing.Size(199, 44)
        Me.txtcostofinal.TabIndex = 145
        Me.txtcostofinal.Text = "0"
        '
        'Label133
        '
        Me.Label133.AutoSize = True
        Me.Label133.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label133.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label133.Location = New System.Drawing.Point(45, 233)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(109, 16)
        Me.Label133.TabIndex = 146
        Me.Label133.Text = "Costo h/Trabajo"
        '
        'Label125
        '
        Me.Label125.AutoSize = True
        Me.Label125.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label125.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label125.Location = New System.Drawing.Point(44, 26)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(133, 16)
        Me.Label125.TabIndex = 144
        Me.Label125.Text = "Costo Luz Bimestral"
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label124.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label124.Location = New System.Drawing.Point(171, 94)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(105, 16)
        Me.Label124.TabIndex = 142
        Me.Label124.Text = "Costo luz diario"
        '
        'Label137
        '
        Me.Label137.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label137.AutoSize = True
        Me.Label137.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label137.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label137.Location = New System.Drawing.Point(15, 50)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(25, 27)
        Me.Label137.TabIndex = 147
        Me.Label137.Text = "$"
        '
        'Label138
        '
        Me.Label138.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label138.AutoSize = True
        Me.Label138.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label138.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label138.Location = New System.Drawing.Point(15, 255)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(25, 27)
        Me.Label138.TabIndex = 148
        Me.Label138.Text = "$"
        '
        'txtcostobimestral
        '
        Me.txtcostobimestral.BackColor = System.Drawing.Color.White
        Me.txtcostobimestral.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostobimestral.Location = New System.Drawing.Point(42, 46)
        Me.txtcostobimestral.Name = "txtcostobimestral"
        Me.txtcostobimestral.Size = New System.Drawing.Size(199, 35)
        Me.txtcostobimestral.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtcostobimestral, "Presiona ESC para salir")
        '
        'txtcostodiasusado
        '
        Me.txtcostodiasusado.BackColor = System.Drawing.Color.White
        Me.txtcostodiasusado.Enabled = False
        Me.txtcostodiasusado.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcostodiasusado.Location = New System.Drawing.Point(174, 114)
        Me.txtcostodiasusado.Name = "txtcostodiasusado"
        Me.txtcostodiasusado.Size = New System.Drawing.Size(135, 35)
        Me.txtcostodiasusado.TabIndex = 141
        '
        'frmconfigurarluz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(356, 384)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmconfigurarluz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Valores de Luz Eléctrica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtdiasusado As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcostohorasusado As TextBox
    Friend WithEvents txtcostofinal As TextBox
    Friend WithEvents Label133 As Label
    Friend WithEvents Label125 As Label
    Friend WithEvents Label124 As Label
    Friend WithEvents Label137 As Label
    Friend WithEvents Label138 As Label
    Friend WithEvents txtcostobimestral As TextBox
    Friend WithEvents txtcostodiasusado As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button78 As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
