using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionScript : InteractionScript {

    public List<KeyInteractionScript> keyList;

    public override void Interact(GameObject InteractionAuthor)
    {
        foreach (KeyInteractionScript key in keyList)
        {
            if (key.state)
                return;
        }

        gameObject.SetActive(false);
    }

}
