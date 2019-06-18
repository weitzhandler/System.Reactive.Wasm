using System.Diagnostics.CodeAnalysis;
using System.Reactive.Concurrency;
using System.Reactive.PlatformServices;
using Xunit;

namespace System.Reactive.Wasm.Tests
{
    /// <summary>
    /// To be implemented later.
    /// </summary>
    [SuppressMessage("Design", "CS0618", Justification = "Intentional")]
    public class TestClass
    {
        /// <summary>
        /// Verifies correct enlightenment provider returned when enabled.
        /// </summary>
        [Fact]
        public void TestCorrectPlatformEnlightenmentProvider()
        {
            PlatformEnlightenmentProvider.Current.EnableWasm();

            Assert.IsType<WasmPlatformEnlightenmentProvider>(PlatformEnlightenmentProvider.Current);
        }

        /// <summary>
        /// Verifies correct services are returned.
        /// </summary>
        [Fact]
        public void TestCorrectServices()
        {
            PlatformEnlightenmentProvider.Current.EnableWasm();

            Assert.IsType<ConcurrencyAbstractionLayerWasmImpl>(GetService<IConcurrencyAbstractionLayer>());
            Assert.Equal(WasmScheduler.Default, GetService<IScheduler>());

            // This is wrong naming, stylecop fail, local functions should be camelcase.
            T GetService<T>()
                where T : class =>
            PlatformEnlightenmentProvider.Current.GetService<T>();
        }
    }
}
