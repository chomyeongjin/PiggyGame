using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCol : MonoBehaviour
{
    public GameObject pinkMoon;
    public GameObject redMoon;
    public GameObject WhiteMoon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GreenMoon")
        {
            SceneManager.LoadScene("ChamChamCham");
            Destroy(collision.gameObject);
            redMoon.SetActive(true);
        }
        else if (collision.gameObject.name == "RedMoon")
        {
            SceneManager.LoadScene("Trickery");
            Destroy(collision.gameObject);
            pinkMoon.SetActive(true);
        }
        else if (collision.gameObject.name == "Sun")
        {
            //SceneManager.LoadScene("EndScene");
            Debug.Log("d");
        }
    }
}

// 달위치 랜덤?
