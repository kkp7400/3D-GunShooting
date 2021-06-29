using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class HighAim : MonoBehaviour
{
    public Image image;
    public GameObject shot;
    Vector3[] a = new Vector3[10];
    public EnemySpawner enemySpawner;
    Vector3 offset = new Vector3(0, 1f, 0);
    public GameObject lastAim;
    // Start is called before the first frame update
    public GameObject[] highAim = new GameObject[10];
    public Transform[] enemyPos = new Transform[10];
    public Camera cam;
    public bool allGreen;
    public PostProcessVolume volume;
    private Vignette vignette;
    private ChromaticAberration chromatic;
    public bool[] aimStart = new bool[10];
    private bool startCo;
    public GameObject audioMain;
    public GameObject audioShot;
    public GameObject audioHigh;
    public GameObject sun;
    private bool sunFall;
    void Start()
    {
        sunFall = false; ;
           startCo = true;
        for (int i = 0; i < highAim.Length; i++)
        {        
            highAim[i].transform.position = cam.WorldToScreenPoint(enemyPos[i].transform.position + offset);
            a[i] = highAim[i].transform.localScale;
            aimStart[i] = false;
        }
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out chromatic);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < highAim.Length; i++)
        {
            highAim[i].transform.position = cam.WorldToScreenPoint(enemyPos[i].transform.position+ offset);
        }
        if (GameManager.instance.nowStage == 4)
        {            
            if (startCo == true)
            {
                audioMain.GetComponent<AudioSource>().Stop();
                audioHigh.GetComponent<AudioSource>().Play();                
                StartCoroutine(Aimming());
                startCo = false;
            }
            for (int i = 0; i < highAim.Length; i++)
            {

                if (aimStart[i] == true)
                {
                    if (a[i].x >= 0.3f)
                    {
                        a[i] -= new Vector3(0.1f, 0.1f , 0.1f);
                    }
                    highAim[i].transform.localScale = a[i];
                    highAim[i].transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
                    //highAim[i].GetComponent<Image>().rectTransform.localScale = a[i];
                    if(vignette.intensity.value<=0.3f)
                        vignette.intensity.value += 0.15f * Time.deltaTime;
                    if (chromatic.intensity.value <=1f)
                        chromatic.intensity.value += 0.5f * Time.deltaTime;
                }
            }
        }
        if(sunFall==true)
        {
            sun.transform.position -= new Vector3(0f, 10f * Time.deltaTime, 0f);
        }
        
    }

    public IEnumerator Aimming()
    {
        sunFall = true;
        for (int i = 0; i < highAim.Length; i++)
        {
            highAim[i].transform.position = cam.WorldToScreenPoint(enemyPos[i].transform.position+offset);
        }
        lastAim.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        highAim[0].SetActive(true);
        aimStart[0] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[1].SetActive(true);
        aimStart[1] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[2].SetActive(true);
        aimStart[2] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[3].SetActive(true);
        aimStart[3] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[4].SetActive(true);
        aimStart[4] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[5].SetActive(true);
        aimStart[5] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[6].SetActive(true);
        aimStart[6] = true;
        yield return new WaitForSeconds(0.5f);
        highAim[7].SetActive(true);
        aimStart[7] = true;

        yield return new WaitForSeconds(0.5f);
        highAim[8].SetActive(true);
        aimStart[8] = true;

        yield return new WaitForSeconds(0.5f);
        highAim[9].SetActive(true);
        aimStart[9] = true;
        yield return new WaitForSeconds(0.5f);
        //sunFall = false;
        StartCoroutine(Shot());
    }
    public IEnumerator Shot()
    {
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[0].SetActive(false);
        aimStart[0] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[1].SetActive(false);
        aimStart[1] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[2].SetActive(false);
        aimStart[2] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[3].SetActive(false);
        aimStart[3] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[4].SetActive(false);
        aimStart[4] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[5].SetActive(false);
        aimStart[5] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[6].SetActive(false);
        aimStart[6] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[7].SetActive(false);
        aimStart[7] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[8].SetActive(false);
        aimStart[8] = false;
        yield return new WaitForSeconds(0.1f);
        audioShot.GetComponent<AudioSource>().Play();
        shot.GetComponent<ParticleSystem>().Play();
        highAim[9].SetActive(false);
        aimStart[9] = false;
        yield return new WaitForSeconds(1.5f);
        enemySpawner.HighNoon();
        yield return new WaitForSeconds(2.0f);
        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        SceneManager.LoadScene("Clear");
    }
}
