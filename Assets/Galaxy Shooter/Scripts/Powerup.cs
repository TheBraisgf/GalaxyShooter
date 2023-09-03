using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
[SerializeField]
private float _speed = 0.3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
        //access the player
        Player player = other.GetComponent<Player>();

        if(player != null)
        {
            //Turn on the tripleShot bool
            player.TripleShotPowerupOn();
        }


        //detroy powerUp
        Destroy(this.gameObject);
        }
    }
}
