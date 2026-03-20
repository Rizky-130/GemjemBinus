using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageEffect : MonoBehaviour
{
    public Image damageImage;
    public float flashDuration = 0.15f;
    public float maxAlpha = 0.7f;

    [Header("Glitch Settings")]
    public int flickerCount = 6;
    public float flickerSpeed = 0.02f;
    [Header("Low Health Glitch")]
    public bool isLowHealth = false;
    public float minInterval = 2f;
    public float maxInterval = 5f;

    Coroutine lowHealthRoutine;
    [Header("Camera Shake")]
    public Transform cameraTransform;
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.15f;

    Coroutine currentEffect;
    Vector3 originalCamPos;

    void Start()
    {
        if (cameraTransform != null)
            originalCamPos = cameraTransform.localPosition;
    }

    public void PlayEffect()
    {
        if (currentEffect != null)
            StopCoroutine(currentEffect);

        currentEffect = StartCoroutine(Flash());
        StartCoroutine(ShakeCamera());
    }
    public void StartLowHealthEffect()
    {
        if (lowHealthRoutine == null)
            lowHealthRoutine = StartCoroutine(LowHealthGlitch());
    }

    public void StopLowHealthEffect()
    {
        if (lowHealthRoutine != null)
        {
            StopCoroutine(lowHealthRoutine);
            lowHealthRoutine = null;
        }
    }
    IEnumerator LowHealthGlitch()
{
    while (true)
    {
        float waitTime = Random.Range(minInterval, maxInterval);
        yield return new WaitForSeconds(waitTime);

        // glitch kecil (lebih ringan dari damage)
        for (int i = 0; i < 2; i++)
        {
            damageImage.color = new Color(1, 0, 0, 0.3f);
            yield return new WaitForSeconds(0.03f);

            damageImage.color = new Color(1, 0, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
    }
}

    IEnumerator Flash()
    {
        // ⚡ glitch flicker cepat
        for (int i = 0; i < flickerCount; i++)
        {
            damageImage.color = new Color(1, 0, 0, maxAlpha);
            yield return new WaitForSeconds(flickerSpeed);

            damageImage.color = new Color(1, 0, 0, 0);
            yield return new WaitForSeconds(flickerSpeed);
        }

        // 🔴 fade out biar smooth
        float t = 0;
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(maxAlpha, 0, t / flashDuration);
            damageImage.color = new Color(1, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;

            Vector3 offset = Random.insideUnitSphere * shakeIntensity;
            offset.z = 0;

            cameraTransform.localPosition = originalCamPos + offset;

            yield return null;
        }

        cameraTransform.localPosition = originalCamPos;
    }
}