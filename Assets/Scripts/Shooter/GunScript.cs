using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public ParticleSystem shootingParticle;
    public GameObject impactSiringe;
    public AudioSource shootingSound;
    public AudioSource rechargeSound;
    public Text ammoText;

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
        {
            Reload();
        }
        //Shoot
        if (isShooting && bulletsLeft > 0 && !isReloading && readyToShoot)
            Shoot();
    }

    void Shoot()
    {
        shootingParticle.Play();
        shootingSound.Play();
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
        
        GameObject siringe = Instantiate(impactSiringe, _rayhit.point, _playerCam.transform.rotation);
        siringe.transform.parent = _rayhit.transform;
        Destroy(siringe, 1f);
        if (bulletsLeft == 0)
        {
            Invoke("RotateGun", 0.2f);
        }
        UpdateAmmo();
        Invoke("ReadyToShoot", shootingInterval);
    }

    void ReadyToShoot() {
        readyToShoot = true;
    }
    void Reload() {
        isReloading = true;
        if (bulletsLeft != 0)
        {
            RotateGun();
        }
        Invoke("Reloading", reloadTime);
    }
    void RotateGun() {
        gameObject.transform.Rotate(0, 0, 40f);
    }
    void Reloading() {
        rechargeSound.Play();
        gameObject.transform.Rotate(0, 0, -40f);
        bulletsLeft = sizeMagazine;
        UpdateAmmo();
        isReloading = false;
    }
    void UpdateAmmo()
    {
        ammoText.text = "" + bulletsLeft;
    }
}
