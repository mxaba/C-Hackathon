using System.Collections.Generic;
using Decision_Pizza_Staff_App.Models.ModelShifts;

namespace Decision_Pizza_Staff_App.Models
{

    public class WaiterManager
    {
        public string EmployId { get; set; }
        public string FullNames { get; set; }
        public string Status { get; set; }
        public int TimeSlotsId { get; set; }
        public List<TimeslotsResults> TimeslotsResults { get; set; }
        public List<ScheduledShift> ScheduledShift { get; set; }
        public List<ModelTable> ApprovedFirstShiftMondayModel { get; set; }
        public List<ModelTable> approvedSecondShiftMondayModel { get; set; }
        public List<ModelTable> approvedThirdtShiftMondayModel { get; set; }
        public List<ModelTable> TuesdayModel { get; set; }
        public List<ModelTable> TuesdayModel2nd { get; set; }
        public List<ModelTable> TuesdayModel3rd { get; set; }

         public List<ModelTable> WednesdayModel { get; set; }
        public List<ModelTable> WednesdayModel2nd { get; set; }
        public List<ModelTable> WednesdayModel3rd { get; set; }

        public List<ModelTable> ThursdayModel { get; set; }
        public List<ModelTable> ThursdayModel2nd { get; set; }
        public List<ModelTable> ThursdayModel3rd { get; set; }

        public List<ModelTable> FridayModel { get; set; }
        public List<ModelTable> FridaysModel2nd { get; set; }
        public List<ModelTable> FridayModel3rd { get; set; }

        public List<WaiterManager> RequestAddShift2 { get; set; }
        public List<WaiterManager> RequestAddShift3 { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Message { get; set; }

        // If less than three waiters for a shift, change this variable to = "table-danger text-secondary"
        public string ColourChange = "table-success text-secondary";
    }
}