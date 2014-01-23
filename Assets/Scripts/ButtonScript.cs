using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	bool mouseIn = false;
	bool mouseDown = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseIn)
		{

		}
		else {

		}
	}

	void OnMouseOver () {
		Debug.Log("Button Hover");
		mouseIn = true;
		Vector3 temp = new Vector3(0.8f, 0.8f, 1); 
		this.transform.localScale = temp;
		if (this.gameObject.name == "BacktoMenu")
		{
			//this.gameObject.GetComponent<SpriteRenderer>().sprite.texture = 
			//Application.LoadLevel(0);

			if (mouseDown)
			{
				mouseDown = false;
				Debug.Log("Click BacktoMenu");
				Application.LoadLevel("Menu");
			}
		}
		else if (this.gameObject.name == "Replay")
		{
			if (mouseDown)
			{
				mouseDown = false;
				Debug.Log("Click Replay");
				Application.LoadLevel(PlayerScript.levelName);
			}
			//
		}
		else if (this.gameObject.name == "NextLevel")
		{
			if (mouseDown)
			{
				mouseDown = false;
				Debug.Log("Click NextLevel");
				Application.LoadLevel(PlayerScript.levelNum+1);
			}
			//Application.LoadLevel();
		}

	}

	void OnMouseExit () {
		mouseIn = false;
		Vector3 temp = new Vector3(1, 1, 1); 
		this.transform.localScale = temp;
		if (this.gameObject.name == "BacktoMenu")
		{
			//this.gameObject.GetComponent<SpriteRenderer>().sprite.texture = 
			//Application.LoadLevel(0);

			//this.transform.position = Vector3.MoveTowards(this.transform.position,
			//                                            new Vector3(transform.position.x,transform.position.y, 11),
			//                                          Time.deltaTime*100);
		}
		else if (this.gameObject.name == "Replay")
		{
			//Application.LoadLevel(0);
		}
		else if (this.gameObject.name == "NextLevel")
		{
			//Application.LoadLevel();
		}
	}


	void OnMouseDown () {
		Debug.Log("Button Click!");
		mouseDown = true;

	}
}
