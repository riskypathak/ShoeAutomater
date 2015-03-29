using JustCopIt.Enumeration;
using JustCopIt.Framework.Model;
using JustCopIt.Logging;
using JustCopIt.UserControls;

namespace JustCopIt.Framework.Simulator
{
  public  class SimulatorFactory
   {
      
      public static Simulator GetSimulator(UILogging spiderLogging, SimulatorView simulatorView, PageModel pageModel)
      {
          switch (pageModel.Type)
          {
              case SiteType.ChampsSports:
                  return new ChampsSportsSimulator(spiderLogging,simulatorView, pageModel);
              case SiteType.Eastbay:
                  return new EastbaySimulator(spiderLogging,simulatorView, pageModel);
              case SiteType.Footaction:
                  return new FootactionSimulator(spiderLogging,simulatorView, pageModel);
              case SiteType.FootLocker:
                  return new FootLockerSimulator(spiderLogging,simulatorView, pageModel);
          }
          return null;
      }
    }
}
