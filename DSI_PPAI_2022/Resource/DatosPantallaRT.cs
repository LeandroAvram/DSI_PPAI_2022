namespace DSI_PPAI_2022.Resource
{
    public class DatosPantallaRT
    {
        private string tipoRecursoTecnologico;
        private int numeroRT;
        private string modelo;
        private string marca;

        public DatosPantallaRT(string tipoRecursoTecnologico, int numeroRT, string modelo, string marca)
        {
            this.tipoRecursoTecnologico = tipoRecursoTecnologico;
            this.numeroRT = numeroRT;
            this.modelo = modelo;
            this.marca = marca;
        }

        public DatosPantallaRT()
        {
        }

        public string TipoRecursoTecnologico { get => tipoRecursoTecnologico; set => tipoRecursoTecnologico = value; }
        public int NumeroRT { get => numeroRT; set => numeroRT = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
    }
}
