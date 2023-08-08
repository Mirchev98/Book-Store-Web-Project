using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.ViewModels.User
{
    public class ApplicationUserViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
