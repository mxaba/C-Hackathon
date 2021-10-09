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
                    if (FridayModel.Count <= 2)
                    {
                        FridayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });

                        waiterManager.ColourChangeFriShift1 = "table-danger text-secondary";

                    } 
                    if (FridayModel.Count == 3)
                    {
                        waiterManager.ColourChangeFriShift1 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    if (FridaysModel2nd.Count <= 2)
                    {
                        FridaysModel2nd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeFriShift2 = "table-danger text-secondary";
                    } 
                    if (FridaysModel2nd.Count == 3)
                    {
                        waiterManager.ColourChangeFriShift2 = "table-success text-secondary";

                    }
                    
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    if (FridayModel3rd.Count <= 2)
                    {
                        FridayModel3rd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeFriShift3 = "table-danger text-secondary";
                    } 
                    if (FridayModel3rd.Count == 3)
                    {
                        waiterManager.ColourChangeFriShift3 = "table-success text-secondary";

                    }
                    
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
                    if (WednesdayModel.Count <= 2)
                    {
                        WednesdayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeWednShift1 = "table-danger text-secondary";
                    } 
                    if (WednesdayModel.Count == 3)
                    {
                        waiterManager.ColourChangeWednShift1 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    if (WednesdayModel2nd.Count <= 2)
                    {
                        WednesdayModel2nd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeWednShift2 = "table-danger text-secondary";
                    } 
                    if (WednesdayModel2nd.Count == 3)
                    {
                        waiterManager.ColourChangeWednShift2 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    if (WednesdayModel3rd.Count <= 2)
                    {
                        WednesdayModel3rd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeWednShift3 = "table-danger text-secondary";
                    } 
                    if (WednesdayModel3rd.Count == 3)
                    {
                        waiterManager.ColourChangeWednShift3 = "table-success text-secondary";
                    }
                    
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
                    if (ThursdayModel.Count <= 2)
                    {
                        ThursdayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeThurShift1 = "table-danger text-secondary";
                    }
                    if (ThursdayModel.Count == 3)
                    {
                        waiterManager.ColourChangeThurShift1 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    if (ThursdayModel2nd.Count <= 2)
                    {
                        ThursdayModel2nd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeThurShift2 = "table-danger text-secondary";
                    } 
                    if (ThursdayModel2nd.Count == 3)
                    {
                        waiterManager.ColourChangeThurShift2 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    if (ThursdayModel3rd.Count <= 2)
                    {
                        ThursdayModel3rd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeThurShift3 = "table-danger text-secondary";
                    } 
                    if (ThursdayModel3rd.Count == 3)
                    {
                        waiterManager.ColourChangeThurShift3 = "table-success text-secondary";
                    }
                    
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
                    if (TuesdayModel.Count <= 2)
                    {
                        TuesdayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeTuesShift1 = "table-danger text-secondary";
                    } 
                    if (TuesdayModel.Count == 3)
                    {
                        waiterManager.ColourChangeTuesShift1 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    if (TuesdayModel2nd.Count <= 2)
                    {
                        TuesdayModel2nd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeTuesShift2 = "table-danger text-secondary";
                    } 
                    if (TuesdayModel2nd.Count == 3)
                    {
                        waiterManager.ColourChangeTuesShift2 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    if (TuesdayModel3rd.Count <= 2)
                    {
                        TuesdayModel3rd.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeTuesShift3 = "table-danger text-secondary";
                    } 
                    if (TuesdayModel3rd.Count == 3)
                    {
                        waiterManager.ColourChangeTuesShift3 = "table-success text-secondary";
                    }
                    
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
                    if (approvedFirstShiftModayModel.Count <= 2)
                    {
                        approvedFirstShiftModayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeMonShift1 = "table-danger text-secondary";
                    } 
                    if (approvedFirstShiftModayModel.Count == 3)
                    {
                        waiterManager.ColourChangeMonShift1 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "12:00 - 16:00")
                {
                    if (approvedSecondShiftModayModel.Count <= 2)
                    {
                        approvedSecondShiftModayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeMonShift2 = "table-danger text-secondary";
                    } 
                    if (approvedSecondShiftModayModel.Count == 3)
                    {
                        waiterManager.ColourChangeMonShift2 = "table-success text-secondary";
                    }
                    
                }
                else if (item.Time == "16:00 - 21:00")
                {
                    if (approvedThirdtShiftModayModel.Count <= 2)
                    {
                        approvedThirdtShiftModayModel.Add(new ModelTable
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames
                        });
                        waiterManager.ColourChangeMonShift3 = "table-danger text-secondary";
                    } 
                    if (approvedThirdtShiftModayModel.Count == 3)
                    {
                        waiterManager.ColourChangeMonShift3 = "table-success text-secondary";

                    }
                    
                }
            }
            waiterManager.ApprovedFirstShiftMondayModel = approvedFirstShiftModayModel;
            waiterManager.approvedSecondShiftMondayModel = approvedSecondShiftModayModel;
            waiterManager.approvedThirdtShiftMondayModel = approvedThirdtShiftModayModel; 
        }
    }
}