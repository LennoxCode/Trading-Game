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
        TileNavigation.instance.SetTerainData(transform.position, this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseDown()
    {
        //if(terrain.isAccesible && !EventSystem.current.IsPointerOverGameObject()) PlayerController.PInstance.transform.position = transform.position + new Vector3(0, 0.8f, 0);
        //Tile test = TileNavigation.instance.GetTerainData(transform.position);
        if (EventSystem.current.IsPointerOverGameObject() || PlayerController.instance.IsMoving()) return;
        if (PlayerController.instance.currTile != null)
        {
            List<Vector3> test = TileNavigation.instance.GetRouteTo(PlayerController.instance.currTile.transform.position,transform.position);
            StartCoroutine(PlayerController.instance.WalkPath(test));
        }
        PlayerController.instance.currTile  = this;
        //Debug.Log(test.GetTerrain().terrainKind);
        
    }
    public Terrain GetTerrain() { return terrain; }
}
