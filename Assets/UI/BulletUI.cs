using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : MonoBehaviour
{
    int bulletCount;
    bool bulletZero;

    Image[] uiImages;
    Image ammoUI;
    public GameObject reload;
    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        bulletCount = 6;
        bulletZero = false;

        uiImages = Canvas.FindObjectsOfType<Image>();
        foreach (Image img in uiImages)
        {
            if (img.name == "AmmoUI")
            {
                ammoUI = img;
                break;
            }
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        anim.SetInteger("AmmoCount", bulletCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletCount == 0) reload.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            bulletCount--;
            anim.SetInteger("AmmoCount", bulletCount);
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("Reload");

            if (bulletCount <= 0)
            {
                bulletZero = true;
                anim.SetBool("AmmoZero", true);
            }
            reload.SetActive(false);
            bulletCount = 6;
            anim.SetInteger("AmmoCount", bulletCount);
        }
        ammoUI.sprite = spriteRenderer.sprite;
    }
    public void Reload()
    {
        
            anim.SetTrigger("Reload");

            if (bulletCount <= 0)
            {
                bulletZero = true;
                anim.SetBool("AmmoZero", true);
            }
            reload.SetActive(false);
            bulletCount = 6;
            anim.SetInteger("AmmoCount", bulletCount);
        ammoUI.sprite = spriteRenderer.sprite;
    }
}
