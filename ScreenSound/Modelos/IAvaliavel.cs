namespace ScreenSound.Modelos;

interval interface IAvaliavel
{
    void AdicionarNota(Avaliacao nota);
    double Media { get; }
}