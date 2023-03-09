using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    public Material placeableMaterial;
    public Material nonPlaceableMaterial;
    Material material;


    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {  get {return isPlaceable; } }

    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        material = meshRenderer.sharedMaterial;      
    }
    private void OnMouseDown()
    {
        
        if (isPlaceable)
        {
            GameObject.Instantiate(towerPrefab,transform.position,Quaternion.identity);
            isPlaceable= false;
        }
    }
    private void OnMouseOver()
    {
            meshRenderer.sharedMaterial = IsPlaceable?placeableMaterial:nonPlaceableMaterial;
    }
    private void OnMouseExit()
    {
        meshRenderer.sharedMaterial = material;
    }

}
