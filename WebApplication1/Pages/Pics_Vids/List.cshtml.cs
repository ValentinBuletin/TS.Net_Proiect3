using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;
using WebApplication1.Models;

namespace WebApplication1.Pages.Pics_Vids
{
    public class ListModel : PageModel
    {
        Nterface1Client pcc = new Nterface1Client();
        public List<string> Props { get; set; }

        public ListModel()
        {
            Props = new List<string>();
        }
        public async Task OnGetAsync()
        {
            Props.Add("Unique_Id");
            Props.Add("Name");
            Props.Add("Full_Path");
            Props.Add("Type");
            Props.Add("Size");
            Props.Add("Date_Created");
            Props.Add("Date_Modified");

            var tags = await pcc.GetAllTagsAsync();
            foreach (var item in tags)
            {
                Props.Add(item.Tag_Name);
            }

            Props.Sort();
        }
    }
}