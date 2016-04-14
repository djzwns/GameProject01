using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public Timer timer;
    public ObjectManager objManager;
    GameObject stage;   // 스테이지 생성 시 여기에 저장됨.
    public int stageCount;// 현재 스테이지
    public int reachStage;     // 최대로 올라간 스테이지

    // Use this for initialization
    void Awake ()
    {
        // stageCount = 2;
        stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
        GetComponent<SaveLoad>().LoadStage();
    }

    // 스테이지 생성 : 스테이지 선택 시 사용
    public void CreateStage()
    {
        stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
    }

    // 스테이지 제거
    public void StageClear()
    {
        Destroy(stage);
        //objManager.DestroyAllObject();
    }

    // 다음 스테이지를 생성한다.
    public void NextStage()
    {
        ++stageCount;

        // 현재 스테이지가 최종 도달한 스테이지보다 커지면 갱신 시킴
        if( stageCount > reachStage )
            reachStage = stageCount;

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


        //objManager = GetComponent<ObjectManager>();
        //objManager.DestroyAllObject();
        //GetComponent<ObjectUIManager>().Reset();
        GetComponent<ObjectUIManager>().StageClear();
    }
}
