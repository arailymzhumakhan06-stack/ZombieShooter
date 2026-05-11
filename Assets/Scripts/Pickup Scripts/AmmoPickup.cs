using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int pickupAmmoAmount = 10;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GameObject floatingTextPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Ammo>().AddAmmo(ammoType, pickupAmmoAmount);
            // Звук сбора лута
            AudioManager.Instance?.PlayPickup();
            ShowFloatingText();
            Destroy(gameObject);
        }
    }

    private void ShowFloatingText()
    {
        if (floatingTextPrefab == null)
        {
            Debug.LogWarning("FloatingTextPrefab not assigned in AmmoPickup!");
            return;
        }

        GameObject textObj = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);

        Canvas statsCanvas = FindFirstObjectByType<Canvas>();
        if (statsCanvas != null)
        {
            textObj.transform.SetParent(statsCanvas.transform, false);
        }

        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = $"+{pickupAmmoAmount} {ammoType}";

            // Разный цвет для разных типов боеприпасов
            switch (ammoType)
            {
                case AmmoType.Bullets:
                    textComponent.color = Color.yellow;
                    break;
                case AmmoType.Shells:
                    textComponent.color = new Color(1f, 0.6f, 0f); // Оранжевый
                    break;
                case AmmoType.Rockets:
                    textComponent.color = Color.red;
                    break;
                default:
                    textComponent.color = Color.white;
                    break;
            }
        }

        Destroy(textObj, 3f);
    }
}