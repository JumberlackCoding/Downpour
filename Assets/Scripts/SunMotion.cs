using UnityEngine;
using System.Collections;

public class SunMotion : MonoBehaviour {

    [SerializeField]
    private GameObject Sun;
    [SerializeField]
    private GameObject Moon;

    [SerializeField]
    private Transform[] sunWaypoints;

    [SerializeField]
    private float moveSpeed;

    private int currentWaypoint;

    private bool sunActive = true;
    private bool moonActive = false;

	// Use this for initialization
	void Start () {
        currentWaypoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if( transform.position.x >= ( sunWaypoints[currentWaypoint].position.x - 0.2f ) )
        {
            if( currentWaypoint < sunWaypoints.Length-1 )
            {
                currentWaypoint++;
            }
            else
            {
                currentWaypoint = 0;
                sunActive = !sunActive;
                moonActive = !moonActive;
                Sun.SetActive( sunActive );
                Moon.SetActive( moonActive );
                transform.position = sunWaypoints[0].position;
            }
            
        }
        Vector3 targetDirection = new Vector3( sunWaypoints[currentWaypoint].position.x - transform.position.x, sunWaypoints[currentWaypoint].position.y - transform.position.y, 0 );
        transform.Translate( targetDirection.normalized * Time.deltaTime * moveSpeed );
	}
}
