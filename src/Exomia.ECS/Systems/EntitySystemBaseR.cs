using System;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary>
    ///     An entity system base with 1 required components.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    public abstract class EntitySystemBaseR1<TComponent1> : EntitySystemBase
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
            _components1[swap] = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
        }

        /// <inheritdoc />
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
        }

        /// <inheritdoc />
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
        }

        /// <inheritdoc />
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
            _components16[index] = _components16[swap];
            _components16[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index],
                _components16[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        /// <param name="c16"> The <typeparamref name="TComponent16"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15,
            TComponent16 c16);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
            _components16[index] = _components16[swap];
            _components16[swap] = default!;
            _components17[index] = _components17[swap];
            _components17[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index],
                _components16[index],
                _components17[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        /// <param name="c16"> The <typeparamref name="TComponent16"/>. </param>
        /// <param name="c17"> The <typeparamref name="TComponent17"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15,
            TComponent16 c16,
            TComponent17 c17);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
            _components16[index] = _components16[swap];
            _components16[swap] = default!;
            _components17[index] = _components17[swap];
            _components17[swap] = default!;
            _components18[index] = _components18[swap];
            _components18[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index],
                _components16[index],
                _components17[index],
                _components18[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        /// <param name="c16"> The <typeparamref name="TComponent16"/>. </param>
        /// <param name="c17"> The <typeparamref name="TComponent17"/>. </param>
        /// <param name="c18"> The <typeparamref name="TComponent18"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15,
            TComponent16 c16,
            TComponent17 c17,
            TComponent18 c18);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
            _components16[index] = _components16[swap];
            _components16[swap] = default!;
            _components17[index] = _components17[swap];
            _components17[swap] = default!;
            _components18[index] = _components18[swap];
            _components18[swap] = default!;
            _components19[index] = _components19[swap];
            _components19[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index],
                _components16[index],
                _components17[index],
                _components18[index],
                _components19[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        /// <param name="c16"> The <typeparamref name="TComponent16"/>. </param>
        /// <param name="c17"> The <typeparamref name="TComponent17"/>. </param>
        /// <param name="c18"> The <typeparamref name="TComponent18"/>. </param>
        /// <param name="c19"> The <typeparamref name="TComponent19"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15,
            TComponent16 c16,
            TComponent17 c17,
            TComponent18 c18,
            TComponent19 c19);

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
            _components1[swap] = default!;
            _components2[index] = _components2[swap];
            _components2[swap] = default!;
            _components3[index] = _components3[swap];
            _components3[swap] = default!;
            _components4[index] = _components4[swap];
            _components4[swap] = default!;
            _components5[index] = _components5[swap];
            _components5[swap] = default!;
            _components6[index] = _components6[swap];
            _components6[swap] = default!;
            _components7[index] = _components7[swap];
            _components7[swap] = default!;
            _components8[index] = _components8[swap];
            _components8[swap] = default!;
            _components9[index] = _components9[swap];
            _components9[swap] = default!;
            _components10[index] = _components10[swap];
            _components10[swap] = default!;
            _components11[index] = _components11[swap];
            _components11[swap] = default!;
            _components12[index] = _components12[swap];
            _components12[swap] = default!;
            _components13[index] = _components13[swap];
            _components13[swap] = default!;
            _components14[index] = _components14[swap];
            _components14[swap] = default!;
            _components15[index] = _components15[swap];
            _components15[swap] = default!;
            _components16[index] = _components16[swap];
            _components16[swap] = default!;
            _components17[index] = _components17[swap];
            _components17[swap] = default!;
            _components18[index] = _components18[swap];
            _components18[swap] = default!;
            _components19[index] = _components19[swap];
            _components19[swap] = default!;
            _components20[index] = _components20[swap];
            _components20[swap] = default!;
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
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(
                gameTime, 
                entity,
                _components1[index],
                _components2[index],
                _components3[index],
                _components4[index],
                _components5[index],
                _components6[index],
                _components7[index],
                _components8[index],
                _components9[index],
                _components10[index],
                _components11[index],
                _components12[index],
                _components13[index],
                _components14[index],
                _components15[index],
                _components16[index],
                _components17[index],
                _components18[index],
                _components19[index],
                _components20[index]      
            );
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1"> The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2"> The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3"> The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4"> The <typeparamref name="TComponent4"/>. </param>
        /// <param name="c5"> The <typeparamref name="TComponent5"/>. </param>
        /// <param name="c6"> The <typeparamref name="TComponent6"/>. </param>
        /// <param name="c7"> The <typeparamref name="TComponent7"/>. </param>
        /// <param name="c8"> The <typeparamref name="TComponent8"/>. </param>
        /// <param name="c9"> The <typeparamref name="TComponent9"/>. </param>
        /// <param name="c10"> The <typeparamref name="TComponent10"/>. </param>
        /// <param name="c11"> The <typeparamref name="TComponent11"/>. </param>
        /// <param name="c12"> The <typeparamref name="TComponent12"/>. </param>
        /// <param name="c13"> The <typeparamref name="TComponent13"/>. </param>
        /// <param name="c14"> The <typeparamref name="TComponent14"/>. </param>
        /// <param name="c15"> The <typeparamref name="TComponent15"/>. </param>
        /// <param name="c16"> The <typeparamref name="TComponent16"/>. </param>
        /// <param name="c17"> The <typeparamref name="TComponent17"/>. </param>
        /// <param name="c18"> The <typeparamref name="TComponent18"/>. </param>
        /// <param name="c19"> The <typeparamref name="TComponent19"/>. </param>
        /// <param name="c20"> The <typeparamref name="TComponent20"/>. </param>
        protected abstract void Tick(
            GameTime gameTime, 
            Entity entity,
            TComponent1 c1,
            TComponent2 c2,
            TComponent3 c3,
            TComponent4 c4,
            TComponent5 c5,
            TComponent6 c6,
            TComponent7 c7,
            TComponent8 c8,
            TComponent9 c9,
            TComponent10 c10,
            TComponent11 c11,
            TComponent12 c12,
            TComponent13 c13,
            TComponent14 c14,
            TComponent15 c15,
            TComponent16 c16,
            TComponent17 c17,
            TComponent18 c18,
            TComponent19 c19,
            TComponent20 c20);

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