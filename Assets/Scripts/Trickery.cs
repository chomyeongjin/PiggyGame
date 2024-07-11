using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trickery : MonoBehaviour
{
    public GameObject sheepL;
    public GameObject sheepR;
    public GameObject chicken;
    public GameObject panel;

    public GameObject q;

    public Button Left;
    public Button Right;

    int ran;
    bool doRandom = false;
    bool isClick = false;

    bool isMove = true;
    Vector3 sheepLstPos;
    Vector3 sheepLtgPos;
    Vector3 sheepRstPos;
    Vector3 sheepRtgPos;
    float lerpDuration = 1.0f; // 이동에 걸리는 시간
    float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sheepLstPos = sheepL.transform.position;
        sheepLtgPos = sheepLstPos + new Vector3(-3.5f, 0, 0);
        sheepRstPos = sheepR.transform.position;
        sheepRtgPos = sheepRstPos + new Vector3(3.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove && !panel.GetComponent<Panel>().isActive)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / lerpDuration;
            t = Mathf.Clamp01(t);

            sheepL.transform.position = Vector3.Lerp(sheepLstPos, sheepLtgPos, t);
            sheepR.transform.position = Vector3.Lerp(sheepRstPos, sheepRtgPos, t);

            if (t >= 1.0f)
            {
                isMove = false;
                RandomChicken();
            }
        }

        // control choose text
        if (doRandom)
        {
            q.SetActive(true);
            doRandom = false;
        }

        if (isClick)
        {
            Left.interactable = false;
            Right.interactable = false;
            q.SetActive(false);
        }
    }

    void RandomChicken()
    {
        ran = Random.Range(1, 3);

        if(ran == 1)
        {
            chicken.transform.position = sheepL.transform.position;
        }
        else if(ran == 2)
        {
            chicken.transform.position = sheepR.transform.position;
        }

        chicken.SetActive(true);
        doRandom = true;
    }

 

    public void OnClickLBtn()
    {
        isClick = true;

        if(ran == 1)
        {
            //win
        }
        else if(ran == 2)
        {
            //lose
        }
    }

    public void OnClickRBtn()
    {
        isClick = true;

        if(ran == 2)
        {
            // win
        }
        else if(ran == 1)
        {
            // lose
        }
    }
}
