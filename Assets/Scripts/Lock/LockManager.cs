using UnityEngine;
using System.Collections.Generic;

public class LockManager : MonoBehaviour
{
    [SerializeField]private InteractionOverall _interactable;
    [SerializeField]private List<byte> _code = new List<byte>(4) {1, 2, 3, 4};
    [SerializeField]private GameObject _light;
    [SerializeField]private ShaderModifierScript _shaderManager;
    private AltCamera _camera;
    private List<Number> _numbers = new List<Number>();
    private List<ShaderModifierScript> _numbersShaders = new List<ShaderModifierScript>();
    private Color _originalColor;
    private Renderer _renderer;
    
    void Start()
    {
        _camera = GetComponent<AltCamera>();
        for (int i = 1; i <=  4; i++)
        {
            GameObject objs = GameObject.Find("Wheel_" + i);

            if (objs != null)
            {
                Number objnumber = objs.GetComponent<Number>();
                if (objnumber != null)
                {
                    _numbers.Add(objnumber);
                }

                ShaderModifierScript objshader = objs.GetComponent<ShaderModifierScript>();
                if (objshader != null)
                {
                    _numbersShaders.Add(objshader);
                }
            }
        }

        //Inverter os objetos que ninguém é de ferro, porque por algum motivo
        // o 4 é o primeiro e o 1 o último
        _numbers.Reverse();

        _renderer = GetComponent<Renderer>();

        if (_renderer != null)
        {
            Material[] materials = _renderer.materials;

            foreach (Material material in materials)
            {
                if (material.HasProperty("_EmissionColor"))
                {
                    _originalColor = material.GetColor("_EmissionColor");
                }
            }
        }
    }

    private void OnMouseDown()
    {
        _camera.ActivateCamera();
        _light.SetActive(true);    //Para ajudar a ver
        _shaderManager.ChangeEmissionValue(0,true, _originalColor);
        print(_numbersShaders.Count);
        for (int i = 0; i < 4; i++)
        {
            print(i);
            _numbersShaders[i].ChangeEmissionValue(0, true, _originalColor);
        }


        for (int i = 0; i < 4; i++)
        {
            _numbers[i].Reset();
            
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _camera.DeactivateCamera();
            _light.SetActive(false);
            _shaderManager.ChangeEmissionValue(0,false, _originalColor);
            for (int i = 0; i < 4; i++)
            {
                _numbersShaders[i].ChangeEmissionValue(0, false, _originalColor);
            }
            
        }

        int temp = 0;
        for (int i = 0; i < 4; i++)
        {
            if(_numbers[i].GetNumber() == _code[i]) //Verifica se o numero é igual ao código
            {
                temp++; //Se sim então esta variavel temporário recebe mais um
            }
        }
        if(temp == 4) //Se a variável temporária tiver a 4 então todos os números estão corretos
        {
            _interactable.IsComplete();
        }
    }
}
