using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeronController : MonoBehaviour {

	public float XLeft;

	public float XRight;

	public float speed;

	private int goingRight = 1;

	private float XPos = 0;

	private float YRot;

	void Start () {
		XPos = XLeft;
		transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
		YRot = transform.rotation.eulerAngles.y;
		print(YRot);
	}
	
	void Update () {
		XPos += speed * goingRight;
		transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
		if (XPos >= XRight) {
			StartCoroutine("RotateLeft");
			goingRight = -1;
		}
		if (XPos <= XLeft) {
			StartCoroutine("RotateRight");
			goingRight = 1;
		}
	}

	IEnumerator RotateLeft()
	{
		while (YRot > 90) {
			yield return new WaitForSeconds(0.01f);
			YRot -= 7;
			transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, YRot, transform.rotation.z));
		}
	}

	IEnumerator RotateRight()
	{
		while (YRot < 270) {
			yield return new WaitForSeconds(0.01f);
			YRot += 7;
			transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, YRot, transform.rotation.z));
		}
	}
}
