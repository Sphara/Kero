using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Canvas mainCanvas;
    public Canvas levelSelectionCanvas;

    bool activeCanvas = true; // shut up franck_r

	void Start () {
		
	}
	
    public void LoadLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

    public void ChangeMenu()
    {
        activeCanvas = !activeCanvas;

        mainCanvas.gameObject.SetActive(activeCanvas);
        levelSelectionCanvas.gameObject.SetActive(!activeCanvas);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
