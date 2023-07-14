using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

		public AuthorController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult GetAll()
		{
			List<Author> authors =_db.Authors.Where(x=>x.isDeleted==false).ToList<Author>();
			return Json(new { data = authors });
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpDelete]
		public IActionResult Delete(Guid id)
		{
			Author author = _db.Authors.FirstOrDefault(c => c.Id == id);
			if (author != null)
			{
				_db.Authors.Remove(author);
				_db.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		public IActionResult GetById(Guid id)
		{
			Author author = _db.Authors.FirstOrDefault(c => c.Id == id);
			return Ok(author);
		}
		//===============Ekle butonunda yeni bir yazar ve açıklama yaratma==============
		[HttpPost]
		public IActionResult Create(Author author)
		{
			if (author.Name != null)
			{
				_db.Authors.Add(author);
				_db.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}

		[HttpPost]
		public IActionResult Update(Author author)
		{

			if (author.Name != null)
			{
				Author asil = _db.Authors.FirstOrDefault(c => c.Id ==author.Id);
				asil.Description= author.Description;
				asil.Name = author.Name;
				asil.DateModified = DateTime.Now;
				_db.Authors.Update(asil);
				_db.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}








	}
}
