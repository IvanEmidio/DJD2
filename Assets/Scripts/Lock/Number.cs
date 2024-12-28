using UnityEngine;

public class Number : MonoBehaviour
{
    private byte _number = 0; 
    private AnimationManager _animator;

    void Start()
    {
        _animator = GetComponent<AnimationManager>();
    }
    public void SetNumber(byte number)
    {
        _number = number;
    }

    private void OnMouseDown()
    {
        if(_number == 9)
        {
            _number = 0;
        }
        else
        {
            _number++;
        }
        print(_number);
    }

    public byte GetNumber()
    {
        return _number;
    }

    public void Reset()
    {
        _number = 0;
    }

    void Update()
    {
        _animator.PlayAnimation(""+_number);
    }
}
