using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoneBuyScript : MonoBehaviour
{
    public bool locked = true;
    public bool canBuying = false;

    [SerializeField] private GameManager gameManager;

    public int cost;
    [SerializeField] private Text costText;

    [SerializeField] GameObject locker;
    [SerializeField] GameObject girlImage;
    [SerializeField] GameObject fone;

    [SerializeField] private Sprite spriteGirl;
    [SerializeField] private GameObject playGirl;


    private void Update()
    {
        CheckAll();
        costText.text = cost.ToString();
    }
    public void CheckAll()
    {
        if (locked)
        {
            locker.SetActive(true);
            girlImage.GetComponent<Image>().color = Color.black;
        }
        else
        {
            locker.SetActive(false);
            girlImage.GetComponent<Image>().color = Color.white;

        }

        if(gameManager.money >= cost && locked) { costText.color = Color.white; gameObject.GetComponent<Button>().interactable = true; canBuying = true; }
        else if (gameManager.money < cost && locked) { costText.color = Color.red; gameObject.GetComponent<Button>().interactable = false; canBuying = false; }
        else { costText.color = Color.green;}

    }

    public void Buy()
    {
        if(canBuying)
        {
            locked = false;
            gameManager.money -= cost;
            canBuying = false;
        }
    }

    public void SetActiveGirl()
    {
        foreach(FoneBuyScript foneScript in gameManager.foneBuyScripts)
        {
            foneScript.fone.SetActive(false);
        }
        fone.SetActive(true);

        playGirl.GetComponent<Image>().sprite = spriteGirl;
    }
}
