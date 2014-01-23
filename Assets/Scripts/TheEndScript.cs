using UnityEngine;
using System.Collections;

public class TheEndScript : MonoBehaviour {

	public static bool beatTheGame = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			Application.LoadLevel("GameMakers");
			beatTheGame = true;
		}
	
	}
}
