using System.Collections.Generic;
using GD.Items;
using UnityEngine;

namespace GD.State
{
    public class InventoryWinCondition : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The resource inventory of the player to check for win condition")]
        private InventoryCollection resourceInventory;

        [SerializeField]
        [Tooltip("The items required for the player to win")]
        private List<Item> requiredItems;

        [SerializeField]
        [Tooltip("The StateManager to trigger the win condition")]
        private StateManager stateManager;

        private void Awake()
        {
            if (resourceInventory == null)
                throw new System.Exception("Resource inventory reference is required!");

            if (stateManager == null)
                throw new System.Exception("StateManager reference is required!");
        }

        private void Update()
        {
            if (HasAllRequiredItems())
            {
                // Trigger win condition on StateManager if game hasn't ended
                if (!stateManager.GameEnded) // Check if the game has already ended
                {
                    stateManager.HandleWin();
                }
            }
        }

        /// <summary>
        /// Check if the player has all the required items in the inventory.
        /// </summary>
        private bool HasAllRequiredItems()
        {
            foreach (var item in requiredItems)
            {
                // Check if the player has the required item in the inventory
                if (!resourceInventory.Contains(item))
                {
                    return false; // Return false if any required item is missing
                }
            }
            return true; // All required items are present
        }
    }
}
