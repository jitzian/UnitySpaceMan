using System;
using UnityEngine;

public enum CollectableItem {
    HEALTH_POTION,
    MANA_POTION,
    MONEY
}

public class Collectable : MonoBehaviour {
    public CollectableItem type = CollectableItem.MONEY;

    private SpriteRenderer sprite;
    private CircleCollider2D itemCollider;

    private bool isCollected;
    public int value = 1;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            collect();
        }
    }

    private void show() {
        sprite.enabled = true;
        itemCollider.enabled = true;
        isCollected = false;
    }

    private void hide() {
        sprite.enabled = false;
        itemCollider.enabled = false;
    }

    private void collect() {
        hide();
        isCollected = true;

        switch (type) {
            case CollectableItem.HEALTH_POTION:
                GameObject.Find("Player").GetComponent<PlayerController>().collectHealth(value);
                break;
            case CollectableItem.MANA_POTION:
                GameObject.Find("Player").GetComponent<PlayerController>().collectMana(value);
                break;
            case CollectableItem.MONEY:
                GameManager.sharedInstance.collectObject(this);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}