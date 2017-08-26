using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour, IInteractable {

    public void Interact(GameObject InteractionAuthor)
    {
        Debug.Log("Korambu a faim");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
