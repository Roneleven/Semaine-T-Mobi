using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{
    public UnityEvent TheAnimator;

    public List<string> paramIntegerName = new List<string>();  // Nom du param�tre integer � modifier
    public List<int> paramIntegerValue = new List<int>();  // Valeur du param�tre integer � affecter

    private Animator animator;

    void Start()
    {
        // R�cup�ration de l'Animator du GameObject cible
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // V�rification que le nombre de noms de param�tres est �gal au nombre de valeurs � affecter
        if (paramIntegerName.Count != paramIntegerValue.Count)
        {
            Debug.LogWarning("Le nombre de noms de param�tres n'est pas �gal au nombre de valeurs � affecter.");
            return;
        }

        // Boucle pour modifier les param�tres integer
        for (int i = 0; i < paramIntegerName.Count; i++)
        {
            string paramName = paramIntegerName[i];
            int paramValue = paramIntegerValue[i];

            // R�cup�ration du param�tre correspondant au nom donn�
            AnimatorControllerParameter param = animator.GetParameter(paramName.ConvertTo<int>());

            // V�rification que le param�tre existe et est de type integer
            if (param != null && param.type == AnimatorControllerParameterType.Int)
            {
                // Affectation de la valeur du param�tre integer
                animator.SetInteger(paramName, paramValue);
            }
            else
            {
                Debug.LogWarning("Le param�tre " + paramName + " n'existe pas ou n'est pas de type integer.");
            }
        }
    }
}
