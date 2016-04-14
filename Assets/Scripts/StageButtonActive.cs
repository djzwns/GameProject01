using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageButtonActive : MonoBehaviour {
    public StageManager stage;
    public Button[] button;
    int reachStage;

	// Use this for initialization
	void Start () {
        ButtonInteractable();
	}

    // 버튼 활성화 시킴
    public void ButtonInteractable()
    {
        reachStage = stage.reachStage;
        for (int i = 0; i < reachStage; ++i)
        {
            button[i].interactable = true;
        }
    }
}
