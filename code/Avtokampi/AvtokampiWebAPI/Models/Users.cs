using System;
using System.Collections.Generic;

namespace AvtokampiWebAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Kampi = new HashSet<Kampi>();
            Mnenja = new HashSet<Mnenja>();
            Rezervacije = new HashSet<Rezervacije>();
        }

        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Kampi> Kampi { get; set; }
        public virtual ICollection<Mnenja> Mnenja { get; set; }
        public virtual ICollection<Rezervacije> Rezervacije { get; set; }
    }
}
