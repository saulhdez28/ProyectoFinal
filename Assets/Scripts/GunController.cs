using PlayerInputsAssetsController;
using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 1.5f;

    private PlayerController playerController;
    private float nextTimeToShoot = 0f;

    private void Start()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        if (playerController == null)
        {
            Debug.LogError("Player Controller not found in the scene!");
        }
    }

    private void Update()
    {
        if (playerController != null)
        {
            if (playerController.Weapon2.activeSelf
            && playerController.canShoot == true
            && Time.time >= nextTimeToShoot) 
            {
                nextTimeToShoot = Time.time + fireRate; 
                StartCoroutine(ShootRoutine());
            }
        }
    }

    private IEnumerator ShootRoutine()
    {
        yield return new WaitForSeconds(1f);
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        
    }
}
