using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/Actions/Look")]
public class LookAction : Action {

	public override void DoAction(string parsedInput, string rawInput) {
		string response = GetArea(parsedInput.Split(' '));
		Response(response, rawInput.Split(' ')[0]);
	}

	private void Response(string response, string input) {
		GameController.Instance.SetLogText(input, response);
	}


	private string GetArea(string[] input) {
		Area area = GameController.Instance.AreaController.Area;
		string response = area.ActionResponses.Find(x => x.action.name == this.name).actionResponse;
		foreach (GameItem item in area.GameItems) {
			if (item.active)
				response += " " + item.Description;
		}
		return response;
	}


	public override void DoAction(GameItem i) {
		return;
	}

	public override void DoAction(Exit e) {
		return;
	}

}
