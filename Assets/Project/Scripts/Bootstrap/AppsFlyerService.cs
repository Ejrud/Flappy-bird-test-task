using UnityEngine;
using AppsFlyerSDK;

public class AppsFlyerService : MonoBehaviour
{
    [SerializeField] private AppsFlyerObjectScript _appsFlyerObject;
    [SerializeField] private GameObject _conversionDataObject;
    
    // Что только не делал так и не понял как вывести ConversionData.
    // Как я понял нужно вызывать AppsFlyerAndroid.getConversionData,
    // но где потом искать результат выполения этого метода - хз.
    // В документации не нашел как получить ConversionData, возможно плохо искал...
    // Время выполнения тестового подходит к концу, так что оставлю как есть.
    public string GetConversionData()
    {
        AppsFlyer.instance.getConversionData(_conversionDataObject.name);
        _appsFlyerObject.onConversionDataSuccess(_conversionDataObject.name);
        Debug.Log(_appsFlyerObject.conversionData);
        return _appsFlyerObject.conversionData;
    }
}
