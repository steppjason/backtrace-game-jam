using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour {

	public static GameController Instance { get; private set; }

	[HideInInspector] public AreaController AreaController;
	[HideInInspector] public InputController InputController;
	[HideInInspector] public ActionController ActionController;
	[HideInInspector] public GameDataController GameDataController;
	[HideInInspector] public InventoryController InventoryController;
	[HideInInspector] public GameItemController GameItemController;
	[HideInInspector] public AudioController AudioController;
	
	public GameData GameData;
	public TMP_Text areaTitleText;
	//public TMP_Text areaDescriptionText;
	public TMP_Text logText;

	public TMP_Text areaDescriptionText;

	public TMP_InputField inputField;

	public Area startingArea;

	void Awake() {
		SetGameInstance();
		GetControllers();
		//GameData = new GameData();
		//GameData.Init();
	}

	void Start() {
		DisplayArea();
		SetLogText("", "");
		//GameData = GameDataController.LoadData("default.json");
		//GameData.SetGameData();

	}

	void Update() {
		inputField.ActivateInputField();
	}

	void SetGameInstance() {
		if (Instance != null) {
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void GetControllers() {
		AudioController = GetComponent<AudioController>();
		GameItemController = GetComponent<GameItemController>();
		InventoryController = GetComponent<InventoryController>();
		GameDataController = GetComponent<GameDataController>();
		ActionController = GetComponent<ActionController>();
		InputController = GetComponent<InputController>();
		AreaController = GetComponent<AreaController>();

		AreaController.SetArea(startingArea);
	}


	public void DisplayArea() {
		SetAreaTitleText();
		SetAreaDescriptionText();
	}


	public void SetAreaDescriptionText() {
		string areaDescription = AreaController.Description;
		areaDescriptionText.text = "";
		StartCoroutine(DisplayText(areaDescription, 0.0001f, areaDescriptionText));
	}


	public void SetAreaTitleText() {
		string areaTitle = AreaController.Title;
		areaTitleText.text = areaTitle;
	}


	public void SetLogText(string command, string response) {
		logText.text = "<color=#FFB100>" + command.ToUpper() + "</color>\n \n";
		StartCoroutine(DisplayText(response, 0.05f, logText));
		
	}

	IEnumerator DisplayText(string str, float speed, TMP_Text element) {
		foreach(string word in str.Split(' ')) {
			element.text += word + " ";
			yield return new WaitForSeconds(speed);
		}

	}

}
