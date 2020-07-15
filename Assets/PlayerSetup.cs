using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	private Behaviour touchControlsToDisable;

	[SerializeField]
	private Behaviour buttonControlsToDisable;

	[SerializeField]
	private Behaviour doneButtonTodisable;

	[SerializeField]
	private Renderer shipToDisable;

	// Use this for initialization
	void Start () {

		if (!isLocalPlayer) {

			buttonControlsToDisable.enabled = false;
			doneButtonTodisable.enabled = false;
			shipToDisable.enabled = false;
			touchControlsToDisable.enabled = true;
		}

		if (isLocalPlayer) {
			touchControlsToDisable.enabled = false;
		}
	}

}
