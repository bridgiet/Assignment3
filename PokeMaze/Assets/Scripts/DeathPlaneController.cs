using UnityEngine;
using System.Collections;

public class DeathPlaneController : MonoBehaviour {
    //PUBLIC INSTANC VARIABLES
    public Transform spawnPoint;
    public GameController gameController;

    //PRIVATE INSTANC VARIABLE
    private AudioSource _playerDead;
	// Use this for initialization
	void Start () {
        this._playerDead = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //when any objects collides with the death plane
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.gameObject.GetComponent<Transform>();
            playerTransform.position = this.spawnPoint.position;
            gameController.LivesValue--;
            this._playerDead.Play();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
