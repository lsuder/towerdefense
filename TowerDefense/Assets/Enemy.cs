using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0; // Current waypoint index.
    private readonly System.Random random = new System.Random();

    private void Start() {
        target = Waypoints.wayPoints[0];
    }

    private void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= random.NextDouble()) {
            if ((wavepointIndex + 1) < Waypoints.wayPoints.Length) {
                GetNextWaypoint();
            } else { 
                Destroy(gameObject);
            }
        }
    }

    private void GetNextWaypoint() {
        target = Waypoints.wayPoints[++wavepointIndex];
    }
}
