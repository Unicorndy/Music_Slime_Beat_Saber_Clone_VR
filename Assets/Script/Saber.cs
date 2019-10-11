using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{

    public LayerMask layer;
    private Vector3 previousPos;

    [HideInInspector]
    public GameObject gameManager;
    GameManager gameManagerScript;
    public GameObject destroyParticle;

    [HideInInspector]
    public AudioSource destroySound;

    // Start is called before the first frame update
    void Start()
    {
        destroySound = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Debug.Log(layer + "Item Hit");
                gameManagerScript.updateHitScore();
                gameManagerScript.updateComboScore();
                destroySound.Play();
                Instantiate(destroyParticle, hit.transform.position, Quaternion.identity);
                Destroy(hit.transform.gameObject);
            }
        }
        previousPos = transform.position;
    }


}
