using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardedApp : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] Press girl;

// Подписываемся на событие открытия рекламы в OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Reward;

// Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Reward;

    // Подписанный метод получения награды
    void Reward(int id)
    {
        //// Если ID = 1, то выдаём "+100 монет"
        if (id == 1)
            girl.voidBoostAutoClick();

        //// Если ID = 2, то выдаём "+оружие".
        else if (id == 2)
            girl.voidBoostClick();
    }

// Метод для вызова видео рекламы
    void ExampleOpenRewardAd(int id)
    {
        // Вызываем метод открытия видео рекламы
        YandexGame.RewVideoShow(id);
    }

    

}
