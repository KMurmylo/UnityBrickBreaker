using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float height=-7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {   Vector3 newPosition=new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,height,1);
        if(newPosition.x<-13.6f) { newPosition.x = -13.6f; }
        if(newPosition.x>13.6f) { newPosition.x = 13.6f; }
        transform.position = newPosition;
    }
}
