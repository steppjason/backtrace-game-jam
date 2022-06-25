using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameData {

	[System.Serializable]
	public struct ExitData {
		public string UUID;
		public bool Active;
		public bool Locked;
	}

	public Area[] areas;
	public List<ExitData> exitData = new List<ExitData>();

	public void Init() {
		areas = Resources.LoadAll<Area>("Areas");

		foreach (Area area in areas) {
			foreach (Exit exit in area.Exits) {
				ExitData saveExitData = new ExitData();
				saveExitData.UUID = exit.UUID;
				saveExitData.Active = exit.active;
				saveExitData.Locked = exit.locked;
				exitData.Add(saveExitData);
			}
		}

	}

	// Loop through each Saved Exit and loop through each Exit in each Area 
	// Then compare UUIDs to set correct Active state for each Exit
	public void SetGameData() {

		foreach (ExitData loadExit in exitData) {
			foreach (Area area in areas) {

				foreach (Exit exit in area.Exits) {
					if (loadExit.UUID == exit.UUID) {
						exit.active = loadExit.Active;
						exit.locked = loadExit.Locked;
					}
				}

			}
		}


	}

}
