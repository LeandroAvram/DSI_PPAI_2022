

    public class Sesion
    {
        private DateTime fechaFin;
        private DateTime fechaInicio;
        private TimeSpan horaFin;
        private TimeSpan horaInicio;
        private Usuario usuario;

        public Sesion() { }

        public Sesion(DateTime fechaFin, DateTime fechaInicio, TimeSpan horaFin, TimeSpan horaInicio, Usuario usuario)
        {
            this.fechaFin = fechaFin;
            this.fechaInicio = fechaInicio;
            this.horaFin = horaFin;
            this.horaInicio = horaInicio;
            this.usuario = usuario;
        }

        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public TimeSpan HoraFin { get => horaFin; set => horaFin = value; }
        public TimeSpan HoraInicio { get => horaInicio; set => horaInicio = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }

        public PersonalCientífico GetPersonalCientificoEnSesion()
        {
            return Usuario.getCientifico();
        }
    }

