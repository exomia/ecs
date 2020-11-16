using System.Collections.Generic;
using Exomia.ECS.Events;

namespace Exomia.ECS
{
    public sealed partial class EntityManager
    {
        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1>(string key, R<T1> callback)
        {
            RHandler<T1>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1>(string key, RR<T1> callback)
        {
            RrHandler<T1>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1>(string key, O<T1> callback)
        {
            OHandler<T1>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2>(string key, O<T1, T2> callback)
        {
            OHandler<T1, T2>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2, T3>(string key, O<T1, T2, T3> callback)
        {
            OHandler<T1, T2, T3>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2, T3, T4>(string key, O<T1, T2, T3, T4> callback)
        {
            OHandler<T1, T2, T3, T4>.Register(key, callback);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1>(string key, R<T1> callback)
        {
            RHandler<T1>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1>(string key, RR<T1> callback)
        {
            RrHandler<T1>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1>(string key, O<T1> callback)
        {
            OHandler<T1>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2>(string key, O<T1, T2> callback)
        {
            OHandler<T1, T2>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2, T3>(string key, O<T1, T2, T3> callback)
        {
            OHandler<T1, T2, T3>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2, T3, T4>(string key, O<T1, T2, T3, T4> callback)
        {
            OHandler<T1, T2, T3, T4>.Unregister(key);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <returns>
        ///     A ref T1.
        /// </returns>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public T1 Get<T1>(string key)
        {
            if (!RHandler<T1>.Get(key, out R<T1> r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            return r.Invoke();
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <returns>
        ///     A ref T1.
        /// </returns>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public ref T1 GetR<T1>(string key)
        {
            if (!RrHandler<T1>.Get(key, out RR<T1> r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            return ref r.Invoke();
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out T1 o1)
        {
            if (!OHandler<T1>.Get(key, out O<T1> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2>(string key, out T1 o1, out T2 o2)
        {
            if (!OHandler<T1, T2>.Get(key, out O<T1, T2> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <param name="o3">  [out] The third out T3. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3>(string key, out T1 o1, out T2 o2, out T3 o3)
        {
            if (!OHandler<T1, T2, T3>.Get(key, out O<T1, T2, T3> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2, out o3);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <param name="o3">  [out] The third out T3. </param>
        /// <param name="o4">  [out] The fourth out T4. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3, T4>(string key, out T1 o1, out T2 o2, out T3 o3, out T4 o4)
        {
            if (!OHandler<T1, T2, T3, T4>.Get(key, out O<T1, T2, T3, T4> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2, out o3, out o4);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="r">   [out] The out R&lt;T1&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out R<T1> r)
        {
            if (!RHandler<T1>.Get(key, out r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="r">   [out] The out R&lt;T1&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out RR<T1> r)
        {
            if (!RrHandler<T1>.Get(key, out r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out O<T1> o)
        {
            if (!OHandler<T1>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2>(string key, out O<T1, T2> o)
        {
            if (!OHandler<T1, T2>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3>(string key, out O<T1, T2, T3> o)
        {
            if (!OHandler<T1, T2, T3>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3, T4>(string key, out O<T1, T2, T3, T4> o)
        {
            if (!OHandler<T1, T2, T3, T4>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }
    }
}
