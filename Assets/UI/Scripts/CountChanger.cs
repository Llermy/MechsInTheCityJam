using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountChanger : MonoBehaviour
{
    public float animationScale;
    private Vector3 originalScale;

    private int currentCount = 0;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void SetCount(int newCount)
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText(newCount.ToString());

        gameObject.LeanCancel();
        transform.localScale = originalScale * animationScale;
        transform.LeanScale(originalScale, 0.2f);

        currentCount = newCount;
    }

    public void IncrementCount()
    {
        currentCount++;
        SetCount(currentCount);
    }

    public int GetCount()
    {
        return currentCount;
    }
}
