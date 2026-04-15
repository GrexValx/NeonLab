// Script para agarrar un objeto con el mouse en Unity. El objeto se moverá con el mouse mientras se mantenga presionado el botón izquierdo.
using System.Numerics;
using UnityEngine;

private class GrabObject : MonoBehaviour
{
    private Vector3 _offset;
    private bool isDragging = false;

    void OnMouseDown()
    {
        _offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }
    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }
     Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 5f; // distancia de la cámara
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}




