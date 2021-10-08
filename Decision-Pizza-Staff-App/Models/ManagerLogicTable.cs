using System.Collections.Generic;
using System.Linq;
using Decision_Pizza_Staff_App.Models.ModelShifts;
using Decision_Pizza_Staff_App.Models.Queries;

namespace Decision_Pizza_Staff_App.Models
{

    public class ManagerLogicTable : IManagerLogicTable
    {
        private readonly IGetSlotsStatus login;

        public ManagerLogicTable(IGetSlotsStatus login)
        {
            this.login = login;
        }

        public void ManagerLogic(WaiterManager waiterManager)
        {
            var pendingSlots = login.PendingSlots().ToList();
            var timeslotsResults = new List<TimeslotsResults>();

            // <MonDay
            

            // TuesDay


            foreach (var item in pendingSlots)
            {
                timeslotsResults.Add(new TimeslotsResults
                {
                    TimeSlotsId = item.TimeSlotsId,
                    EmployId = item.EmployId,
                    FullNames = item.FullNames,
                    Status = item.Status,
                    Time = item.Time,
                    Day = item.Day
                });
            }


            MondaySlots(waiterManager);
            TuesdaySlots(waiterManager);
            WednesDaySlots(waiterManager);
            ThursdaySlots(waiterManager);
            FriDaySlots(waiterManager);

            waiterManager.TimeslotsResults = timeslotsResults;
            
        }

        public void FriDaySlots(WaiterManager waiterManager)
        {
            var aprovedSlotsFridays = login.AprovedSlotsFridayss().ToList();
            var FridayModel = new List<ModelTable>();
            var FridaysModel2nd = new List<ModelTable>();
            var FridayModel3rd = new List<ModelTable>();
            for (int i = 0; i < aprovedSlotsFridays.Count; i++)
            {
                WaiterManager item = aprovedSlotsFridays[i];
                if (item.Time == "09:00 - 12:00")
                {
                    FridayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    FridaysModel2nd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    FridayModel3rd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
            }
            waiterManager.FridayModel = FridayModel;
            waiterManager.FridaysModel2nd = FridaysModel2nd;
            waiterManager.FridayModel3rd = FridayModel3rd;
        }

        public void WednesDaySlots(WaiterManager waiterManager)
        {
            var aprovedSlotsWednesdays = login.AprovedSlotsWednesdays().ToList();
            var WednesdayModel = new List<ModelTable>();
            var WednesdayModel2nd = new List<ModelTable>();
            var WednesdayModel3rd = new List<ModelTable>();
            for (int i = 0; i < aprovedSlotsWednesdays.Count; i++)
            {
                WaiterManager item = aprovedSlotsWednesdays[i];
                if (item.Time == "09:00 - 12:00")
                {
                    WednesdayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    WednesdayModel2nd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    WednesdayModel3rd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
            }
            waiterManager.WednesdayModel = WednesdayModel;
            waiterManager.WednesdayModel2nd = WednesdayModel2nd;
            waiterManager.WednesdayModel3rd = WednesdayModel3rd;
        }

        public void ThursdaySlots(WaiterManager waiterManager)
        {
            var aprovedSlotsThursday = login.AprovedSlotsThursdays().ToList();
            var ThursdayModel = new List<ModelTable>();
            var ThursdayModel2nd = new List<ModelTable>();
            var ThursdayModel3rd = new List<ModelTable>();
            for (int i = 0; i < aprovedSlotsThursday.Count; i++)
            {
                WaiterManager item = aprovedSlotsThursday[i];
                if (item.Time == "09:00 - 12:00")
                {
                    ThursdayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "12:00 - 16:00")
                {
                    ThursdayModel2nd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "16:00 - 21:00")
                {
                    ThursdayModel3rd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
            }
            waiterManager.ThursdayModel = ThursdayModel;
            waiterManager.ThursdayModel2nd = ThursdayModel2nd;
            waiterManager.ThursdayModel3rd = ThursdayModel3rd;
        }

        public void TuesdaySlots(WaiterManager waiterManager)
        {
            var aprovedSlotsTuesdays = login.AprovedSlotsTuesdays().ToList();
            var TuesdayModel = new List<ModelTable>();
            var TuesdayModel2nd = new List<ModelTable>();
            var TuesdayModel3rd = new List<ModelTable>();
            for (int i = 0; i < aprovedSlotsTuesdays.Count; i++)
            {
                WaiterManager item = aprovedSlotsTuesdays[i];
                if (item.Time == "09:00 - 12:00")
                {
                    TuesdayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "12:00 - 16:00")
                {
                    TuesdayModel2nd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "16:00 - 21:00")
                {
                    TuesdayModel3rd.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
            }
            waiterManager.TuesdayModel = TuesdayModel;
            waiterManager.TuesdayModel2nd = TuesdayModel2nd;
            waiterManager.TuesdayModel3rd = TuesdayModel3rd;
        }

        public void MondaySlots(WaiterManager waiterManager)
        {
            var aprovedSlotsMonday = login.AprovedSlotsMondays().ToList();
            var approvedFirstShiftModayModel = new List<ModelTable>();
            var approvedSecondShiftModayModel = new List<ModelTable>();
            var approvedThirdtShiftModayModel = new List<ModelTable>();
            foreach (var item in aprovedSlotsMonday)
            {
                if (item.Time == "09:00 - 12:00")
                {
                    approvedFirstShiftModayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "12:00 - 16:00")
                {
                    approvedSecondShiftModayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
                if (item.Time == "16:00 - 21:00")
                {
                    approvedThirdtShiftModayModel.Add(new ModelTable
                    {
                        EmployId = item.EmployId,
                        FullNames = item.FullNames
                    });
                }
            }
            waiterManager.ApprovedFirstShiftMondayModel = approvedFirstShiftModayModel;
            waiterManager.approvedSecondShiftMondayModel = approvedSecondShiftModayModel;
            waiterManager.approvedThirdtShiftMondayModel = approvedThirdtShiftModayModel;
        }
    }
}