using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveTrain : MonoBehaviour
{
    public GameObject fx;
    float a = 0;
    public float fadeCount = 255;
    public Image image;
    bool fadeIn;
    bool fadeOut;
    bool textScroll;
    bool fadeText;
    public GameObject q;
    public GameObject w;
    public GameObject e;
    public GameObject r;
    public GameObject t;
    // Start is called before the first frame update
    void Start()
    {
        fadeCount = 255;
        fadeIn = true;
        fadeOut = true;
        textScroll = false;
        fadeText = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            StartCoroutine(FadeInCoroutine());
            fadeIn = false;
        }
        a += Time.deltaTime;

        if (a > 3f)
            fx.SetActive(true);

        if (a > 7f)
        {
            this.gameObject.transform.position += new Vector3(10 * Time.deltaTime, 0f);
            if (fadeOut)
            {
                StartCoroutine(FadeOutCoroutine());
                q.SetActive(true);
                w.SetActive(true);
                e.SetActive(true);
                fadeOut = false;
            }
        }
        if (textScroll)
        {
            if (r.transform.position.y <=  500f*1.7f)
            {
                r.transform.position += new Vector3(0f, 100 * Time.deltaTime);
            }
            else if(r.transform.position.y > 500f * 1.7f)
            {
                if (fadeText)
                {
                    StartCoroutine(FadeInText());
                    fadeText = false;
                }
            }

        }
                


    }
    public IEnumerator FadeInCoroutine()
    {
        float fadeCount = 1;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }        
    }

    public IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        r.SetActive(true);

        yield return new WaitForSeconds(2f);
        textScroll = true;
    }

    public IEnumerator FadeInText()
    {
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            t.GetComponent<Text>().color = new Color(255, 255, 255, fadeCount);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Intro");
    }
}
