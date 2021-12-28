using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerCRUD.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace BlazorServerCRUD.Web.Context
{
     public class DatabaseContext : DbContext
    {
    

        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options)
        {
             
        }

        public DbSet<JobAdvertisement> JobAdvertisements { get; set; }

    }
}