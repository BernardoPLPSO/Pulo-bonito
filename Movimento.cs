using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {
	private Rigidbody rb;
	[SerializeField]
	private float Force=2f;
	private float Jump = 50f;
	private float Timer=0f;
	private float X=0, X_1=10f;
	[SerializeField]
	private float forcaMin = 90f;
	private Vector3 Resultante;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update (){
		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (transform.forward*Force,ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb.AddForce (transform.forward*(-Force),ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb.AddForce (transform.right*(-Force), ForceMode.VelocityChange);
		}
		if(Input.GetKey(KeyCode.D)){
			rb.AddForce (transform.right*Force, ForceMode.VelocityChange);
		}
		if (Input.GetKeyDown (KeyCode.Space) && rb.velocity.y==0) {
			X = 0f;
			X_1 = 0f;

			//Timer = 0.5f;
		}
		if (rb.velocity.y != 0) {
			rb.AddForce (transform.up * -(20*Mathf.Pow(X,2f)+forcaMin), ForceMode.Force);
			X += Time.deltaTime;
			Debug.Log (20*Mathf.Pow(X,2f));
		}
		if (rb.velocity.y < 0)
			X_1 = 10f;
		rb.AddForce (transform.up *5* Mathf.Exp(-2*X_1), ForceMode.Impulse);
		X_1 += Time.deltaTime;
		//Timer -= Time.deltaTime;
	}

}
