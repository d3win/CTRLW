<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmconfigticket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmconfigticket))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.p1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.p2 = New System.Windows.Forms.TextBox()
        Me.p3 = New System.Windows.Forms.TextBox()
        Me.p4 = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.logoticket = New System.Windows.Forms.PictureBox()
        Me.pbabrir = New System.Windows.Forms.Button()
        Me.pbguardar = New System.Windows.Forms.Button()
        Me.txtruta = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logoticket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(158, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(370, 570)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'p1
        '
        Me.p1.Location = New System.Drawing.Point(40, 86)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(84, 20)
        Me.p1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Posición (0 - 100)"
        '
        'p2
        '
        Me.p2.Location = New System.Drawing.Point(40, 112)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(84, 20)
        Me.p2.TabIndex = 3
        '
        'p3
        '
        Me.p3.Location = New System.Drawing.Point(40, 138)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(84, 20)
        Me.p3.TabIndex = 4
        '
        'p4
        '
        Me.p4.Location = New System.Drawing.Point(40, 164)
        Me.p4.Name = "p4"
        Me.p4.Size = New System.Drawing.Size(84, 20)
        Me.p4.TabIndex = 5
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(534, 16)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(249, 228)
        Me.RichTextBox1.TabIndex = 7
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Crimson
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(30, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 39)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(32, 245)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 39)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Previsualizar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PrintDocument1
        '
        '
        'logoticket
        '
        Me.logoticket.Location = New System.Drawing.Point(853, 92)
        Me.logoticket.Name = "logoticket"
        Me.logoticket.Size = New System.Drawing.Size(263, 223)
        Me.logoticket.TabIndex = 10
        Me.logoticket.TabStop = False
        '
        'pbabrir
        '
        Me.pbabrir.BackColor = System.Drawing.Color.Crimson
        Me.pbabrir.ForeColor = System.Drawing.Color.White
        Me.pbabrir.Location = New System.Drawing.Point(853, 331)
        Me.pbabrir.Name = "pbabrir"
        Me.pbabrir.Size = New System.Drawing.Size(120, 39)
        Me.pbabrir.TabIndex = 11
        Me.pbabrir.Text = "Abrir"
        Me.pbabrir.UseVisualStyleBackColor = False
        '
        'pbguardar
        '
        Me.pbguardar.BackColor = System.Drawing.Color.Crimson
        Me.pbguardar.ForeColor = System.Drawing.Color.White
        Me.pbguardar.Location = New System.Drawing.Point(996, 331)
        Me.pbguardar.Name = "pbguardar"
        Me.pbguardar.Size = New System.Drawing.Size(120, 39)
        Me.pbguardar.TabIndex = 12
        Me.pbguardar.Text = "Guardar"
        Me.pbguardar.UseVisualStyleBackColor = False
        '
        'txtruta
        '
        Me.txtruta.Location = New System.Drawing.Point(853, 66)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.Size = New System.Drawing.Size(263, 20)
        Me.txtruta.TabIndex = 13
        '
        'frmconfigticket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1209, 644)
        Me.Controls.Add(Me.txtruta)
        Me.Controls.Add(Me.pbguardar)
        Me.Controls.Add(Me.pbabrir)
        Me.Controls.Add(Me.logoticket)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.p4)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmconfigticket"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar Tickets"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logoticket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents p1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents p2 As TextBox
    Friend WithEvents p3 As TextBox
    Friend WithEvents p4 As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents logoticket As PictureBox
    Friend WithEvents pbabrir As Button
    Friend WithEvents pbguardar As Button
    Friend WithEvents txtruta As TextBox
End Class
