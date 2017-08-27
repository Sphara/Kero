using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public Vector3 startingPoint;
    public Vector3 endPoint;

    public Death death;

    public LayerMask layer;

	void Start () {
		
	}
	
	void Update () {

        if (Physics2D.Linecast(startingPoint, endPoint, layer))
            death.Die();
	}
}
