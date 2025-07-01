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

# 🏆 Algoritmo Bully

## 🚀 Visão Geral
Implementação em Python do clássico Algoritmo Bully para eleição de coordenador em sistemas distribuídos. Este algoritmo garante que, em caso de falha do coordenador atual, um novo líder será eleito entre os processos ativos.

## 📂 Estrutura do Projeto
```
📁 Bully/
└── 🐍 Bully.py    # Implementação do algoritmo
```

## 🛠️ Requisitos
- Python 3.6 ou superior
- Nenhuma dependência externa necessária

## 🚀 Como Executar
1. Navegue até o diretório do projeto:
   ```bash
   cd "caminho/para/Bully"
   ```
2. Execute o script Python:
   ```bash
   python Bully.py
   ```

## 🎯 Funcionalidades
- Simulação de múltiplos processos em nós diferentes
- Detecção de falhas no coordenador
- Eleição de novo coordenador quando necessário
- Tratamento de mensagens entre processos

## 📚 Documentação do Código
### Classes Principais
- `Process`: Representa um nó no sistema distribuído
- `BullyAlgorithm`: Implementa a lógica do algoritmo Bully

### Métodos Principais
- `start_election()`: Inicia o processo de eleição
- `send_message()`: Envia mensagens entre processos
- `handle_message()`: Processa mensagens recebidas

## 🧪 Testes
O código inclui exemplos de uso que demonstram:
1. Inicialização dos processos
2. Simulação de falha do coordenador
3. Processo de eleição
4. Recuperação de falhas

## 📝 Exemplo de Uso
```python
# Criar instâncias dos processos
processes = [
    Process(1, [2, 3]),
    Process(2, [1, 3]),
    Process(3, [1, 2])
]

# Iniciar o algoritmo Bully
bully = BullyAlgorithm(processes)
bully.start()
```

## 📄 Licença
Este projeto está licenciado sob a licença MIT.

## 📅 Última Atualização
Julho de 2025


---

<div align="center">
  <p>Desenvolvido com ❤️ por Fernando Furtado</p>
  <p>PPGCC - INF/UFG - 2025</p>
</div>