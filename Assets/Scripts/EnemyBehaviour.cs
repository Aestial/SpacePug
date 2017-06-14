using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            coll.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(gameObject, 0.1f);
        }
    }
}
