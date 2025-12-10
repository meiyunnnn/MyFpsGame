using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // กระสุน
    public Transform firePoint;     // จุดยิง
    public float shootDelay = 0.1f; // หน่วงเวลาแก้ยิงเร็วเกิน

    float nextTimeToShoot = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToShoot)
        {
            Shoot();
            nextTimeToShoot = Time.time + shootDelay;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}