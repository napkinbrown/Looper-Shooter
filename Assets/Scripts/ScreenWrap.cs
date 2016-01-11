using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

	public Renderer render;
	public GameObject ghost;

	void Start()
	{
		render = GetComponent<Renderer> ();
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
	//private void CreateGhostObjects(prefab)
}
