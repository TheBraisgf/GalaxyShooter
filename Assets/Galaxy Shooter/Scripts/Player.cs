using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Public or private identify
//Data type ( Int, float, bool, string)
//Every variable has a NAME
//Option value assigned

[SerializeField]
private float speed = 5.0f;


 // Start is called before the first frame update
void Start()
{
     //Reset Player Position
    transform.position = new Vector3(0,-3,0);

}

// Update is called once per frame
void Update()
{
Movement();
}


//Methods

private void Movement()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    transform.Translate(Vector3.right  * speed * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

     // If player on the y is greater than0 set player position 0
    if(transform.position.y > 0){
    transform.position = new Vector3 (transform.position.x, 0, 0);
}
    else if(transform.position.y < -4.2f){
    transform.position = new Vector3(transform.position.x, -4.2f, 0);
}

    //If player on the x is greater than 9.47 make -9.47

    if(transform.position.x > 9.4f){
    transform.position = new Vector3(-9.4f, transform.position.y, 0 );
}
    else if(transform.position.x < -9.4f){
    transform.position = new Vector3(9.4f, transform.position.y, 0 );
}

}
}

