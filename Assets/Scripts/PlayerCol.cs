using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCol : MonoBehaviour
{

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
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name == "RedMoon")
        {
            SceneManager.LoadScene("RockScissorPaper");
            collision.gameObject.SetActive(false);
        }
        else if(collision.gameObject.name == "PinkMoon")
        {
            SceneManager.LoadScene("Trickery");
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name == "Sun")
        {
            
            SceneManager.LoadScene("EndScene");
            
        }
    }
}
