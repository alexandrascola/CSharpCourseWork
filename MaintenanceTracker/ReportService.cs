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
        //Async task to report weekly labor 
        public async Task<List<WeeklyHours>> WeeklyLaborAsync(MaintenanceContext db)
        {
            var data = await db.WorkOrders.AsNoTracking().ToListAsync();

            return data
                .GroupBy( w=> WeekStartMonday(w.RequestDate))
                .Select(g => new WeeklyHours(g.Key, g.Count(), Math.Round(g.Sum(x => x.HoursWorked), 1)))
                .OrderBy(x => x.WeekOf)
                .ToList();
        }

        //Async task to report top performers
        public async Task<TopPerf?> TopPerformerAsync(MaintenanceContext db, int minClosed = 3)
        {
            var data = await db.WorkOrders.AsNoTracking().Include(w => w.Technician).ToListAsync();

            var s = data.Where(w => w.Status == "Closed" && w.CompletionDate.HasValue)
                .GroupBy(w => w.Technician.Name)
                .Select(g => new TopPerf(
                    g.Key,
                    g.Count(),
                    g.Average(w => (w.CompletionDate.Value - w.RequestDate).TotalDays)
                ))
                .Where(x => x.Closed >= minClosed)
                .OrderBy(x => x.AvgDays)
                .FirstOrDefault();
        return s is null ? null : s with {  AvgDays =Math.Round(s.AvgDays, 1) };
        }

        //Async task to get bonus info
        public async Task<BonusResult> BonusAsync(MaintenanceContext db, DateTime? nowUTC = null)
        {
            var now = nowUTC ?? DateTime.UtcNow;
            var data = await db.WorkOrders.AsNoTracking().ToListAsync();

            var busiest = data
                .Where(w => w.Status == "Closed" && w.CompletionDate.HasValue)
                .GroupBy(w => WeekStartMonday(w.CompletionDate.Value))
                .Select(g => new { WeekOf = g.Key, Closed = g.Count() })
                .OrderByDescending(x => x.Closed)
                .FirstOrDefault();

            var overdue = data
                .Where(w => w.Status == "Open" && (now - w.RequestDate).TotalDays > 7)
                .Count();
            return new BonusResult(busiest?.WeekOf, busiest?.Closed ?? 0, overdue);

        }


    }
}
