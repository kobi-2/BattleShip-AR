using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	public DoneButtonScript doneButton;
	private GameObject tile;

	private Color originalColor;

	// Use this for initialization
	void Start () {
		//originalColor = GameObject.Find ("Tile").GetComponent<Renderer> ().material.color;

	}


	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.transform.tag == "Tile") {

					tile = hit.transform.gameObject;

					performAttack ();

				}
			}
		}
	}


	public void performAttack(){
	
		GameObject battleShip = GameObject.Find ("Battleship");
		doneButton = battleShip.GetComponent<DoneButtonScript> ();

		if((tile == doneButton.tile0) && (tile.transform.parent == doneButton.tile0.transform.parent)){
			tile.GetComponent <Renderer> ().material.color = Color.green;
		}
		else if((tile == doneButton.tile1) && (tile.transform.parent == doneButton.tile1.transform.parent)){
			tile.GetComponent <Renderer> ().material.color = Color.green;
		}
		else if((tile == doneButton.tile2) && (tile.transform.parent == doneButton.tile2.transform.parent)){
			tile.GetComponent <Renderer> ().material.color = Color.green;
		}
		else{
			tile.GetComponent <Renderer> ().material.color = Color.red;
		}


		/*
					 * different ways to find equality between gameobjects:
					 * 

					if(GameObject.ReferenceEquals(doneButton.tile0, tile))
						tile.GetComponent <Renderer> ().material.color = Color.grey;
					
					if(tile.GetInstanceID() == doneButton.tile1.GetInstanceID())
						tile.GetComponent <Renderer> ().material.color = Color.green;

					if(tile == doneButton.tile2)
						tile.GetComponent <Renderer> ().material.color = Color.blue;


					*/
		Debug.Log ("my log: touch controls: position: " + tile.transform.position);




	}



}
