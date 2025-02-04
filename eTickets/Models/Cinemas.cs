﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinemas
    {


        [Key]
        public int Id { get; set; }
        [Display (Name ="Cinema Logo")]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Discription")]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
