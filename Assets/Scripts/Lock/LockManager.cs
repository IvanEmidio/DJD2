using UnityEngine;
using System.Collections.Generic;

public class LockManager : MonoBehaviour
{
    [SerializeField]private List<InteractionOverall> _doors;
    [SerializeField]private List<PickUpEnabler> _interactable;
    [SerializeField]private List<byte> _code = new List<byte>(4) {1, 2, 3, 4};
    [SerializeField]private GameObject _light;
    [SerializeField]private GameObject _mainBody;
    [SerializeField]private ShaderModifierScript _shaderManager;
    [SerializeField] private List<ShaderModifierScript> _numberShaders;
    [SerializeField] private List<Number> _numbers;
    private AltCamera _camera;
    private Color _originalColor;
    private Renderer _renderer;
    private bool _isOnIt;
    
    void Start()
    {
        _camera = GetComponent<AltCamera>();

        //Inverter os objetos que ningu�m � de ferro, porque por algum motivo
        // o 4 � o primeiro e o 1 o �ltimo
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
        _shaderManager.NotNeon();
        foreach(ShaderModifierScript lever in _numberShaders)
        {
            lever.NotNeon();
        }
        _isOnIt = true;


        /* for (int i = 0; i < 4; i++)
        {
            _numbers[i].Reset();
            
        } */
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _camera.DeactivateCamera();
            _light.SetActive(false);
            _shaderManager.Neon();
            foreach(ShaderModifierScript lever in _numberShaders)
            {
                lever.Neon();
            }
            _isOnIt = false;
            
        }

        int temp = 0;

        for (int i = 0; i < 4; i++)
        {
            //print(_numbers[i].GetNumber() + " -> " + _code[i]);
            if(_numbers[i].GetNumber() == _code[i]) //Verifica se o numero � igual ao c�digo
            {
                temp = temp + 1; //Se sim ent�o esta variavel tempor�rio recebe mais um
            }
        }
        
        if(temp == 4 || (Input.GetKeyDown(KeyCode.H) && _isOnIt)) //Se a vari�vel tempor�ria tiver a 4 ent�o todos os n�meros est�o corretos
        {
            for(int i = 0; i < _doors.Count; i++)
                _doors[i].IsComplete();
            for(int i = 0; i < _interactable.Count; i++)
                _interactable[i].CanGrab();
            _shaderManager.NotNeon();
            foreach(ShaderModifierScript lever in _numberShaders)
            {
                lever.NotNeon();
            }
            _camera.DeactivateCamera();
            _mainBody.SetActive(false);
        }
    }
}
