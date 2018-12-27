﻿using System.Collections.Generic;

namespace ELearning.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
