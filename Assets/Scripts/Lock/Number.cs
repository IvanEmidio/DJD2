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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_number == 9)
            {
                _number = 0;
            }
            else
            {
                _number++;
            }
            _animator.PlayAnimation(""+_number);
        }
        if (Input.GetMouseButtonDown(1)) // 1 = Right mouse button
        {
            if(_number == 0)
            {
                _number = 9;
            }
            else
            {
                _number--;
            }
            _animator.PlayAnimation(""+_number);
        }
        
        
        
    }

    public byte GetNumber()
    {
        return _number;
    }

    public void Reset()
    {
        if(_number < 5)
            while(_number != 0)
            {
                _number--;
                _animator.PlayAnimation(""+_number);
            }
        else{
            while(_number != 0)
            {
                _number++;
                if(_number == 10)
                {
                    _number = 0;
                }
                _animator.PlayAnimation(""+_number);
                
            }
        }
    }
}
