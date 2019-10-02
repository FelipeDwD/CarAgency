﻿using System;
using System.Collections.Generic;
using CarAgency.Entities;
using System.Globalization;
using CarAgency.Entities.Enums;

namespace CarAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoUsuario = 5;
            //Clientes
            List<Cliente> clientes = new List<Cliente>();
            int opcaoUsuarioCliente = 5;

            //Carros
            List<Carro> carros = new List<Carro>();
            int opcaoUsuarioCarro = 5;

            //Vendas
            List<Consultor> consultores = new List<Consultor>();
            List<Carro> carrosComprados = new List<Carro>();
            int opcaoUsuarioVendas = 5;
            bool addCarrosVendas = false; 

            int count = 0;


            while (opcaoUsuario != 0)
            {
                Console.Write("Bem - vindo, (a)" +
              "\n1 - Menu Cliente" +
              "\n2 - Menu Carros" +
              "\n3 - Hall de Vendas" +
              "\n0 - Sair" +
              "\n" +
              "\n>_ ");

                opcaoUsuario = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcaoUsuario)
                {
                    case 1:
                        count = 0;
                        do
                        {
                            if (count == 0)
                            {
                                Console.Write("Menu Clientes" +
                                "\n 1 - Cadastrar Clientes" +
                                "\n 2 - Listar Todos Clientes" +
                                "\n 0 - Sair" +
                                "\n >_ ");
                                count++;
                            }

                            opcaoUsuarioCliente = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (opcaoUsuarioCliente == 1)
                            {
                                Console.Write("Digite o nome do cliente: ");
                                string nome = Console.ReadLine();

                                Console.Write("Digite a idade do cliente: ");
                                int idade = int.Parse(Console.ReadLine());

                                Cliente cliente = new Cliente(nome, idade);
                                clientes.Add(cliente);
                                Console.Clear();
                                Console.WriteLine("Cliente cadastrado");
                                count = 0;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (opcaoUsuarioCliente == 2)
                            {
                                Console.Clear();
                                if (clientes.Count > 0)
                                {
                                    Console.WriteLine($"Total de clientes: {clientes.Count}");
                                    Console.WriteLine();
                                    foreach (Cliente cliente in clientes)
                                    {
                                        Console.WriteLine(cliente);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não existe nenhum cliente cadastrado!");
                                }
                                Console.WriteLine();
                                Console.WriteLine("0 - voltar");
                            }
                        } while (opcaoUsuarioCliente != 0);

                        break;

                    case 2:
                        count = 0;
                        do
                        {
                            if (count == 0)
                            {
                                Console.Write("Menu de carros" +
                                                      "\n 1 - Cadastrar Carro" +
                                                      "\n 2 - Listar Todos carros cadastrados" +
                                                      "\n 0 - Voltar" +
                                                      "\n >_ ");
                                count++;
                            }


                            opcaoUsuarioCarro = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (opcaoUsuarioCarro == 1)
                            {
                                Console.Write("Digite a marca do carro: ");
                                string marca = Console.ReadLine();

                                Console.Write("Digite o modelo do carro: ");
                                string modelo = Console.ReadLine();

                                Console.Write("Digite a cor do carro: ");
                                string cor = Console.ReadLine();

                                Console.Write("Digite a placa do carro: ");
                                string placa = Console.ReadLine();

                                Console.Write("Digite o preço do carro: ");
                                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                Carro carro = new Carro(marca, modelo, cor, placa, preco);
                                carros.Add(carro);
                                Console.Clear();
                                Console.WriteLine("Carro cadastrado!");
                                count = 0;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (opcaoUsuarioCarro == 2)
                            {
                                Console.Clear();
                                if (carros.Count > 0)
                                {
                                    Console.WriteLine($"Total de carros cadastrados: {carros.Count}");
                                    foreach (Carro carro in carros)
                                    {
                                        Console.WriteLine(carro);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não existe nenhum carro cadastrado!");
                                }
                                Console.WriteLine();
                                Console.WriteLine("0 - Voltar");
                            }

                        } while (opcaoUsuarioCarro != 0);

                        break;

                    case 3:
                        count = 0;
                        do
                        {
                            if (count == 0)
                            {
                                Console.Write("Menu de vendas" +
                                    "\n 1 - Vender" +
                                    "\n 2 - Cadastrar Consultor" +
                                    "\n 3 - Listar Consultores Cadastrados" +
                                    "\n 0 - Sair" +
                                    "\n >_ ");
                                count++;
                            }

                            opcaoUsuarioVendas = int.Parse(Console.ReadLine());
                            Console.Clear();

                            if (opcaoUsuarioVendas == 1)
                            {
                                if (false)
                                {
                                    Console.WriteLine("Não há disponível todos recursos suficientes para efetuar uma venda!" +
                                        "\nFavor, verificar recursos: " +
                                        "\n" +
                                        $"\n Carros cadastrados: {carros.Count}" +
                                        $"\n Consultores cadastrados: {consultores.Count}" +
                                        $"\n Clientes cadastrados: {clientes.Count}");
                                }
                                else
                                {
                                    addCarrosVendas = true;
                                    Console.WriteLine("Quem efetuou a venda? ");
                                    for (int i = 0; i < consultores.Count; i++)
                                    {
                                        Console.WriteLine($"[{(i + 1)}] - {consultores[i].Nome}");
                                    }
                                    Console.WriteLine();
                                    Console.Write(">_ ");
                                    int vendedor = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"{consultores[(vendedor - 1)].Nome} vendeu para qual cliente? ");

                                    Console.WriteLine("Qual cliente efeutou a compra? ");
                                    for (int i = 0; i < clientes.Count; i++)
                                    {
                                        Console.WriteLine($"[{(i + 1)}] - {clientes[i].Nome}");
                                    }
                                    Console.WriteLine();
                                    Console.Write(">_ ");

                                    int clienteEfeutouCompra = int.Parse(Console.ReadLine());                                    

                                    while (addCarrosVendas)
                                    {
                                        Console.WriteLine($"Qual carro {clientes[(clienteEfeutouCompra - 1)].Nome} comprou? ");
                                        for (int i = 0; i < carros.Count; i++)
                                        {
                                            Console.WriteLine($"\n[{(i + 1)}] :: " +
                                                $"{carros[i]}");
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine(">_ ");
                                        int carroVendido = int.Parse(Console.ReadLine());
                                        carrosComprados.Add(carros[(carroVendido - 1)]);

                                        Console.WriteLine("Acrescentar carro na venda? " +
                                            "\n 1 - Sim" +
                                            "\n 0 - Não");

                                        Console.Write(">_ ");
                                        int continuarRegistrandoVenda = int.Parse(Console.ReadLine());

                                        if (continuarRegistrandoVenda == 0)
                                        {
                                            Venda venda = new Venda(clientes[(clienteEfeutouCompra - 1)], carrosComprados);
                                            consultores[(vendedor - 1)].Vender(venda);
                                            addCarrosVendas = false;
                                            count = 1;
                                        }
                                    }
                                    
                                }
                            }
                            else if (opcaoUsuarioVendas == 2)
                            {
                                Console.Write("Digite o nome do consultor: ");
                                string nome = Console.ReadLine();

                                Console.Write($"Digite o nível do {nome} (Estagiario/Junior/Pleno/Senior): ");
                                ConsultorNivel nivelConsultor = Enum.Parse<ConsultorNivel>(Console.ReadLine());

                                Consultor consultor = new Consultor(nome, nivelConsultor);
                                consultores.Add(consultor);
                                Console.Clear();              
                                Console.WriteLine($"Consultor: {nome} cadastrado com sucesso!");
                                count = 0;
                                Console.ReadKey();
                                Console.Clear();

                            }else if (opcaoUsuarioVendas == 3)
                            {
                                if (consultores.Count > 0)
                                {
                                    foreach (Consultor consultor in consultores)
                                    {
                                        Console.WriteLine(consultor);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não existe nenhum consultor cadastrado!");
                                }
                                Console.WriteLine();
                                Console.WriteLine("0 - Voltar");
                            }

                        } while (opcaoUsuarioVendas != 0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

        }
    }
}