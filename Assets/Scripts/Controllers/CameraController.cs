﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[Header("Camera Settings")]
	public float xOffset;
	public float yOffset;

	public float followSpeed;
	public Transform myObjectToFollow;
	private Vector3 tempFollowedObjectWithOffset;

	void FixedUpdate () {
		if (myObjectToFollow.position.x > 0) {
			tempFollowedObjectWithOffset = new Vector3 (myObjectToFollow.position.x + xOffset, 0, transform.position.z);
		} else {
			tempFollowedObjectWithOffset = new Vector3 (0, 0, transform.position.z);
		}
		transform.position = Vector3.Lerp(transform.position, tempFollowedObjectWithOffset, followSpeed * Time.deltaTime);
	}
}
