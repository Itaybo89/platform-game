using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicup : MonoBehaviour
{
    [SerializeField] int coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;
    bool wasCollected = false;

 
  void OnTriggerEnter2D(Collider2D other) 
  {
     if (other.tag == "Player" && !wasCollected)
     {
         wasCollected = true;
         FindObjectOfType<GameSession>().CoinScoreIncrease(coinValue);
         AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
         gameObject.SetActive(false);
         Destroy(gameObject);
     }
 }

 
}
