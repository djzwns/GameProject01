using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    void Start()
    {
        Screen.SetResolution(747, 420, false);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void StartClick()
    {
        SceneManager.LoadScene("game");
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
