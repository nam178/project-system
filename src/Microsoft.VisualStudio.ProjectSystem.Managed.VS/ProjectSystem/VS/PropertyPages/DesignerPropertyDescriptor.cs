using System;
using System.ComponentModel;

namespace Microsoft.VisualStudio.ProjectSystem.VS.PropertyPages
{
    /// <summary>
    /// For undo/redo support, IVsProjectDesignerPageSite
    /// requires us to supply a PropertyDescriptor for each property change.
    /// </summary>
    internal sealed class DesignerPropertyDescriptor
        : PropertyDescriptor
    {
        public DesignerPropertyDescriptor(string name) 
            : base(name, Array.Empty<Attribute>())
        {
        }

        public override Type ComponentType
        { get => throw new NotSupportedException(); }

        public override bool IsReadOnly
        { get => false; }
        
        public override Type PropertyType
        { get; }

        public override bool CanResetValue(object component)
            => false;

        public override object GetValue(object component)
            => throw new NotSupportedException();

        public override void ResetValue(object component)
            => throw new NotSupportedException();

        public override void SetValue(object component, object value)
            => throw new NotSupportedException();

        public override bool ShouldSerializeValue(object component)
            => throw new NotSupportedException();
    }
}
