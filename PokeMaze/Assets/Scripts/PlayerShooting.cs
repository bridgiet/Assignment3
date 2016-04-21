using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    //PUBLIC MEMBER VARIABLES
    public Transform flashPoint;
    public GameObject muzzleFlash;
    public GameObject bulletImpact;
    public GameObject explosion;

    public GameController gameController;

    // PRIVATE INSTANCE VARIABLES
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        this._transform = gameObject.GetComponent<Transform>();
        this.gameController = GameObject.FindWithTag("GameController").GetComponent("GameController") as GameController;

    } // end Start

    // Update is called once per frame
    void Update()
    {

    } // end Update


    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gameController.BulletValue--;
            Instantiate(this.muzzleFlash, flashPoint.position, Quaternion.identity);
            RaycastHit hit; // stores information from the Ray;
            if (Physics.Raycast(this._transform.position, this._transform.forward, out hit, 50f))
            {
                if (hit.transform.gameObject.CompareTag("Target")) //when target is hit
                {
                    Instantiate(this.explosion, hit.point, Quaternion.identity);
                    Destroy(hit.transform.gameObject); //destroying game object
                    this.gameController.ScoreValue += 100;
                }
                else
                {
                    Instantiate(this.bulletImpact, hit.point, Quaternion.identity);
                }
            }
        } 
    } 
}
