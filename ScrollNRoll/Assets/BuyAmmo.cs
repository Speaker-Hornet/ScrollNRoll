using UnityEngine;
using UnityEngine.UI;

public class BuyAmmo : MonoBehaviour
{
    public Image buttonSoldImg;
    public void AddAmmo()
    {
        GameManager.Instance.ammo += GameManager.Instance.ammoToAdd;
        Color newAlpha = buttonSoldImg.color;
        newAlpha.a = 1f;
        buttonSoldImg.color = newAlpha;
        GameManager.Instance.dopamineCurrent += 10f;
        GameManager.Instance.ammo += 10;
        this.GetComponent<Button>().interactable = false;
    }
}
