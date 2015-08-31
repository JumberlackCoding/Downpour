using UnityEngine;
using System.Collections;

public class SunMotion : MonoBehaviour {

    [SerializeField]
    private Transform[] sunWaypoints;

    [SerializeField]
    private float moveSpeed;

    private int currentWaypoint;

	// Use this for initialization
	void Start () {
        currentWaypoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDirection = new Vector3( sunWaypoints[currentWaypoint].position.x - transform.position.x, sunWaypoints[currentWaypoint].position.y - transform.position.y, 0 );
        if( transform.position.x >= sunWaypoints[currentWaypoint].position.x )
        {
            currentWaypoint++;
        }
        transform.Translate( targetDirection.normalized * Time.deltaTime * moveSpeed );
	}
}
