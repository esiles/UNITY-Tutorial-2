using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, ZMax;
}

public class MovementScript : MonoBehaviour {

	private Rigidbody rb;
	public Boundary boundary;
	public float tilt;
	public float speed;
	private AudioSource audio;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			audio = GetComponent<AudioSource> ();
			audio.Play ();
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); 

		}
	}


	void Start () 
	{

		rb = GetComponent<Rigidbody>();
	
	}
	   void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement*speed; 

		rb.position = new Vector3 
		(
				Mathf.Clamp(rb.position.x,boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z,boundary.zMin, boundary.ZMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
