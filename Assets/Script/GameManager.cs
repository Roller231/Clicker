using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Press girl;

    public Int64 money;
    public Text moneyText;
    public Text ShopMoneyText;


    public int upgradeClickCost = 10;
    public int upgradeAutoClickCost = 30;

    public GirlBuyScript[] girlBuyScripts;
    public FoneBuyScript[] foneBuyScripts;




    [SerializeField] private Text costClickText;
    [SerializeField] private Text costAutoClickText;

    private void Start()
    {
        StartCoroutine(AutoClick());

    }
    private void Awake()
    {
        if (YandexGame.SDKEnabled) LoadSaveCloud();
    }

    private void Update()
    {
        moneyText.text = money.ToString();  
        ShopMoneyText.text = money.ToString();

        costClickText.text = upgradeClickCost.ToString();
        costAutoClickText.text = upgradeAutoClickCost.ToString();


        if (money >= 1000000000000000000) { money = 1000000000000000000; }
        else if(money <= 0) { money = 0; }


    }



    public void UpgradeClickCost()
    {
        if(upgradeClickCost <= money) {
            money -= upgradeClickCost;
            girl.countPlusMoney++;
            upgradeClickCost += 20;

        }
    }

    public void UpgradeAutoClickCost()
    {
        if (upgradeAutoClickCost <= money)
        {
            money -= upgradeAutoClickCost;
            girl.autoClick++;
            upgradeAutoClickCost += 20;
        }
    }

    IEnumerator AutoClick()
    {
        yield return new WaitForSeconds(girl.timeAutoClick);

        girl.OnPressAutoClick();

        StartCoroutine(AutoClick());
    }

    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;


    public void MySave()
    {
        YandexGame.savesData.money = money;
        YandexGame.savesData.upgradeClickCost = upgradeClickCost;
        YandexGame.savesData.upgradeAutoClickCost = upgradeAutoClickCost;

        YandexGame.savesData.countPlusMoney = girl.countPlusMoney;
        YandexGame.savesData.autoClick = girl.autoClick;

        int i = 0;
        foreach(GirlBuyScript girlBuyScript in girlBuyScripts) { YandexGame.savesData.girlBuyScripts[i] = girlBuyScript.locked; i++; }
        int j = 0;
        foreach(FoneBuyScript foneBuyScript in foneBuyScripts) { YandexGame.savesData.foneBuyScripts[j] = foneBuyScript.locked; j++; }

        YandexGame.SaveProgress();

    }

    public void LoadSaveCloud()
    {
        money = YandexGame.savesData.money;
        upgradeClickCost = YandexGame.savesData.upgradeClickCost;
        upgradeAutoClickCost = YandexGame.savesData.upgradeAutoClickCost;

        girl.countPlusMoney = YandexGame.savesData.countPlusMoney;
        girl.autoClick = YandexGame.savesData.autoClick;


        int i = 0;
        foreach (bool locker in YandexGame.savesData.girlBuyScripts) { girlBuyScripts[i].locked = locker; i++; }
        int j = 0;
        foreach (bool locker in YandexGame.savesData.foneBuyScripts) { foneBuyScripts[j].locked = locker; j++; }
    }


}
