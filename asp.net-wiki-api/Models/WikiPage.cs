using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_wiki_api.Models
{
    public class WikiPage
    {
        public long Id { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        public string Snippet { get; set; }

        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
