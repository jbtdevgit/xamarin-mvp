using System;

namespace Xamarin_MVP.Ioc.Modules
{
    public class ModuleInfo : IModuleInfo
    {
        public ModuleInfo()
        {
        }


        public ModuleInfo(string name, string type, params string[] dependsOn)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (dependsOn == null)
                throw new ArgumentNullException(nameof(dependsOn));

            ModuleType = Type.GetType(type) ?? throw new ArgumentNullException(nameof(type));
            Name = name;
        }

        public ModuleInfo(string name, string type)
            : this(name, type, Array.Empty<string>())
        {
        }

        public ModuleInfo(Type moduleType)
            : this(moduleType, moduleType.Name) { }

        public ModuleInfo(Type moduleType, string moduleName)
            : this(moduleType, moduleName, InitMode.WhenAvailable) { }

        public ModuleInfo(Type moduleType, string moduleName, InitMode initializationMode)
            : this(moduleName, moduleType.AssemblyQualifiedName)
        {
            InitializeMode = initializationMode;
        }

        public ModuleInfo(string moduleName, Type moduleType) : this(moduleName, moduleType, InitMode.WhenAvailable)
        {

        }

        public ModuleInfo(string moduleName, Type moduleType , InitMode initMode) : this(moduleName, moduleType.AssemblyQualifiedName)
        {
             
        }

        private string _Name;
        public string Name 
        { 
            get => string.IsNullOrEmpty(_Name) ? ModuleType.Name : _Name;
            set => _Name = value;
        }

        string IModuleInfo.ModuleType
        {
            get => ModuleType.AssemblyQualifiedName;
            set => ModuleType = Type.GetType(value);
        }

        private Type _moduleType;
        public Type ModuleType
        {
            get => _moduleType;
            set
            {
                _moduleType = value;
                Name = value.Name;
            }
        }
        public InitMode InitializeMode { get; set; }
    }
}
