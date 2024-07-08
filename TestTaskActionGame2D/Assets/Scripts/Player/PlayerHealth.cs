using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Slider enemyHp;
    [SerializeField] int startHp;
    float currentHp;

    void Start()
    {
        currentHp = startHp;
        enemyHp.maxValue = currentHp;
        enemyHp.value = currentHp;
    }

    public void GetHit(float damage)
    {
        currentHp -= damage;

        if (currentHp < 0)
        {
            GameOver();
        }
        else
        {
            enemyHp.value = currentHp;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
