using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ShipOrientation {

	public static bool rowWise { get; set; }

}


public class ButtonControls : MonoBehaviour {

	public static float MovementAlongXAxis = 0.0f, MovementAlongZAxis = 0.0f, Rotation=0.0f;

	public bool rowWise;
	public float xMin, xMax, zMin, zMax, addXRange, addZRange;

	public Vector3 spawnPoint= Vector3.zero;

	// Use this for initialization
	void Start () {
		MovementAlongXAxis = 0.0f;
		MovementAlongZAxis = 0.0f;

		spawnPoint = this.transform.position;

		//rowWise = true;
		//ShipOrientation.Instance.rowWise = true;
		ShipOrientation.rowWise = true;

		changeParameters ();

	}

	public void LeftButtonTouched()
	{
		MovementAlongXAxis = -5f;
		if ((this.transform.position.x + MovementAlongXAxis) >= xMin) {
			this.transform.position = this.transform.position + new Vector3 (MovementAlongXAxis, 0f, 0f);
		}
	}

	public void RightButtonTouched()
	{
		MovementAlongXAxis = 5f;
		if ((this.transform.position.x + MovementAlongXAxis) <= xMax) {
			this.transform.position = this.transform.position + new Vector3 (MovementAlongXAxis, 0f, 0f);
		}
	}
		
	public void UpButtonTouched()
	{
		MovementAlongZAxis = 5f;
		if ((this.transform.position.z + MovementAlongZAxis) <= zMax) {
			this.transform.position = this.transform.position + new Vector3 (0f, 0f, MovementAlongZAxis);
		}
	}

	public void DownButtonTouched()
	{
		MovementAlongZAxis = -5f;
		if ((this.transform.position.z + MovementAlongZAxis) >= zMin) {
			this.transform.position = this.transform.position + new Vector3 (0f, 0f, MovementAlongZAxis);
		}
	}
		


	public void RotateClockwiseButtonTouched()
	{
		Rotation = 90f;
		//this.transform.Rotate(0,Rotation,0);


		//if ( (this.transform.rotation.eulerAngles.y > 88) && (this.transform.rotation.eulerAngles.y < 92) ) {
		if ( ((int) this.transform.rotation.eulerAngles.y) > 50) {
			this.transform.Rotate (0, -90f, 0);
		} else {
			this.transform.Rotate (0, 90f, 0);
		}


		//rowWise = !rowWise;
		//ShipOrientation.Instance.rowWise = ! ShipOrientation.Instance.rowWise;
		ShipOrientation.rowWise = ! ShipOrientation.rowWise;
		changeParameters ();
	}

	public void RotateAnticlockwiseButtonTouched()
	{
		Rotation = -90f;
		//this.transform.Rotate(0,Rotation,0);


		//if ( (this.transform.rotation.eulerAngles.y > 88) && (this.transform.rotation.eulerAngles.y < 92) ) {
		if ( ((int) this.transform.rotation.eulerAngles.y) > 50) {
			this.transform.Rotate (0, -90f, 0);
		} else {
			this.transform.Rotate (0, 90f, 0);
		}


		//rowWise = !rowWise;
		//ShipOrientation.Instance.rowWise = ! ShipOrientation.Instance.rowWise;
		ShipOrientation.rowWise = ! ShipOrientation.rowWise;
		changeParameters ();
	}



	private void changeParameters(){
		//if (ShipOrientation.Instance.rowWise) {
		//if(rowWise){
		if(ShipOrientation.rowWise){
			addXRange = 0f;
			addZRange = 5f;
		} else {
			addXRange = 5f;
			addZRange = 0f;
		}


		xMin = -18.9f - addXRange;
		xMax = 16.5f + addXRange;
		zMin = -24.2f - addZRange + spawnPoint.z;	// add spawnPoint.z??
		zMax = 16.2f + addZRange + spawnPoint.z;		//add spawnPoint.z??

		makeCorrections ();
	
	}

	private void makeCorrections(){
		if(this.transform.position.x > xMax) this.transform.position = this.transform.position + new Vector3 (-5f, 0f, 0f);
		if(this.transform.position.x < xMin) this.transform.position = this.transform.position + new Vector3 (5f, 0f, 0f);

		if(this.transform.position.z > zMax) this.transform.position = this.transform.position + new Vector3 (0f, 0f, -5f);
		if(this.transform.position.z < zMin) this.transform.position = this.transform.position + new Vector3 (0f, 0f, 5f);
	}

}
