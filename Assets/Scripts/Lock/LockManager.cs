using UnityEngine;
using System.Collections.Generic;

public class LockManager : MonoBehaviour
{
    private AltCamera _camera;
    private List<Number> _numbers = new List<Number>();
    private List<byte> _code = new List<byte>() {1, 2, 3, 4};
    void Start()
    {
        _camera = GetComponent<AltCamera>();
        for (int i = 1; i <=  4; i++)
        {
            GameObject objs = GameObject.Find("Wheel_" + i);

            if (objs != null)
            {
                Number obj = objs.GetComponent<Number>();
                if (obj != null)
                {
                    _numbers.Add(obj);
                }
            }
        }

        //Inverter os objetos que ninguém é de ferro, porque por algum motivo
        // o 4 é o primeiro e o 1 o último
        _numbers.Reverse();
    }

    private void OnMouseDown()
    {
        _camera.ActivateCamera();
    }

    void Update() 
    {
        // Check if the space key is pressed 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _camera.DeactivateCamera();
            for (int i = 0; i < 4; i++)
        {
            _numbers[i].Reset();
            
        }
        }

        int temp = 0;
        for (int i = 0; i < 4; i++)
        {
            if(_numbers[i].GetNumber() == _code[i])
            {
                temp++;
            }
        }
    }
}
