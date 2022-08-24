using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class MonsterEffect : MonoBehaviour
{
    public GameObject target;
    Volume volume;

    public static bool monsterIsNear;

    // Start is called before the first frame update
    void Start()
    {

        volume = target.GetComponent<Volume>();

    }

    // Update is called once per frame
    void Update()
    {

        if (monsterIsNear)
        {
            if (volume.profile.TryGet<ChromaticAberration>(out var chromaticAbe))
            {
                chromaticAbe.intensity.value = Mathf.Lerp(chromaticAbe.intensity.value,1, 0.01f);
            }
            if (volume.profile.TryGet<LensDistortion>(out var lensDistortion))
            {
                lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, -0.50f, 0.01f);
            }
          
            if (volume.profile.TryGet<FilmGrain>(out var filmGrain))
            {
                filmGrain.intensity.value = Mathf.Lerp(filmGrain.intensity.value, 1, 0.01f);
                filmGrain.type.value = FilmGrainLookup.Large01;
            }
        }
        else
        {
            if (volume.profile.TryGet<ChromaticAberration>(out var chromaticAbe))
            {
                chromaticAbe.intensity.value = Mathf.Lerp(chromaticAbe.intensity.value, 0f, 0.01f);
            }
            if (volume.profile.TryGet<LensDistortion>(out var lensDistortion))
            {
                lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, 0, 0.01f);
            }
            if (volume.profile.TryGet<FilmGrain>(out var filmGrain))
            {
                filmGrain.intensity.value = Mathf.Lerp(filmGrain.intensity.value, 0.5f, 0.01f);
                filmGrain.type.value = FilmGrainLookup.Thin1;
            }
        }
       
        
    }
}
