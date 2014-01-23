using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	public AudioSource lose;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerScript.gameOver)
		{
			Debug.Log("Play lose music");

			lose.Play();
			Debug.Log(lose.isPlaying);

		}
	
	}
}
