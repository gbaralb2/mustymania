using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public Transform crouchFirePoint;

    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Crouch") == true && Input.GetButtonDown("Fire1")))
        {
            CrouchShot();
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        void CrouchShot()
        {
            if (PauseMenu.gameIsPaused)
            {
                return;
            }
            Instantiate(bulletPrefab, crouchFirePoint.position, crouchFirePoint.rotation);
        }

        void Shoot()
        {
            if (PauseMenu.gameIsPaused)
            {
                return;
            }
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

}
