using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeInteraction : InteractionScript
{

    public int level;

    public override void Interact(GameObject InteractionAuthor)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}

