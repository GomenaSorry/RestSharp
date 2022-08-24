using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
    class Model
    {

        public class Rootobject
        {
            public int Page { get; set; }
            public int Per_page { get; set; }
            public int Total { get; set; }
            public int Total_pages { get; set; }
            public Datum[] Data { get; set; }
            public Support Support { get; set; }
        }

        public class Support
        {
            public string Url { get; set; }
            public string Text { get; set; }
        }

        public class Datum
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Avatar { get; set; }
        }

    }
}
