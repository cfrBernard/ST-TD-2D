using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour
{
    private Health health;
    
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(float amount, Vector2 sourcePosition)
    {
        health.TakeDamage(amount);

        // Feedback (blink, animation...)
        StartCoroutine(FlashRed());

        // knockback ???
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // if (rb != null) rb.AddForce((transform.position - (Vector3)sourcePosition).normalized * 2f, ForceMode2D.Impulse);
    }

    private IEnumerator FlashRed()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
