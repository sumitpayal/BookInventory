using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookInventory.Models;

namespace BookInventory.Controllers
{
    public class BookController : ApiController
    {
        private bookdbEntities db = new bookdbEntities();

        // GET: api/Book
        public IQueryable<BookTable> GetBookTables()
        {
            return db.BookTables;
        }

        // GET: api/Book/5
        [ResponseType(typeof(BookTable))]
        public IHttpActionResult GetBookTable(string Title)
        {
            BookTable bookTable = db.BookTables.Find(Title);
            if (bookTable == null)
            {
                return NotFound();
            }

            return Ok(bookTable);
        }

        // PUT: api/Book/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookTable(string Title, BookTable bookTable)
        {
           

            if (Title != bookTable.Title)
            {
                return BadRequest();
            }

            db.Entry(bookTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTableExists(Title))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Book
        [ResponseType(typeof(BookTable))]
        public IHttpActionResult PostBookTable(BookTable bookTable)
        {
           
            db.BookTables.Add(bookTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BookTableExists(bookTable.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { Title = bookTable.Title }, bookTable);
        }

        // DELETE: api/Book/5
        [ResponseType(typeof(BookTable))]
        public IHttpActionResult DeleteBookTable(string Title)
        {
            BookTable bookTable = db.BookTables.Find(Title);
            if (bookTable == null)
            {
                return NotFound();
            }

            db.BookTables.Remove(bookTable);
            db.SaveChanges();

            return Ok(bookTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookTableExists(string Title)
        {
            return db.BookTables.Count(e => e.Title == Title) > 0;
        }
    }
}