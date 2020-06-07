using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun, projectile;
    AttackerSpawner myLaneSpawner;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Cached References
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        // Look for any attackers in the same lane as us
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        GameObject newProjecile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjecile.transform.parent = projectileParent.transform;
    }
}
