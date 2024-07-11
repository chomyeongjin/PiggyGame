using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    bool isWin;

    int score = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if(isWin)
        {
            score++;
            isWin = false;
        }
    }

    public void Win()
    {
        isWin = true;
        Debug.Log("win");
    }


}
