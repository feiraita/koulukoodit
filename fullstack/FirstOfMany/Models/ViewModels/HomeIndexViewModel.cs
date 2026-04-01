using System.Reflection;

namespace FirstOfMany.Models.ViewModels {
    public class HomeIndexViewModel {
        public Dictionary<string, int> VarienLukumaarat { get; set; } = new();
        public List<Motorcycle> Motorcycles { get; set; } = new();

        public HomeIndexViewModel(List<Motorcycle> motorcycles) {
            Motorcycles = motorcycles;
            var eri_varit = Motorcycles.Select(e => e.Vari).Distinct().ToList();
            foreach (var vari in eri_varit) {
                VarienLukumaarat.Add(vari, Motorcycles.Where(e => e.Vari == vari).Count());
            }
        }
    }
}
