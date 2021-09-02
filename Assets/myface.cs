using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myface : MonoBehaviour
{

    public static Material skinmat;
    private void Awake()
    {
        skinmat = GetComponent<MeshRenderer>().materials[0];
    }
}
