using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Update() {
        transform.Translate(Vector3.forward * 0.5f);

        Destroy(gameObject, 3f);
    }
}
