# MauiAppEventos: Cadastro de Eventos

Atividade da **Agenda 15** (Programação Mobile I, ETEC / Centro Paula Souza): .NET MAUI com `BindingContext`, `DateTime` e `TimeSpan`.

## O que o app faz
1. **Cadastro de Eventos:** nome, data de início, data de término, número de participantes, local e custo por participante.
2. Ao tocar em **Cadastrar**, abre o **Resumo do Evento** com tudo formatado: datas `dd/MM/yyyy`, valores em R$, duração em dias (`TimeSpan`) e **custo total** (participantes x custo).

## Como foi feito
- `Models/Evento.cs`: propriedades do evento mais `Duracao` (`DataFim.Subtract(DataInicio)`, um `TimeSpan`), `DuracaoDias` e `CustoTotal`.
- `Views/CadastroEvento`: valida os campos, monta o `Evento` e navega com `new ResumoEvento { BindingContext = evento }`.
- `Views/ResumoEvento`: exibe os dados com `{Binding ...}` e `StringFormat`.
- `App.xaml.cs`: fixa a cultura `pt-BR` e abre o app em uma `NavigationPage` (override de `CreateWindow`).

## Validações (mostram `DisplayAlert`)
Nome ou local vazio, término antes do início, participantes vazio/zero/inválido, custo vazio/inválido/negativo.
Se início e término forem o mesmo dia, a duração é 0 dia e o custo total continua sendo participantes x custo (o enunciado pede o custo com base no número de participantes).

## Como rodar
Requisitos: Visual Studio 2026 (.NET 10) com a carga de trabalho **.NET Multi-platform App UI development** e um emulador Android. Para Visual Studio 2022 / .NET 8, troque `net10.0-android` por `net8.0-android` no `.csproj`.

1. Abra a pasta `MauiAppEventos` (arquivo `MauiAppEventos.csproj`).
2. Escolha o emulador Android e rode (F5).

> Se o Visual Studio reclamar do projeto, crie um projeto "App .NET MAUI" novo chamado `MauiAppEventos` e copie para ele as pastas `Models` e `Views`. Apague `MainPage.xaml(.cs)` e `AppShell.xaml(.cs)` do template e troque o `App.xaml.cs` pelo deste repositório.

## Capturas de tela
Veja `docs/roteiro-capturas.md`.
