using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/Actions/Move", fileName = "ACTION_")]
public class MoveAction : Action {

	public override void DoAction(string parsedInput, string rawInput) {
		Area area = GameController.Instance.AreaController.Area;
		Exit exit = GetExit(parsedInput.Split(' '));
		Response(exit, rawInput);
		if(exit != null && !exit.locked && exit.active) {

			if(area.Music.name != exit.Area.Music.name)	
				GameController.Instance.AudioController.SwapTrack(exit.Area.Music, exit.Area.MusicVolume);

			LoadArea(exit.Area);
		}
	}

	private void Response(Exit exit, string input) {

		string response;
		if(exit != null && !exit.locked && exit.active)
			response = exit.Response;
		else if(exit != null && exit.locked && exit.active)
			response = exit.Rejection;
		else{
			response = "Not sure what you mean.\n";
		}

		GameController.Instance.SetLogText(input, response);
	}

	private void LoadArea(Area area) {
		GameController.Instance.AreaController.SetArea(area);
		GameController.Instance.DisplayArea();
	}

	private Exit GetExit(string[] input) {

		Area area = GameController.Instance.AreaController.Area;
		string reference;

		for (int i = 0; i < input.Length; i++) {
			reference = "";
			for (int j = i; j < input.Length; j++) {
				reference += input[j] + " ";
				
				for (int t = 0; t < area.Exits.Count; t++) {
					Exit currentExit = area.Exits[t];

					for (int r = 0; r < currentExit.References.Count; r++) {
						string currentRef = currentExit.References[r];

						if (reference.Trim() == currentRef.ToUpper())
							return currentExit;
							
					}
				}
			}
		}

		return null;
	}


	public override void DoAction(GameItem i) {
		return;
	}

	public override void DoAction(Exit e) {
		return;
	}


}
