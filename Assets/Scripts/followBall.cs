using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followBall : MonoBehaviour {

	public GameObject	ball = null;
	public float		distance = 0f;

	private Transform _transformBall = null;
	private Rigidbody	_rbBall;


	// Use this for initialization
	void Start () {
		_transformBall = ball.transform;
		_rbBall = ball.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = new Vector3();
		newPosition.z = ball.transform.position.z;
		newPosition.y = ball.transform.position.y + distance;
		newPosition.x = ball.transform.position.x;
		gameObject.transform.position = newPosition;
		if (_rbBall.velocity != Vector3.zero)
			// gameObject.transform.rotation = _rbBall.velocity;
			transform.rotation = Quaternion.AngleAxis(_rbBall.velocity.magnitude*Time.deltaTime, _rbBall.velocity) * transform.rotation;

	}
}
