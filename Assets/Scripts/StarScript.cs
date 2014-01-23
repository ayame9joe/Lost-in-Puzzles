using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerScript.health > 10 && PlayerScript.health <= 40)
		{
			GameObject.Find("Star1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Star2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Star3").GetComponent<SpriteRenderer>().enabled = false;
		}
		else if (PlayerScript.health > 40 && PlayerScript.health <= 70)
		{
			GameObject.Find("Star1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Star2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Star3").GetComponent<SpriteRenderer>().enabled = false;
		}
		else if (PlayerScript.health > 70)
		{
			GameObject.Find("Star1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Star2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("Star3").GetComponent<SpriteRenderer>().enabled = true;
		}
		else if (PlayerScript.health <= 10)
		{
			GameObject.Find("Star1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Star2").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("Star3").GetComponent<SpriteRenderer>().enabled = false;
		}
	
	}
}
