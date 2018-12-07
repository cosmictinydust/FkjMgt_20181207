using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FkjMgt_20181207.Data
{
    public class FkjDbContext : IdentityDbContext
    {
        public FkjDbContext(DbContextOptions<FkjDbContext> options)
    : base(options)
        {
        }
    }
}
