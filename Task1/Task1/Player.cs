using System;
using System.ComponentModel.DataAnnotations;

    public class Player
    {

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int WinsNumber { get; set; }

        public int FailsNumber { get; set; }



    }

