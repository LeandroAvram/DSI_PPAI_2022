namespace DSI_PPAI_2022.Resource
{
    public class ModeloYMarca
    {
        private string modelo;
        private string marca;

        public ModeloYMarca(string modelo, string marca)
        {
            this.Modelo = modelo;
            this.Marca = marca;
        }

        public ModeloYMarca()
        {
        }

        public string Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
    }
}
