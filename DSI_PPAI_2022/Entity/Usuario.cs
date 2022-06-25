public class Usuario
{

	private string clave;
	private string nameUsuario;
	private int habilitado;
    private PersonalCientífico personalCientifico;

	public Usuario(string clave, string nameUsuario, int habilitado, PersonalCientífico personalCientifico)
	{
		this.Clave = clave;
		this.NameUsuario = nameUsuario;
		this.Habilitado = habilitado;
		this.PersonalCientifico = personalCientifico;
	}

	public string Clave { get => clave; set => clave = value; }
	public string NameUsuario { get => nameUsuario; set => nameUsuario = value; }
	public int Habilitado { get => habilitado; set => habilitado = value; }
	public PersonalCientífico PersonalCientifico { get => personalCientifico; set => personalCientifico = value; }
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

	public PersonalCientífico getCientifico()
	{

		return this.PersonalCientifico;

	}
}