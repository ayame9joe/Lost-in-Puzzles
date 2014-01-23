using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	public static float health = 100;
	bool youOnlyGetOne = false;
	public static string levelName;
	public static int levelNum;

	// 2 - Store the movement
	public static Vector2 movement;
	public static bool gameOver = false;
	bool gamePause = false;

	public AudioSource level;
	public AudioSource click;
	public AudioSource walk;
	public AudioSource getItem;
	public AudioSource hurt;

	public static bool youCanPushTheBoxNow = false;

	Vector2 direction;

	void Start()
	{
		health = 100f;

		GameObject.Find("Pause").GetComponent<SpriteRenderer>().enabled = false;



		if (!level.isPlaying)
		{
			level.Play();
		}
	
	}

	void Update()
	{

		levelName = Application.loadedLevelName;
		levelNum = Application.loadedLevel;
		Debug.Log(levelNum + levelName);

		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");


		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		if (inputX > 0 || inputY > 0 || inputX < 0 || inputY < 0)
		{
			this.GetComponent<Animator>().enabled = true;
			walk.Play();
		}
		else {this.GetComponent<Animator>().enabled = false;}

		if (!TheEndScript.beatTheGame)
		{
			health -= Time.deltaTime * 3f;
		}
		else { health -= Time.deltaTime * 6f;}

		if (health >= 100f)
		{
			health = 100f;
		}
		else if (health <= 0f)
		{
			health = 0f;

			gameOver = true;
		}

		if (this.transform.position.x - GameObject.Find("Main Camera").transform.position.x > 5.75f)
		{
			this.transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x + 5.75f, this.transform.position.y, this.transform.position.z);
		}
		else if (this.transform.position.x - GameObject.Find("Main Camera").transform.position.x < -5.75f)
		{
			this.transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x - 5.75f, this.transform.position.y, this.transform.position.z);
		}
		if (this.transform.position.y < -3.2f)
		{
			this.transform.position = new Vector3(this.transform.position.x, -3.2f, this.transform.position.z);
		}
		else if (this.transform.position.y > 3.2f)
		{
			this.transform.position = new Vector3(this.transform.position.x, 3.2f, this.transform.position.z);
		}

		if (gameOver)
		{
			level.Stop();
			Application.LoadLevel("GameOver");
		}



		if (Input.GetKeyDown(KeyCode.P))
		{

			GameObject.Find("Pause").GetComponent<SpriteRenderer>().enabled = true;
			gamePause = true;
		}

		if (gamePause)
		{
			Time.timeScale = 0;
			level.Pause();
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Time.timeScale = 1;
				GameObject.Find("Pause").GetComponent<SpriteRenderer>().enabled = false;
				gamePause = false;
				level.Play();
			}
		}
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;


	}

	void OnTriggerEnter2D(Collider2D collider)
	{


		if (!youOnlyGetOne)
		{
			if (collider.gameObject.name == "Full")
			{
				Debug.Log("Get touch with Full");
				health = 100f;
				Destroy(collider.gameObject);
				youOnlyGetOne = true;
				getItem.Play();
				GameObject.Find("full").transform.position = new Vector3(GameObject.Find("full").transform.position.x, GameObject.Find("full").transform.position.y, -1f);
			}
			else if (collider.gameObject.name == "Half")
			{
				Debug.Log("Get touch with Half");

				health += health * 0.5f;

				Destroy(collider.gameObject);
				youOnlyGetOne = true;
				getItem.Play();
				GameObject.Find("half").transform.position = new Vector3(GameObject.Find("half").transform.position.x, GameObject.Find("half").transform.position.y, -1f);
			}
			else if (collider.gameObject.name == "Double")
			{
				Debug.Log("Get touch with Double");
				if (health <= 100f)
				{
					health += health * 2f;
				}
				Destroy(collider.gameObject);
				youOnlyGetOne = true;
				getItem.Play();
				GameObject.Find("double").transform.position = new Vector3(GameObject.Find("double").transform.position.x, GameObject.Find("double").transform.position.y, -1f);
			}
		}
		else {
			if (GameObject.Find("Full"))
			{
				GameObject.Find("Full").collider2D.isTrigger = false;
			}
			if (GameObject.Find("Double"))
			{
				GameObject.Find("Double").collider2D.isTrigger = false;
			}
			if (GameObject.Find("Half"))
			{
				GameObject.Find("Half").collider2D.isTrigger = false;
		
			}
		}
		if (collider.gameObject.name == "End The Level")
		{

			Application.LoadLevel("LevelClear");
			level.Stop();

		}
	}

	void OnCollisionEnter2D (Collision2D collider)
	{

		if (collider.gameObject.name == "Enemy1")
		{
			health -= 10;
			Debug.Log("Hit by the enemy!");
			hurt.Play();
		}
		if (collider.gameObject.name == "Enemy2")
		{
			health -= 30;
			hurt.Play();
		}
		Debug.Log("Collision!");
		click.Play();
		if (this.transform.position.x < GameObject.Find("Main Camera").transform.position.x - 5.75f)
		{
			gameOver = true;
		}
	}
}