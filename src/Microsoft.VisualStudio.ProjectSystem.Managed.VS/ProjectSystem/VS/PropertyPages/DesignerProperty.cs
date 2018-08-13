using System;

namespace Microsoft.VisualStudio.ProjectSystem.VS.PropertyPages
{
    /// <summary>
    /// Represents a property with undo/redo support.
    /// </summary>
    internal sealed class DesignerProperty
    {
        private readonly Func<object> _getter;
        private readonly Action<object> _setter;
        private readonly DesignerPropertyType _propertyType;

        /// <summary>
        /// Construct a single-value property, specifying deleages to get/set its value.
        /// </summary>
        public DesignerProperty(string name, Func<object> getter, Action<object> setter)
        {
            _getter = getter 
                ?? throw new ArgumentNullException(nameof(getter));
            _setter = setter 
                ?? throw new ArgumentNullException(nameof(setter));
            _propertyType = DesignerPropertyType.SingleValue;
        }

        /// <summary>
        /// Name of this property
        /// </summary>
        public string Name
        { get; private set; }

        public object Getvalue()
        {
            ThrowIfNotPropertyType(DesignerPropertyType.SingleValue);
            return _getter.Invoke();
        }

        public void SetValue(object value)
        {
            ThrowIfNotPropertyType(DesignerPropertyType.SingleValue);
            _setter.Invoke(value);
        }

        private void ThrowIfNotPropertyType(DesignerPropertyType requiredPropertyType)
        {
            if (_propertyType != requiredPropertyType)
                throw new InvalidOperationException(
                    PropertyPageResources.IncorrectMethodUsedToAccessPropertyValue
                    );
        }
    }
}
