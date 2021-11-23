using DCBot.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCBot.DAL
{
    public class ECOctx : DbContext
    {
        public ECOctx(DbContextOptions<ECOctx> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
