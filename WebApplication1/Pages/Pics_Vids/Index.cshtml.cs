using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference1;
using WebApplication1.Models;

namespace WebApplication1.Pages.Pics_Vids
{
    public class IndexModel : PageModel
    {
        Nterface1Client pcc = new Nterface1Client();
        public List<Pic_VidDTO> Pics_Vids { get; set; }
        public List<TagDTO> Tags { get; set; }

        public List<string> Props { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel()
        {
            Pics_Vids = new List<Pic_VidDTO>();
            Tags = new List<TagDTO>();
            Props = new List<string>();
        }
        public async Task OnGetAsync()
        {
            var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\";
            var pics_vids = await pcc.GetAllPics_VidsAsync();
            foreach (var item in pics_vids)
            {
                Pic_VidDTO pv = new Pic_VidDTO();
                pv.Unique_Id = item.Unique_Id;
                pv.Name = item.Name;
                pv.Full_Path = item.Full_Path;
                pv.Type = item.Type;
                pv.Size = item.Size;
                pv.Date_Created = item.Date_Created;
                pv.Date_Modified = item.Date_Modified;
                List<string> tmp = new List<string>();
                foreach(string value in item.Values.Split(','))
                {
                    if (value.Equals("null"))
                        tmp.Add("-");
                    else if(!value.Equals(""))
                        tmp.Add(value);
                }
                Console.WriteLine(tmp.Count);
                tmp.RemoveAt(tmp.Count-1);
                pv.Values = tmp;
                Pics_Vids.Add(pv);

                //Se copiaza pozele in "wwwroot" pentru a putea fi accesate si in pagina web
                var path_tmp = path + pv.Name + pv.Type;
                try
                {
                    System.IO.File.Copy(pv.Full_Path, path_tmp, true);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error on COPY:\t" + e.ToString());
                }
               
            }



            if (!string.IsNullOrEmpty(SearchString))
            {
                List<Pic_VidDTO> Found = new List<Pic_VidDTO>();
                foreach (var item in Pics_Vids)
                {
                    
                    if (item.Unique_Id.ToString().Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Name.Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Full_Path.Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Type.Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Size.ToString().Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Date_Created.ToString().Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Date_Modified.ToString().Contains(SearchString) == true)
                        Found.Add(item);
                    else if (item.Values.Contains(SearchString) == true)
                        Found.Add(item);
                }
                Pics_Vids = Found;
            }
            var tags = await pcc.GetAllTagsAsync();
            foreach (var item in tags)
            {
                TagDTO tag = new TagDTO();
                tag.Tag_Id = item.Tag_Id;
                tag.Tag_Name = item.Tag_Name;
                Tags.Add(tag);
            }
        }
    }

}