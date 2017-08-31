using System.IO;
using System.Web;

namespace DataLayer {
    public partial class PBase {
        public string Imagem80 => Imagem("80");

        public string Imagem200 => Imagem("200");

        private string Imagem(string size) {
            var filepath = $"/Images/Products/{ID:000}x{size}x{size}.jpg";
            var absolutePath = $"{HttpRuntime.AppDomainAppPath}/Images/Products/{ID:000}x{size}x{size}.jpg";
            return !File.Exists(absolutePath) ? $"/Images/Products/000x{size}x{size}.jpg" : filepath;
        }
    }
}
