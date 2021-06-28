using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int hp;
    public bool isDead;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "¢¾ x " + hp;
        if (hp <= 0) isDead = true;
    }
}
