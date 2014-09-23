namespace GenericList
{
    using System;

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    class Version : Attribute
    {
        public string VersionCode { get; private set; }

        public Version(string version)
        {
            this.VersionCode = version;
        }
    }
}
