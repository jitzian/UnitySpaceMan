using System;
using UnityEngine;
using UnityEngine.UI;

public enum BarTYpe {
    HEALTH_BAR,
    MANA_BAR
}

public class PlayerBar : MonoBehaviour {
    private Slider slider;
    public BarTYpe barTYpe;

    // Start is called before the first frame update
    void Start() {
        slider = GetComponent<Slider>();
        slider.value = barTYpe switch {
            BarTYpe.HEALTH_BAR => PlayerController.MIN_HEALTH,
            BarTYpe.MANA_BAR => PlayerController.MIN_MANA,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void Update() {
        switch (barTYpe) {
            case BarTYpe.HEALTH_BAR:
                slider.value = GameObject.Find("Player").GetComponent<PlayerController>().healthPoints;
                break;
            case BarTYpe.MANA_BAR:
                slider.value = GameObject.Find("Player").GetComponent<PlayerController>().manaPoints;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}