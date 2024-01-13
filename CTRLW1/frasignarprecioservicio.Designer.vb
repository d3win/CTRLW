<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frasignarprecioservicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frasignarprecioservicio))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.txtprecioservicio = New System.Windows.Forms.TextBox()
        Me.Button94 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button94)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button17)
        Me.GroupBox1.Controls.Add(Me.txtprecioservicio)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 290)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 37)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "PRECIO PRODUCTO"
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.DimGray
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button17.Location = New System.Drawing.Point(14, 164)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(360, 63)
        Me.Button17.TabIndex = 20
        Me.Button17.Text = "ASIGNAR"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'txtprecioservicio
        '
        Me.txtprecioservicio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtprecioservicio.BackColor = System.Drawing.Color.White
        Me.txtprecioservicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 54.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecioservicio.Location = New System.Drawing.Point(29, 67)
        Me.txtprecioservicio.Name = "txtprecioservicio"
        Me.txtprecioservicio.Size = New System.Drawing.Size(330, 89)
        Me.txtprecioservicio.TabIndex = 18
        '
        'Button94
        '
        Me.Button94.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Button94.FlatAppearance.BorderSize = 0
        Me.Button94.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button94.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button94.ForeColor = System.Drawing.Color.White
        Me.Button94.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button94.Location = New System.Drawing.Point(14, 233)
        Me.Button94.Name = "Button94"
        Me.Button94.Size = New System.Drawing.Size(360, 36)
        Me.Button94.TabIndex = 109
        Me.Button94.Text = "Cancelar"
        Me.Button94.UseVisualStyleBackColor = False
        '
        'frasignarprecioservicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(399, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frasignarprecioservicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frasignarprecioservicio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button17 As Button
    Friend WithEvents txtprecioservicio As TextBox
    Friend WithEvents Button94 As Button
End Class
