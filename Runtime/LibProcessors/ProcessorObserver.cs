//  Project : ecs
// Contacts : Pix - ask@pixeye.games


namespace Pixeye.Actors
{
#if ACTORS_EVENTS_MANUAL
	[Events(Op.Add | Op.Remove)]
#endif
  sealed class ProcessorObserver : Processor<ComponentObserver>, ITick
  {
    public override void HandleEvents()
    {
      foreach (var entity in source.removed)
      {
        ref var cObserver = ref entity.ComponentObserver();
        for (var j = 0; j < cObserver.length; j++)
          cObserver.wrappers[j].Check();
      }

      foreach (var entity in source.added)
      {
        ref var cObserver = ref entity.ComponentObserver();
        for (var j = 0; j < cObserver.length; j++)
          cObserver.wrappers[j].FirstTime();
      }
    }


    public void Tick(float delta)
    {
      for (var i = 0; i < source.length; i++)
      {
        ref var cObserver = ref source.entities[i].ComponentObserver();
        for (var j = 0; j < cObserver.length; j++)
          cObserver.wrappers[j].Check();
      }
    }
  }
}