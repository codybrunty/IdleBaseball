using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberTest : MonoBehaviour{

    public TextMeshProUGUI numberText;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI rateText;
    public float number=0f;
    public float cost=50f;
    public float rate=5f;
    private float baseCost = 50f;
    private float baseRate = 5f;
    private int level = 0;

    private float delayTime = .1f;
    private float timer = 0f;

    private void Start() {
        UpdateText();
    }

    private void UpdateText() {
        headerText.text = "Contact Level " + level.ToString();
        numberText.text = number.ToString("F2");
        rateText.text = rate.ToString();
        costText.text = cost.ToString();
    }

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= delayTime) {
            timer = 0f;
            number += (rate/10f);
            numberText.text = number.ToString("F2");
        }
    }

    public void vButtonOnClick() {
        if (number < cost) {
            return;
        }

        number -= cost;
        rate += baseRate;
        level++;
        cost = baseCost*Mathf.Pow(1.07f, level);

        UpdateText();
    }

}
