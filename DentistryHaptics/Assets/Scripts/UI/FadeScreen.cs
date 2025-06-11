using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private bool fadeOnStart = true;
    public float fadeDuration = 2;
    [SerializeField] private Color fadeColor;
    private new Renderer renderer;

    private float alphaIn = 1;
    private float alphaOut = 0;

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(alphaIn, alphaOut);
    }

    public void FadeOut()
    {
        Fade(alphaOut, alphaIn);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            renderer.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        renderer.material.SetColor("_BaseColor", newColor2);
    }
}
