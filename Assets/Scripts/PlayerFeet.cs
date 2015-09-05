using UnityEngine;
using System.Collections;

public class PlayerFeet : MonoBehaviour {
    [SerializeField]
    private PlayerMovement playerScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D( Collision2D collision )
    {
        if( collision.gameObject.tag == "Cloud" )
        {
            playerScript.jumpBegan = false;
        }
    }
}
