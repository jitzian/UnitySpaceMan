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

    private bool isCollected = false;
    public int value = 1;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
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
        isCollected = true;
        hide();

        switch (type) {
            case CollectableItem.HEALTH_POTION:
                break;
            case CollectableItem.MANA_POTION:
                break;
            case CollectableItem.MONEY:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}