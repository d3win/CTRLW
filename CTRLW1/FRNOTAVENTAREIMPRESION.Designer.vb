﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRNOTAVENTAREIMPRESION
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRNOTAVENTAREIMPRESION))
        Me.ventaproBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dwinDataSet = New CTRLW1.dwinDataSet()
        Me.datos_empresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dslogoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.ventaproBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ventaproBindingSource
        '
        Me.ventaproBindingSource.DataMember = "ventapro"
        Me.ventaproBindingSource.DataSource = Me.dwinDataSet
        '
        'dwinDataSet
        '
        Me.dwinDataSet.DataSetName = "dwinDataSet"
        Me.dwinDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'datos_empresaBindingSource
        '
        Me.datos_empresaBindingSource.DataMember = "datos_empresa"
        Me.datos_empresaBindingSource.DataSource = Me.dwinDataSet
        '
        'dslogoBindingSource
        '
        Me.dslogoBindingSource.DataMember = "dslogo"
        Me.dslogoBindingSource.DataSource = Me.dwinDataSet
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsventapro"
        ReportDataSource1.Value = Me.ventaproBindingSource
        ReportDataSource2.Name = "dsdatos_empresa"
        ReportDataSource2.Value = Me.datos_empresaBindingSource
        ReportDataSource3.Name = "dslogo"
        ReportDataSource3.Value = Me.dslogoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CTRLW1.rptventareimpresion.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(784, 461)
        Me.ReportViewer1.TabIndex = 0
        '
        'FRNOTAVENTAREIMPRESION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRNOTAVENTAREIMPRESION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REIMPRESION DE SERVICIO"
        CType(Me.ventaproBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwinDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datos_empresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dslogoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ventaproBindingSource As BindingSource
    Friend WithEvents dwinDataSet As dwinDataSet
    Friend WithEvents datos_empresaBindingSource As BindingSource
    Friend WithEvents dslogoBindingSource As BindingSource
End Class
