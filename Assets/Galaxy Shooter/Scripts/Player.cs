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
public bool shieldsActive = false;
public int lives = 3;

[SerializeField]
private GameObject _explosionPrefab;

[SerializeField]
private GameObject _laserPrefab;

[SerializeField]
private GameObject _tripleShotPrefab;

[SerializeField]
private GameObject _shieldGameObject;

[SerializeField]
private GameObject[] _engines;

[SerializeField]
private float _fireRate = 0.25f;
private float _canFire = 0.0f;


[SerializeField]
private float _speed = 5.0f;

private UIManager _uiManager;
private GameManager _gameManager;
private SpawnManager _spawnManager;
private AudioSource _audioSource;


private int hitCount = 0;

 // Start is called before the first frame update
void Start()
{
     //Reset Player Position
    transform.position = new Vector3(0,-3,0);

    _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

if (_uiManager != null)
{
    _uiManager.UpdateLives(lives);
}

    _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();


if (_spawnManager != null)
{
_spawnManager.StartSpawnRoutines();

}

_audioSource = GetComponent<AudioSource>();
hitCount = 0;
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
        _audioSource.Play();
    _canFire = Time.time + _fireRate;
}
}

private void Movement()
{
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    if (isSpeedBoostActive == true)
    {

    transform.Translate(Vector3.right  * _speed * 4f * horizontalInput * Time.deltaTime);
    transform.Translate(Vector3.up * _speed * 4f * verticalInput * Time.deltaTime);
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

public void Damage()
{

    
    if(shieldsActive == true){
        shieldsActive = false;
        _shieldGameObject.SetActive(false);
        return;
    }
    
    hitCount++;

    if (hitCount == 1)
    {
        _engines[0].SetActive(true);
    }
    else if (hitCount == 2)
    {
        _engines[1].SetActive(true);
    }
lives--;

    _uiManager.UpdateLives(lives);
    if (lives < 1)
{
    Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    _gameManager.gameOver = true;
    _uiManager.ShowTitleScreen();
    Destroy(this.gameObject);
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


public void enableShields()
{
    shieldsActive = true;
    _shieldGameObject.SetActive(true);
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

