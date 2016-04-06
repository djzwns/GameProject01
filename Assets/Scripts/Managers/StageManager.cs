using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public Timer timer;
    public ObjectManager objManager;
    GameObject stage;   // 스테이지 생성 시 여기에 저장됨.
    int stageCount;

    // Use this for initialization
    void Awake ()
    {
        stageCount = 1;
        stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
        //objManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
    }

    public void StageClear()
    {
        ++stageCount;
        Destroy(stage);
        objManager.DestroyAllObject();
    }

    public void NextStage()
    {
        stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
        Debug.Log(stage.name);

        if (stage == null)
        {
            print("스테이지 없음");
            --stageCount;
            stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);

        }

        // 스테이지 새로 생기면 타이머 초기화
        timer.Init();
    }
}
