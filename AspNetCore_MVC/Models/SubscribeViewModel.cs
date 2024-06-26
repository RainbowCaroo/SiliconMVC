﻿using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.Models;

public class SubscribeViewModel
{
	[Required]
	[EmailAddress]
	[Display(Name = "E-mail address", Prompt = "Your Email")]
	public string Email { get; set; } = null!;
	public bool DailyNewsLetter { get; set; }
	public bool AdvertisingUpdates { get; set; }
	public bool WeekInReview { get; set; }
	public bool EventUpdates { get; set; }
	public bool StartupWeekly { get; set; }
	public bool Podcasts { get; set; }
}
