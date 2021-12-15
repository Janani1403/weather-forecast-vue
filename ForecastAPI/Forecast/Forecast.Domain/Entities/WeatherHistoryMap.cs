using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forecast.Domain.Entities 
{
    public class HistoryMap
    {
        /// <summary>
        /// Define mapping for Context object
        /// </summary>
        /// <param name="entityBuilder">(Internal)</param>
        public HistoryMap(EntityTypeBuilder<History> entityBuilder) {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Date); 
            entityBuilder.Property(t => t.AccessedDateTime);
            entityBuilder.Property(t => t.City);
            entityBuilder.Property(t => t.Temperature);
            entityBuilder.Property(t => t.Humidity);
        }
    }
}
