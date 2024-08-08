using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, 1));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            spriteRenderer.color = color;
            yield return null;
        }
        Color finalColor = spriteRenderer.color;
        finalColor.a = endAlpha;
        spriteRenderer.color = finalColor;
    }
}
