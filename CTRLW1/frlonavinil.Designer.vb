<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frlonavinil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frlonavinil))
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.stxtlistaclientes = New System.Windows.Forms.ListBox()
        Me.stxtdescripcion = New System.Windows.Forms.TextBox()
        Me.stxtclave = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Button68 = New System.Windows.Forms.Button()
        Me.stxtcliente = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Button69 = New System.Windows.Forms.Button()
        Me.stxtcantidad = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.GroupBox26.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox26
        '
        Me.GroupBox26.BackColor = System.Drawing.Color.White
        Me.GroupBox26.Controls.Add(Me.stxtlistaclientes)
        Me.GroupBox26.Controls.Add(Me.stxtdescripcion)
        Me.GroupBox26.Controls.Add(Me.stxtclave)
        Me.GroupBox26.Controls.Add(Me.Label88)
        Me.GroupBox26.Controls.Add(Me.Button68)
        Me.GroupBox26.Controls.Add(Me.stxtcliente)
        Me.GroupBox26.Controls.Add(Me.Label89)
        Me.GroupBox26.Controls.Add(Me.Button69)
        Me.GroupBox26.Controls.Add(Me.stxtcantidad)
        Me.GroupBox26.Controls.Add(Me.Label90)
        Me.GroupBox26.Controls.Add(Me.Label92)
        Me.GroupBox26.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(323, 295)
        Me.GroupBox26.TabIndex = 10
        Me.GroupBox26.TabStop = False
        '
        'stxtlistaclientes
        '
        Me.stxtlistaclientes.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtlistaclientes.FormattingEnabled = True
        Me.stxtlistaclientes.ItemHeight = 19
        Me.stxtlistaclientes.Location = New System.Drawing.Point(14, 142)
        Me.stxtlistaclientes.Name = "stxtlistaclientes"
        Me.stxtlistaclientes.Size = New System.Drawing.Size(258, 156)
        Me.stxtlistaclientes.TabIndex = 62
        '
        'stxtdescripcion
        '
        Me.stxtdescripcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtdescripcion.BackColor = System.Drawing.Color.White
        Me.stxtdescripcion.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtdescripcion.Location = New System.Drawing.Point(9, 173)
        Me.stxtdescripcion.Multiline = True
        Me.stxtdescripcion.Name = "stxtdescripcion"
        Me.stxtdescripcion.Size = New System.Drawing.Size(303, 59)
        Me.stxtdescripcion.TabIndex = 16
        '
        'stxtclave
        '
        Me.stxtclave.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtclave.BackColor = System.Drawing.Color.White
        Me.stxtclave.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtclave.Location = New System.Drawing.Point(13, 27)
        Me.stxtclave.Name = "stxtclave"
        Me.stxtclave.Size = New System.Drawing.Size(299, 27)
        Me.stxtclave.TabIndex = 1
        '
        'Label88
        '
        Me.Label88.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label88.Location = New System.Drawing.Point(11, 154)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(111, 21)
        Me.Label88.TabIndex = 58
        Me.Label88.Text = "Observación"
        '
        'Button68
        '
        Me.Button68.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button68.FlatAppearance.BorderSize = 0
        Me.Button68.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button68.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button68.Image = CType(resources.GetObject("Button68.Image"), System.Drawing.Image)
        Me.Button68.Location = New System.Drawing.Point(272, 119)
        Me.Button68.Name = "Button68"
        Me.Button68.Size = New System.Drawing.Size(46, 26)
        Me.Button68.TabIndex = 56
        Me.Button68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button68.UseVisualStyleBackColor = False
        '
        'stxtcliente
        '
        Me.stxtcliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcliente.BackColor = System.Drawing.Color.White
        Me.stxtcliente.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcliente.Location = New System.Drawing.Point(14, 120)
        Me.stxtcliente.Name = "stxtcliente"
        Me.stxtcliente.Size = New System.Drawing.Size(257, 27)
        Me.stxtcliente.TabIndex = 15
        '
        'Label89
        '
        Me.Label89.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label89.Location = New System.Drawing.Point(13, 101)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(66, 21)
        Me.Label89.TabIndex = 55
        Me.Label89.Text = "Cliente"
        '
        'Button69
        '
        Me.Button69.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Button69.FlatAppearance.BorderSize = 0
        Me.Button69.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button69.Image = CType(resources.GetObject("Button69.Image"), System.Drawing.Image)
        Me.Button69.Location = New System.Drawing.Point(9, 241)
        Me.Button69.Name = "Button69"
        Me.Button69.Size = New System.Drawing.Size(304, 42)
        Me.Button69.TabIndex = 17
        Me.Button69.Text = "(F2)"
        Me.Button69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button69.UseVisualStyleBackColor = False
        '
        'stxtcantidad
        '
        Me.stxtcantidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcantidad.BackColor = System.Drawing.Color.White
        Me.stxtcantidad.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcantidad.Location = New System.Drawing.Point(14, 73)
        Me.stxtcantidad.Name = "stxtcantidad"
        Me.stxtcantidad.Size = New System.Drawing.Size(298, 27)
        Me.stxtcantidad.TabIndex = 14
        '
        'Label90
        '
        Me.Label90.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label90.Location = New System.Drawing.Point(11, 54)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(82, 21)
        Me.Label90.TabIndex = 14
        Me.Label90.Text = "Cantidad"
        '
        'Label92
        '
        Me.Label92.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Arial", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label92.Location = New System.Drawing.Point(13, 9)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(56, 21)
        Me.Label92.TabIndex = 12
        Me.Label92.Text = "Clave"
        '
        'frlonavinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(974, 753)
        Me.Controls.Add(Me.GroupBox26)
        Me.Name = "frlonavinil"
        Me.Text = "frlonavinil"
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox26 As GroupBox
    Friend WithEvents stxtlistaclientes As ListBox
    Friend WithEvents stxtdescripcion As TextBox
    Friend WithEvents stxtclave As TextBox
    Friend WithEvents Label88 As Label
    Friend WithEvents Button68 As Button
    Friend WithEvents stxtcliente As TextBox
    Friend WithEvents Label89 As Label
    Friend WithEvents Button69 As Button
    Friend WithEvents stxtcantidad As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents Label92 As Label
End Class
