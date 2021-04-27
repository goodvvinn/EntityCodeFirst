using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlTypes;
using EntityCodeFirst.Entities;
using EntityCodeFirst.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityCodeFirst
{
    public class EntitiesDataModify
    {
        private ApplicationContext _context;
        public EntitiesDataModify(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeEntityAsync()
        {
            Employee kirk = new Employee
            {
                FirstName = "Kirk",
                LastName = "Oganesyan",
                HiredDate = DateTime.Now,
                DateOfBirth = new DateTime(1998, 12, 03),
                OfficeId = 1,
                TitleId = 1
            };
            Employee mark = new Employee
            {
                FirstName = "Mark",
                LastName = "Oganesyan",
                HiredDate = DateTime.Now,
                DateOfBirth = new DateTime(1996, 12, 03),
                OfficeId = 2,
                TitleId = 2
            };
            Employee felicia = new Employee
            {
                FirstName = "Felicia",
                LastName = "Klark",
                HiredDate = DateTime.Now,
                DateOfBirth = new DateTime(1991, 12, 03),
                OfficeId = 2,
                TitleId = 3
            };
            Employee lora = new Employee
            {
                FirstName = "Lora",
                LastName = "Vega",
                HiredDate = DateTime.Now,
                DateOfBirth = new DateTime(2001, 12, 03),
                OfficeId = 2,
                TitleId = 1
            };
            Employee kristina = new Employee
            {
                FirstName = "Kristina",
                LastName = "Vega",
                HiredDate = DateTime.Now,
                DateOfBirth = new DateTime(2010, 12, 03),
                OfficeId = 1,
                TitleId = 3
            };
            await _context.Employee.AddRangeAsync(kirk, mark, felicia, lora, kristina);
            _context.SaveChanges();
        }

        public async Task DateTimeGapAsync()
        {
            try
            {
                var dateGap = await (from d in _context.Employee.AsQueryable().OrderByDescending(d => d.HiredDate)
                               select new
                               {
                                   FirstName = d.FirstName,
                                   LastName = d.LastName,
                                   StartDate = d.HiredDate,
                                   DateTimeNow = DateTime.Now,
                                   TimeDiff = DateTime.Now.Subtract(d.HiredDate).TotalMinutes
                               })
                               .ToListAsync();
                foreach (var dG in dateGap)
                {
                    Console.WriteLine($"{dG.FirstName} {dG.LastName} was hired:{dG.TimeDiff}  hours ago");
                }
            }
            catch (Exception)
            {
                throw new Exception("OOps some shit");
            }
        }

        public async Task EmployeeGroupByTitleAsync()
        {
            try
            {
                var employeeGroup = await _context.Employee
                    .Where(c => c.Title.Name.Contains("a"))
                    .GroupBy(u => u.Title.Name)
                    .Select(g => new
                {
                    g.Key,
                    Count = g.Count()
                }).ToListAsync();
                foreach (var group in employeeGroup)
                {
                    Console.WriteLine($"Group:{group.Key} - has {group.Count} members");
                }
            }
            catch (Exception)
            {
            }
        }

        public async Task EntityUpdateAsync()
        {
            try
            {
                var ofId = await _context.Employee
                    .Where(o => o.OfficeId == 1).ToListAsync();
                foreach (var employee in ofId)
                {
                    employee.OfficeId += 1;
                }

                _ = _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        public async Task JoinTablesAsync()
        {
            var emp = await (from employee in _context.Employee
                           join title in _context.Title on employee.TitleId equals title.TitleId
                           from o in _context.Office.DefaultIfEmpty()
                              select new
                              {
                                FirstName = employee.FirstName,
                                Title = title.Name
                              }).ToListAsync();
            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} ({e.Title})");
            }
        }

        public async Task RemoveEmployeeEntityAsync()
        {
            try
            {
                var comp = await _context.Employee.FirstOrDefaultAsync();
                _context.Employee.Remove(comp);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}
