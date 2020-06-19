using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    // Страбатывает при выходе объекта из границ коллайдера 
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }


}
