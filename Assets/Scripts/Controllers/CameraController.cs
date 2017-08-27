using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[Header("Camera Settings")]
	public float xOffset;
	public float yOffset;

    public float minX = 0;
    public float maxX = 10;

	public float followSpeed;
	public Transform myObjectToFollow;
	private Vector3 tempFollowedObjectWithOffset;

	void FixedUpdate () {

        tempFollowedObjectWithOffset = new Vector3(Mathf.Clamp(myObjectToFollow.position.x + xOffset, minX, maxX), 0, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, tempFollowedObjectWithOffset, followSpeed * Time.deltaTime);
	}
}
