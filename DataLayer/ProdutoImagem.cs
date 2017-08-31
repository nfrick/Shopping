using System.IO;
using System.Web;

namespace DataLayer {
    public class ProdutoImagem {
        private readonly int _id;

        public ProdutoImagem(int id) {
            _id = id;
        }

        public int ID => _id;

        public string Imagem80 => Imagem("80");
        public string Imagem200 => Imagem("200");

        private string Imagem(string size) {
            var absolutePath = $"{HttpRuntime.AppDomainAppPath}/Images/Products/{ID:000}x{size}x{size}.jpg";
            var id = File.Exists(absolutePath) ? ID : 0;
            return $"{id:000}x{size}x{size}.jpg";
        }
    }
}
