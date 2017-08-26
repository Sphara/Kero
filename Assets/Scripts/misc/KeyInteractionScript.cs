using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractionScript : InteractionScript {

    public bool state = true;

    public override void Interact(GameObject InteractionAuthor)
    {
        gameObject.SetActive(false);
        state = false;
    }
}
