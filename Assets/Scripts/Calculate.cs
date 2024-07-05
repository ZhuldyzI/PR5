using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Calculate : MonoBehaviour
{
    float T1;
    float T2;
    float Q;

    [SerializeField] private Slider T1string;
    [SerializeField] private Slider T2string;

    [SerializeField] private Slider Qstring;

    [SerializeField] private TMP_Text result;

    [SerializeField] private GameObject accum;

    private float resultSize;

    public void ManageCalculation()
    {
        ProcessInput();
        ShowResult(GetResult(Q, T1, T2));
        StartChangeSize(resultSize, 1.5f);
        //AccumChangeSize(resultSize);

    }

    private void ProcessInput()
    {
        T1 = T1string.value;
        T2 = T2string.value;
        Q = Qstring.value;
    }

    public float GetResult(float Q, float T1, float T2)
    {
        resultSize = Round((Q * Mathf.Pow(10, 9)) / (4200 * 1000 * (T1 - T2)),1);
        return resultSize;
    }
    private void ShowResult(float number)
    {
        result.text = "V = "+ number.ToString();
    }

    private float Round(float x, int decimalPlaces)
    {
        return Mathf.Round(x * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
    }

    public void AccumChangeSize(float size)
    {
        var newScale = new Vector3(
            transform.localScale.x *(size/10),
            transform.localScale.y * (size / 10),
            transform.localScale.z);
        Debug.Log("newScale "+newScale);
        Debug.Log("size " + size);
        accum.transform.localScale = newScale;


        
    }

    public void StartChangeSize(float targetSize, float duration)
    {
        StartCoroutine(ChangeSizeOverTime(targetSize, duration));

    }

    IEnumerator ChangeSizeOverTime(float targetSize, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialScale = accum.transform.localScale;
        Vector3 targetScale = new Vector3(targetSize / 10f, targetSize / 10f, initialScale.z);

        while (elapsedTime < duration)
        {
            accum.transform.localScale = new Vector3(
                Mathf.Lerp(initialScale.x, targetScale.x, elapsedTime / duration),
                Mathf.Lerp(initialScale.y, targetScale.y, elapsedTime / duration),
                initialScale.z
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        accum.transform.localScale = targetScale; // Установка точного размера после завершения корутины
    }
}

