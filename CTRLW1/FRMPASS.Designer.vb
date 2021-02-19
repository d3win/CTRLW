<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMPASS
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button53 = New System.Windows.Forms.Button()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtpassnuevore = New System.Windows.Forms.TextBox()
        Me.txtpassnuevo = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtpassactual = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button53)
        Me.GroupBox1.Controls.Add(Me.Label73)
        Me.GroupBox1.Controls.Add(Me.Label61)
        Me.GroupBox1.Controls.Add(Me.txtpassnuevore)
        Me.GroupBox1.Controls.Add(Me.txtpassnuevo)
        Me.GroupBox1.Controls.Add(Me.Label59)
        Me.GroupBox1.Controls.Add(Me.txtpassactual)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 417)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button53
        '
        Me.Button53.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.Button53.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button53.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button53.ForeColor = System.Drawing.Color.White
        Me.Button53.Location = New System.Drawing.Point(18, 300)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(228, 98)
        Me.Button53.TabIndex = 62
        Me.Button53.Text = "Actualizar"
        Me.Button53.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button53.UseVisualStyleBackColor = False
        '
        'Label73
        '
        Me.Label73.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label73.Location = New System.Drawing.Point(63, 192)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(195, 17)
        Me.Label73.TabIndex = 60
        Me.Label73.Text = "Reingresa contraseña nueva"
        '
        'Label61
        '
        Me.Label61.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(63, 129)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(126, 17)
        Me.Label61.TabIndex = 61
        Me.Label61.Text = "Nueva contraseña"
        '
        'txtpassnuevore
        '
        Me.txtpassnuevore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpassnuevore.BackColor = System.Drawing.Color.White
        Me.txtpassnuevore.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassnuevore.Location = New System.Drawing.Point(63, 212)
        Me.txtpassnuevore.Name = "txtpassnuevore"
        Me.txtpassnuevore.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassnuevore.Size = New System.Drawing.Size(169, 35)
        Me.txtpassnuevore.TabIndex = 57
        '
        'txtpassnuevo
        '
        Me.txtpassnuevo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpassnuevo.BackColor = System.Drawing.Color.White
        Me.txtpassnuevo.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassnuevo.Location = New System.Drawing.Point(63, 149)
        Me.txtpassnuevo.Name = "txtpassnuevo"
        Me.txtpassnuevo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassnuevo.Size = New System.Drawing.Size(169, 35)
        Me.txtpassnuevo.TabIndex = 58
        '
        'Label59
        '
        Me.Label59.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label59.Location = New System.Drawing.Point(63, 28)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(127, 17)
        Me.Label59.TabIndex = 59
        Me.Label59.Text = "Contraseña actual"
        '
        'txtpassactual
        '
        Me.txtpassactual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpassactual.BackColor = System.Drawing.Color.White
        Me.txtpassactual.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassactual.Location = New System.Drawing.Point(63, 48)
        Me.txtpassactual.Name = "txtpassactual"
        Me.txtpassactual.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassactual.Size = New System.Drawing.Size(172, 35)
        Me.txtpassactual.TabIndex = 56
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(250, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 98)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "X"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FRMPASS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(344, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FRMPASS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar contraseña"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label73 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents txtpassnuevore As TextBox
    Friend WithEvents txtpassnuevo As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents txtpassactual As TextBox
    Friend WithEvents Button53 As Button
    Friend WithEvents Button1 As Button
End Class
