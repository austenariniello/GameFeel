using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Toggle SFXToggle;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSFX;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (SFXToggle.isOn)
            shootSFX.Play();
    }
}
