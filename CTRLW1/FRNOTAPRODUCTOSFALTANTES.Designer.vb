<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRNOTAPRODUCTOSFALTANTES
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
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource9 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRNOTAPRODUCTOSFALTANTES))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dwinDataSet = New CTRLW1.dwinDataSet()
        Me.dslogoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.datos_empresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DTPRODUCTOSFALTANTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPRODUCTOSFALTANTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource7.Name = "dslogo"
        ReportDataSource7.Value = Me.dslogoBindingSource
        ReportDataSource8.Name = "dsdatos_empresa"
        ReportDataSource8.Value = Me.datos_empresaBindingSource
        ReportDataSource9.Name = "dsproductosfaltantes"
        ReportDataSource9.Value = Me.DTPRODUCTOSFALTANTESBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource8)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource9)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CTRLW1.rptNOTAPRODUCTOSFALTANTES.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'dwinDataSet
        '
        'Me.dwinDataSet.DataSetName = "dwinDataSet"
        'Me.dwinDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        ''
        'dslogoBindingSource
        '
        Me.dslogoBindingSource.DataMember = "dslogo"
        Me.dslogoBindingSource.DataSource = Me.dwinDataSet
        '
        'datos_empresaBindingSource
        '
        Me.datos_empresaBindingSource.DataMember = "datos_empresa"
        Me.datos_empresaBindingSource.DataSource = Me.dwinDataSet
        '
        'DTPRODUCTOSFALTANTESBindingSource
        '
        Me.DTPRODUCTOSFALTANTESBindingSource.DataMember = "DTPRODUCTOSFALTANTES"
        Me.DTPRODUCTOSFALTANTESBindingSource.DataSource = Me.dwinDataSet
        '
        'FRNOTAPRODUCTOSFALTANTES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRNOTAPRODUCTOSFALTANTES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LISTA PRODUCTOS FALTANTES"
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPRODUCTOSFALTANTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dslogoBindingSource As BindingSource
    Friend WithEvents dwinDataSet As dwinDataSet
    Friend WithEvents datos_empresaBindingSource As BindingSource
    Friend WithEvents DTPRODUCTOSFALTANTESBindingSource As BindingSource
End Class
