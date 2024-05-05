using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGB : MonoBehaviour
{
    Image image;
    float r;
    float g; 
    float b;
    Color color;

    void Start()
    {
        r = 1f;g = 1f;b = 0f;
        color = new Color(r, g, b);
        image = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        ColorUpdate();
        if (r == 1f)
        {
            if (b == 0f)
            {
                g = g - (1f / 120f);
                g = Mathf.Clamp(g, 0f, 1f);
            }
            if (g == 0f)
            {
                b = b + (1f / 120f);
                b = Mathf.Clamp(b, 0f, 1f);
            }
        }

        if (b == 1f)
        {
            if (g == 0f)
            {
                r = r - (1f / 120f);
                r = Mathf.Clamp(r, 0f, 1f);
            }
            if (r == 0f)
            {
                g = g + (1f / 120f);
                g = Mathf.Clamp(g, 0f, 1f);
            }
        }

        if (g == 1f)
        {
            if (r == 0f)
            {
                b = b - (1f / 120f);
                b = Mathf.Clamp(b, 0f, 1f);
            }
            if (b == 0f)
            {
                r = r + (1f / 120f);
                r = Mathf.Clamp(r, 0f, 1f);
            }
        }
        color = new Color(r, g, b);
    }

    void ColorUpdate()
    {
        image.color = color;
    }
}
