using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    private Text myTextToFlash;
    private readonly int keywordl;
    [SerializeField]
    private float flashSpeed;
    private float r, g, b, a;
    private bool goingUp;

    // Use this for initialization
    void Start()
    {
        myTextToFlash = GetComponent<Text>();
        r = myTextToFlash.color.r;
        g = myTextToFlash.color.g;
        b = myTextToFlash.color.b;
        a = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (a <= 0)
        {
            goingUp = true;
        }
        else if (a >= 1)
        {
            goingUp = false;
        }
        if (goingUp == true)
        {
            a += flashSpeed * Time.deltaTime;
        }
        else
        {
            a -= flashSpeed * Time.deltaTime;
        }

        myTextToFlash.color = new Color(r, g, b, a);
    }
}
