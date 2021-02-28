Sistema Web com ASP Net core MVC e Entity framework core, utilizando o Microsoft SQL Server.


**Funcionalidades:**

> � CRUD de Alunos, Salas, Lanchonetes e Matriculas.

**Tecnologias utilizadas:**

> � Back-End: .net 5.0<br/>
> � ORM: Entity Framework Core 5.0.3<br/>
> � Banco de dados: Microsoft SQL Server


**Instru��es para execu��o:**

> 1. Utilizar IDE Visual Studio e SGBD Microsoft SQL Server Management Studio.
> 2. Inicie o servidor SQL Server.
> 3. Inicie o SQL Server Management Studio .
>> 3.1 No SQL Server Management Studio abra o arquivo script.sql na pasta MatriculaProway\utils e execute o script para criar o banco e as tabelas.<br/>
>> 3.2 Na pasta MatriculaProway\utils tamb�m existe um pdf com o Esquema de modelagem de dados para consulta.<br/>
> 4. No Visual Studio Abra o arquivo solu��o MatriculaProway.sln
>> 4.1 Em Startup.cs e Models/testeprowayContext, altere a string de conex�o, caso necess�rio. 
>> 4.2 Execute o sistema (Control + F5)


**Intru��es de utiliza��o**
> 1. O sistema consiste em um app web para cadastrar Alunos, Salas, Lanchonetes e vincular cada aluno � sua sala em determinada etapa, e � sua lanchonete em determinado turno, atrav�s do cadastro de Matriculas.
> 2. Antes de tudo, � importante que se cadastre todos os Alunos, Salas e Lanchonetes em suas respectivas abas pelo link "Create New".
> 3. Ap�s isso, v� para a aba Matriculas e clique no link "Matricular Aluno"
>> 3.1 Neste formul�rio, basta Escolher o Aluno, e fazer o vinculo dele nas salas e lanchonetes de acordo com a Etapa e o turno.<br/>
>> 3.2 Na tela de Matriculas � poss�vel ver todos os Alunos Matriculados e em que sala e lanchonete estar�o em determinada etapa e turno.