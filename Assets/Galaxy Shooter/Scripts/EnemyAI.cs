using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
//3.0f
    private float _speed = 2.0f;

    private UIManager _uiManager;



    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Laser")
    {
        if (other.transform.parent != null)
        {
            Destroy(other.transform.parent.gameObject);
        }
        Destroy(other.gameObject);
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        _uiManager.UpdateScore();
        Destroy(this.gameObject);
    }
    else if (other.tag == "Player")
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.Damage();
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}


}
