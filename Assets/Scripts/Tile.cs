using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Terrain terrain;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseDown()
    {
        if(terrain.isAccesible && !EventSystem.current.IsPointerOverGameObject()) PlayerController.PInstance.transform.position = transform.position + new Vector3(0, 0.8f, 0);
        //TileNavigation.instance.GetRouteTo(transform.position, transform.position);
    }
    public Terrain GetTerrain() { return terrain; }
}
