using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardedApp : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] Press girl;

// ������������� �� ������� �������� ������� � OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Reward;

// ������������ �� ������� �������� ������� � OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Reward;

    // ����������� ����� ��������� �������
    void Reward(int id)
    {
        //// ���� ID = 1, �� ����� "+100 �����"
        if (id == 1)
            girl.voidBoostAutoClick();

        //// ���� ID = 2, �� ����� "+������".
        else if (id == 2)
            girl.voidBoostClick();
    }

// ����� ��� ������ ����� �������
    void ExampleOpenRewardAd(int id)
    {
        // �������� ����� �������� ����� �������
        YandexGame.RewVideoShow(id);
    }

    

}
