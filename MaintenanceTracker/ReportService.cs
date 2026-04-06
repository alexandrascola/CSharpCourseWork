using MaintenanceTracker.WinForms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;

namespace MaintenanceTracker
{
    //Grid-friendly records
    public record TechSummary(string Tech, int Orders, double AvgHours, double AvgDaystoClose);
    public record StatusRow(string Name, string Status, int Count);
    public record WeeklyHours(DateTime WeekOf, int Orders, double TotalHours);
    public record TopPerf(string Tech, int Closed, double AvgDays);
    public record BonusResult(DateTime? BusiestWeek, int BusiestClosed, int OverdueCount);
    public class ReportService
    {
        //DateTime method to calculate time to close across multiple weeks
        private static DateTime WeekStartMonday(DateTime dt)
        {
            var local = dt.ToLocalTime().Date;
            int diff = (7 + (local.DayOfWeek - DayOfWeek.Monday)) % 7;
            return local.AddDays(diff);
        }

        //Async task to create a technician summary report
        public async Task<List<TechSummary>> TechnicianSummaryAsync(MaintenanceContext db)
        {
            //Get info from DB and store as a var
            var data = await db.WorkOrders.AsNoTracking().Include(w => w.Technician).ToListAsync();

            //Return some data in report form
            return data
                .GroupBy(w => w.Technician.Name)
                .Select(g =>
                {
                    var orders = g.ToList();
                    var closed = orders.Where(w => w.Status == "Closed" && w.CompletionDate.HasValue);
                    double avgHours = orders.Any() ? orders.Average(w => w.HoursWorked) : 0.0;
                    double avgDays = closed.Any()
                        ? closed.Average(w => (w.CompletionDate.Value - w.RequestDate).TotalDays)
                        : 0.0;
                    return new TechSummary(g.Key, orders.Count(), Math.Round(avgHours, 1), Math.Round(avgDays,1));
                })
                .OrderByDescending(x => x.Orders)
                .ToList();
        }
        //Async task to create a status summary report
        public async Task<(List<(string Status, int Count)> overall, List<StatusRow> perTech)> StatusSummaryAsync(MaintenanceContext db)
        {
            //Get data from DB
            var data = await db.WorkOrders.AsNoTracking().Include(w => w.Technician).ToListAsync();

            //Create overall summary
            var overall = data
                .GroupBy(w => w.Status)
                .Select(g => (Status: g.Key, g.Count()))
                .OrderByDescending(x => x.Item2)
                .ToList();

            //Create per-tech summary
            var perTech = data
                .GroupBy(w => new {w.Technician.Name, w.Status })
                .Select(g => new StatusRow(g.Key.Name, g.Key.Status, g.Count()))
                .OrderBy(x => x.Name).ThenByDescending(x => x.Count)
                .ToList();

            //Return both summaries
            return (overall, perTech);

        }

    }
}
