using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChild : MonoBehaviour
{
    // Start is called before the first frame update
    public TargetController controller;
    void OnDestroy()
    {
        controller.RemoveMe(this.gameObject);
    }

}
