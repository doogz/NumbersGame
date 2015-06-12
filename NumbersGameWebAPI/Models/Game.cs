using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace NumbersGameWebAPI.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int BigNumbers { get; set; }

        [Required]
        public int[] InitialValues { get; set; }
        public int Target { get; set; }

    }
}