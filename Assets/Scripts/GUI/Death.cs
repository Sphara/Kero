using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public Canvas DeathMenu;

    public void Die()
    {
        DeathMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ChangeLevel(int level)
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
