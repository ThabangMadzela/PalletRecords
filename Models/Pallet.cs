/// <summary>
/// The Pallet class represents a pallet entity with properties like number, weight, material, 
/// and description. This model is used to create, update, and manage pallets in the system.
/// </summary>
/// <author>Thabang Thubane</author>
/// <version>v1</version>
/// 

using System.ComponentModel.DataAnnotations;

namespace PalletRecords.Models
{
    public class Pallet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pallet Number is required.")]
        [StringLength(50, ErrorMessage = "Pallet Number cannot be longer than 50 characters.")]
        public string Number  { get; set; } = string.Empty;


        public DateTime InputDate { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; } // Weight
        
        [Required(ErrorMessage = "Material is required.")]
        [StringLength(100, ErrorMessage = "Material name cannot be longer than 100 characters.")]
        public string Material  { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        // Number of items stored in the database
        public int NumberOfItems { get; set; }
    }
}
