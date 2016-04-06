using UnityEngine;
using System.Collections;

public class EndPointTime : MonoBehaviour
{
    // 열리고 닫히는 시간 -----------
    public float openTime;
    public float closeTime;
    // ------------------------------


    // 열리는 시간을 반환
    public float GetOpenTime()
    {
        return openTime;
    }

    // 닫히는 시간을 반환
    public float GetCloseTime()
    {
        return closeTime;
    }
}
