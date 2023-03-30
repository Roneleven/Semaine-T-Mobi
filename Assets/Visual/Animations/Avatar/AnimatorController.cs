using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{
    public UnityEvent TheAnimator;

    public List<string> paramIntegerName = new List<string>();  // Nom du paramètre integer à modifier
    public List<int> paramIntegerValue = new List<int>();  // Valeur du paramètre integer à affecter

    private Animator animator;

    void Start()
    {
        // Récupération de l'Animator du GameObject cible
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Vérification que le nombre de noms de paramètres est égal au nombre de valeurs à affecter
        if (paramIntegerName.Count != paramIntegerValue.Count)
        {
            Debug.LogWarning("Le nombre de noms de paramètres n'est pas égal au nombre de valeurs à affecter.");
            return;
        }

        // Boucle pour modifier les paramètres integer
        for (int i = 0; i < paramIntegerName.Count; i++)
        {
            string paramName = paramIntegerName[i];
            int paramValue = paramIntegerValue[i];

            // Récupération du paramètre correspondant au nom donné
            AnimatorControllerParameter param = animator.GetParameter(paramName.ConvertTo<int>());

            // Vérification que le paramètre existe et est de type integer
            if (param != null && param.type == AnimatorControllerParameterType.Int)
            {
                // Affectation de la valeur du paramètre integer
                animator.SetInteger(paramName, paramValue);
            }
            else
            {
                Debug.LogWarning("Le paramètre " + paramName + " n'existe pas ou n'est pas de type integer.");
            }
        }
    }
}
