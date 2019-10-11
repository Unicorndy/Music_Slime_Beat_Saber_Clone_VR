using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timeLeft = 6f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeLeft);
    }


}
