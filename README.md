# BarDG
Avalia��o T�cnica Clear Sale - Junho 2020

## Usabilidade

### 1. Login

Usu�rio de teste: caixa@bardg.com, senha:123456

![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/login.png)

### 2. Gerenciamento de comandas

Adicionar nova comanda ou recuperar comadas existentes:

![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/inserir-comanda.png)

### 3. Adicionar itens

Inserir novos itens na comanda selecionada:

![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/adicionar-itens.png)

### 4. Visualizar comanda

Com a comanda aberta aberta � poss�vel resetar ou finalizar a comanda:

![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/visualizar-comanda-aberta.png)

Com a comanda fechada � poss�vel apenas visualizar a comanda:

![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/visualizar-comanda.png)

## Backend

- AspNetCore 3.1
- Entity Framework Core
- Autentica��o JWT
- Inje��o de Depend�ncia
- Arquitetura em camadas
- WebApi padr�o REST
- Swagger
- Health Checks
- Testes de Unidade

## FrontEnd

- AngularJS
- BootStrap

## Pontos de Melhoria

### Funcional
- Implementa��o da gera��o e p�gina da nota fiscal

### T�cnico
- Poderia ser desenvolvido em microservi�o espec�fico para as opera��es fiscais e utilizar mensageria para comuni��o.
- Interceptor no frontEnd para identificar requisi��es sem permiss�o
- Refresh token

### Desenvolvido por
Rodolfo Sparapan