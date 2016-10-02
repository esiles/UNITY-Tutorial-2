using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	private Transform t;
	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		t = GetComponent<Transform> ();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}


	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Boundary") {
			return;
		}
		Instantiate(explosion, t.position, t.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
