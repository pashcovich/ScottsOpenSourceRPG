using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Engine.Models.Mutable
{
    public abstract class BaseModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            if(PropertyChanged != null)
            {
                MemberExpression memberExpression = (MemberExpression)property.Body;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }
    }
}
