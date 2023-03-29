using System;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorControl: MonoBehaviour
{
    [SerializeField] private Animator animator;

    public string [] parameterName;
    public int [] parameterValue;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void SetParameterValue0()
    {
        animator.SetInteger(parameterName[0], parameterValue[0]);
    }
    public void SetParameterValue1()
    {
        animator.SetInteger(parameterName[1], parameterValue[1]);
    }
    public void SetParameterValue2()
    {
        animator.SetInteger(parameterName[2], parameterValue[2]);
    }
    public void SetParameterValue3()
    {
        animator.SetInteger(parameterName[3], parameterValue[3]);
    }
    public void SetParameterValue4()
    {
        animator.SetInteger(parameterName[4], parameterValue[4]);
    }
    public void SetParameterValue5()
    {
        animator.SetInteger(parameterName[5], parameterValue[5]);
    }
}