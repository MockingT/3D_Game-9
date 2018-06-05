using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour {
    private Button mybutton;
    public Text text;
    private int frame = 25;
    private bool is_collapsed = false;
    private string _text;

    // Use this for initialization
    void Start () {
        Button button = this.gameObject.GetComponent<Button>();
        // add the listener to the button
        button.onClick.AddListener(Click_button);
	}

    IEnumerator rotateIn()
    {
        float rx = 0;
        float xy = 120;
        for (int i = 0; i < frame; i++)
        {
            rx -= 90f / frame;
            xy -= 120f / frame;
            text.transform.rotation = Quaternion.Euler(rx, 0, 0);
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
            if (i == frame - 1)
            {
                //save the text and delete the original text so it can go up
                _text = text.text;
                text.text = "";
                is_collapsed = true;
            }
            yield return null;
        }
    }

    IEnumerator rotateOut()
    {
        float rx = -90;
        float xy = 0;
        for (int i = 0; i < frame; i++)
        {
            rx += 90f / frame;
            xy += 120f / frame;
            text.transform.rotation = Quaternion.Euler(rx, 0, 0);
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
            if (i == 0)
            {
                //return to the orginal state
                text.text = _text;
                is_collapsed = false;
            }
            yield return null;
        }
    }

    void Click_button()
    {
        //judge the state 
        if (is_collapsed == false)
        {
            StartCoroutine(rotateIn());
        }
        else
        {
            StartCoroutine(rotateOut());
        }

    }
}
