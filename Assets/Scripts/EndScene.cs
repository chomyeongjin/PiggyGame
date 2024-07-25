using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class EndScene : MonoBehaviour
{
    float timer;
    float waitingTime;

    public GameObject pixel;
    public GameObject cartoon;

    public Canvas c;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        waitingTime = 1.95f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            pixel.SetActive(false);
        }

        if(timer > waitingTime + 1.5f)
        {
            cartoon.SetActive(true);
        }

        if (timer > waitingTime + 5f)
        {

            c.gameObject.SetActive(true);
        }
    }

    public void OnclickHomeBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnClickExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit;
#endif
    }
}



// 5초 후에 캔버스 나오게
// 파티클 하면서 픽셀돼지 -> 카툰돼지로
// Exit
