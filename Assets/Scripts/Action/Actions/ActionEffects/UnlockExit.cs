using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/ActionEffects/UnlockExit", fileName = "ACTION_EFFECT_")]
public class UnlockExit : Action {
	
	public override void DoAction(Exit exit) {
		exit.locked = false;
	}

	public override void DoAction(GameItem i) {
		return;
	}

	public override void DoAction(string s, string q) {
		return;
	}

}
