using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy properties")]
    [SerializeField] float spotDistance;
    [SerializeField] float attackDistance;

    [SerializeField] Slider enemyHp;
    [SerializeField] int startHp;
    int currentHp;

    [SerializeField] ItemCollectible itemDrop;

    GameObject player;
    GameObject gun;
    Gun gunScript;
    PlayerHealth playerHealth;

    Vector3 distanceToPlayer;
    bool spottedByPlayer = false;

    void Start()
    {
        player = GameObject.Find("Player");
        gun = GameObject.Find("Gun");
        gunScript = gun.GetComponent<Gun>();
        playerHealth = player.GetComponent<PlayerHealth>();

        currentHp = startHp;
        enemyHp.maxValue = currentHp;
        enemyHp.value = currentHp;
        
    }

    void Update()
    {
        distanceToPlayer = player.transform.position - transform.position;

        if (distanceToPlayer.magnitude < spotDistance)
        {
            if (!spottedByPlayer)
            {
                spottedByPlayer = true;
                gunScript.FoundEnemy(this.gameObject);
            }

            transform.position = transform.position + (distanceToPlayer.normalized * 1f * Time.deltaTime);

            if(distanceToPlayer.magnitude < attackDistance)
            {
                //Attack
                Debug.LogError("Attacking!");
                playerHealth.GetHit(3f * Time.deltaTime);
            }

        }
        else
        {
            if(gunScript.enemyInSight != null)
            {
                if (gunScript.enemyInSight == this.gameObject)
                {
                    gunScript.enemyInSight = null;
                    spottedByPlayer=false;
                }
            }

            spottedByPlayer = false;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            GetHit(bullet.damage);
            Destroy(bullet.gameObject);
        }
    }

    public void GetHit(float damage)
    {
        currentHp -= (int)damage;

        if (currentHp < 0)
        {
            Death();
        }
        else
        {
            enemyHp.value = currentHp;
        }
    }

    public void Death()
    {
        gunScript.enemyInSight = null;
        Instantiate(itemDrop.gameObject, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
