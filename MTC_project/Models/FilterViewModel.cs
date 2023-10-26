using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MTC_project.Models
{
	public class FilterViewModel
	{
		public FilterViewModel(List<User> users, string name, Ranks rank)
		{
			users.Insert(0, new User { Name = "Все", Id = 0 });
			Users = new SelectList(users, "Id", "Name");
			SelectedName = name;
            SelectedRank = rank;

        }
		public SelectList Users { get; } 
		public Ranks SelectedRank { get; set; }
        public string SelectedName { get; } // введенное имя
	}
}
