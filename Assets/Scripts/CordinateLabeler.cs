using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
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
        SetLabelColor();
        ToggleLabels();
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if (waypoint.IsPlaceable/* && GetComponent<CordinateLabeler>().tag!="InCastle" */) //sor Onura
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
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);//WARNING yapay zeka ile ilgili hata olu�abilir.
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);//WARNING yapay zeka ile ilgili hata olu�abilir.
        label.text = cordinates.x + "," + cordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name=cordinates.ToString();
    }
}
