using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forecast.Domain.Entities
{
    [Table("History")]
    public class History : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Date { get; init; } = String.Empty;
        public string City { get; init; } = String.Empty;
        public float Temperature { get; init; }
        public float Humidity { get; init; }
    }
}
