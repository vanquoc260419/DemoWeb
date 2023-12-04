using DatabaseFirstDemo.Models;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace WebDemo14112023.Areas.Admin.Models
{
    public class RoleUser
    {
        public ICollection<Role> Roles { get; set; }
        public IPagedList<User> Users { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
