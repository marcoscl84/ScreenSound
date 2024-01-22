using System;
using System.Collections.Generic;
using ScreenSound.Modelos;
using ScreenSound.Menus;

public class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.WriteLine("Valeu!)");
    }
}
