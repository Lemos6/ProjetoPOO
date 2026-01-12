#  Sistema de Votação Eletrónica

**[](#sistema-de-votação-eletrónica)**  
**Projeto académico desenvolvido no âmbito da Licenciatura em Engenharia Informática (IPB Bragança).**

##  Funcionalidades principais
**[](#funcionalidades-principais)**

- Gestão de utilizadores com autenticação segura (3 tentativas, bloqueio 5min)
- 3 tipos de eleições: Presidencial (50%), Assembleia (33%), Municipal (25%)
- Votação com validações multicamadas (idade, elegibilidade, duplicação)
- Sistema de notificações inteligentes (4 níveis de prioridade)
- Auditoria completa de todos eventos
- Relatórios estatísticos com gráficos ASCII
- Persistência automática + backup/restore

##  Tecnologias
**[](#tecnologias)**

- **Backend**: C# .NET (Console Application)
- **Paradigma**: Programação Orientada a Objetos
- **Persistência**: Arquivos UTF-8 estruturados
- **Arquitetura**: 3 Camadas (Model-Service-Presentation)
- **Validações**: 15+ regras de negócio
- **Documentação**: Relatório Técnico HTML completo
