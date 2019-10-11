using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCollison : MonoBehaviour
{
    public GameObject gameManager;
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager") ;
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("miss cube collided");
        gameManagerScript.resetComboScore();
        gameManagerScript.updateMissScore();
        Destroy(other.gameObject);
    }


}
