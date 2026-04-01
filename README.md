IT Maintenance Manager API é uma API RESTful desenvolvida para simplificar e automatizar o controle de equipamentos de TI e o gerenciamento de chamados de manutenção (tickets). Esta API procura resolver o controle de consertos e o tempo necessário para manutenção de equipamentos de TI, de forma que não fique desorganizado. Suas funcionalidades são:

- Gestão de Equipamentos: Permite cadastrar hardwares (Servidores, Desktops, Notebooks e Periféricos) com validação rígida de dados;
- Abertura de Chamados: Cria requisições de manutenção vinculadas a um equipamento específico;
- Cálculo Automático de SLA (Inteligência do Sistema): Utiliza o Padrão Strategy para calcular automaticamente o prazo limite de resolução com base na categoria do equipamento afetado (Servidores: 4 horas, Desktops/Notebooks: 24 horas, Periféricos: 48 horas);
- Fechamento de Chamados: Atualiza o status do ticket para "Concluído" e registra a data/hora exata do término do serviço.

Stack utilizada:
- C#: Ferramente e ambiente .NET;
- ASP.NET: Framework para construção das rotas REST;
- SQLite: Banco de dados leve e embutido (perfeito para testes rápidos);
- Entity Framework Core: ORM para manipulação do banco de dados (Code-First);
- Swagger: Interface interativa para documentação e teste da API.

PARA TESTAR O PROJETO:

- Certifique-se de ter o [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado;

- Abra o seu terminal e clone o projeto:
- git clone [https://github.com/Lucdijord/Controle_de_Manuten_de_equipTI](https://github.com/Lucdijord/Controle_de_Manuten_de_equipTI) 
- cd SEU_REPOSITORIO/ITMaintenanceManager