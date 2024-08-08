using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trickery : MonoBehaviour
{
    public GameObject sheepL;
    public GameObject sheepR;
    public GameObject chicken;
    public GameObject panel;
    public GameObject winT;
    public GameObject loseT;

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
    float lerpDuration = 1.0f;
    float elapsedTime = 0f;

    float timer = 0;
    float wait = 1.0f;
    bool startTimer = false;


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
        //pig move
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

        // Scene trans
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > wait)
            {
                SceneManager.LoadScene("PixelWorld");
            }
        }
    }

    void RandomChicken()
    {
        ran = Random.Range(1, 11);

        if(ran <= 5)
        {
            chicken.transform.position = sheepL.transform.position;
        }
        else if(ran > 5)
        {
            chicken.transform.position = sheepR.transform.position;
        }

        chicken.SetActive(true);
        doRandom = true;
    }

 

    public void OnClickLBtn()
    {
        isClick = true;
        sheepL.SetActive(false);
        sheepR.SetActive(false);

        if(ran <= 5)
        {
            Invoke("Win", 2.0f);
        }
        else if(ran > 5)
        {
            Invoke("Lose", 2.0f);
        }
    }

    public void OnClickRBtn()
    {
        isClick = true;
        sheepL.SetActive(false);
        sheepR.SetActive(false);

        if (ran > 5)
        {
            Invoke("Win", 1.5f);

        }
        else if(ran <= 5)
        {
            Invoke("Lose", 1.5f);
        }
    }

    void Win()
    {
        winT.SetActive(true);
        startTimer = true;

        GameManager.instance.Win();
    }

    void Lose()
    {
        loseT.SetActive(true);
        startTimer = true;

        GameManager.instance.Lose();
    }
}
