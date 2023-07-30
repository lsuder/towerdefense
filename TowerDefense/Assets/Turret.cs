using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public Transform target;
    public float range = 15f;
    public Transform partToRotate;

    private string enemyObjectTag = "Enemy";

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("FindTarget", 0.0f, 0.5f);
    }

    void FindTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyObjectTag);
        Debug.Log("finding target.." + enemies.Length);

        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance < range) {
            target = closestEnemy.transform;
        } else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
