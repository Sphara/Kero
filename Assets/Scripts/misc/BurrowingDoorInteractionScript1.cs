using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowingDoorInteractionScript1 : InteractionScript {

    public List<KeyInteractionScript> keyList;

    public bool isBurrowing = false;

    public override void Interact(GameObject InteractionAuthor)
    {
        foreach (KeyInteractionScript key in keyList)
        {
            if (key.state)
                return;
        }

        isBurrowing = true;

    }


    private void Update()
    {
        if (isBurrowing)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1);
        }
    }
}
