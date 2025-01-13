using GD.Items;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InventoryCollection inventoryCollection;

    void Start()
    {
        ClearInventories();
    }

    void ClearInventories()
    {
        if (inventoryCollection != null)
        {
            inventoryCollection.ClearAllInventories();
        }
    }
}