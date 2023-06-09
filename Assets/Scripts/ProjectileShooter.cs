using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;

    [Header("References")]
    public Transform shootingMouth;
    public Camera cam;

    [Header("Shooting parameters")]
    public float shootForce = 1.0f;
    public float timeBetweenShooting = 0.5f;

    private bool shootingAvailable;

    public delegate void Attack();
    public static event Attack OnAttack;
    public static event Attack OnAttackEnd;

    // Start is called before the first frame update
    void Start()
    {
        shootingAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot()
    {
        if(shootingAvailable)
        {
            shootingAvailable = false;

            // Shooting direction
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = cam.ScreenPointToRay(screenCenterPoint);
            Vector3 shootDirection = new Vector3(
                shootingMouth.transform.forward.x,
                ray.direction.y,
                shootingMouth.transform.forward.z);

            if (animator)
                animator.SetTrigger("Attack");

            // Shoot projectile
            GameObject projectile = Instantiate(projectilePrefab, shootingMouth.position, Quaternion.identity);
            projectile.transform.forward = shootDirection;
            projectile.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce, ForceMode.Impulse);
            //projectile.GetComponent<Rigidbody>().AddForce(Vector3.up);

            OnAttack();
            Invoke("ResetShooting", timeBetweenShooting);
        }
    }

    public void ResetShooting()
    {
        EnableShooting(true);
        OnAttackEnd();
    }

    public void EnableShooting(bool enable)
    {
        shootingAvailable = enable;
    }
}
