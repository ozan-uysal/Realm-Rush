using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[ExecuteAlways]
public class CordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor= Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int cordinates= new Vector2Int();
    Waypoint waypoint;
   
    private void Awake()
    {
      label = GetComponent<TextMeshPro>();
      label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCordinates();
        UpdateObjectName();
    }

    void Update()
    {
        if (Application.isPlaying)
        {
            DisplayCordinates();
            UpdateObjectName();
        }
        ColoorCordinates();
        ToggleLabels();
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ColoorCordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }


    void DisplayCordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x/40);//WARNING yapay zeka ile ilgili hata oluþabilir.
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z/40);//WARNING yapay zeka ile ilgili hata oluþabilir.
        label.text = cordinates.x + "," + cordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name=cordinates.ToString();
    }
}
