using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChamChamCham : MonoBehaviour
{
    public GameObject cowHead;
    public Button left;
    public Button right;

    public GameObject win;
    public GameObject lose;

    int click = 0;
    int cowNum;

    float timer = 0;
    float wait = 1.5f;

    bool startTimer = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(click != 0)
        {
            left.interactable = false;
            right.interactable = false;
        }

        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > wait)
            {
                SceneManager.LoadScene("PixelWorld");
            }
        }
    }

    public void OnClickLeftBtn()
    {
        click = 1;

        Invoke("CowHead", 0.5f);
        Invoke("isWin", 1.5f);
    }

    public void OnClickRightBtn()
    {
        click = 2;

        Invoke("CowHead", 0.5f);
        Invoke("isWin", 1.5f);
    }

    void CowHead()
    {
        cowNum = Random.Range(1, 3);
        if(cowNum == 1)
        {
            cowHead.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void isWin()
    {
        if (click == cowNum)
        {
            win.SetActive(true);
            GameManager.instance.Win();
        }
        else
        {
            lose.SetActive(true);
        }

        startTimer = true;
    }
}


// 버튼 누르기
// 값 받기
// 소 얼굴 랜덤
// 비교
// 결과