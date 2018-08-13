namespace Microsoft.VisualStudio.ProjectSystem.VS.PropertyPages
{
    internal enum DesignerPropertyType
    {
        /// <summary>
        /// This property always have one single value accross all configurations
        /// </summary>
        SingleValue,

        /// <summary>
        /// This property can have multiple values, configuration dependent.
        /// </summary>
        MultipleValues
    }
}
