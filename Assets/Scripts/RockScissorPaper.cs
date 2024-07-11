using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RockScissorPaper : MonoBehaviour
{
    public GameObject[] rsp = new GameObject[3];
    public GameObject[] winlose = new GameObject[2];

    public Button[] rsp_me = new Button[3];
   

    public GameObject hide;

    int ran;
    int tmp = 2;

    float timer = 0;
    float wait = 1.5f;

    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        randomRSP();
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp != 2)
        {
            rsp_me[0].interactable = false;
            rsp_me[1].interactable = false;
            rsp_me[2].interactable = false;
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

    void randomRSP()
    {
        ran = Random.Range(0, 3);
        rsp[ran].SetActive(true);
    }

    public void OnClickRockBtn()
    {
        if (rsp[ran].name == "Scissor")
        {
            hide.SetActive(false);
            tmp = 0;
        } else
        {
            hide.SetActive(false);
            tmp = 1;
        }

        Invoke("isWin", 3.0f);
    }

    public void OnClickScissorBtn()
    {
        if (rsp[ran].name == "Paper")
        {
            hide.SetActive(false);
            tmp = 0;
        } else
        {
            hide.SetActive(false);
            tmp = 1;
        }

        Invoke("isWin", 3.0f);
    }

    public void OnClickPaperBtn()
    {
        if (rsp[ran].name == "Rock")
        {
            hide.SetActive(false);
            tmp = 0;
        }
        else
        {
            hide.SetActive(false);
            tmp = 1;
        }

        Invoke("isWin", 3.0f);
    }

    void isWin()
    {
        winlose[tmp].SetActive(true);

        startTimer = true;
    }
}
