using Microsoft.AspNetCore.Mvc.Rendering;


namespace proyecto01.Models.ViewModels
{
    public class LugarVM
    {
        public Lugar Lugar { get; set; }
        public IEnumerable<SelectListItem>? ListacategoriaLugar { get; set; }
        public IEnumerable<SelectListItem>? Listaubigeo { get; set; }
    }
}
