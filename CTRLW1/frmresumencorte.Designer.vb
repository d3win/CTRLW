<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmresumencorte
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbusuario = New System.Windows.Forms.Label()
        Me.lbfecha = New System.Windows.Forms.Label()
        Me.lbhora = New System.Windows.Forms.Label()
        Me.lbventatotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lbcantproductos = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbobservacion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbid = New System.Windows.Forms.Label()
        Me.lbhorafin = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbhorainicio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RESUMEN CORTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(70, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 31)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hora:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 31)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Venta Total:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Crimson
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(7, 532)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 75)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Ticket corte"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lbusuario
        '
        Me.lbusuario.AutoSize = True
        Me.lbusuario.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbusuario.Location = New System.Drawing.Point(151, 115)
        Me.lbusuario.Name = "lbusuario"
        Me.lbusuario.Size = New System.Drawing.Size(26, 25)
        Me.lbusuario.TabIndex = 6
        Me.lbusuario.Text = "--"
        '
        'lbfecha
        '
        Me.lbfecha.AutoSize = True
        Me.lbfecha.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbfecha.Location = New System.Drawing.Point(151, 163)
        Me.lbfecha.Name = "lbfecha"
        Me.lbfecha.Size = New System.Drawing.Size(26, 25)
        Me.lbfecha.TabIndex = 7
        Me.lbfecha.Text = "--"
        '
        'lbhora
        '
        Me.lbhora.AutoSize = True
        Me.lbhora.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbhora.Location = New System.Drawing.Point(155, 209)
        Me.lbhora.Name = "lbhora"
        Me.lbhora.Size = New System.Drawing.Size(26, 25)
        Me.lbhora.TabIndex = 8
        Me.lbhora.Text = "--"
        '
        'lbventatotal
        '
        Me.lbventatotal.AutoSize = True
        Me.lbventatotal.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbventatotal.Location = New System.Drawing.Point(204, 344)
        Me.lbventatotal.Name = "lbventatotal"
        Me.lbventatotal.Size = New System.Drawing.Size(33, 32)
        Me.lbventatotal.TabIndex = 9
        Me.lbventatotal.Text = "--"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.lbcantproductos)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lbobservacion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbid)
        Me.GroupBox1.Controls.Add(Me.lbhorafin)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbhorainicio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbventatotal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbhora)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbfecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbusuario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(488, 613)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Crimson
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(248, 532)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(159, 75)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "Ver resumen"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'lbcantproductos
        '
        Me.lbcantproductos.AutoSize = True
        Me.lbcantproductos.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcantproductos.Location = New System.Drawing.Point(204, 384)
        Me.lbcantproductos.Name = "lbcantproductos"
        Me.lbcantproductos.Size = New System.Drawing.Size(33, 32)
        Me.lbcantproductos.TabIndex = 21
        Me.lbcantproductos.Text = "--"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(43, 380)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(155, 31)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Cant. Prod.:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Crimson
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(132, 532)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 75)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Ticket ventas"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(37, 423)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 31)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Observacion:"
        '
        'lbobservacion
        '
        Me.lbobservacion.AutoSize = True
        Me.lbobservacion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbobservacion.Location = New System.Drawing.Point(46, 454)
        Me.lbobservacion.Name = "lbobservacion"
        Me.lbobservacion.Size = New System.Drawing.Size(18, 18)
        Me.lbobservacion.TabIndex = 17
        Me.lbobservacion.Text = "--"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 31)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Corte ID:"
        '
        'lbid
        '
        Me.lbid.AutoSize = True
        Me.lbid.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbid.Location = New System.Drawing.Point(149, 64)
        Me.lbid.Name = "lbid"
        Me.lbid.Size = New System.Drawing.Size(37, 36)
        Me.lbid.TabIndex = 16
        Me.lbid.Text = "--"
        '
        'lbhorafin
        '
        Me.lbhorafin.AutoSize = True
        Me.lbhorafin.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbhorafin.Location = New System.Drawing.Point(222, 310)
        Me.lbhorafin.Name = "lbhorafin"
        Me.lbhorafin.Size = New System.Drawing.Size(26, 25)
        Me.lbhorafin.TabIndex = 14
        Me.lbhorafin.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 31)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Hora fin corte:"
        '
        'lbhorainicio
        '
        Me.lbhorainicio.AutoSize = True
        Me.lbhorainicio.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbhorainicio.Location = New System.Drawing.Point(222, 273)
        Me.lbhorainicio.Name = "lbhorainicio"
        Me.lbhorainicio.Size = New System.Drawing.Size(26, 25)
        Me.lbhorainicio.TabIndex = 12
        Me.lbhorainicio.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Black", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 267)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(225, 31)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Hora inicio corte:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Crimson
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(444, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(38, 39)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "x"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'PrintDocument2
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmresumencorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Crimson
        Me.ClientSize = New System.Drawing.Size(511, 634)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmresumencorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmresumencorte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lbusuario As Label
    Friend WithEvents lbfecha As Label
    Friend WithEvents lbhora As Label
    Friend WithEvents lbventatotal As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents lbhorafin As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbhorainicio As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbid As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbobservacion As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents lbcantproductos As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PrintDocument2 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents Button4 As Button
End Class
