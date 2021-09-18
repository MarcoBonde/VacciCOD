using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] bool automatic;
    bool isShooting;
    bool isReloading;
    bool readyToShoot;

    int bulletsLeft;
    public int sizeMagazine;
    public float _maxdistance;

    public float reloadTime;
    public float shootingInterval;
    public float spread;
    public int damage;

    [SerializeField] Camera _playerCam;

    RaycastHit _rayhit;


    private void Awake()
    {
        isShooting = false;
        isReloading = false;
        readyToShoot = true;
        reloadTime = 2f;
        bulletsLeft = sizeMagazine;


    }

    public void Update()
    {
        if (automatic)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < sizeMagazine && !isReloading)
            Reload();

        //Shoot
        if (isShooting && bulletsLeft > 0 && !isReloading && readyToShoot)
            Shoot();
    }

    void Shoot()
    {
        print("sparo");
        readyToShoot = false;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 direction = _playerCam.transform.forward + new Vector3(x, y, 0);
        //raycast
        if (Physics.Raycast(_playerCam.transform.position, _playerCam.transform.forward, out _rayhit, _maxdistance)) {
            print(_rayhit.collider.name);
            Enemy enemy = _rayhit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);   
            }
        }
        bulletsLeft--;
        Invoke("ReadyToShoot", shootingInterval);
    }

    void ReadyToShoot() {
        readyToShoot = true;
    }
    void Reload() {
        isReloading = true;

        Invoke("Reloading", reloadTime);

        isReloading = false;

    }

    void Reloading() {
        bulletsLeft = sizeMagazine;
    }
}
