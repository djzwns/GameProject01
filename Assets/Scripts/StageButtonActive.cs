using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageButtonActive : MonoBehaviour {
    public StageManager stage;
    public Button[] button;
    public Sprite[] sprite;
    int reachStage;
    int MAXSTAGE;

    const int CLEAR = 0;
    const int NOTHING = 1;
    const int CLOSE = 2;

	// Use this for initialization
	void Start () {
        MAXSTAGE = stage.lastStage;
        ButtonInteractable();
	}

    // 버튼 활성화 시킴
    public void ButtonInteractable()
    {
        reachStage = stage.reachStage;
        // clear noting close 이미지 변경해줌
        for (int i = 0; i < MAXSTAGE; ++i)
        {
            //button[i].GetComponentsInChildren<Image>()[1].sprite = Resources.Load("Textures/StageSelect/" + (i+1) ) as Sprite;
            // 클리어한 스테이지들 clear 이미지 사용
            if (i < reachStage)
            {
                button[i].GetComponentsInChildren<Image>()[2].sprite = sprite[CLEAR];
                button[i].interactable = true;
            }

            // 앞에 스테이지 못깨서 접속 못 하는 부분은 close
            else
                button[i].GetComponentsInChildren<Image>()[2].sprite = sprite[CLOSE];
        }
        // 스테이지에 들어갈 수는 있지만 아직 클리어 하지 않은 부분은 빈 이미지 사용
        if( MAXSTAGE > reachStage )
            button[reachStage-1].GetComponentsInChildren<Image>()[2].sprite = sprite[NOTHING];
    }
}
