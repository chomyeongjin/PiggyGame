using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;

    public AudioSource bgm;

    public AudioClip bgmClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(bgmClip != null)
        {
            PlayBGM(bgmClip);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.loop = true;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
