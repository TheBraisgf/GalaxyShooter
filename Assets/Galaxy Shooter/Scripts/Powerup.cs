using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
[SerializeField]
private float _speed = 3.0f;
[SerializeField]
private int powerupID;

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

            if (powerupID == 0)
            {
            //Turn on the tripleShot bool
            player.TripleShotPowerupOn();
            }
            else if (powerupID == 1)
            {
            //Turn on the speed
            player.SpeedBoostPowerupOn();

            } else if (powerupID == 2)
            {
            //Turn on the shield bool
            player.enableShields();
            }
        }


        //detroy powerUp
        Destroy(this.gameObject);
        }
    }
}
