using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public bool jumpBegan = false;
    
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
    [SerializeField]
    private float jumpHeight;

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
            if( jumpBegan == false )
            {
                jumpBegan = true;
                StartCoroutine( Jumping() );
            }
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

    IEnumerator Jumping()
    {
        bool jumping = true;
        float startHeight = transform.position.y;
        float maxHeight = startHeight + jumpHeight;
        float jumpForceStart = jumpForce;
        while( jumping )
        {
            if( Input.GetKey( KeyCode.Space ) )
            {
                body.AddForce( new Vector2( 0f, jumpForce ), ForceMode2D.Force );
                jumpForce *= .9f;
            }
            if( Input.GetKeyUp( KeyCode.Space ) )
            {
                jumping = false;
            }
            if( transform.position.y >= maxHeight )
            {
                jumping = false;
            }
            yield return null;
        }
        jumpForce = jumpForceStart;
        yield return null;
    }
}
