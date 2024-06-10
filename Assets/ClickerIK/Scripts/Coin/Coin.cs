using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText; //UI текст
    private float coinCount = 0f;
    public float coinIncrement = 1f;
    private bool isAnimating = false;

    void Start()
    {
        UpdateCoinText(coinCount);

        // Получаем компонент Image
        Image coinImage = GetComponent<Image>();
        if (coinImage != null)
        {
            // Добавляем слушатель события нажатия на монету
            coinImage.GetComponent<Button>().onClick.AddListener(OnCoinClicked);
        }
    }

    public void OnCoinClicked()
    {
        // Эффект при нажатии - пульсация
        if (isAnimating) return; // Если анимация уже запущена, ничего не делаем

        isAnimating = true; // Устанавливаем флаг в true
        
        // Эффект при нажатии - пульсация
        transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f, 10, 1).OnComplete(() =>
        {
            isAnimating = false; // Сбрасываем флаг после завершения анимации
        });


        // Увеличиваем счетчик монет
        coinCount += coinIncrement;
        UpdateCoinText(coinCount);
    }

    void UpdateCoinText(float value)
    {
        coinText.text = value.ToString();
    }
}
