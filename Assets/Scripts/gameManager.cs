using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public GameObject	ball;
	public RectTransform panel;

	[SerializeField] private float	_power;
	private int		_direction = 1;
	private bool	_onCharge = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (!_onCharge)
				_onCharge = true;
			else
			{
				_onCharge = false;
				Shoot();
				_power = 0;
				// panel.anchorMax = new Vector2(1f, 0f);
			}
		}
		if (_onCharge)
			Charge();
	}

	private void Charge() {
		if (_power >= 100)
			_direction = -1;
		else if (_power <= 0)
			_direction = 1;
		_power += Time.deltaTime * _direction * 60f;
		panel.anchorMax = new Vector2(1f, _power / 100f);
	}

	private void Shoot() {
		ball.GetComponent<Rigidbody>().velocity = Vector3.up * _power * 0.1f;
	}
}
