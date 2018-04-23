Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Controls
Imports DevExpress.XtraScheduler

Namespace SilverlightApplication1
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
		Private restrictedArea As New TimeOfDayInterval(TimeSpan.FromHours(14), TimeSpan.FromHours(15))

        Private Sub schedulerControl1_AllowAppointmentConflicts(ByVal sender As Object, _
                                                                ByVal e As AppointmentConflictEventArgs)
            Dim interval As TimeInterval = e.Interval
            If (Not IsIntervalAllowed(interval)) Then
                e.Conflicts.Add(e.AppointmentClone)
            End If
        End Sub

        Private Sub schedulerControl1_AllowAppointmentCreate(ByVal sender As Object, _
                                                             ByVal e As AppointmentOperationEventArgs)
            e.Allow = IsIntervalAllowed(schedulerControl1.ActiveView.SelectedInterval)
        End Sub

		Private Function IsIntervalAllowed(ByVal interval As TimeInterval) As Boolean
			Dim dayStart As DateTime = interval.Start.Date
			Do While dayStart < interval.End
				If (Not IsIntervalAllowed(interval, dayStart)) Then
					Return False
				End If
				dayStart = dayStart.AddDays(1)
			Loop
			Return True
		End Function

        Private Function IsIntervalAllowed(ByVal interval As TimeInterval, _
                                           ByVal dayStart As DateTime) As Boolean
            Dim lunchTime As New TimeInterval(dayStart.Add(restrictedArea.Start), _
                                              dayStart.Add(restrictedArea.End))
            Return Not interval.IntersectsWithExcludingBounds(lunchTime)
        End Function
	End Class
End Namespace
