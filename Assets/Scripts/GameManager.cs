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


    int tmp = -99;
    

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


        if(scene.name == "PixelWorld")
        {
            ObjectActiveOn();
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
            Invoke("screen", 2.0f);
          
            
        }

        if(isLose)
        {
            isLose = false;

            if (score != 0)
            {
                score--;
            }

            Invoke("screen", 2.0f);

        }

        scoreT.text = "Score " + score.ToString();
    }

    public void Win()
    {
        isWin = true;
    }

    public void Lose()
    {
        isLose = true;
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


    public void Hide()
    {
        for(int i = 0; i < 4; i++)
        {
            if (managedObj[i].activeSelf)
            {
                tmp = i;
                managedObj[tmp].SetActive(false);
            }
        }

        score = 0;
    }

    void ObjectActiveOn()
    {
        if(tmp != -99)
        {
            screen();
        }
    }
}



// ㅜㅜ 홈으로 돌아가도 오브젝트 나타남 ㅠ
