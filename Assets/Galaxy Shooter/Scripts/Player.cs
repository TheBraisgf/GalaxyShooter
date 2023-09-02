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
private GameObject _laserPrefab;

[SerializeField]
private float _fireRate = 0.25f;
private float _canFire = 0.0f;


[SerializeField]
private float _speed = 5.0f;




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

//If key pressed spawn laser at player position
if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
{
Shoot();
}

}


//Methods

private void Shoot()
{
    if(Time.time > _canFire)
    {
    //Spawn laser
    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
    _canFire = Time.time + _fireRate;
    }
}

private void Movement()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    transform.Translate(Vector3.right  * _speed * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

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

