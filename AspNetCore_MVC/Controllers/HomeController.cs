﻿using AspNetCore_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCore_MVC.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

	public IActionResult Index()
    {

		return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7149/api/subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
				TempData["StatusMessage"] = "You are already subscribed";
			}
        }
        else
        {
			TempData["StatusMessage"] = "Invalid email adress";
		}

        return RedirectToAction("Index", "Home", "subscribe");
    }

}
