using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.net_wiki_api.Models;
using asp.net_wiki_api.Repository;

namespace asp.net_wiki_api.Controllers
{
    [Route("page")]
    [ApiController]
    public class WikiPagesController : ControllerBase
    {
        private readonly WikiPageDBContext _context;

        public WikiPagesController(WikiPageDBContext context)
        {
            _context = context;
        }

        // PUT: api/WikiPages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [Route("update/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutWikiPage(long id, WikiPage wikiPage)
        {
            if (id != wikiPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(wikiPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WikiPageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update successfully");
        }

        // POST: api/WikiPages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<WikiPage>> PostWikiPage(WikiPage wikiPage)
        {
            _context.WikiPage.Add(wikiPage);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetWikiPage", new { id = wikiPage.Id }, wikiPage);
            return Ok("Ok");
        }

        // DELETE: api/WikiPages/5
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult<WikiPage>> DeleteWikiPage(long id)
        {
            var wikiPage = await _context.WikiPage.FindAsync(id);
            if (wikiPage == null)
            {
                return NotFound();
            }

            _context.WikiPage.Remove(wikiPage);
            await _context.SaveChangesAsync();

            return wikiPage;
        }

        private bool WikiPageExists(long id)
        {
            return _context.WikiPage.Any(e => e.Id == id);
        }
    }
}
