using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public Timer timer;
    public ObjectManager objManager;
    public SaveLoad file;

    public Canvas StageSelect;
    public Canvas UICanvas;


    GameObject stage;   // 스테이지 생성 시 여기에 저장됨.
    public int stageCount;// 현재 스테이지
    public int reachStage;     // 최대로 올라간 스테이지
    public int lastStage;      // 마지막 스테이지

    // Use this for initialization
    void Start ()
    {
        // stageCount = 2;
        //stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
        UICanvas.enabled = false;
        file.LoadStage();
    }

    // 스테이지 생성 : 스테이지 선택 시 사용
    public void CreateStage(string stageNumber)
    {
        if (int.Parse(stageNumber) <= reachStage)
        {
            UICanvas.enabled = true;            // 스테이지 생성시 UI 활성화
            StageSelect.enabled = false;        // 선택창 비활성화
            stageCount = int.Parse(stageNumber);
            stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
            timer.Init(stage);
        }
    }

    // 스테이지 선택화면으로 돌아감.
    public void ReturnStage(string fileNamePath)
    {
        UICanvas.enabled = false;           // 선택화면에서 UI 비활성화
        StageSelect.enabled = true;
        file.SaveFile(fileNamePath);
        GetComponent<StageButtonActive>().ButtonInteractable();
        GetComponent<ObjectUIManager>().StageClear();


        Destroy(stage);
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
        // 마지막 스테이지인지 체크
        if (stageCount + 1 > lastStage)
        {
            stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
            return;
        }
        // 마지막 아니면 다음 스테이지로
        ++stageCount;


        // 현재 스테이지가 최종 도달한 스테이지보다 커지면 갱신 시킴
        if( stageCount > reachStage )
            reachStage = stageCount;

        stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);
        Debug.Log(stage.name);

        //if (stage == null)
        //{
        //    print("스테이지 없음");
        //    --stageCount;
        //    stage = Instantiate(Resources.Load("Prefabs/Stage/" + "Stage" + stageCount) as GameObject);

        //}

        // 스테이지 새로 생기면 타이머 초기화
        timer.Init(stage);


        //objManager = GetComponent<ObjectManager>();
        //objManager.DestroyAllObject();
        //GetComponent<ObjectUIManager>().Reset();
        GetComponent<ObjectUIManager>().StageClear();
    }
}
