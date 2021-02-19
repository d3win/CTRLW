<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frbuscarcompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frbuscarcompras))
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.gb2 = New System.Windows.Forms.GroupBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtnombreproducto = New System.Windows.Forms.TextBox()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grilla
        '
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Location = New System.Drawing.Point(6, 67)
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.Size = New System.Drawing.Size(321, 377)
        Me.grilla.TabIndex = 78
        '
        'gb2
        '
        Me.gb2.BackColor = System.Drawing.Color.White
        Me.gb2.Controls.Add(Me.grilla)
        Me.gb2.Controls.Add(Me.Label67)
        Me.gb2.Controls.Add(Me.txtnombreproducto)
        Me.gb2.Location = New System.Drawing.Point(-1, -3)
        Me.gb2.Name = "gb2"
        Me.gb2.Size = New System.Drawing.Size(336, 454)
        Me.gb2.TabIndex = 96
        Me.gb2.TabStop = False
        '
        'Label67
        '
        Me.Label67.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(6, 18)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(67, 17)
        Me.Label67.TabIndex = 63
        Me.Label67.Text = "Producto"
        '
        'txtnombreproducto
        '
        Me.txtnombreproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtnombreproducto.BackColor = System.Drawing.Color.White
        Me.txtnombreproducto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombreproducto.Location = New System.Drawing.Point(9, 35)
        Me.txtnombreproducto.Name = "txtnombreproducto"
        Me.txtnombreproducto.Size = New System.Drawing.Size(321, 26)
        Me.txtnombreproducto.TabIndex = 0
        '
        'frbuscarcompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(335, 449)
        Me.Controls.Add(Me.gb2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frbuscarcompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar producto"
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb2.ResumeLayout(False)
        Me.gb2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grilla As DataGridView
    Friend WithEvents gb2 As GroupBox
    Friend WithEvents Label67 As Label
    Friend WithEvents txtnombreproducto As TextBox
End Class
