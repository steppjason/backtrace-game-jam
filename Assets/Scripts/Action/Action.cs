using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject {

	public new string name;
	public List<string> commands;
	public abstract void DoAction(string parsedInput, string rawInput);
	public abstract void DoAction(GameItem item);
	public abstract void DoAction(Exit exit);

}
