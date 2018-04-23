Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Grid
Imports System.Globalization

Namespace FilterColumnChooserExample
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			gcMain.ItemsSource = CreateData(10)
		End Sub

		Private Shared Function CreateData(ByVal listCnt As Integer) As List(Of Task)
			Dim rand As New Random()
			Dim list As New List(Of Task)()
			For i As Integer = 0 To listCnt - 1
				Dim startDate As New DateTime(rand.Next(DateTime.Today.Year - 3, DateTime.Today.Year), rand.Next(1, 12), rand.Next(1, 27))
				list.Add(New Task With {.Name = "Task" & (i + 1), .StartDate = startDate, .FinishDate = startDate.AddDays(rand.NextDouble() * (DateTime.Now.Subtract(startDate)).Days), .IsComplete = Math.Round(rand.NextDouble()) = 0})
			Next i
			Return list
		End Function
	End Class

	Public Class Task
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateStartDate As DateTime
		Public Property StartDate() As DateTime
			Get
				Return privateStartDate
			End Get
			Set(ByVal value As DateTime)
				privateStartDate = value
			End Set
		End Property
		Private privateFinishDate As DateTime
		Public Property FinishDate() As DateTime
			Get
				Return privateFinishDate
			End Get
			Set(ByVal value As DateTime)
				privateFinishDate = value
			End Set
		End Property
		Private privateIsComplete As Boolean
		Public Property IsComplete() As Boolean
			Get
				Return privateIsComplete
			End Get
			Set(ByVal value As Boolean)
				privateIsComplete = value
			End Set
		End Property
	End Class

	Public Class ColumnFilterMultiValueConverter
		Implements IMultiValueConverter
		Public Function Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
			Dim columns As ReadOnlyCollection(Of ColumnBase) = TryCast(values(0), ReadOnlyCollection(Of ColumnBase))
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