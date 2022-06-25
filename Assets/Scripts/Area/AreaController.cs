using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour {


	public Areas areas;

	Area _area;
	Area[] _areas;



	public void SetArea(Area area){
		_area = area;
	}

	public Area Area { get { return _area; } }
	public Area[] Areas { get { return _areas; } }
	public string Description { get { return _area.Description; } }
	public string Title { get { return _area.Title; } }

	// public Exit GetExists(){
	// 	return area.exits;
	// }

	// public Object GetObjects(){
	// 	return area.objects;
	// }

	// public Person GetPeople(){
	// 	return area.people;
	// }

}
