using System.Collections.Generic;

namespace CustomerManagement.Models
{
    public class Application
    {
        public Application()
        {
            Menus = new List<Menu>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
