public class Usuario
{

	private string clave;
	private string nameUsuario;
	private int habilitado;
    private PersonalCient�fico personalCientifico;

	public Usuario(string clave, string nameUsuario, int habilitado, PersonalCient�fico personalCientifico)
	{
		this.Clave = clave;
		this.NameUsuario = nameUsuario;
		this.Habilitado = habilitado;
		this.PersonalCientifico = personalCientifico;
	}

	public string Clave { get => clave; set => clave = value; }
	public string NameUsuario { get => nameUsuario; set => nameUsuario = value; }
	public int Habilitado { get => habilitado; set => habilitado = value; }
	public PersonalCient�fico PersonalCientifico { get => personalCientifico; set => personalCientifico = value; }
	public void crear()
	{

	}

	public void habilitar()
	{

	}

	public void inhabilitar()
	{

	}

	public void modificarPassword()
	{

	}

	public PersonalCient�fico getCientifico()
	{

		return this.PersonalCientifico;

	}
}