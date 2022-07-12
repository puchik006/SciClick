using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuVisualEffects
{
    public IEnumerator FadeOut(Text text, float speed)
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(speed);
        }
    }

    public IEnumerator FadeIn(Text text, float speed)
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = text.color;
            c.a = f;
            text.color = c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void SetZeroAlfaColor(Text text)
    {
        Color c = text.color;
        c.a = 0f;
        text.color = c;
    }
}
