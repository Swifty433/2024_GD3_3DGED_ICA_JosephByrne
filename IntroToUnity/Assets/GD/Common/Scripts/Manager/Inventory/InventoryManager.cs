using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace GD.Items
{
    /// <summary>
    /// Manages the players inventory, listens for events, etc.
    /// </summary>
    /// <see cref="Inventory"/>
    /// <see cref="ItemData"/>
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        [InlineEditor]
        [Tooltip("The player's inventory collection (e.g. a saddlebag")]
        private InventoryCollection inventoryCollection;

        [SerializeField]
        [Tooltip("Refrence to the UI manager")]
        private UIManager uiManager;

        private void Awake()
        {
            //check if the inventory collection has been added
            if (inventoryCollection == null)
                throw new NullReferenceException("No inventory collection has been added");
        }

        /// <summary>
        /// Adds the item to the inventory.
        /// </summary>
        /// <param name="data"></param>

        

        public void OnInventoryAdd(ItemData item)
        {
            inventoryCollection.Add(item);
            uiManager?.DisplayItemFact(item.ItemFact);
        }
    }
}