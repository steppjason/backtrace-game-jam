using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/ActionEffects/RemoveInventoryItem", fileName = "ACTION_EFFECT_")]
public class RemoveInventoryItem : Action {
	
	public override void DoAction(GameItem item) {
		Inventory inventory = GameController.Instance.InventoryController.Inventory;
		inventory.GameItems.Remove(item);
	}


	public override void DoAction(string parsedInput, string rawInput) {
		return;
	}

	public override void DoAction(Exit e) {
		return;
	}

	
}
