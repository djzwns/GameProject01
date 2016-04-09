using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
