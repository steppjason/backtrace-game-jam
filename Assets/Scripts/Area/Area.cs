using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Negotiator/Area", fileName = "AREA_")]
public class Area : ScriptableObject {


	[Tooltip("The name of the Area used in the Editor.")]
	[SerializeField] new string name;


	[SerializeField] string uuid = Guid.NewGuid().ToString();


	[Tooltip("The title of the Area displayed in Game.")]
	[SerializeField] string title;
	[Space(10)]


	[Tooltip("The description of the Area in Game.")]
	[SerializeField][TextArea(15, 99)] string description;
	[Space(10)]

	[SerializeField] AudioClip musicTrack;
	[Space(10)]

	[SerializeField] float musicVolume;
	[Space(10)]

	[Tooltip("Reference nouns used by the parser (Not implemented yet).")]
	[SerializeField] string[] refs;
	[Space(10)]


	[Tooltip("Array of Exits connected to the Area.")]
	[SerializeField] List<Exit> exits;
	[Space(10)]


	[Tooltip("Array of GameItems in the Area.")]
	[SerializeField] List<GameItem> gameItems;
	[Space(10)]


	[Tooltip("")]
	[SerializeField] List<ActionResponse> actionResponses;
	//public People[] people;

	public string UUID { get { return uuid; } }
	public string Name { get { return name; } }
	public string Title { get { return title; } }
	public string Description { get { return description; } }
	public AudioClip Music { get { return musicTrack; } }
	public float MusicVolume { get { return musicVolume; } }
	public string[] References { get { return refs; } }
	public List<Exit> Exits { get { return exits; } }
	public List<GameItem> GameItems { get { return gameItems; } }
	public List<ActionResponse> ActionResponses { get { return actionResponses; } }
	//public People[] People {get { return people; } }

}
