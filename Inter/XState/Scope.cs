using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XState
{
    internal class Scope: DynamicObject, INotifyPropertyChanged
    {
        private static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        private readonly object instance;
        private readonly Type type;
        private readonly IDictionary<string, object> _dictionary;

        public bool IsReadOnly { get; private set; }

        public Scope()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            var resut = base.TryDeleteMember(binder);

            if (resut)
            {
                NotifyPropertyChanged(binder.Name);
            }

            return resut;
        }

        // Implement the TryGetMember method of the DynamicObject class for dynamic member calls.
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if (IsReadOnly)
            {
                throw new InvalidOperationException("This dictionary instance is read-only, you cannot modify the data it contains");
            }

            var key = binder.Name;

            var property = this.type.GetProperty(binder.Name, Flags);

            if (property != null)
            {
                property.SetValue(this.instance, value);

                NotifyPropertyChanged(binder.Name);

                return true;
            }

            var field = this.type.GetField(binder.Name, Flags);

            if (field != null)
            {
                field.SetValue(this.instance, value);

                NotifyPropertyChanged(binder.Name);

                return true;
            }

            //check if the dictionary already has this key
            if (_dictionary.ContainsKey(key))
            {
                //it did so we can assign it to the new value
                _dictionary[key] = value;

                NotifyPropertyChanged(binder.Name);

                return true;
            }

            //check the base for the property
            var found = base.TrySetMember(binder, value);

            //if it wasn't found then the user must have wanted a new key
            //we'll expect implicit casting here, and an exception will be raised
            //if it cannot explicitly cast
            if (!found)
            {
                _dictionary.Add(key, value);
            }

            NotifyPropertyChanged(binder.Name);

            return true;
        }

        // Implement the TryInvokeMember method of the DynamicObject class for
        // dynamic member calls that have arguments.
        public override bool TryInvokeMember(InvokeMemberBinder binder,
                                             object[] args,
                                             out object result)
        {
            StringSearchOption StringSearchOption = StringSearchOption.StartsWith;
            bool trimSpaces = true;

            try
            {
                if (args.Length > 0) { StringSearchOption = (StringSearchOption)args[0]; }
            }
            catch
            {
                throw new ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.");
            }

            try
            {
                if (args.Length > 1) { trimSpaces = (bool)args[1]; }
            }
            catch
            {
                throw new ArgumentException("trimSpaces argument must be a Boolean value.");
            }

            result = GetPropertyValue(binder.Name, StringSearchOption, trimSpaces);

            return result == null ? false : true;
        }
    }
}
