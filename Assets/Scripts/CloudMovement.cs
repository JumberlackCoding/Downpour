using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed;

	// Use this for initialization
	void Start () {
        if( MoveSpeed == 0 )
        {
            MoveSpeed = Random.Range( 0.05f, 0.1f );
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( MoveSpeed * Time.deltaTime, 0f, 0f );

        if( transform.position.x >= 2.7f )
        {
            transform.position = new Vector3( -2.7f, transform.position.y, 0f );
        }
	}
}
