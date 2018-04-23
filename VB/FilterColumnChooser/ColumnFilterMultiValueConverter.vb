Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Data

Namespace FilterColumnChooserExample
	Public Class ColumnFilterMultiValueConverter
		Implements IMultiValueConverter

		Public Function Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
			If values(0) Is Nothing Then
				Return Nothing
			End If
			Dim columns = DirectCast(values(0), IList).Cast(Of BaseColumn)()
			Dim filter As String = values(1).ToString()
			If String.IsNullOrEmpty(filter) Then
				Return columns
			End If
			Return columns.Where(Function(col) col.HeaderCaption.ToString().StartsWith(filter, True, culture))
		End Function
		Public Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
	End Class
End Namespace
