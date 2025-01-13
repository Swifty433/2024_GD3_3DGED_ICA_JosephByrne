using GD.Items;
using System.Collections.Generic;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that ensures prefabs are spawned within a specified area.
    /// </summary>
    [CreateAssetMenu(fileName = "WinCondition", menuName = "GD/Conditions/Single/Win", order = 1)]
    public class WinCondition : ConditionBase
    {
        [Tooltip("The bounds within which spawning is allowed.")]
        [SerializeField]
        private Bounds spawnArea;

        [SerializeField]
        [Tooltip("The resource inventory of the player to check for win condition")]
        private Inventory resourceInventory;

        [SerializeField]
        private List<ItemData> items;

        //[SerializeField]
        //[Tooltip("The StateManager to trigger the win condition")]
        //private StateManager stateManager;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            return HasAllRequiredItems();
        }

        private void Awake()
        {
            if (resourceInventory == null)
                throw new System.Exception("Resource inventory reference is required!");

            //if (stateManager == null)
            //    throw new System.Exception("StateManager reference is required!");
        }

        /// <summary>
        /// Check if the player has all the required items in the inventory.
        /// </summary>
        private bool HasAllRequiredItems()
        {
            foreach (var item in items)
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