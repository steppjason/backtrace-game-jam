using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/ActionEffects/SetItemInactive", fileName = "ACTION_EFFECT_")]
public class SetItemInactive : Action {

	public override void DoAction(GameItem item) {
		item.active = false;
	}

	public override void DoAction(string parsedInput, string rawInput) {
		return;
	}

	public override void DoAction(Exit e) {
		return;
	}

}
