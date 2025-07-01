<div align="center">
  <img src="https://avatars.githubusercontent.com/u/78055338?v=4" width="150" height="150" style="border-radius: 50%; object-fit: cover; border: 4px solid #4285F4;" alt="Foto de Fernando Furtado">
  
  <h1>Fernando Furtado</h1>
  
  <div>
    <img src="https://img.shields.io/badge/PPGCC-INF%20UFG-0078D7?style=for-the-badge&logo=university&logoColor=white" alt="PPGCC INF UFG">
    <img src="https://img.shields.io/badge/Ano-2025-34A853?style=for-the-badge" alt="Ano 2025">
    <img src="https://img.shields.io/badge/Disciplina-Sistemas%20Distribu%C3%ADdos-4285F4?style=for-the-badge" alt="Sistemas Distribuídos">
  </div>
</div>

---

# 🍽️ Jantar dos Filósofos

## 🧠 Visão Geral
Implementação em Java do clássico problema de concorrência "Jantar dos Filósofos". Este problema ilustra desafios de sincronização e bloqueio mútuo em sistemas operacionais e programação concorrente.

## 📂 Estrutura do Projeto
```
📁 Jantar Filósofos/
├── 📁 src/
│   ├── 🗡️ Garfo.java           # Classe que representa os garfos
│   ├── 🧑‍🤝‍🧑 Filosofo.java        # Classe que implementa o comportamento dos filósofos
│   └── 🏛️ JantarDosFilosofos.java  # Classe principal que orquestra a simulação
└── 📁 out/                    # Arquivos compilados
```

## 🛠️ Requisitos
- Java JDK 11 ou superior
- Maven (opcional, para gerenciamento de dependências)

## 🚀 Como Compilar e Executar

### Usando o compilador Java:
```bash
# Navegue até o diretório src
cd "caminho/para/Jantar Filósofos/src"

# Compilar
javac -d ../out *.java

# Executar
cd ../out
java JantarDosFilosofos
```

### Usando Maven:
```bash
# Na raiz do projeto
mvn clean package
java -cp target/classes JantarDosFilosofos
```

## 🎯 Funcionalidades
- Simulação do problema clássico com N filósofos
- Implementação de bloqueio para evitar deadlocks
- Visualização do estado de cada filósofo (pensando, faminto, comendo)
- Controle de concorrência usando monitores Java

## 🧩 Classes Principais

### 🧑‍🤝‍🧑 Filosofo.java
- Implementa a lógica de cada filósofo
- Gerencia os estados: PENSANDO, FAMINTO, COMENDO
- Controla a sincronização dos garfos

### 🗡️ Garfo.java
- Representa os garfos compartilhados
- Gerencia o bloqueio dos recursos

### 🏛️ JantarDosFilosofos.java
- Classe principal
- Inicializa os filósofos e garfos
- Inicia as threads

## 🧪 Testes
O programa inclui exemplos que demonstram:
1. Criação de 5 filósofos (valor padrão)
2. Sincronização no acesso aos garfos
3. Prevenção de deadlocks
4. Visualização do estado dos filósofos

## 📝 Exemplo de Saída
```
Filósofo 0 está PENSANDO
Filósofo 1 está FAMINTO
Filósofo 2 está COMENDO
...
```

## 📚 Referências
- Problema original proposto por Edsger Dijkstra
- Livro: "Sistemas Operacionais Modernos" - Andrew S. Tanenbaum

## 📄 Licença
Este projeto está licenciado sob a licença MIT.

## 📅 Última Atualização
Julho de 2025

---

<div align="center">
  <p>Desenvolvido com ❤️ por Fernando Furtado</p>
  <p>PPGCC - INF/UFG - 2025</p>
</div>
