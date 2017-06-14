using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class PlayerBehaviour : MonoBehaviour {
    
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.

    public AudioClip jumpClip;
    public AudioClip damageClip;

    private int life;

    private Rigidbody2D m_Rigidbody2D;
    private AudioSource aSource;
    private SpriteRenderer sr;

    public Color damageColor = Color.red;

    // Use this for initialization
    void Start () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        life = 100;
    }
	
	// Update is called once per frame
	void Update () {
	    if ( Input.GetKeyDown(KeyCode.Space) 
            || ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ) {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            aSource.PlayOneShot(jumpClip);
        }
	}

    void ApplyDamage (int damage) {
        aSource.PlayOneShot(damageClip);
        life -= damage;
        Debug.Log(life);
        if (life <= 0) {
            Death();
            Debug.Log("You are dead!");
        }
        Color playerColor = Color.Lerp(damageColor, Color.white, life / 100.0f);
        sr.color = playerColor;
    }

    void Death () {
        Destroy(gameObject, 0.5f);
    }
}
