using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject[] managedObj = new GameObject[4];
    public TextMeshProUGUI scoreT;

    

    bool isWin = false;
    bool isLose = false;

    int score = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (var obj in managedObj)
            {
                DontDestroyOnLoad(obj);
            }
        }
        else
        {
            Destroy(gameObject);

            foreach (var obj in managedObj)
            {
                Destroy(obj);
            }
        }
        
    }

    private void OnEnable()
    {
        // 씬이 로드될 때마다 scoreT를 다시 찾습니다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        try
        {
            // scoreT 오브젝트를 다시 찾습니다.
            if (scoreT == null)
            {
                GameObject scoreObject = GameObject.Find("ScoreText");
                if (scoreObject != null)
                {
                    scoreT = scoreObject.GetComponent<TextMeshProUGUI>();
                    Debug.Log("scoreT 오브젝트를 찾았습니다.");
                }
                else
                {
                    Debug.Log("현재 씬에는 'ScoreText' 오브젝트가 없습니다.");
                }
            }
            else
            {
                Debug.Log("scoreT가 이미 설정되어 있습니다.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("scoreT를 찾는 중 오류가 발생했습니다 ." + ex.Message);
        }
    }

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                managedObj[i].SetActive(true);
            } else
            {
                managedObj[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        // score
        if(isWin)
        {
            isWin = false;

            score++;
            //Debug.Log(score);

            Invoke("screen", 3.0f);
          
            
        }

        if(isLose)
        {
            isLose = false;

            if (score != 0)
            {
                score--;
                //Debug.Log(score);
            }

            Invoke("screen", 2.0f);

        }

        scoreT.text = "Score " + score.ToString();
    }

    public void Win()
    {
        isWin = true;
        //Debug.Log("win");
    }

    public void Lose()
    {
        isLose = true;
        //Debug.Log("lose");
    }

    void screen()
    {
        
        if(score == 0)
        {
            managedObj[0].SetActive(true);
        }
        else if (score == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 1)
                {
                    managedObj[i].SetActive(true);
                }
                else
                {
                    managedObj[i].SetActive(false);
                }
            }
        }
        else if (score == 2)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 2)
                {
                    managedObj[i].SetActive(true);
                }
                else
                {
                    managedObj[i].SetActive(false);
                }
            }
        }
        else if (score == 3)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    managedObj[i].SetActive(true);
                }
                else
                {
                    managedObj[i].SetActive(false);
                }
            }
        }
    }
}
