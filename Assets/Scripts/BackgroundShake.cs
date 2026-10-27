using UnityEngine;

public class BackgroundShake : MonoBehaviour
{
    public float speed = 0.5f;
    public float magnitude = 15f;

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private float offsetX;
    private float offsetY;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            originalPosition = rectTransform.anchoredPosition;
            offsetX = Random.Range(0f, 1000f);
            offsetY = Random.Range(0f, 1000f);
        }
    }

    private void Update()
    {
        if (rectTransform == null) return;

        float time = Time.time * speed;

        float x = (Mathf.PerlinNoise(time + offsetX, 0f) * 2f - 1f) * magnitude;
        float y = (Mathf.PerlinNoise(0f, time + offsetY) * 2f - 1f) * magnitude;

        rectTransform.anchoredPosition = originalPosition + new Vector2(x, y);
    }
}