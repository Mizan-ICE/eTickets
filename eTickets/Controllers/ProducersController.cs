using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service ;

        public ProducersController(IProducersService service)
        {
           _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null)
            { 
                return View("Not Found");
            }
            else { return View(producersDetails); }

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //httpget
        public async Task<IActionResult> Edit(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null)
            {
                return View("Not Found");
            }
            else { return View(producersDetails); }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if(id==producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
            
        }
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails= await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Not Found");
            }
  
            return View(producerDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails= await _service.GetByIdAsync(id);
            if(producerDetails == null)
            {
                return View("Not Found");
                    }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
