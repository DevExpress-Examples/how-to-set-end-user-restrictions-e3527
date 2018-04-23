using System;
using System.Windows.Controls;
using DevExpress.XtraScheduler;

namespace SilverlightApplication1 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
        TimeOfDayInterval restrictedArea = 
            new TimeOfDayInterval(TimeSpan.FromHours(14), TimeSpan.FromHours(15));

        private void schedulerControl1_AllowAppointmentConflicts(object sender, 
            AppointmentConflictEventArgs e) {
            TimeInterval interval = e.Interval;
            if (!IsIntervalAllowed(interval))
                e.Conflicts.Add(e.AppointmentClone);
        }

        private void schedulerControl1_AllowAppointmentCreate(object sender, 
            AppointmentOperationEventArgs e) {
            e.Allow = IsIntervalAllowed(schedulerControl1.ActiveView.SelectedInterval);
        }

        private bool IsIntervalAllowed(TimeInterval interval) {
            DateTime dayStart = interval.Start.Date;
            while (dayStart < interval.End) {
                if (!IsIntervalAllowed(interval, dayStart))
                    return false;
                dayStart = dayStart.AddDays(1);
            }
            return true;
        }

        bool IsIntervalAllowed(TimeInterval interval, DateTime dayStart) {
            TimeInterval lunchTime = new TimeInterval(dayStart.Add(restrictedArea.Start),
                dayStart.Add(restrictedArea.End));
            return !interval.IntersectsWithExcludingBounds(lunchTime);
        }  
    }
}
