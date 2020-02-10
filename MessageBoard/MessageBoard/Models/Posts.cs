using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Models
{
    public class Posts
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Content { get; set; }
    }
}
