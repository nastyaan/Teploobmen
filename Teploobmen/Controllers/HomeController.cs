using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Teploobmen.Data;
using Teploobmen.Models;

namespace Teploobmen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, MyApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var inputDatas = _context.inDatas.Where(x => x.UserId == userId || x.UserId == null).ToList();
            return View(inputDatas);
        }

        [HttpGet]
        public IActionResult TestPage(int variant)
        {
            var userId = GetUserId();
            var inputData = _context.inDatas.FirstOrDefault(x => x.Id == variant && (x.UserId == userId || x.UserId == null));
            var model = new TestPageModel
            {
                InData = inputData,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();
            var inputData = _context.inDatas.FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if(inputData != null)
            {
                _context.inDatas.Remove(inputData);
                _context.SaveChanges();
                    
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult TestPage(InputData inputData)
        {
            var lib = new TeploobmenLib();
            var result = lib.Calc(inputData);

            if (!string.IsNullOrEmpty(inputData.Name))
            {

                _context.inDatas.Add(new InData
                {
                    UserId = GetUserId(),
                    H0 = inputData.H0,
                    t0_ = inputData.t0_,
                    T_ = inputData.T_,
                    wg = inputData.wg,
                    Cg = inputData.Cg,
                    av = inputData.av,
                    Cm = inputData.Cm,
                    Gm = inputData.Gm,
                    r = inputData.r,
                    Name = inputData.Name,
                    DateAdd = DateTime.Now
                });
                _context.SaveChanges();
            }
            var model = new TestPageModel
            {
                InData = new InData
                {
                    H0 = inputData.H0,
                    t0_ = inputData.t0_,
                    T_ = inputData.T_,
                    wg = inputData.wg,
                    Cg = inputData.Cg,
                    av = inputData.av,
                    Cm = inputData.Gm,
                    Gm = inputData.Gm,
                    r = inputData.r
                },
                OutputResData = result
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int? GetUserId()
        {
            var userIdString = User.FindFirst("Id")?.Value;
            int? userId = userIdString != null ? Convert.ToInt32(userIdString) : null;

            return userId;
        }
    }
}