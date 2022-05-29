using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.OneDay
{[ExecuteInEditMode]

	// ReSharper disable once InvalidXmlDocComment
	///<summary>
	///	1日を再現するマネージャークラス
	///	Postエフェクトなどを時間の経過で値を推移したりする。
	/// </summary>
	public class TimeOfDayManager : MonoBehaviour
	{
    public GameObject sunDirection;
	public GameObject moonDirection;
	
    public Material skyboxDay;
    public Material skyboxNight;

    [Range(0, 1)]
    public float nowTimeOfDay = 0;

    public float timeOfDay;
    
    public float NightTime = 1;

    public float dayOfSpeed=100;
    public float speed=100;

    [Space(10)]
    public bool updateLighting = false;

    public bool canUpDateTime;
    public bool toNight;

/*---------------------------------------------------------------------------------*/
    
        public Bloom morningBloom;
        public Bloom nightBloom;
        public Bloom nowBloom;
        
        [SerializeField] private Vignette morningVignette;
        [SerializeField] private Vignette nowVignette;
        [SerializeField] private Vignette nightVignette;
        
        [SerializeField] private WhiteBalance morningWhiteBalance;
        [SerializeField] private WhiteBalance nowWhiteBalance;
        [SerializeField] private WhiteBalance nightWhiteBalance;
        
        [SerializeField] private ColorAdjustments morningColorAdjustments;
        [SerializeField] private ColorAdjustments nowColorAdjustments;
        [SerializeField] private ColorAdjustments nightColorAdjustments;
        
        float tempBloomIntensity;
        [SerializeField] private Volume morningVolume;

        [SerializeField] private Volume nowVolume;

        [SerializeField] private Volume nightVolume;
        
        [SerializeField] private Volume morningVolumeVignette;
        
        [SerializeField] private Volume nowVolumeVignette;
        
        [SerializeField] private Volume nightVolumeVignette;    
        
        [SerializeField] private Volume morningVolumeWhiteBalance;
        
        [SerializeField] private Volume nowVolumeWhiteBalance;
        
        [SerializeField] private Volume nightVolumeWhiteBalance;
        
        [SerializeField] private Volume morningVolumeAdjustMents;
                
        [SerializeField] private Volume nowVolumeAdjustMents;
                
        [SerializeField] private Volume nightVolumeAdjustMents;

/*---------------------------------------------------------------------------------*/

/// <summary>
/// 初期化処理
/// </summary>
    public void Start()
    {
	     morningVolume.profile.TryGet(out morningBloom);
         nowVolume.profile.TryGet(out nowBloom);
         nightVolume.profile.TryGet(out nightBloom);
         morningVolumeVignette.profile.TryGet(out morningVignette);
         nowVolumeVignette.profile.TryGet(out nowVignette);
         nightVolumeVignette.profile.TryGet(out nightVignette);   
         morningVolumeWhiteBalance.profile.TryGet(out morningWhiteBalance);
         nowVolumeWhiteBalance.profile.TryGet(out nowWhiteBalance);
         nightVolumeWhiteBalance.profile.TryGet(out nightWhiteBalance);
          morningVolumeAdjustMents.profile.TryGet(out morningColorAdjustments);
         nowVolumeAdjustMents.profile.TryGet(out nowColorAdjustments);
         nightVolumeAdjustMents.profile.TryGet(out nightColorAdjustments);
         
    }

    //毎フレーム朝から夜へ（その逆も）ポストエフェクトを調整する処理
    public void Update ()
    { 
	    //時間が動く設定であり夜へと時間を移動するときの処理
	    if (canUpDateTime&&toNight)
	    {  
		    nowTimeOfDay = Mathf.MoveTowards(nowTimeOfDay, NightTime,speed);
		    nowBloom.intensity.value = Mathf.SmoothDamp(nowBloom.intensity.value,nightBloom.intensity.value,ref dayOfSpeed,timeOfDay);
		    nowBloom.tint.value=Color.Lerp(nowBloom.tint.value,nightBloom.tint.value,timeOfDay);
		    nowVignette.smoothness.value=Mathf.MoveTowards(nowVignette.smoothness.value,nightVignette.smoothness.value,speed);
		    nowWhiteBalance.temperature.value=Mathf.MoveTowards(nowWhiteBalance.temperature.value,nightWhiteBalance.temperature.value,speed);
		    nowWhiteBalance.tint.value=Mathf.MoveTowards(nowWhiteBalance.tint.value,nightWhiteBalance.tint.value,speed);
		    nowColorAdjustments.postExposure.value=Mathf.MoveTowards(nowColorAdjustments.postExposure.value,nightColorAdjustments.postExposure.value,speed);
		    nowColorAdjustments.colorFilter.value=Color.Lerp(nowColorAdjustments.colorFilter.value,nightColorAdjustments.colorFilter.value,speed);
		    if (nowTimeOfDay>=.98)
		    {
			    toNight = false;
		    }
	    }
	    //時間が動く設定であり朝へと時間を移動するときの処理
	    if (canUpDateTime&&!toNight)
	    {
	        if (nowTimeOfDay<.01)
           {
                  toNight = true;
            }
		    nowTimeOfDay = Mathf.MoveTowards(nowTimeOfDay,0,speed);
   		    nowBloom.intensity.value = Mathf.SmoothDamp(nowBloom.intensity.value,morningBloom.intensity.value,ref dayOfSpeed,timeOfDay);
		    nowBloom.tint.value=Color.Lerp(nowBloom.tint.value,morningBloom.tint.value,timeOfDay);
		    nowVignette.smoothness.value=Mathf.MoveTowards(nowVignette.smoothness.value,morningVignette.smoothness.value,speed);
            nowWhiteBalance.temperature.value=Mathf.MoveTowards(nowWhiteBalance.temperature.value,morningWhiteBalance.temperature.value,speed);
		    nowWhiteBalance.tint.value=Mathf.MoveTowards(nowWhiteBalance.tint.value,morningWhiteBalance.tint.value,speed);
		    nowColorAdjustments.postExposure.value=Mathf.MoveTowards(nowColorAdjustments.postExposure.value,morningColorAdjustments.postExposure.value,speed);
		    nowColorAdjustments.colorFilter.value=Color.Lerp(nowColorAdjustments.colorFilter.value,morningColorAdjustments.colorFilter.value,speed);
  
		
	    }
		if (sunDirection != null)
        {
			Shader.SetGlobalVector ("GlobalSunDirection", -sunDirection.transform.forward);
		}
        else
        {
			Shader.SetGlobalVector ("GlobalSunDirection", Vector3.zero);
		}

		if (moonDirection != null)
        {
			Shader.SetGlobalVector ("GlobalMoonDirection", -moonDirection.transform.forward);
		}
        else
        {
			Shader.SetGlobalVector ("GlobalMoonDirection", Vector3.zero);
		}

        if (skyboxDay != null && skyboxNight != null)
        {
            Material skyboxMaterial = new Material(skyboxDay);
            skyboxMaterial.Lerp(skyboxDay, skyboxNight, nowTimeOfDay);
            RenderSettings.skybox = skyboxMaterial;
        }

        if (updateLighting)
        {
            DynamicGI.UpdateEnvironment();
        }
        
    }
	void Change2NightOrMorning()
	{
		if (toNight)
		{
			toNight = false;
			return;
		}

		if (!toNight)
		{
			toNight = true;
			return;
		}
	}
}
}
