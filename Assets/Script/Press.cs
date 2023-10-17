using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Press : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject particle;

    [SerializeField] private Transform transformToSpawnParticle;

    [SerializeField] private Button buttonBoostClick;
    [SerializeField] private Button buttonBoostAutoClick;


    public bool shopOpened = false;

    public int countPlusMoney;
    public int autoClick = 0;
    public float timeAutoClick = 1.7f;
    public void OnPress()
    {
        GetComponent<Animator>().SetTrigger("Press");
        gameManager.money += countPlusMoney;

        if (!shopOpened)
        {
            var value = Instantiate(particle, new Vector3(transformToSpawnParticle.position.x, transformToSpawnParticle.position.y, 81.38f), Quaternion.identity);
            value.GetComponent<ParticleSystem>().Play();
            Destroy(value, 3f);
        }


        GetComponent<AudioSource>().Play();

        gameManager.MySave();
    }

    public void OnPressAutoClick()
    {
        if (autoClick > 0)
        {
            GetComponent<Animator>().SetTrigger("Press");
            gameManager.money += autoClick;

            if (!shopOpened)
            {
                var value = Instantiate(particle, new Vector3(-2.16f, -0.77f, 81.38f), Quaternion.identity);
                value.GetComponent<ParticleSystem>().Play();
                Destroy(value, 3f);
            }

            GetComponent<AudioSource>().Play();

            gameManager.MySave();

        }

    }

    public void shopOpen() { shopOpened = true; }
    public void shopClose() { shopOpened = false; }

    IEnumerator boostAutoClick()
    {
        autoClick *= 2;
        timeAutoClick = 0.8f;
        buttonBoostAutoClick.interactable = false;

        yield return new WaitForSeconds(17f);

        buttonBoostAutoClick.interactable = true;

        timeAutoClick = 1.7f;
        autoClick /= 2;
    }

    public void voidBoostAutoClick() { StartCoroutine(boostAutoClick()); }

    IEnumerator boostClick()
    {
        countPlusMoney *= 2;
        buttonBoostClick.interactable = false;


        yield return new WaitForSeconds(26f);

        buttonBoostClick.interactable = true;

        countPlusMoney /= 2;
    }

    public void voidBoostClick() { StartCoroutine(boostClick()); }

}
