using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CambiardeScenario : MonoBehaviour
{
    [Header("PrmerLvl")]
    public Material skyboxDiaScene;
    [Header("SegundoNivelLava")]
    public Material skyboxLava;

void Start(){
    skyboxDiaScene = RenderSettings.skybox;
}
    public void CambiarSegundoLvlLava(){
        RenderSettings.skybox = skyboxLava;
        DynamicGI.UpdateEnvironment();
    }
    public void CambiarSegundoLvlDia(){
        RenderSettings.skybox = skyboxDiaScene;
        DynamicGI.UpdateEnvironment();
    }

}
