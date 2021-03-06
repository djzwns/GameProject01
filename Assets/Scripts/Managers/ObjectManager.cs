﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
    public AudioClip clickSound;
    public CameraController camController;
    private GameObject clickObj;

    // Start 함수 앞에서 호출됨.
    void Awake()
    {
        //mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(clickSound,transform.position, 10f);
            clickObj = GetClickedObject();

            if (clickObj.tag == "Preview")
            {
                // 오브젝트의 클론을 생성
                camController.userObject = CreateObject();
                camController.userObject.GetComponent<ObjectController>().HoldObject();
            }
        }
    }

    // 클릭된 위치에 있는 오브젝트를 반환해준다.
    private GameObject GetClickedObject()
    {
        return GetComponent<CameraManager>().GetClickedObject();
    }

    // 오브젝트 생성 후 생성된 오브젝트 반환
    GameObject CreateObject()
    {
        // 리소스 폴더에서 프리팹을 불러온다.
        GameObject obj = Instantiate(Resources.Load("Prefabs/" + clickObj.name) as GameObject);

        //obj.GetComponent<ObjectController>().enabled = true;
        // 트리거를 바꿔준다.
        //obj.GetComponentInChildren<Collider2D>().isTrigger = false;

        return obj;
    }

    // 오브젝트 파괴
    public void DestroyAllObject()
    {
        GameObject destroyObj/* = GameObject.FindGameObjectWithTag("UserObject")*/;

        // 오브젝트가 null이 될때 까지 찾아서 다 디스트로이 시킴.
        while ((destroyObj = GameObject.FindGameObjectWithTag("UserObject")) != null)
        {
            // Destroy 를 쓰려 했는데 바로 지워지지 않고 
            // 남았다가 Update 종료 시점에서 지워지는 탓인지 유니티 먹통 ㅠ
            DestroyImmediate(destroyObj); 
           // destroyObj = GameObject.FindGameObjectWithTag("UserObject");
        }
    }
}
