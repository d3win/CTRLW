<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRNOTAVENTASRAPIDAS
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRNOTAVENTASRAPIDAS))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dslogoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dwinDataSet = New CTRLW1.dwinDataSet()
        Me.datos_empresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DTVENTASRAPIDASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTVENTASRAPIDASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "dslogo"
        ReportDataSource4.Value = Me.dslogoBindingSource
        ReportDataSource5.Name = "dsdatos_empresa"
        ReportDataSource5.Value = Me.datos_empresaBindingSource
        ReportDataSource6.Name = "dsventasrapidas"
        ReportDataSource6.Value = Me.DTVENTASRAPIDASBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CTRLW1.rptVENTASRAPIDAS.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'dslogoBindingSource
        '
        Me.dslogoBindingSource.DataMember = "dslogo"
        Me.dslogoBindingSource.DataSource = Me.dwinDataSet
        '
        'dwinDataSet
        '
        'Me.dwinDataSet.DataSetName = "dwinDataSet"
        'Me.dwinDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'datos_empresaBindingSource
        '
        Me.datos_empresaBindingSource.DataMember = "datos_empresa"
        Me.datos_empresaBindingSource.DataSource = Me.dwinDataSet
        '
        'DTVENTASRAPIDASBindingSource
        '
        Me.DTVENTASRAPIDASBindingSource.DataMember = "DTVENTASRAPIDAS"
        Me.DTVENTASRAPIDASBindingSource.DataSource = Me.dwinDataSet
        '
        'FRNOTAVENTASRAPIDAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRNOTAVENTASRAPIDAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de ventas rapidas"
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTVENTASRAPIDASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dslogoBindingSource As BindingSource
    Friend WithEvents dwinDataSet As dwinDataSet
    Friend WithEvents datos_empresaBindingSource As BindingSource
    Friend WithEvents DTVENTASRAPIDASBindingSource As BindingSource
End Class
