using asp.net_wiki_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_wiki_api.Repository
{
    public class WikiPageDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=WikiAppDb.db");
        }

        public DbSet<WikiPage> WikiPage { get; set; }
    }
}
