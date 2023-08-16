using Unity.VisualScripting;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int currentwaypointIndex;

    [SerializeField] float speed = 100f;

    private Vector3[] _waypointPos;

    void Start()
    {
        currentwaypointIndex = 0;
        _waypointPos = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            _waypointPos[i] = waypoints[i].position;
        }
    }

    void FixedUpdate()
    {
        if (_waypointPos == null && _waypointPos.Length == 0) return;
        if (Vector3.Distance(transform.position, _waypointPos[currentwaypointIndex]) < .1f)
        {
            currentwaypointIndex++;
            if (currentwaypointIndex >= _waypointPos.Length)
            {
                currentwaypointIndex = 0;
                

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _waypointPos[currentwaypointIndex], speed * Time.deltaTime);
    }
}
