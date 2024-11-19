/// <summary>
/// The ConfiguredPallet class represents a pallet and its associated configuration.
/// It is used to calculate the number of batches in a pallet based on its weight and configuration.
/// </summary>
/// <author>Thabang Thubane</author>
/// <version>v1</version>
/// 

using System.ComponentModel.DataAnnotations;

namespace PalletRecords.Models
{
    public class ConfiguredPallet {

        [Required(ErrorMessage = "Pallet is required.")]
        public Pallet? Pallet { get; set; }

        [Required(ErrorMessage = "Pallet Configuration is required.")]
        public PalletConfig? PalletConfig { get; set; }
    }

}