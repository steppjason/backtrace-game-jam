using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

	[SerializeField] private Inventory inventory;

	public void AddItem(GameItem item) {
		inventory.GameItems.Add(item);
	}

	public void RemoveItem(GameItem item) {
		inventory.GameItems.Remove(item);
	}

	public Inventory Inventory { get { return inventory; } }

}
