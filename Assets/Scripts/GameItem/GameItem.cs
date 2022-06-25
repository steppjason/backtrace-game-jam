using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/GameItem", fileName = "ITEM_")]
public class GameItem : ScriptableObject {

	[SerializeField] private new string name;
	[SerializeField] private string uuid = Guid.NewGuid().ToString();
	

	public bool active = true;
	public bool canTake = true;
	public bool canUse = true;

	[SerializeField] private GameItem itemUse;
	[SerializeField] private Exit exitUse;
	

	[SerializeField][TextArea(5, 99)] private string areaDescription;

	[SerializeField] private List<string> refs;
	
	[SerializeField] private List<ActionResponse> actionResponses;


	public string UUID { get { return uuid; } }
	public string Name { get { return name; } }
	public GameItem ItemUse { get { return itemUse; } }
	public Exit ExitUse { get { return exitUse; } }
	public string Description {get { return areaDescription; } }
	public List<string> References {get { return refs; } }
	public List<ActionResponse> ActionResponses {get { return actionResponses; } }

}
