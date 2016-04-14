using UnityEngine;
using System.Collections;
using System.IO;

public class SaveLoad : MonoBehaviour {
    public StageManager stageManager;
    string loadStage;

    void Awake()
    {
        LoadFile("game_data.dat");
    }

    public void SaveFile(string fileNamePath)
    {
        //File.Delete(fileNamePath);
        StreamWriter write = new StreamWriter(fileNamePath);
        write.Write(stageManager.reachStage.ToString());

        write.Close();
    }

    public void LoadFile(string fileNamePath)
    {
        StreamReader read = new StreamReader(fileNamePath);

        if (read == null)
        {
            loadStage = "1";
        }
        if (read.Peek() >= 0)
        {
            loadStage = read.ReadLine();
        }
        read.Close();
    }

    // 스테이지 선택
    public void SelectStage( int stage )
    {
        stageManager.stageCount = stage;
    }

    // 스테이지 반환, string을 int로 바꿔 반환시킴.
    public void LoadStage()
    {
        if (loadStage != null)
            stageManager.reachStage = int.Parse(loadStage);
        else
            stageManager.reachStage = 1;
    }
}
