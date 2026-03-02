using UnityEngine;

namespace _Source
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _lastSafeArea = new Rect(0, 0, 0, 0);
        private Vector2 _lastScreenSize = new Vector2(0, 0);
        private ScreenOrientation _lastOrientation = ScreenOrientation.AutoRotation;

        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            Refresh();
        }
        
        void Update()
        {
            if (_lastSafeArea != Screen.safeArea || _lastScreenSize.x != Screen.width || _lastScreenSize.y != Screen.height || _lastOrientation != Screen.orientation)
            {
                Refresh();
            }
        }

        void Refresh()
        {
            Rect safeArea = Screen.safeArea;
            Debug.Log($"Safe Area: {safeArea}, Screen Res: {Screen.width}x{Screen.height}, Orientation: {Screen.orientation}");
            
            _lastSafeArea = safeArea;
            _lastScreenSize = new Vector2(Screen.width, Screen.height);
            _lastOrientation = Screen.orientation;
            
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
            
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }
    }
}