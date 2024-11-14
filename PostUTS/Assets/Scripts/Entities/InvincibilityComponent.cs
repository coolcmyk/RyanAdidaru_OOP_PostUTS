using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private IEnumerator BlinkEffect()
    {
        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval / 2f);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval / 2f);
        }
        spriteRenderer.material = originalMaterial;
        isInvincible = false;
    }

    public void StartInvincibility()
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(BlinkEffect());
        }
    }
}