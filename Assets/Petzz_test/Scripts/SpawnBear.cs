using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PerguntasUI.Instance.ShowQuestion("Quer invocar o urso?", () => {

        }, () => {

        });       
    }

}
