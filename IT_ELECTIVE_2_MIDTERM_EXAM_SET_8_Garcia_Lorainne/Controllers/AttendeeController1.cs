using IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Models;
using IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private readonly AttendeeVisitRepository _attendeeRepository;

        public AttendeeController()
        {
            _attendeeRepository = new AttendeeVisitRepository();
        }

        // GET: /Attendee/Index
        public IActionResult Index(string search)
        {
            var attendees = _attendeeRepository.Search(search);

            ViewBag.Search = search;

            return View(attendees);
        }

        // GET: /Attendee/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Attendee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AttendeeVisit attendee)
        {
            if (!ModelState.IsValid)
            {
                return View(attendee);
            }

            attendee.CheckInTime = DateTime.Now;
            attendee.Status = "Present";

            _attendeeRepository.Add(attendee);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Attendee/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var attendee = _attendeeRepository.GetById(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // POST: /Attendee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AttendeeVisit attendee)
        {
            if (id != attendee.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(attendee);
            }

            _attendeeRepository.Update(attendee);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Attendee/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var attendee = _attendeeRepository.GetById(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // GET: /Attendee/CheckOut/5
        [HttpGet]
        public IActionResult CheckOut(int id)
        {
            var attendee = _attendeeRepository.GetById(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // POST: /Attendee/CheckOut/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOutConfirmed(int id)
        {
            var attendee = _attendeeRepository.GetById(id);

            if (attendee == null)
            {
                return NotFound();
            }

            attendee.CheckOutTime = DateTime.Now;
            attendee.Status = "Left Event";

            _attendeeRepository.Update(attendee);

            return RedirectToAction(nameof(Index));
        }
    }
}
