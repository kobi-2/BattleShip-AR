using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerGetInstance : NetworkBehaviour {

	public DoneButtonScript doneButtonScript;
	public GameObject localTile0, localTile1, localTile2;
	public GameObject remoteTile0, remoteTile1, remoteTile2;


	void Start () {
		
		//Object[] objects = Object.FindObjectsOfType<GameObject.>;
		//GameObject ob = GameObject.FindGameObjectsWithTag;
		//this.GetInstanceID;

		getTiles ();

		RemotePlayer remotePlayer = new RemotePlayer();
		remotePlayer.playerInstanceID = this.GetInstanceID ();
		remotePlayer.remoteTiles [0] = localTile0;
		remotePlayer.remoteTiles [1] = localTile1;
		remotePlayer.remoteTiles [2] = localTile2;
		
		CmdSendTiles (remotePlayer);

	}


	
	void Update () {

		getTiles ();

		RemotePlayer remotePlayer = new RemotePlayer();
		remotePlayer.playerInstanceID = this.GetInstanceID ();
		remotePlayer.remoteTiles [0] = localTile0;
		remotePlayer.remoteTiles [1] = localTile1;
		remotePlayer.remoteTiles [2] = localTile2;

		CmdSendTiles (remotePlayer);

	}



	void getTiles(){

		if (isLocalPlayer) {
			doneButtonScript = this.GetComponentInChildren<DoneButtonScript> ();

			localTile0 = doneButtonScript.tile0;
			localTile1 = doneButtonScript.tile1;
			localTile2 = doneButtonScript.tile2;
		}

		

		/*
		 * 
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Battleship");

		for (int i = 0; i < gameObjects.Length; i++) {
			
			DoneButtonScript dB = gameObjects [i].GetComponent<DoneButtonScript> ();

			if ((localTile0 != dB.tile0) || (localTile1 != dB.tile1) || (localTile2 != dB.tile2)) {

				remoteTile0 = dB.tile0;
				remoteTile1 = dB.tile1;
				remoteTile2 = dB.tile2;

				break;
			}
		
		}

		*/



/*
		DoneButtonScript[] doneButtonScriptsArray = this.GetComponents<DoneButtonScript> ();	

		for(int i=0; i<doneButtonScriptsArray.Length; i++){
			
			if ((localTile0 != doneButtonScriptsArray [i].tile0) || (localTile1 != doneButtonScriptsArray [i].tile1) || (localTile2 != doneButtonScriptsArray [i].tile2)) {

				remoteTile0 = doneButtonScriptsArray[i].tile0;
				remoteTile1 = doneButtonScriptsArray[i].tile1;
				remoteTile2 = doneButtonScriptsArray[i].tile2;
				
				break;
			}
		
		}

*/

	}



	[Command]
	public void CmdSendTiles(RemotePlayer remotePlayer){
		RpcGetRemoteTiles (remotePlayer);
	}



	[ClientRpc]
	void RpcGetRemoteTiles (RemotePlayer remotePlayer){

		if (remotePlayer.playerInstanceID != this.GetInstanceID ()) {
		
			remoteTile0 = remotePlayer.remoteTiles [0];
			remoteTile1 = remotePlayer.remoteTiles [1];
			remoteTile2 = remotePlayer.remoteTiles [2];

		}
	
	}
		

}




public class RemotePlayer {

	public int playerInstanceID;
	public GameObject[] remoteTiles;

}



