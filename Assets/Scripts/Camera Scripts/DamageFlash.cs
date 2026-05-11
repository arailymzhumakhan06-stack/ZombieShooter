using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] Image flashImage;
    [SerializeField] float flashDuration = 0.1f; // ”меньшили до 0.1
    [SerializeField] Color flashColor = new Color(1f, 0f, 0f, 0.7f); // ярче и насыщеннее

    private Color originalColor;

    void Start()
    {
        if (flashImage == null)
            flashImage = GetComponent<Image>();

        originalColor = flashImage.color;
        flashImage.color = originalColor;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        // ћгновенно включаем красный
        flashImage.color = flashColor;

        // ∆дЄм очень мало
        yield return new WaitForSeconds(flashDuration);

        // ћгновенно возвращаем прозрачный
        flashImage.color = originalColor;
    }
}