using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float lifetime = 1.5f;      // Время жизни
    [SerializeField] float fadeDuration = 0.5f;   // Время затухания

    private TextMeshProUGUI text;
    private Color color;
    private float elapsed = 0f;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        color = text.color;
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= lifetime)
        {
            Destroy(gameObject);
            return;
        }

        // Двигаемся вверх
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        // Затухание в конце
        float fadeStart = lifetime - fadeDuration;
        if (elapsed > fadeStart)
        {
            float alpha = Mathf.Lerp(1, 0, (elapsed - fadeStart) / fadeDuration);
            text.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}