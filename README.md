
# 🏛️ Espaço Cultural Tour — Navegador 360º Interativo WebGL

> **Projeto desenvolvido para o Desafio Técnico do Processo Seletivo de Estágio em Jogos — Laboratório Vortex (Universidade de Fortaleza - UNIFOR)**.

[![Unity Version](https://img.shields.io/badge/Unity-6000.0.35f1-blue.svg?style=flat&logo=unity)](https://unity.com/)
[![WebGL](https://img.shields.io/badge/Platform-WebGL-orange.svg)](https://vercel.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 📌 Visão Geral do Projeto

O **Espaço Cultural Tour** é uma aplicação WebGL interativa que replica o funcionamento do *Google Street View* em uma plataforma dedicada. A aplicação permite a navegação panorâmica em 360º pelas galerias de arte do **Espaço Cultural da Unifor**, conectando pontos reais e proporcionando uma simulação imersiva de caminhada pelo ambiente.

🌐 **Acesse a Aplicação Online (Deploy WebGL):** [https://espacoculturaltour.vercel.app](https://espacoculturaltour.vercel.app)  

---

## 📸 Fluxo da Aplicação & Demonstração Visual

<div align="center">

| 1. Menu Principal | 2. Tutorial de Início |
| :---: | :---: |
| ![Menu Principal](./screenshots/Menu.jpeg) | ![Tutorial](./screenshots/Tutorial.jpeg) |
| *Tela de abertura com botão interativo para iniciar o tour.* | *Instruções iniciais para orientação do usuário no ambiente 360º.* |

<br/>

| 3. Navegação 360º & Minimapa | 4. Conclusão da Exploração |
| :---: | :---: |
| ![Cenário Exemplo](./screenshots/CenaExemplo.jpeg) | ![Conclusão](./screenshots/Conclusao.jpeg) |
| *Navegação pelas salas, setas de transição (hotspots) e minimapa em tempo real.* | *Mecânica de gamificação com feedback ao explorar todas as 12 salas.* |

</div>

---

## ⚡ Requisitos Técnicos Atendidos

Conforme as diretrizes do edital do Laboratório Vortex:

### ✅ Requisitos Mínimos (Obrigatórios)
* **Motor de Jogos:** Desenvolvido no Unity 6.
* **Imagens de Lugares Reais e Conectadas:** Mais de 10 imagens panorâmicas 360º do Espaço Cultural Unifor mapeadas logicamente.
* **Navegação Multimodal:**
  * Navegação entre imagens via **clique do mouse** (*Hotspots*).
  * Navegação entre imagens via **teclado**.
* **Build WebGL:** Aplicação compilada nativamente para a Web e disponibilizada publicamente para avaliação.

### ✨ Requisitos Bônus (Diferenciais Implementados)
* 🎮 **Mecânicas de Gamificação:** Contador visual de salas visitadas (`Salas Visitadas: X / 12`) e tela de parabéns ao concluir a exploração do espaço.
* 🎧 **Feedbacks Sonoros e Visuais:** Efeitos de áudio e transições visuais ao interagir com o menu e os pontos de navegação.
* 🔍 **Zoom / Pan:** Rotação e movimentação livre de câmera panorâmica.
* 🗺️ **Minimapa Interativo:** Indicador visual que reflete em tempo real a posição e localização do visitante.

---

## 📁 Organização do Projeto

A estrutura de diretórios do repositório segue rigorosamente a especificação do edital:

```text
EspacoCulturalTour/
├── Assets/                # Scripts C#, Materiais, Texturas 360°, Prefabs e Cenas
├── Packages/              # Pacotes e dependências do projeto Unity
├── ProjectSettings/       # Configurações do projeto e WebGL Player Settings
├── screenshots/           # Capturas de tela (Menu, Tutorial, CenaExemplo, Conclusao)
└── README.md              # Documentação oficial e Diário de Bordo da IA
