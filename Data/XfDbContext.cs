using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FkjMgt_20181207.Models;

namespace FkjMgt_20181207.Data
{
    public class XfDbContext : IdentityDbContext
    {
        public XfDbContext(DbContextOptions<XfDbContext> options)
    : base(options)
        {
        }
        public DbSet<FkjMgt_20181207.Models.ClientListViewModel> ClientListViewModel { get; set; }
        public DbSet<FkjMgt_20181207.Models.Client.ClientListDetail> ClientListDetail { get; set; }
    }
}
