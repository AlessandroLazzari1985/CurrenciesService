using System.Reflection;

namespace Apsoft.Domain.Entities;

public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetEqualityComponents();
        
    public static List<T> GetAll()
    {
        var instances = new List<T>();
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);

        foreach (var field in fields)
        {
            if (field.FieldType == typeof(T))
            {
                var instance = (T)field.GetValue(null);
                instances.Add(instance);
            }
        }

        return instances;
    }

    #region IEquatable

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValueObject<T>)obj);
    }

    public bool Equals(ValueObject<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(new HashCode(), (hashCode, obj) => {
                hashCode.Add(obj);
                return hashCode;
            }).ToHashCode();
    }

    #endregion

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }
}