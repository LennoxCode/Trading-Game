using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject PInstance;

    // Start is called before the first frame update
    void Start()
    {
        PInstance = this.gameObject;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
