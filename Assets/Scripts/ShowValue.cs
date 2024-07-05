using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowValue : MonoBehaviour
{
    [SerializeField] GameObject icon;

    public void Showvalue(int decimals)
    {
        icon.GetComponent<TextMeshProUGUI>().text = Round(gameObject.GetComponent<Slider>().value,decimals).ToString();
    }
    private float Round(float x, int decimalPlaces)
    {
        return Mathf.Round(x * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
    }


}
