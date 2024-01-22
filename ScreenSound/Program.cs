
using ScreenSound;
using System.Collections.Generic; // Added for Dictionary and List
using System.Linq; // Added for Sum and Average
using System.Threading; // Added for Thread.Sleep
using ScreenSound.Modelos; // Added for Banda, Avaliacao, Album, and Musica
using ScreenSound.Menus;
using OpenAI_API;
using System;

var client = new OpenAIAPI("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");

var chat = client.Chat.CreateConversation();
chat.AppendSystemMessage("Resuma a banda Beatles!");

string resposta = await chat.getResponseFromChatbotAsync();
Console.WriteLine(resposta);


Banda rollingStones = new Banda("Rolling Stones");
rollingStones.AdicionarNota(new Avaliacao(10));
rollingStones.AdicionarNota(new Avaliacao(9));
rollingStones.AdicionarNota(new Avaliacao(8));

Banda beatles = new Banda("The Beatles");
beatles.AdicionarNota(new Avaliacao(10));
beatles.AdicionarNota(new Avaliacao(10));
beatles.AdicionarNota(new Avaliacao(8));

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(rollingStones.Nome, rollingStones);
bandasRegistradas.Add(beatles.Nome, beatles);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarBanda());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuMostrarBandasRegistradas());
opcoes.Add(4, new MenuAvaliarBanda());
opcoes.Add(5, new MenuAvaliarAlbum());
opcoes.Add(6, new MenuExibirDetalhes());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if(opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(bandasRegistradas);
        if(opcaoEscolhidaNumerica > 0)
        {
            ExibirOpcoesDoMenu();
        }
    } else
    {
        Console.WriteLine("Opção inválida");
    }

    //switch (opcaoEscolhidaNumerica)
    //{
    //    case 1:
    //        MenuRegistrarBanda menu1 = new();
    //        menu1.Executar(bandasRegistradas);
    //        ExibirOpcoesDoMenu();
    //        break;
    //    case 2:
    //        MenuRegistrarAlbum menu2 = new();
    //        menu2.Executar(bandasRegistradas);
    //        ExibirOpcoesDoMenu();
    //        break;
    //    case 3:
    //        MenuMostrarBandasRegistradas menu3 = new();
    //        menu3.Executar(bandasRegistradas);
    //        ExibirOpcoesDoMenu();
    //        break;
    //    case 4:
    //        MenuAvaliarBanda menu4 = new();
    //        menu4.Executar(bandasRegistradas);
    //        ExibirOpcoesDoMenu();
    //        break;
    //    case 5:
    //        MenuExibirDetalhes menu5 = new MenuExibirDetalhes();
    //        menu5.Executar(bandasRegistradas);
    //        ExibirOpcoesDoMenu();
    //        break;
    //    case -1:
    //        MenuSair menu6 = new MenuSair();
    //        break;
    //    default:
    //        Console.WriteLine("Opção inválida");
    //        break;
    //}
}

ExibirOpcoesDoMenu();

//sk - lP5BApTfcnmwHUu9QQdvT3BlbkFJHM3tBePs6G2xfMr4xJWx