/// <summary>
/// PalletsController handles the CRUD operations for managing pallets.
/// This includes actions for creating, editing, deleting, viewing, and listing pallets,
/// as well as calculating the number of batches based on the pallet's weight and configuration.
/// </summary>
/// <author>Thabang Thubane</author>
/// <version>v1</version>
/// 

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalletRecords.Data;
using PalletRecords.Models;

namespace PalletRecords.Controllers
{
    public class PalletsController : Controller
    {
        private readonly AppDbContext _context;

        public PalletsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pallets
        public async Task<IActionResult> Index(string searchString)
        {
            var pallets = from m in _context.Pallets
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                pallets = pallets.Where(s => s.Material!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await pallets.ToListAsync());
        }

        // GET: Pallets/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the pallet and its corresponding configuration
            var pallet = await _context.Pallets.FindAsync(id);
            if (pallet == null)
            {
                return NotFound();
            }

            var palletConfig = await _context.PalletConfigs.FirstOrDefaultAsync(pc => pc.PalletId == id);

            // Pass both the pallet and config to the view using a ViewModel
            var viewModel = new ConfiguredPallet
            {
                Pallet = pallet,
                PalletConfig = palletConfig
            };

            return View(viewModel);
        }

        // GET: Pallets/Create
        public IActionResult Create()
        {
            var model = new ConfiguredPallet
            {
                Pallet = new Pallet
                {
                    InputDate = DateTime.Now // Set the current date and time
                }
            };

            return View(model);
        }

        // POST: Pallets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfiguredPallet configuredPallet)
        {
            if (configuredPallet == null || configuredPallet.Pallet == null || configuredPallet.PalletConfig == null)
            {
                ModelState.AddModelError(string.Empty, "Both pallet and pallet configuration are required.");
                return View(configuredPallet);
            }

            // Calculate the number of items
            var pallet = configuredPallet.Pallet;
            var palletConfig = configuredPallet.PalletConfig;

            if (ModelState.IsValid){
                pallet.NumberOfItems = CalculateNumberOfItems(pallet.Weight, palletConfig.Weight);

                // Save the pallet and its configuration
                _context.Pallets.Add(pallet);
                await _context.SaveChangesAsync();

                palletConfig.PalletId = pallet.Id;
                _context.PalletConfigs.Add(palletConfig);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(configuredPallet);
        }

        // GET: Pallets/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pallet = await _context.Pallets.FindAsync(id);
            if (pallet == null)
            {
                return NotFound();
            }
            return View(pallet);
        }

        // POST: Pallets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pallet pallet)
        {
            if (id != pallet.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Recalculate NumberOfItems
                    var firstPalletConfigWeight = await _context.PalletConfigs
                        .Where(i => i.PalletId == pallet.Id)
                        .Select(i => i.Weight)
                        .FirstOrDefaultAsync();

                    pallet.NumberOfItems = CalculateNumberOfItems(pallet.Weight, firstPalletConfigWeight);

                    // Update and save the changes
                    _context.Update(pallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalletExists(pallet.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pallet);
        }

        // GET: Pallets/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pallet = await _context.Pallets.FindAsync(id);
            if (pallet == null)
            {
                return NotFound();
            }

            return View(pallet);
        }

        // POST: Pallets/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pallet = await _context.Pallets.FindAsync(id);
            if (pallet != null)
            {
                _context.Pallets.Remove(pallet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper method to calculate the number of items
        private int CalculateNumberOfItems(double palletWeight, double firstItemWeight)
        {
            return firstItemWeight > 0
                ? (int)(palletWeight / firstItemWeight)
                : 0;
        }

        private bool PalletExists(int id)
        {
            return _context.Pallets.Any(e => e.Id == id);
        }
    }
}
