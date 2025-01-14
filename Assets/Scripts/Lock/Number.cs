using UnityEngine;

public class Number : MonoBehaviour
{
    private int _number; 
    private AnimationManager _animator;

    void Start()
    {
        _animator = GetComponent<AnimationManager>();
        _number = 0;
    }
    public void SetNumber(int number)
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

    public int GetNumber()
    {
        return _number;
    }

    public void Reset()
    {
        if(_number < 5)
        {
            while(_number != 0)
            {
                _number--;
                _animator.PlayAnimation(""+_number);
            }
        }
        else
        {
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
