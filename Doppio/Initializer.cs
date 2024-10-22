#if UNITY_EDITOR
namespace Caffeine.Initializers
{
    using Scriptables.Cache;
    using UnityEditor;

    public static class Initializer
    {
        [InitializeOnLoadMethod]
        public static void InitializeIfEnabled()
        {
            BuilderSettings.Instance.HasInitialized += () =>
            {
                if (BuilderSettings.Instance.EnableCaffeinePlus)
                {
                    Doppio.CustomAssembly.CustomAssemblyProvider.Init();
                }
            };
        }
    }
}
#endif
