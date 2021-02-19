<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRventaporclientevinil
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button78 = New System.Windows.Forms.Button()
        Me.stxtfolio = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grilla2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.stxtlistaclientes = New System.Windows.Forms.ListBox()
        Me.stxtcliente = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox32.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Button78)
        Me.GroupBox3.Controls.Add(Me.stxtfolio)
        Me.GroupBox3.Location = New System.Drawing.Point(572, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(372, 154)
        Me.GroupBox3.TabIndex = 697
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Id seleccionado"
        '
        'Button78
        '
        Me.Button78.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button78.FlatAppearance.BorderSize = 0
        Me.Button78.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button78.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button78.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button78.Location = New System.Drawing.Point(149, 41)
        Me.Button78.Name = "Button78"
        Me.Button78.Size = New System.Drawing.Size(206, 55)
        Me.Button78.TabIndex = 691
        Me.Button78.Text = "Cerrar"
        Me.Button78.UseVisualStyleBackColor = False
        '
        'stxtfolio
        '
        Me.stxtfolio.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.stxtfolio.BackColor = System.Drawing.Color.White
        Me.stxtfolio.Font = New System.Drawing.Font("Arial", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtfolio.Location = New System.Drawing.Point(25, 46)
        Me.stxtfolio.Name = "stxtfolio"
        Me.stxtfolio.Size = New System.Drawing.Size(118, 50)
        Me.stxtfolio.TabIndex = 692
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grilla)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(386, 274)
        Me.GroupBox2.TabIndex = 696
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Elige el Servicio"
        '
        'grilla
        '
        Me.grilla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(6, 25)
        Me.grilla.Name = "grilla"
        Me.grilla.RowTemplate.Height = 32
        Me.grilla.Size = New System.Drawing.Size(374, 243)
        Me.grilla.TabIndex = 109
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grilla2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(412, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(643, 274)
        Me.GroupBox1.TabIndex = 695
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elige el Servicio"
        '
        'grilla2
        '
        Me.grilla2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla2.Location = New System.Drawing.Point(6, 25)
        Me.grilla2.Name = "grilla2"
        Me.grilla2.RowTemplate.Height = 32
        Me.grilla2.Size = New System.Drawing.Size(631, 243)
        Me.grilla2.TabIndex = 109
        '
        'GroupBox32
        '
        Me.GroupBox32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox32.Controls.Add(Me.stxtlistaclientes)
        Me.GroupBox32.Controls.Add(Me.stxtcliente)
        Me.GroupBox32.Controls.Add(Me.Label89)
        Me.GroupBox32.Location = New System.Drawing.Point(20, 12)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(534, 154)
        Me.GroupBox32.TabIndex = 694
        Me.GroupBox32.TabStop = False
        '
        'stxtlistaclientes
        '
        Me.stxtlistaclientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtlistaclientes.FormattingEnabled = True
        Me.stxtlistaclientes.ItemHeight = 24
        Me.stxtlistaclientes.Location = New System.Drawing.Point(23, 67)
        Me.stxtlistaclientes.Name = "stxtlistaclientes"
        Me.stxtlistaclientes.Size = New System.Drawing.Size(429, 76)
        Me.stxtlistaclientes.TabIndex = 109
        '
        'stxtcliente
        '
        Me.stxtcliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stxtcliente.BackColor = System.Drawing.Color.White
        Me.stxtcliente.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtcliente.Location = New System.Drawing.Point(23, 39)
        Me.stxtcliente.Name = "stxtcliente"
        Me.stxtcliente.Size = New System.Drawing.Size(429, 29)
        Me.stxtcliente.TabIndex = 107
        '
        'Label89
        '
        Me.Label89.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label89.Location = New System.Drawing.Point(22, 20)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(52, 16)
        Me.Label89.TabIndex = 108
        Me.Label89.Text = "Cliente"
        '
        'FRventaporclientevinil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1069, 488)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox32)
        Me.Name = "FRventaporclientevinil"
        Me.Text = "FRventaporclientevinil"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grilla2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button78 As Button
    Friend WithEvents stxtfolio As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents grilla As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grilla2 As DataGridView
    Friend WithEvents GroupBox32 As GroupBox
    Friend WithEvents stxtlistaclientes As ListBox
    Friend WithEvents stxtcliente As TextBox
    Friend WithEvents Label89 As Label
End Class
