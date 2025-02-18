﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakasfoglalasLoginClient.Models
{
    public partial class User
    {
        public int Id { get; set; }

        public string LoginNev { get; set; } = null!;

        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int PermissionId { get; set; }

        public bool Active { get; set; }

        public string Email { get; set; } = null!;

        public string ProfilePicturePath { get; set; } = null!;
    }
}
