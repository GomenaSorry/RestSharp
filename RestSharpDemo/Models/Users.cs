using System;
using System.Collections.Generic;

namespace RestSharpDemo.Models
{
    public class Users
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<UserData> Data { get; set; }
    }
}
