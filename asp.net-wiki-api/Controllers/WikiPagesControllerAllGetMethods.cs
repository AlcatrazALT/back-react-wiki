using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.net_wiki_api.Models;
using asp.net_wiki_api.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp.net_wiki_api.Controllers
{
    [Route("page")]
    [ApiController]
    public class WikiPagesControllerAllGetMethods : ControllerBase
    {
        private readonly WikiPageDBContext _context;

        public WikiPagesControllerAllGetMethods(WikiPageDBContext context)
        {
            _context = context;
        }

        // GET: api/WikiPages
        [Route("readAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WikiPage>>> GetWikiPage()
        {
            return await _context.WikiPage.ToListAsync();
        }

        [Route("readAllWithSnippet")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WikiPage>>> GetWikiPageWithSnippet()
        {
            var wikiPage = from page in _context.WikiPage
                           where !string.IsNullOrWhiteSpace(page.Snippet) 
                           select page;
            return await wikiPage.ToListAsync();
        }

        // GET: api/WikiPages/5

        [HttpGet("{id}")]
        public async Task<ActionResult<WikiPage>> GetWikiPage(long id)
        {
            var wikiPage = await _context.WikiPage.FindAsync(id);

            if (wikiPage == null)
            {
                return NotFound();
            }

            return wikiPage;
        }
    }
}
