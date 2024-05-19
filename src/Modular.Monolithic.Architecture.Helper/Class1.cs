using System.Threading.Tasks;

namespace Modular.Monolithic.Architecture.Helper
{
    public class Class1
    {
        public async Task GetValue3Async() => await Task.Delay(100);

        public async Task GetValue2Async() => await Task.Delay(100);

        public async Task GetValueAsync() => await Task.Delay(100);
    }
}
