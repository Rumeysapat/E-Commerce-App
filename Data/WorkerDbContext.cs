using System;
using Microsoft.EntityFrameworkCore;

namespace UserApp3_1.Models
{
	public class WorkerDbContext:DbContext
	{
        public WorkerDbContext(DbContextOptions<WorkerDbContext> options)
            : base(options) { }


        public DbSet<Category> Categories { get; set; }
    }
}

