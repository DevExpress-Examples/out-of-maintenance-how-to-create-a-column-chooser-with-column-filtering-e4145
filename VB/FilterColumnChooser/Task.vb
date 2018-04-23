Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace FilterColumnChooserExample
	Public Class Task
		Public Property Name() As String
		Public Property StartDate() As Date
		Public Property FinishDate() As Date
		Public Property IsComplete() As Boolean

		Public ReadOnly Property COl1() As Object
			Get
				Return "test #1"
			End Get
		End Property
		Public ReadOnly Property COl2() As Object
			Get
				Return "test #2"
			End Get
		End Property
		Public ReadOnly Property COl3() As Object
			Get
				Return "test #3"
			End Get
		End Property
		Public ReadOnly Property COl4() As Object
			Get
				Return "test #4"
			End Get
		End Property
		Public ReadOnly Property COl5() As Object
			Get
				Return "test #5"
			End Get
		End Property
		Public ReadOnly Property COl6() As Object
			Get
				Return "test #6"
			End Get
		End Property
		Public ReadOnly Property COl7() As Object
			Get
				Return "test #7"
			End Get
		End Property

		Public Shared ReadOnly Property GetList() As ObservableCollection(Of Task)
			Get
				Dim collection As New ObservableCollection(Of Task)()
				For i As Integer = 0 To 4
					Dim rnd As New Random(i)
					Dim _startDate As Date = Date.Now.AddDays(i)
					collection.Add(New Task With {
						.Name = "Task " & i,
						.StartDate = _startDate,
						.FinishDate = _startDate.AddDays(rnd.Next(10, 20)),
						.IsComplete = rnd.Next(2) = 0
					})
				Next i
				Return collection
			End Get
		End Property
	End Class
End Namespace