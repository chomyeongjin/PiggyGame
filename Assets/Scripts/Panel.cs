using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Panel : MonoBehaviour
{
    float timer;
    float waitingTime;

    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        waitingTime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }
}
