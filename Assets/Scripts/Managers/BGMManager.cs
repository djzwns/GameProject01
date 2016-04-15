using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour
{
    public AudioSource source;      // 오디오 소스
    public AudioClip[] clip;        // 오디오 클립 배열

    public void ChangeBGM(int BGMNumber)
    {
        source.clip = clip[BGMNumber];
        source.Play();
    }
}