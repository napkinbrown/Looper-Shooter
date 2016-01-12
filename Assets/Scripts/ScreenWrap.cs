using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

	public Renderer render;
	public Rigidbody original;
	public Transform ghost;
	public GhostPositions ghostsPos;

	[System.Serializable]
	public class GhostPositions
	{
		public float xMin, xMax, yMin, yMax;
	}

	void Start()
	{
		render = GetComponent<Renderer> ();
		ghost = GetComponent<Transform> ();
		original = GetComponent<Rigidbody> (); 

		CreateGhostObjects ();
		
	}
	private bool CheckRenderers(Renderer render)
	{
		//if the object is off screen, return false
		if (render.isVisible) 
		{
			//Debug.Log("on screen");
			return true;
		}
		else 
		{
			//Debug.Log ("off screen");
			return false;
		}
	}
	private void CreateGhostObjects() //VERY BROKEN
	{
		Vector3 originalPosition = new Vector3 (original.transform.position.x, original.transform.position.y, 0.0f);

		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMin, originalPosition.y + ghostsPos.yMax,0.0f),original.rotation); //upper left ghost
		Instantiate (ghost,new Vector3(originalPosition.x, originalPosition.y + ghostsPos.xMax,0.0f),original.rotation); // upper middle ghost
		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMax, originalPosition.y + ghostsPos.yMax,0.0f),original.rotation); //upper right ghost

		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMin, originalPosition.y,0.0f),original.rotation); //middle left ghost
		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMax, originalPosition.y,0.0f),original.rotation); //middle right ghost

		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMin, originalPosition.y + ghostsPos.yMin,0.0f),original.rotation); //lower left ghost
		Instantiate (ghost,new Vector3(originalPosition.x, originalPosition.y + ghostsPos.yMin,0.0f),original.rotation); //lower middle ghost
		Instantiate (ghost,new Vector3(originalPosition.x + ghostsPos.xMax, originalPosition.y + ghostsPos.yMin,0.0f),original.rotation); //lower right ghost
	}
}
