# API de Cadastro de Pessoas
Api que simula um CRUD (cadastro, busca, atualização e remoção) de informações de pessoas.

# Configuração
  * Instalar SDK .NET (a versão utilizada no projeto é o .Net Core 3.1);
  * Instalar editor de código (Opcional);
  * Clonar ou baixar código zipado deste repositório;
  * Instalar ferramenta CLI [**dotnet ef**](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install);
  * Instalar banco de dados Postgres;
    * Localizar o arquivo **appsettings.json** dentro da pasta CadastroPessoa.API e modificar atributos **User Id** e **Password** ;
      ![image](https://user-images.githubusercontent.com/48768035/226211853-a8c2df22-e5d6-4dc5-b1f7-a69bf3716fc2.png)


# Como Usar
  * Dentro da pasta CadastroPessoa.API iniciar o terminal e digitar os comandos:    
    ```
    dotnet ef
    dotnet ef database update    
    ```
  * Em seguida digitar o comando ```dotnet watch run```;
  * Após inicializar o próprio programa irá direcionar o usuário para uma página de documentação gerada pelo [Swagger](https://swagger.io/tools/swagger-ui/);
    ![image](https://user-images.githubusercontent.com/48768035/226211771-baae2da0-0d9a-4c21-b9f4-0a855d8c8cfa.png)
  * Documentação alternativa no [Postman](https://documenter.getpostman.com/view/19837297/2s93JzMggL);

# Tecnologias
  * Desenvolvido em C#, .Net Core 3.1, Entity Framework 5 e PostgreSQL;
