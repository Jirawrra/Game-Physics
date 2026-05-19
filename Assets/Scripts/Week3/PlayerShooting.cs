using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Mouse Look")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 30f;
    public float fireRate = 0.2f;

    private float nextFireTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
        Shoot();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical camera rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal player rotation
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * bulletSpeed;
            }
        }
    }
}
