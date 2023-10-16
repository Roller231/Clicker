using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {
        moneyText.text = money.ToString();  
        ShopMoneyText.text = money.ToString();

        if(money >= 1000000000000000000) { money = 1000000000000000000; }
        else if(money <= 0) { money = 0; }

        if (Input.GetKeyUp(KeyCode.Space)) { girl.OnPress(); }
    }

    private void FixedUpdate()
    {

    }

    public void UpgradeClickCost()
    {
        if(upgradeClickCost <= money) {
            money -= upgradeClickCost;
            girl.countPlusMoney++;
            upgradeClickCost += 20;
            costClickText.text = upgradeClickCost.ToString();
        }
    }

    public void UpgradeAutoClickCost()
    {
        if (upgradeAutoClickCost <= money)
        {
            money -= upgradeAutoClickCost;
            girl.autoClick++;
            upgradeAutoClickCost += 20;
            costAutoClickText.text = upgradeAutoClickCost.ToString();
        }
    }

    IEnumerator AutoClick()
    {
        yield return new WaitForSeconds(girl.timeAutoClick);

        girl.OnPressAutoClick();

        StartCoroutine(AutoClick());
    }

}
