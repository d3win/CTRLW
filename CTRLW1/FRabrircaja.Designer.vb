﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRabrircaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRabrircaja))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pblogoticket = New System.Windows.Forms.PictureBox()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.txtmontoinicial = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pblogoticket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.pblogoticket)
        Me.GroupBox1.Controls.Add(Me.btncerrar)
        Me.GroupBox1.Controls.Add(Me.txtmontoinicial)
        Me.GroupBox1.Controls.Add(Me.Label92)
        Me.GroupBox1.Controls.Add(Me.Button17)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 179)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Abriendo caja"
        '
        'pblogoticket
        '
        Me.pblogoticket.Location = New System.Drawing.Point(401, 22)
        Me.pblogoticket.Name = "pblogoticket"
        Me.pblogoticket.Size = New System.Drawing.Size(36, 33)
        Me.pblogoticket.TabIndex = 98
        Me.pblogoticket.TabStop = False
        Me.pblogoticket.Visible = False
        '
        'btncerrar
        '
        Me.btncerrar.BackColor = System.Drawing.Color.DimGray
        Me.btncerrar.FlatAppearance.BorderSize = 0
        Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btncerrar.Location = New System.Drawing.Point(264, 119)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(132, 44)
        Me.btncerrar.TabIndex = 24
        Me.btncerrar.Text = "Cancelar"
        Me.btncerrar.UseVisualStyleBackColor = False
        '
        'txtmontoinicial
        '
        Me.txtmontoinicial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtmontoinicial.BackColor = System.Drawing.Color.White
        Me.txtmontoinicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontoinicial.Location = New System.Drawing.Point(39, 68)
        Me.txtmontoinicial.Name = "txtmontoinicial"
        Me.txtmontoinicial.Size = New System.Drawing.Size(357, 35)
        Me.txtmontoinicial.TabIndex = 21
        '
        'Label92
        '
        Me.Label92.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label92.Location = New System.Drawing.Point(34, 26)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(148, 29)
        Me.Label92.TabIndex = 23
        Me.Label92.Text = "Monto inicial"
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.DimGray
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button17.Location = New System.Drawing.Point(39, 119)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(219, 44)
        Me.Button17.TabIndex = 20
        Me.Button17.Text = "AGREGAR"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'FRabrircaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(461, 201)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRabrircaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FRabrircaja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pblogoticket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button17 As Button
    Friend WithEvents txtmontoinicial As TextBox
    Friend WithEvents Label92 As Label
    Friend WithEvents btncerrar As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents pblogoticket As PictureBox
End Class
