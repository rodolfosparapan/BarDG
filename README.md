# BarDG
BarDG - Avaliação Técnica Clear Sale - Junho 2020

## Usabilidade

### Login

Usuário de teste: caixa@bardg.com, senha:123456
![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/login.png)

### Gerenciamento de comandas

Adicionar nova comanda ou recuperar comadas existentes:
![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/inserir-comanda.png)

### Adicionar itens

Inserir novos itens na comanda selecionada:
![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/adicionar-itens.png)

### Visualizar comanda

Com a comanda aberta aberta é possível resetar ou finalizar a comanda:
![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/visualizar-comanda-aberta.png)

Com a comanda fechada é possível apenas visualizar a comanda:
![alt text](https://github.com/rodolfosparapan/BarDG/blob/dev/src/BarDG.UI/app/assets/visualizar-comanda.png)

## Backend

- AspNetCore 3.1
- Entity Framework Core
- Autenticação JWT
- Injeção de Dependência
- Arquitetura em camadas
- WebApi padrão REST
- Swagger
- Health Checks
- Testes de Unidade

## FrontEnd

- AngularJS
- BootStrap

## Pontos de Melhoria

### Funcional
- Implementação da geração e página da nota fiscal

### Técnico
- Poderia ser desenvolvido em microserviço específico para as operações fiscais e utilizar mensageria para comunição.
- Interceptor no frontEnd para identificar requisições sem permissão
- Refresh token

### Desenvolvido por
Rodolfo Sparapan @2020