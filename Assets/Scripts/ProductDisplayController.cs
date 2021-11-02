using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ProductDisplayController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        EventManager.bondBreakSuccess += DisplaySprite;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void DisplaySprite()
    {
        spriteRenderer.enabled = true;
    }

    // Avoid memory leaks
    private void OnDestroy()
    {
        EventManager.bondBreakSuccess -= DisplaySprite;
    }
}
