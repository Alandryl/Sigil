using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
        [SerializeField]
        public Vector3 rotation;

        private void Start()
        {
            StartCoroutine(nameof(Run));
        }

        private IEnumerator Run()
        {
            while (Application.isPlaying)
            {
                yield return 0f;

                this.transform.Rotate(rotation * Time.deltaTime);
            }
        }
    
}