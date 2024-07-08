using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 5f;

    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        
    }



    void Update()
    {
        if((this.transform.position - startPos).sqrMagnitude > 1000)
        {
            Destroy(this.gameObject);
        }
    }
}
