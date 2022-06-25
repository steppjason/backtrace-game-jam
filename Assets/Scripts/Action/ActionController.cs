using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionResponse {
	[SerializeField] public Action action;
	[SerializeField] [TextArea(5,99)] public string actionResponse;
	[SerializeField] [TextArea(5,99)] public string actionRejection;
	[SerializeField] public List<ItemActionEffect> itemActionEffects;
	[SerializeField] public List<ExitActionEffect> exitActionEffects;
}

[System.Serializable]
public struct ItemActionEffect {
	[SerializeField] public Action action;
	[SerializeField] public GameItem item;
}

[System.Serializable]
public struct ExitActionEffect {
	[SerializeField] public Action action;
	[SerializeField] public Exit exit;
}

public class ActionController : MonoBehaviour {

	public Actions ActionList;
	Action _action;

	public void DoAction(string parsedInput, string rawInput) {
		_action = CheckInput(parsedInput);
		if (_action != null)
			_action.DoAction(parsedInput, rawInput);
		else
			GameController.Instance.SetLogText(rawInput, "Unable to do that."); // Should let another class handle logging
	}


	public Action CheckInput(string input) {
		string[] words = input.Split(' ');
		string actionWord;

		for (int i = 0; i < words.Length; i++) {
			actionWord = "";

			for (int j = 0; j <= i; j++) {
				actionWord += words[j] + " ";
			}

			Action action = FindAction(actionWord.Trim());
			if (action != null)
				return action;
		}

		return null;
	}

	public Action FindAction(string action) {
		return ActionList.actions.Find(x => x.commands.Contains(action));
	}

}
