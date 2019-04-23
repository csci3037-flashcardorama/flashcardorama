namespace Project4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deck
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string AspNetUserId { get; set; }

        [Required]
        [StringLength(60)]
        public string DeckName { get; set; }
    }
}
