/// <summary>
/// The PalletConfig class represents the configuration for a pallet, including its name, description, 
/// and batch weight. This model helps define the specific characteristics for different pallet types.
/// </summary>
/// <author>Thabang Thubane</author>
/// <version>v1</version>
/// 

using System.ComponentModel.DataAnnotations;

namespace PalletRecords.Models  {
    public class PalletConfig   {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; } // Weight of the item

        // Foreign key and navigation property
        public int PalletId { get; set; }
    }
}