using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class EnemyScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(2, 2);
	public float distance = 0.03f;
	bool checkTheDirection = false;
	int i = 0;
	public int max = 50;
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);



	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
		i++;
		if (i > max)
		{
			direction.x = -direction.x;
			i = 0;
		}

	}
}
