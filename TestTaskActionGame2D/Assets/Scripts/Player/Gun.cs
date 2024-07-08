using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Properties")]
    [SerializeField] int startingAmmo;
    [SerializeField] int magSize;
    [SerializeField] float reloadCoolDown;

    [SerializeField] float spotRadius;

    [Header("Bullet Properties")]
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI ammoText;

    int ammoInMag;
    int totalAmmo;

    //public GameObject enemyInSight {  get; private set; }
    public GameObject enemyInSight;

    void Start()
    {
        ammoInMag = magSize;
        totalAmmo = startingAmmo;

        ammoText.text = "Ammo: " + ammoInMag + " / " + totalAmmo;
    }

    void Update()
    {
        if(enemyInSight != null)
        {
            RotateGun();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyInSight = null;
        }
    }

    public void FoundEnemy(GameObject go)
    {
        if(enemyInSight != null)
        {
            if ((go.transform.position - this.transform.position).sqrMagnitude > (enemyInSight.transform.position - this.transform.position).sqrMagnitude)
            {
                enemyInSight = go;
            }
        }
        else
        {
            enemyInSight = go;
        }

    }

    void RotateGun()
    {
        float enemyY = enemyInSight.transform.position.y - this.transform.position.y;
        float enemyX = enemyInSight.transform.position.x - this.transform.position.x;

        float enemyAngle = Mathf.Rad2Deg * Mathf.Atan2(enemyX, enemyY);

        this.transform.rotation = Quaternion.Euler(0f, 0f, -enemyAngle);
    }

    public void Shoot()
    {
        if(ammoInMag > 0 & enemyInSight != null)
        {
            SpawnBullet((enemyInSight.transform.position - this.transform.position).normalized);

            if(totalAmmo > 0)
                totalAmmo--;

            ammoInMag--;

            ammoText.text = "Ammo: " + ammoInMag + " / " + totalAmmo;

            if (ammoInMag == 0)
            {
                Debug.LogError("Start reload");
                StartCoroutine(Reload());
                Debug.LogError("finish reload");
            }
        }
        else
        {
          
        }
    }

    void SpawnBullet(Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0f, 0f, 90f));
        bullet.damage = bulletDamage;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    IEnumerator Reload()
    {
        ammoText.text = "Reloading...";

        yield return new WaitForSeconds(reloadCoolDown);

        if(totalAmmo > magSize)
        {
            totalAmmo -= magSize;
            ammoInMag = magSize;
        }
        else if(totalAmmo > 0 & totalAmmo < magSize)
        {
            ammoInMag = totalAmmo;
            totalAmmo = 0;
        }

        ammoText.text = "Ammo: " + ammoInMag + " / " + totalAmmo;
    }
}
