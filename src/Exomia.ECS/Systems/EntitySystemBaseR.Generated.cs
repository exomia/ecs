﻿using System;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary>
    ///     An entity system base with 1 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    public abstract class EntitySystemBaseR1<TComponent1> : EntitySystemBase
        where TComponent1 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR1{TComponent1}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR1(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 2 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    public abstract class EntitySystemBaseR2<TComponent1,TComponent2> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR2{TComponent1,TComponent2}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR2(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 3 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    public abstract class EntitySystemBaseR3<TComponent1,TComponent2,TComponent3> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR3{TComponent1,TComponent2,TComponent3}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR3(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 4 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    public abstract class EntitySystemBaseR4<TComponent1,TComponent2,TComponent3,TComponent4> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR4{TComponent1,TComponent2,TComponent3,TComponent4}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR4(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 5 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    public abstract class EntitySystemBaseR5<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR5{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR5(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 6 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    public abstract class EntitySystemBaseR6<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR6{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR6(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 7 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    public abstract class EntitySystemBaseR7<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR7{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR7(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 8 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    public abstract class EntitySystemBaseR8<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR8{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR8(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 9 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    public abstract class EntitySystemBaseR9<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR9{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR9(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 10 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    public abstract class EntitySystemBaseR10<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR10{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR10(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 11 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    public abstract class EntitySystemBaseR11<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR11{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR11(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 12 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    public abstract class EntitySystemBaseR12<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR12{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR12(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 13 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    public abstract class EntitySystemBaseR13<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR13{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR13(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 14 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    public abstract class EntitySystemBaseR14<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR14{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR14(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 15 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    public abstract class EntitySystemBaseR15<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR15{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR15(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 16 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    /// <typeparam name="TComponent16"> Type of the component 16. </typeparam>
    public abstract class EntitySystemBaseR16<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
        where TComponent16 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;
        /// <summary>
        ///     The required components at index 16.
        /// </summary>
        protected TComponent16[] _components16;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR16{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR16(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
            _components16 = new TComponent16[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]) &&
                entity.Get(out _components16[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
            _components16[index] = _components16[swap];
            _components16[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
            Array.Resize(ref _components16, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
            _components16 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 17 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    /// <typeparam name="TComponent16"> Type of the component 16. </typeparam>
    /// <typeparam name="TComponent17"> Type of the component 17. </typeparam>
    public abstract class EntitySystemBaseR17<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
        where TComponent16 : class
        where TComponent17 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;
        /// <summary>
        ///     The required components at index 16.
        /// </summary>
        protected TComponent16[] _components16;
        /// <summary>
        ///     The required components at index 17.
        /// </summary>
        protected TComponent17[] _components17;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR17{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR17(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
            _components16 = new TComponent16[EntityManager.INITIAL_ARRAY_SIZE];
            _components17 = new TComponent17[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]) &&
                entity.Get(out _components16[index]) &&
                entity.Get(out _components17[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
            _components16[index] = _components16[swap];
            _components16[swap] = null!;
            _components17[index] = _components17[swap];
            _components17[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
            Array.Resize(ref _components16, size);
            Array.Resize(ref _components17, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
            _components16 = null!;
            _components17 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 18 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    /// <typeparam name="TComponent16"> Type of the component 16. </typeparam>
    /// <typeparam name="TComponent17"> Type of the component 17. </typeparam>
    /// <typeparam name="TComponent18"> Type of the component 18. </typeparam>
    public abstract class EntitySystemBaseR18<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
        where TComponent16 : class
        where TComponent17 : class
        where TComponent18 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;
        /// <summary>
        ///     The required components at index 16.
        /// </summary>
        protected TComponent16[] _components16;
        /// <summary>
        ///     The required components at index 17.
        /// </summary>
        protected TComponent17[] _components17;
        /// <summary>
        ///     The required components at index 18.
        /// </summary>
        protected TComponent18[] _components18;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR18{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR18(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
            _components16 = new TComponent16[EntityManager.INITIAL_ARRAY_SIZE];
            _components17 = new TComponent17[EntityManager.INITIAL_ARRAY_SIZE];
            _components18 = new TComponent18[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]) &&
                entity.Get(out _components16[index]) &&
                entity.Get(out _components17[index]) &&
                entity.Get(out _components18[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
            _components16[index] = _components16[swap];
            _components16[swap] = null!;
            _components17[index] = _components17[swap];
            _components17[swap] = null!;
            _components18[index] = _components18[swap];
            _components18[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
            Array.Resize(ref _components16, size);
            Array.Resize(ref _components17, size);
            Array.Resize(ref _components18, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
            _components16 = null!;
            _components17 = null!;
            _components18 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 19 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    /// <typeparam name="TComponent16"> Type of the component 16. </typeparam>
    /// <typeparam name="TComponent17"> Type of the component 17. </typeparam>
    /// <typeparam name="TComponent18"> Type of the component 18. </typeparam>
    /// <typeparam name="TComponent19"> Type of the component 19. </typeparam>
    public abstract class EntitySystemBaseR19<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18,TComponent19> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
        where TComponent16 : class
        where TComponent17 : class
        where TComponent18 : class
        where TComponent19 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;
        /// <summary>
        ///     The required components at index 16.
        /// </summary>
        protected TComponent16[] _components16;
        /// <summary>
        ///     The required components at index 17.
        /// </summary>
        protected TComponent17[] _components17;
        /// <summary>
        ///     The required components at index 18.
        /// </summary>
        protected TComponent18[] _components18;
        /// <summary>
        ///     The required components at index 19.
        /// </summary>
        protected TComponent19[] _components19;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR19{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18,TComponent19}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR19(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
            _components16 = new TComponent16[EntityManager.INITIAL_ARRAY_SIZE];
            _components17 = new TComponent17[EntityManager.INITIAL_ARRAY_SIZE];
            _components18 = new TComponent18[EntityManager.INITIAL_ARRAY_SIZE];
            _components19 = new TComponent19[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]) &&
                entity.Get(out _components16[index]) &&
                entity.Get(out _components17[index]) &&
                entity.Get(out _components18[index]) &&
                entity.Get(out _components19[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
            _components16[index] = _components16[swap];
            _components16[swap] = null!;
            _components17[index] = _components17[swap];
            _components17[swap] = null!;
            _components18[index] = _components18[swap];
            _components18[swap] = null!;
            _components19[index] = _components19[swap];
            _components19[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
            Array.Resize(ref _components16, size);
            Array.Resize(ref _components17, size);
            Array.Resize(ref _components18, size);
            Array.Resize(ref _components19, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
            _components16 = null!;
            _components17 = null!;
            _components18 = null!;
            _components19 = null!;
        }
    }

    /// <summary>
    ///     An entity system base with 20 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    /// <typeparam name="TComponent5"> Type of the component 5. </typeparam>
    /// <typeparam name="TComponent6"> Type of the component 6. </typeparam>
    /// <typeparam name="TComponent7"> Type of the component 7. </typeparam>
    /// <typeparam name="TComponent8"> Type of the component 8. </typeparam>
    /// <typeparam name="TComponent9"> Type of the component 9. </typeparam>
    /// <typeparam name="TComponent10"> Type of the component 10. </typeparam>
    /// <typeparam name="TComponent11"> Type of the component 11. </typeparam>
    /// <typeparam name="TComponent12"> Type of the component 12. </typeparam>
    /// <typeparam name="TComponent13"> Type of the component 13. </typeparam>
    /// <typeparam name="TComponent14"> Type of the component 14. </typeparam>
    /// <typeparam name="TComponent15"> Type of the component 15. </typeparam>
    /// <typeparam name="TComponent16"> Type of the component 16. </typeparam>
    /// <typeparam name="TComponent17"> Type of the component 17. </typeparam>
    /// <typeparam name="TComponent18"> Type of the component 18. </typeparam>
    /// <typeparam name="TComponent19"> Type of the component 19. </typeparam>
    /// <typeparam name="TComponent20"> Type of the component 20. </typeparam>
    public abstract class EntitySystemBaseR20<TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18,TComponent19,TComponent20> : EntitySystemBase
        where TComponent1 : class
        where TComponent2 : class
        where TComponent3 : class
        where TComponent4 : class
        where TComponent5 : class
        where TComponent6 : class
        where TComponent7 : class
        where TComponent8 : class
        where TComponent9 : class
        where TComponent10 : class
        where TComponent11 : class
        where TComponent12 : class
        where TComponent13 : class
        where TComponent14 : class
        where TComponent15 : class
        where TComponent16 : class
        where TComponent17 : class
        where TComponent18 : class
        where TComponent19 : class
        where TComponent20 : class
    {
        /// <summary>
        ///     The required components at index 1.
        /// </summary>
        protected TComponent1[] _components1;
        /// <summary>
        ///     The required components at index 2.
        /// </summary>
        protected TComponent2[] _components2;
        /// <summary>
        ///     The required components at index 3.
        /// </summary>
        protected TComponent3[] _components3;
        /// <summary>
        ///     The required components at index 4.
        /// </summary>
        protected TComponent4[] _components4;
        /// <summary>
        ///     The required components at index 5.
        /// </summary>
        protected TComponent5[] _components5;
        /// <summary>
        ///     The required components at index 6.
        /// </summary>
        protected TComponent6[] _components6;
        /// <summary>
        ///     The required components at index 7.
        /// </summary>
        protected TComponent7[] _components7;
        /// <summary>
        ///     The required components at index 8.
        /// </summary>
        protected TComponent8[] _components8;
        /// <summary>
        ///     The required components at index 9.
        /// </summary>
        protected TComponent9[] _components9;
        /// <summary>
        ///     The required components at index 10.
        /// </summary>
        protected TComponent10[] _components10;
        /// <summary>
        ///     The required components at index 11.
        /// </summary>
        protected TComponent11[] _components11;
        /// <summary>
        ///     The required components at index 12.
        /// </summary>
        protected TComponent12[] _components12;
        /// <summary>
        ///     The required components at index 13.
        /// </summary>
        protected TComponent13[] _components13;
        /// <summary>
        ///     The required components at index 14.
        /// </summary>
        protected TComponent14[] _components14;
        /// <summary>
        ///     The required components at index 15.
        /// </summary>
        protected TComponent15[] _components15;
        /// <summary>
        ///     The required components at index 16.
        /// </summary>
        protected TComponent16[] _components16;
        /// <summary>
        ///     The required components at index 17.
        /// </summary>
        protected TComponent17[] _components17;
        /// <summary>
        ///     The required components at index 18.
        /// </summary>
        protected TComponent18[] _components18;
        /// <summary>
        ///     The required components at index 19.
        /// </summary>
        protected TComponent19[] _components19;
        /// <summary>
        ///     The required components at index 20.
        /// </summary>
        protected TComponent20[] _components20;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR20{TComponent1,TComponent2,TComponent3,TComponent4,TComponent5,TComponent6,TComponent7,TComponent8,TComponent9,TComponent10,TComponent11,TComponent12,TComponent13,TComponent14,TComponent15,TComponent16,TComponent17,TComponent18,TComponent19,TComponent20}" /> class.
        /// </summary>
        /// <param name="manager"> The <see cref="EntityManager"/>. </param>
        protected EntitySystemBaseR20(EntityManager manager)
                : base(manager) 
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
            _components5 = new TComponent5[EntityManager.INITIAL_ARRAY_SIZE];
            _components6 = new TComponent6[EntityManager.INITIAL_ARRAY_SIZE];
            _components7 = new TComponent7[EntityManager.INITIAL_ARRAY_SIZE];
            _components8 = new TComponent8[EntityManager.INITIAL_ARRAY_SIZE];
            _components9 = new TComponent9[EntityManager.INITIAL_ARRAY_SIZE];
            _components10 = new TComponent10[EntityManager.INITIAL_ARRAY_SIZE];
            _components11 = new TComponent11[EntityManager.INITIAL_ARRAY_SIZE];
            _components12 = new TComponent12[EntityManager.INITIAL_ARRAY_SIZE];
            _components13 = new TComponent13[EntityManager.INITIAL_ARRAY_SIZE];
            _components14 = new TComponent14[EntityManager.INITIAL_ARRAY_SIZE];
            _components15 = new TComponent15[EntityManager.INITIAL_ARRAY_SIZE];
            _components16 = new TComponent16[EntityManager.INITIAL_ARRAY_SIZE];
            _components17 = new TComponent17[EntityManager.INITIAL_ARRAY_SIZE];
            _components18 = new TComponent18[EntityManager.INITIAL_ARRAY_SIZE];
            _components19 = new TComponent19[EntityManager.INITIAL_ARRAY_SIZE];
            _components20 = new TComponent20[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]) &&
                entity.Get(out _components5[index]) &&
                entity.Get(out _components6[index]) &&
                entity.Get(out _components7[index]) &&
                entity.Get(out _components8[index]) &&
                entity.Get(out _components9[index]) &&
                entity.Get(out _components10[index]) &&
                entity.Get(out _components11[index]) &&
                entity.Get(out _components12[index]) &&
                entity.Get(out _components13[index]) &&
                entity.Get(out _components14[index]) &&
                entity.Get(out _components15[index]) &&
                entity.Get(out _components16[index]) &&
                entity.Get(out _components17[index]) &&
                entity.Get(out _components18[index]) &&
                entity.Get(out _components19[index]) &&
                entity.Get(out _components20[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap] = null!;
            _components2[index] = _components2[swap];
            _components2[swap] = null!;
            _components3[index] = _components3[swap];
            _components3[swap] = null!;
            _components4[index] = _components4[swap];
            _components4[swap] = null!;
            _components5[index] = _components5[swap];
            _components5[swap] = null!;
            _components6[index] = _components6[swap];
            _components6[swap] = null!;
            _components7[index] = _components7[swap];
            _components7[swap] = null!;
            _components8[index] = _components8[swap];
            _components8[swap] = null!;
            _components9[index] = _components9[swap];
            _components9[swap] = null!;
            _components10[index] = _components10[swap];
            _components10[swap] = null!;
            _components11[index] = _components11[swap];
            _components11[swap] = null!;
            _components12[index] = _components12[swap];
            _components12[swap] = null!;
            _components13[index] = _components13[swap];
            _components13[swap] = null!;
            _components14[index] = _components14[swap];
            _components14[swap] = null!;
            _components15[index] = _components15[swap];
            _components15[swap] = null!;
            _components16[index] = _components16[swap];
            _components16[swap] = null!;
            _components17[index] = _components17[swap];
            _components17[swap] = null!;
            _components18[index] = _components18[swap];
            _components18[swap] = null!;
            _components19[index] = _components19[swap];
            _components19[swap] = null!;
            _components20[index] = _components20[swap];
            _components20[swap] = null!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
            Array.Resize(ref _components5, size);
            Array.Resize(ref _components6, size);
            Array.Resize(ref _components7, size);
            Array.Resize(ref _components8, size);
            Array.Resize(ref _components9, size);
            Array.Resize(ref _components10, size);
            Array.Resize(ref _components11, size);
            Array.Resize(ref _components12, size);
            Array.Resize(ref _components13, size);
            Array.Resize(ref _components14, size);
            Array.Resize(ref _components15, size);
            Array.Resize(ref _components16, size);
            Array.Resize(ref _components17, size);
            Array.Resize(ref _components18, size);
            Array.Resize(ref _components19, size);
            Array.Resize(ref _components20, size);
        }

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
            _components5 = null!;
            _components6 = null!;
            _components7 = null!;
            _components8 = null!;
            _components9 = null!;
            _components10 = null!;
            _components11 = null!;
            _components12 = null!;
            _components13 = null!;
            _components14 = null!;
            _components15 = null!;
            _components16 = null!;
            _components17 = null!;
            _components18 = null!;
            _components19 = null!;
            _components20 = null!;
        }
    }

 }