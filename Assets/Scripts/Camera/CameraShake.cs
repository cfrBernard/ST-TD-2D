using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 originalPosition;
    private float shakeMagnitude = 0.1f;
    private float shakeDuration = 0.2f;

    private void Start()
    {
        originalPosition = mainCamera.transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = Random.Range(-shakeMagnitude, shakeMagnitude);
            mainCamera.transform.position = originalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = originalPosition;
    }
}

