using JobsityChat.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobsityChat.Models
{
    public class Message : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public string User { get; set; }
    }
}
