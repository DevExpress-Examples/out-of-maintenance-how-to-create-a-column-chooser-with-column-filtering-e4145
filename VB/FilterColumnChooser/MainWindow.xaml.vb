Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows

Namespace FilterColumnChooserExample
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim band As New GridControlBand() With {.Header = "Band" & gcMain.Bands.Count}
			If gcMain.Bands.Count = 0 Then
				Dim columns As List(Of GridColumn) = gcMain.Columns.ToList()
				gcMain.Columns.Clear()
				For Each item In columns
					band.Columns.Add(item)
				Next item
			End If
			gcMain.Bands.Add(band)
		End Sub

		Private Sub btn_ShowChooser_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			view.ShowColumnChooser()
		End Sub
	End Class
End Namespace