﻿using System;
using System.Collections.Generic;

namespace WebAPIdeGraaf.Models
{
    public partial class PasswordResets
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
