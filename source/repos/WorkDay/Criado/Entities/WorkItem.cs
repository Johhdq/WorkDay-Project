using Criado.Enums;
using System;
using System.Collections.Generic;

namespace Criado.Entities
{
    public class WorkItem
    {
        public string Description { get; set; }
        public int CodItem { get; set; }
        public WorkItemCategory Category { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public WorkItem(string description, int codItem, WorkItemCategory category, DateTime start, DateTime finish)
        {
            Description = description;
            CodItem = codItem;
            Category = category;
            Start = start;
            Finish = finish;
        }

        public int TotalTime()
        {
            TimeSpan duration = Finish.Subtract(Start);

            if (duration.TotalMinutes >= 60 && duration.TotalHours < 24)
            {
                return (int)duration.TotalHours;
            }
            else if (duration.TotalMinutes < 60)
            {
                return (int)duration.TotalMinutes;
            }
            else
            {
                return (int)duration.Days;
            }
        }

        public override string ToString()
        {
            return "Category >> " + Category +  "; Description >> " + Description + "; Start >> " + Start + "; Finish >> " + Finish
                + "; Work Time >> " + TotalTime();
        }
    }
}

