# Navegador 360º Interativo - "Silent Hill: The View"

**Candidato:** João Gabriel de Holanda Montenegro
**Desafio Técnico:** Processo Seletivo para Estágio em Jogos - Laboratório Vortex (UNIFOR)

---

## Sobre o Projeto
Este projeto é um protótipo de navegador panorâmico interativo em 360º. O sistema replica as mecânicas fundamentais do Google Street View, mas foi construído com uma atmosfera sombria de terror psicológico inspirada na franquia *Silent Hill*. 

## Documentação do Projeto
O jogo foi desenvolvido na Unity (Versão 6000.3.20f1 LTS) e estruturado em múltiplas cenas para simular a caminhada pela rua.

**Controles:**
* **Mouse (Clique e arraste):** Rotaciona a câmera (Pan) para olhar o ambiente em 360º.
* **Scroll do Mouse:** Aplica Zoom In e Zoom Out na visão do jogador.
* **Teclado (A/D):** Navegação secundária de rotação da câmera.
* **Teclado (W/S):** Navegação para frente e trás.

**Mecânicas de Gamificação e Diferenciais Implementados:**
* Elementos de terror (inspirados na demo P.T. de Hideo Kojima).
* Trilha sonora contínua e imersiva.
* Sistema de looping do mapa (portas de teletransporte).

---

## Diário de Bordo da Inteligência Artificial

O uso de ferramentas de IA foi utilizado para otimizar a estruturação do código e solucionar dúvidas de lógica da engine.

* **Ferramentas utilizadas:** Gemini
* **Prompts importantes:**
 * "Preciso desenvolver um jogo baseado nas informações desse pfd, me ajude na criação dele, primeiramente com os scripts básicos de movimentação e camera..."
  * *"Como posso criar um script em C# para gerenciar múltiplas trilhas sonoras de forma independente no Unity? Preciso que o áudio do menu transite para o jogo e que novos efeitos sonoros sejam adicionados em cenas específicas..."*
  * *"Como posso implementar um controle no gerenciador de áudio contínuo para que, ao entrar em uma cena de transição narrativa, todos os áudios e efeitos sonoros acumulados das cenas anteriores sejam destruídos..."*
  * *"Quais são as melhores práticas e ferramentas no Unity para aplicar efeitos visuais de pós-processamento (Post-Processing) na câmera principal, visando criar uma atmosfera de terror psicológico..."*
  * *"Estou enfrentando o erro de compilação 'CS1519: Invalid token' ao tentar implementar os efeitos visuais via script... qual é o procedimento correto para vincular esse pacote clássico de Post-Processing diretamente à Main Camera sem conflitar com o URP?"*
 
  
* **Dificuldades encontradas (Desafios):** 
  * **Gerenciamento Contínuo de Múltiplos Áudios:** O comportamento padrão do Unity destrói objetos ao carregar novas cenas. A implementação inicial de um padrão *Singleton* mantinha uma música, mas impedia a sobreposição de novos sons (como vento ou passos nas cenas seguintes). A solução exigiu refatorar o gerenciador para utilizar um *Dictionary* em C#, controlando instâncias de áudio através de IDs únicos (`idDoAudio`).
  * **O Efeito de Deslizamento em Mapas 360º:** Posicionar um objeto 3D real (um portal) sobre um cenário projetado no infinito (Skybox) causou problemas de proporção e ilusão de ótica. Ao afastar o objeto no eixo Z para o fim da rua da imagem, ele alcançava valores extremos (Z = 3500+), sofrendo falhas de precisão matemática (*Floating Point Precision Error*) e deslizando pela tela ao girar a câmera. A solução foi trazer o objeto para muito perto da câmera (Z = 15) e aplicar uma redução drástica em sua escala (*Scale*), forçando a perspectiva correta.
  * **Conflito de Pacotes de Pós-Processamento:** A implementação dos efeitos de terror (aberração cromática, grão de filme e vinheta) gerou erros de compilação iniciais devido à divergência de bibliotecas. O código tentava acessar o sistema *Volume* do URP (*Universal Render Pipeline*), enquanto o projeto estava configurado com o pacote clássico *Post-process Volume*. Foi necessário adaptar o script e a estrutura da *Main Camera* para utilizar o namespace correto (`UnityEngine.Rendering.PostProcessing`) e configurar o *Post-process Layer* adequadamente.
  * **Proporção Geométrica Involuntária:** Ao criar objetos primitivos (Esfera/Cubo) para atuar como portais ou *hotspots*, a escala original fez com que a câmera nascesse dentro da geometria do objeto, bloqueando a visão do jogador e invisibilizando o modelo 3D (devido ao *backface culling* padrão da engine). O ajuste preciso do componente *Transform* e a aplicação correta nos *Prefabs* foram fundamentais para estabilizar a interface em todas as cenas.

* **Como validei as respostas da IA:** 
  Nenhum código foi implementado de forma cega. A validação ocorreu através de:
  * **Testes iterativos no Unity Editor:** Ajuste de variáveis (como velocidade, escala e duração de efeitos) em tempo real pelo *Inspector* utilizando a tag `[SerializeField]` e variáveis públicas.
  * **Debugging Console:** Leitura de logs de erro para ajustar namespaces sugeridos erroneamente pela IA (ex: pacotes URP vs Post-Processing Clássico).
  * **Ajuste visual e espacial:** Para o problema de profundidade 360º, a solução matemática da IA precisou ser validada através do ajuste manual via *Scene View*, aproximando fisicamente os objetos e reduzindo o *Scale* para forçar a perspectiva, ao invés de afastá-los no eixo Z.

* **Reflexão crítica sobre o uso da IA:**
  O uso da IA provou-se uma ferramenta poderosa de mentoria técnica e aceleração de desenvolvimento, especialmente para desvendar particularidades e solucionar bugs específicos da engine Unity (como o comportamento de objetos 3D sobrepostos a materiais Skybox ou o conflito de pacotes). No entanto, ficou evidente que a IA atua como um suporte avançado, não como uma substituta para a visão do desenvolvedor. Soluções matemáticas ou scripts isolados só funcionaram porque foram cuidadosamente integrados a uma arquitetura de cenas pensada previamente. A montagem do *level design*, a construção da atmosfera e a forma como as imagens se conectam dependem puramente da direção criativa e da organização estrutural do projeto.

---

obs: a sensibilidade na hora de movimentar a câmera (clicando com o botão esquerdo do mouse) está um pouco alta nessa build do itch . io, na unity não estava assim. 

foi bem dificil fazer tudo ficar numa duração de 6min, cortei um pouco a introdução no youtube (pois meio que ja tem essas informações no forms e aqui no github)

## Links e Entregáveis
* **Vídeo de Apresentação:** https://www.youtube.com/watch?v=E3lOXR5jnpA
* **Jogue no Navegador (WebGL):** (https://martygabrielus.itch.io/silent-hill-the-view-desafio-vortex)
