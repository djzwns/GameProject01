using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberPrint : MonoBehaviour {
    public Sprite[] number;

    Image[] currentTime;
    Image[] openTime;
    Image[] closeTime;

    int[] timeCount;
    Timer timer;

	// Use this for initialization
	void Start () {
        //numberImage = new Image[2];
        //numberImage[0] = GameObject.Find("Number1").GetComponent<Image>();
        //numberImage[1] = GameObject.Find("Number2").GetComponent<Image>();
        currentTime = GameObject.Find("CurrentTimePrint").GetComponentsInChildren<Image>();
        openTime = GameObject.Find("OpenTimePrint").GetComponentsInChildren<Image>();
        closeTime = GameObject.Find("CloseTimePrint").GetComponentsInChildren<Image>();

        timer = GetComponent<Timer>();
        timeCount = new int[2];
	}
	
	// Update is called once per frame
	void Update ()
    {
        OpenCloseTimePrint();
        NumberDivision();
        currentTime[0].sprite = number[timeCount[0]];
        currentTime[1].sprite = number[timeCount[1]];
    }

    void NumberDivision()
    {
        timeCount[0] = timer.GetTime(0) / 10;
        timeCount[1] = timer.GetTime(0) % 10;
    }

    void OpenCloseTimePrint()
    {
        openTime[0].sprite = number[timer.GetTime(1) / 10]; // 10의자리
        openTime[1].sprite = number[timer.GetTime(1) % 10]; // 1의 자리
        closeTime[0].sprite = number[timer.GetTime(2) / 10];
        closeTime[1].sprite = number[timer.GetTime(2) % 10];
    }

    public void ResetTimePrint()
    {
        openTime[0].sprite = number[0]; // 10의자리
        openTime[1].sprite = number[0]; // 1의 자리
        closeTime[0].sprite = number[0];
        closeTime[1].sprite = number[0];
    }
}
