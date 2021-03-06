﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointManager.instance.ResetPlayerPosition();
            DataCollector.instance.AddDeathCounter();
        }
    }
}
