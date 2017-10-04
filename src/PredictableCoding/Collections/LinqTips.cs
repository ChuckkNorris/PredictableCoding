using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PredictableCoding.Collections
{
    public class LinqTips
    {
        List<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

        void CountVsAny()
        {
            // will scan entire set in order to get count
            var count = loadedAssemblies.Where(IsSystemWeb)
                .Count() > 0;

            // will stop when any element is found - MUCH FASTER in bigger collections
            var any = loadedAssemblies.Where(IsSystemWeb)
                .Any();

            // but why stop there - almost all LINQ extension methods take a predicate param
            var betterAny = loadedAssemblies.Any(IsSystemWeb);
        }

        void FluentVsQuerySyntax()
        {
            // query syntax provides a syntactical sugar around the underlying extension methods
            // may be easier to write for complex queries, where lambdas become hard to read
            var fakeAssemblyNames = new List<string> { "System.Web.NotReal", "system.web.fake " };
            var webAssembliesQuery = from a in loadedAssemblies
                                     join f in fakeAssemblyNames on a.FullName equals f   // <----- THis is quite a bit harder to express in fluent
                                     where a.FullName.StartsWith("system.web", StringComparison.OrdinalIgnoreCase)
                                     where a.GlobalAssemblyCache == false
                                     select a;

            // fluent syntax makes you more aware of method invocations, making it easier to identify lazy evaluations
            // you can encapsulate Where predicates into functions for better semantics and encapsulation
            var webAssembliesFluent = loadedAssemblies.Where(IsSystemWeb);
        }

        void FalseCompositionQueryForTypes()
        {
            // this will iterate the collections multiple times
            var sysWebTypes = ClosedChain()
                .SelectMany(a => a.GetTypes())
                .ToList();
        }
        void ComposeQueryForTypes()
        {
            var query = OpenChain()
                .SelectMany(a => a.GetTypes());

            // this will force query execution and close the chain
            var sysWebTypes = query.ToList();
        }

        IEnumerable<Assembly> ClosedChain()
        {
            // the ToList() materializes the results immediately, then returns
            return loadedAssemblies.Where(IsSystemWeb).ToList();
        }

        IQueryable<Assembly> OpenChain()
        {
            // make sure you don't have side-effects in this method
            // if returning an open chain - otherwise you're delivering a time bomb
            return loadedAssemblies.Where(IsSystemWeb).AsQueryable();
        }

        private bool IsSystemWeb(Assembly assemblyName)
        {
            return assemblyName.FullName.StartsWith("system.web", StringComparison.OrdinalIgnoreCase);
        }
    }
}
