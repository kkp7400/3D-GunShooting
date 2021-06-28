using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Textblink : MonoBehaviour
{
    Text flashingText;
    // Use this for initialization
    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }
    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "     touch the screen";
            yield return new WaitForSeconds(.5f);
        }
    }
}
