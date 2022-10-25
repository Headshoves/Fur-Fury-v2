using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LookCursor : MonoBehaviour
{
    private void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        
    }
}
