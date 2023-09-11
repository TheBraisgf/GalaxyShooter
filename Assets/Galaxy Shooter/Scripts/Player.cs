using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
//Public or private identify
//Data type ( Int, float, bool, string)
//Every variable has a NAME
//Option value assigned


public bool canTripleShot = false;
public bool isSpeedBoostActive = false;

[SerializeField]
private GameObject _laserPrefab;

[SerializeField]
private GameObject _tripleShotPrefab;


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
    //Triple Shot
    if(canTripleShot == true)
    {
    Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
    }
    else{
    //Spawn laser
    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
    }
    _canFire = Time.time + _fireRate;
}
}

private void Movement()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    if (isSpeedBoostActive == true)
    {

    transform.Translate(Vector3.right  * _speed * 1.5f * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * _speed * 1.5f * verticalInput * Time.deltaTime);
    }
    else
    {
    transform.Translate(Vector3.right  * _speed * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
    }




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

public void TripleShotPowerupOn()
{
    canTripleShot = true;
    StartCoroutine(TripleShotPowerDownRoutine());
}

public void SpeedBoostPowerupOn()
{
isSpeedBoostActive = true;
StartCoroutine(SpeedBoostDownRoutine());
}


public IEnumerator TripleShotPowerDownRoutine()
{
    yield return new WaitForSeconds(5.0f);
    canTripleShot = false;
}

public IEnumerator SpeedBoostDownRoutine()
{
    yield return new WaitForSeconds(5.0f);
    isSpeedBoostActive = false;
}
}

