using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float shootSpeed = 10f;
    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // 0.01666666666s if 60f/s
        //if we press "the shoot button" (left mouse?)
        if (Input.GetButton("fire1") && timer > shootDelay && Time.timeScale != 0)
        {
            timer = 0;
            //fire a projectile in a straight line in the direction of the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            mousePos = mousePos - transform.position;
            mousePos.Normalize();
            //spawn in the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = mousePos * shootSpeed;
            Destroy(bullet, bulletLifetime);
            //Debug.Log(mousePos);
        }
    }
}
