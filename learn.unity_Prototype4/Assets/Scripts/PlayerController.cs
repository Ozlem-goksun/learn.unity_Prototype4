using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject Indicator;

    public float speed = 0.0f;
    public float poweUpStregth = 0.0f;

    public bool hasPowerUp = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.forward * forwardInput *  speed); // the player move forward and backward and that's all
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed); //now we can move according to the focal points rotation.

        Indicator.gameObject.transform.position = transform.position - new Vector3(0, 0.5f, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);

            Indicator.gameObject.SetActive(true);
            StartCoroutine(PoweUpCountDown());
        }
    }

    IEnumerator PoweUpCountDown()
    {
        yield return new WaitForSeconds(5);

        hasPowerUp = false;
        Indicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer *  poweUpStregth, ForceMode.Impulse);

            Debug.Log("Collided with " + collision.gameObject.name + " powerUp set to " + hasPowerUp);
        }
    }

}
