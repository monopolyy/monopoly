using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Card
    {
        public int Id { get; set; }
        public string Deck { get; set; }
        public int Number { get; set; }
    }
}
