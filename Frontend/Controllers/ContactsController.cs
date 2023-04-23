using Frontend.Models.Forms;
using Frontend.Services.Api;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Frontend_App.Controllers
{
    public class ContactsController : Controller
    {
        private readonly MessageApi _messageApi;

        public ContactsController(MessageApi messageApi)
        {

            _messageApi = messageApi;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Send(MessageFormModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _messageApi.PostAsync(model);

                switch (result)
                {
                    case OkResult:
                        return RedirectToAction("Index", "Home");

                    default:
                        ModelState.AddModelError("", "Något gick fel. Kontakta administratören.");
                        break;

                }
            }

            return View("Index", model);
        }




        //if (!ModelState.IsValid)
        //{
        //    return BadRequest();
        //}

        //await _messageApi.PostAsync(model);

        //return RedirectToAction("Index", "Home");

    }
}
