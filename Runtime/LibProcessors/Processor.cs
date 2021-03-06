//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games

using System;

namespace Pixeye.Actors
{
  public abstract class Processor : IDisposable
  {
    protected Processor()
    {
      if (Framework.Processors.length == Framework.Processors.storage.Length)
        Array.Resize(ref Framework.Processors.storage, Framework.Processors.length << 1);

      Framework.Processors.storage[Framework.Processors.length++] = this;
      ProcessorUpdate.AddProc(this);
      ProcessorGroups.Setup(this);
      ProcessorSignals.Add(this);
      Toolbox.disposables.Add(this);
    }

    public void Dispose()
    {
      ProcessorSignals.Remove(this);
      ProcessorUpdate.RemoveProc(this);
      OnDispose();
    }


    //===============================//
    // Events
    //===============================//

    public virtual void HandleEvents()
    {
    }

    protected virtual void OnDispose()
    {
    }
  }

  #region PROCESSORS

  public abstract class Processor<T> : Processor
  {
    [InnerGroupAttribute]
    public Group<T> source = default;
  }

  public abstract class Processor<T, Y> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y> source = default;
  }

  public abstract class Processor<T, Y, U> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U> source = default;
  }

  public abstract class Processor<T, Y, U, I> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I> source = default;
  }

  public abstract class Processor<T, Y, U, I, O> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O> source = default;
  }

  public abstract class Processor<T, Y, U, I, O, P> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O, P> source = default;
  }

  public abstract class Processor<T, Y, U, I, O, P, A> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O, P, A> source = default;
  }

  public abstract class Processor<T, Y, U, I, O, P, A, S> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O, P, A, S> source = default;
  }

  public abstract class Processor<T, Y, U, I, O, P, A, S, D> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O, P, A, S, D> source = default;
  }

  public abstract class Processor<T, Y, U, I, O, P, A, S, D, F> : Processor
  {
    [InnerGroupAttribute]
    public Group<T, Y, U, I, O, P, A, S, D, F> source = default;
  }

  #endregion

  class InnerGroupAttribute : Attribute
  {
  }
}