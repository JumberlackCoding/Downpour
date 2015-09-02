using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private BoxCollider2D feet;

    [SerializeField]
    private float movespeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxSpeed;

    private Vector2 speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if( body.velocity.magnitude >= 2f )
        {
            speed = body.velocity.normalized;
            body.velocity = speed * maxSpeed;
        }
	    if( Input.GetKey( KeyCode.A ) )
        {
            body.AddForce( new Vector2( -movespeed, 0f ), ForceMode2D.Force );
        }
        if( Input.GetKey( KeyCode.D ) )
        {
            body.AddForce( new Vector2( movespeed, 0f ), ForceMode2D.Force );
        }
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            body.AddForce( new Vector2( 0f, jumpForce ), ForceMode2D.Impulse );
        }

        if( transform.position.y <= -1.6f )
        {
            transform.position = new Vector3( transform.position.x, 1.5f, 0f );
        }
        if( transform.position.y >= 1.6f )
        {
            transform.position = new Vector3( transform.position.x, -1.5f, 0f );
        }
        if( transform.position.x >= 2.55f )
        {
            transform.position = new Vector3( -2.5f, transform.position.y, 0f );
        }
        if( transform.position.x <= -2.55f )
        {
            transform.position = new Vector3( 2.5f, transform.position.y, 0f );
        }
	}
}
