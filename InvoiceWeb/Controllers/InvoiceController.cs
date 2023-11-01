using InvoiceWeb.Models;
using InvoiceWeb.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace InvoiceWeb.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly HttpClient _client;
        private readonly InvoiceViewModel _vm;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public InvoiceController(IHttpClientFactory clientFactory, InvoiceViewModel vm, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _vm=vm;
            _userManager = userManager;
            _signInManager = signInManager;
            _client = clientFactory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:7268/api/"); // Replace with the API URL
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: InvoiceController
        public async Task<ActionResult> IndexAsync()
        {
           return View();
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public async Task<IActionResult> CreateAsync()
        {
           // _client.BaseAddress = new Uri("https://localhost:7268/api/"); // Replace with the API URL
            HttpResponseMessage storeResponse = await _client.GetAsync("store");
            HttpResponseMessage unitResponse = await _client.GetAsync("unit");
            HttpResponseMessage invoiiceResponse = await _client.GetAsync("invoice");
            HttpResponseMessage itemResponse = await _client.GetAsync("item");
          
            if (storeResponse.IsSuccessStatusCode)
            {
                
                var json = await storeResponse.Content.ReadAsStringAsync();
                List<Store>? stores = JsonConvert.DeserializeObject<List<Store>>(json);
                _vm.Stores = stores;
            }
            if (unitResponse.IsSuccessStatusCode)
            {
                var json = await unitResponse.Content.ReadAsStringAsync();

                List<Unit>? units = JsonConvert.DeserializeObject<List<Unit>>(json);
                _vm.Units = units;
            }
            if (invoiiceResponse.IsSuccessStatusCode)
            {
                var json = await invoiiceResponse.Content.ReadAsStringAsync();

                List<Invoice>? invoices = JsonConvert.DeserializeObject<List<Invoice>>(json);
                var LastinvoiceId = invoices.Select(i => i.Id).LastOrDefault();
                _vm.Invoices = invoices;
                _vm.Id = LastinvoiceId + 1;
            }
            if (itemResponse.IsSuccessStatusCode)
            {
                var json = await itemResponse.Content.ReadAsStringAsync();

                List<Item>? items = JsonConvert.DeserializeObject<List<Item>>(json);
                _vm.Items = items;

            }

                return View(_vm);
                      
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromForm]Invoice invoice)
        {

        
            _client.BaseAddress = new Uri("https://localhost:7268/api/"); // Replace with the API URL

            HttpResponseMessage response = await _client.PostAsJsonAsync("invoice", invoice);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // POST: InvoiceController/Create
       

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
