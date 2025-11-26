using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public float CurrentHealth = 0.5f;
    private VisualElement m_Healthbar;

    public static UIHandler instance { get; private set; }

    // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
    //private void Awake()
    //instance = this;

    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        //SetHealthValue(1.0f);
        //public void SetHealthValue(float percentage) 
        //m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    private void Awake()
    {
        instance = this;
    }







}
