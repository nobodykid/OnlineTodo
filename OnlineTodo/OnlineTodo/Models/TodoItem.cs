﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTodo.Models
{
    public class TodoItem
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}
