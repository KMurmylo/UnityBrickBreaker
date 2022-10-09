using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rBody;
    private GameStateBehaviour state;
    [SerializeField]
    private float speed=10f;
    private Vector3 velocityBeforeImpact;
    [SerializeField]
    private Vector3 startingVelocity = new Vector3(-1, 2, 0);
    [SerializeField]
    private float controlMultiplier = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Startup());
        state = GameObject.Find("GameState").GetComponent<GameStateBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {  
        rBody.velocity = rBody.velocity.normalized * speed;
        velocityBeforeImpact = rBody.velocity;

    }
    private IEnumerator Startup()
    {
        
        Debug.Log("Waiting");
        
        yield return new WaitForSeconds(2);
        
        rBody.velocity = startingVelocity;
        Debug.Log("Finished waiting");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {   
        rBody.velocity = Vector3.Reflect(velocityBeforeImpact, other.GetContact(0).normal);
        if (other.gameObject.tag == "Player")
        {
            rBody.velocity=new Vector3(rBody.velocity.x+(controlMultiplier*(other.GetContact(0).point.x- other.gameObject.transform.position.x)), rBody.velocity.y,0);
        }
        if (other.gameObject.tag == "Block")
        {

            state.AddScore(other.gameObject.GetComponent<BlockBehaviour>().points);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bottom")
        {
            Destroy(this.gameObject);
        }
    }
}
