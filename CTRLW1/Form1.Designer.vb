<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.usuarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dwinDataSet = New CTRLW1.dwinDataSet()
        Me.ventaproBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.datos_empresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.usuarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ventaproBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(341, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "dsventapro"
        ReportDataSource1.Value = Me.ventaproBindingSource
        ReportDataSource2.Name = "dsdatos_empresa"
        ReportDataSource2.Value = Me.datos_empresaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CTRLW1.rptventa.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 53)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(758, 385)
        Me.ReportViewer1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(152, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 20)
        Me.TextBox1.TabIndex = 2
        '
        'usuarioBindingSource
        '
        Me.usuarioBindingSource.DataMember = "usuario"
        Me.usuarioBindingSource.DataSource = Me.dwinDataSet
        '
        'dwinDataSet
        '
        Me.dwinDataSet.DataSetName = "dwinDataSet"
        Me.dwinDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ventaproBindingSource
        '
        Me.ventaproBindingSource.DataMember = "ventapro"
        Me.ventaproBindingSource.DataSource = Me.dwinDataSet
        '
        'datos_empresaBindingSource
        '
        Me.datos_empresaBindingSource.DataMember = "datos_empresa"
        Me.datos_empresaBindingSource.DataSource = Me.dwinDataSet
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.usuarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ventaproBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents usuarioBindingSource As BindingSource
    Friend WithEvents dwinDataSet As dwinDataSet
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ventaproBindingSource As BindingSource
    Friend WithEvents datos_empresaBindingSource As BindingSource
End Class
