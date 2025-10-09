using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MopController : MonoBehaviour
{
    private Animator _mopAnim;

    private void Start()
    {
        _mopAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mopAnim.SetTrigger("Sweep");
        }
    }
}
