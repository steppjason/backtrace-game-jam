using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataController : MonoBehaviour {

	string _directory = "/SaveData/";

	void Start() {
		GameController.Instance.GameData = LoadData("default.json");
	}

	public void SaveData(GameData gameData, string fileName) {
		string dir = Application.persistentDataPath + _directory;

		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);

		string json = JsonUtility.ToJson(gameData);
		File.WriteAllText(dir + fileName, json);
	}


	public GameData LoadData(string fileName) {
		string dir = Application.persistentDataPath + _directory + fileName;

		GameData gameData = new GameData();

		if (!File.Exists(dir))
			CreateDefaultData();
			
		string json = File.ReadAllText(dir);
		gameData = JsonUtility.FromJson<GameData>(json);

		return gameData;
	}


	public void CreateDefaultData() {
		SaveData(GameController.Instance.GameData, "default.json");
	}

}
