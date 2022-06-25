using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Negotiator/Exit", fileName = "EXIT_")]
public class Exit : ScriptableObject{

	[SerializeField] new string name;
	[SerializeField] string uuid = Guid.NewGuid().ToString();

	public bool active = true;
	public bool locked = false;
	public GameItem requiredItem = null;

	[Tooltip("The area that is loaded upon using the Exit.")]
	[SerializeField] Area area = null;

	//[SerializeField] GameItem gameItem;

	[Tooltip("A description of the Exit.")]
	[TextArea][SerializeField] string description = null;
	[Space(10)]

	[Tooltip("The log response upon using the Exit.")]
	[TextArea][SerializeField] string response = null;
	[Space(10)]

	[Tooltip("The log response upon using the Exit.")]
	[TextArea][SerializeField] string rejection = null;
	[Space(10)]

	[Tooltip("Reference nouns used by the parser to call the Exit in game.")]
	[SerializeField] List<string> refs = null;

	[SerializeField] private List<ActionResponse> actionResponses;
	

	public string UUID { get { return uuid; } }
	public Area Area { get { return area; } }
	public string Name { get { return name; } }
	public string Description { get { return description; } }
	public string Response { get { return response; }}
	public string Rejection { get { return rejection; }}
	public List<string> References {get { return refs; } }
	public List<ActionResponse> ActionResponses {get { return actionResponses; } }

}
