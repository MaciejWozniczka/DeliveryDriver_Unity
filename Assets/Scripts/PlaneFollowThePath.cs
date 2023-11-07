using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlaneFollowThePath : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 10f;
    private int waypointIndex = 0;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            Vector3 toPosition = waypoints[waypointIndex].transform.position;
            Vector3 fromPosition = transform.position;

            fromPosition.z = 0f;
            Vector3 dir = (toPosition - fromPosition).normalized;

            float angle = UtilsClass.GetAngleFromVectorFloat(dir);
            transform.localEulerAngles = new Vector3(0, 0, angle - 90);
            
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }

        StartCoroutine(WaitBeforeNextFlight());
    }

    private IEnumerator WaitBeforeNextFlight()
    {
        yield return new WaitForSeconds(5f);
    }
}