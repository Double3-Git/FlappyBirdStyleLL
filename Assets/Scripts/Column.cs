using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    // OnTriggerEnter2D вызывается, когда Collider2D входит в триггер (только двухмерная физика)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            GameManager.instance.BirdScored();
        }
    }

}
