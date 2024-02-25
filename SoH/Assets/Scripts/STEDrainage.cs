using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class STEDrainage : MonoBehaviour
{
    public float ste = 0, maxSTE = 1000;
    public GameObject steBar;
    public GameObject steDisplay;
    public static TextMeshProUGUI steDisplayText;
    public Image steBarImage;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;
    public float collisionTime;
    public float steCooldown;
    public float steCooldownHolder;
    public Slider steSlider;
    public void Start()
    {
        steBar = GameObject.Find("STE Bar");
        steDisplay = GameObject.Find("STE Display");
        ste = 600;
        steSlider = steBar.GetComponent<Slider>();
        playerCollider = this.GetComponent<Collider2D>();
        steDisplayText = steDisplay.GetComponent<TextMeshProUGUI>();
        UpdateSTEBar(ste / maxSTE);
        steDisplayText.text = ste + "/" + maxSTE;

    }
    public void loseSTE(float dmg)
    {
        ste -= dmg;
        Mathf.Round(ste);
        UpdateSTEBar(ste / maxSTE);
        steCooldownHolder = Time.time;

    }
    void Update()
    {
        
        steCooldown = Time.time;
        if (steCooldown - steCooldownHolder >= 2)
        {
            loseSTE(1f);
        }
        if (ste <= 0)
        {
            ste = maxSTE;
            this.transform.position = new Vector3(0f, 0f, 0f);
            loseSTE(ste / maxSTE);
        }
    }


    
    public void UpdateSTEBar(float newSTE)
    {
        steSlider.value = newSTE;
        steDisplayText.text = ste + "/" + Mathf.Round(maxSTE);


    }
}