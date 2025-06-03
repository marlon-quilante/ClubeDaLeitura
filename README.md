# Clube Da Leitura

## Introdução

Este é um sistema para o controle de um clube de leitura. 
Nele é possível gerenciar caixas de revistas, amigos e empréstimos.

## Funcionalidades

### **Controle de Amigos**

O sistema permite cadastrar, visualizar, editar e excluir amigos, com as seguintes validações:

- **Não é possível haver amigos com o mesmo nome e telefone**
- **Não é permitido excluir um amigo caso tenha empréstimos vinculados**

![](https://imgur.com/3jvpLFb.gif)

### **Controle de Caixas**

O sistema permite cadastrar, visualizar, editar e excluir caixas, com as seguintes validações:

- **Não é possível haver etiquetas duplicadas**
- **Não é permitido excluir uma caixa caso tenha revistas vinculadas**
- **Cada caixa define o prazo máximo para empréstimo de suas revistas**

![](https://imgur.com/0NZMO6B.gif)

### **Controle de Revistas**

O sistema permite cadastrar, visualizar, editar e excluir revistas, com as seguintes validações:

- **Não é possível haver revistas com mesmo título e edição**
- **As revistas podem ficar com status Disponível, Emprestada ou Reservada**
- **Cada revista deve ser vinculada a uma caixa**

![](https://imgur.com/OZCJw13.gif)

### **Controle de Empréstimos e Devoluções**

O sistema permite registrar e visualizar empréstimos e devoluções de revistas a amigos, com as seguintes validações:

- **Cada amigo só pode ter um empréstimo ativo por vez**
- **As revistas podem ficar com status Aberto, Concluído ou Atrasado**
- **Empréstimos atrasados devem ser destacados visualmente**
- **A data de devolução é calculada automaticamente com base na quantidade de dias máximo de empréstimo de cada caixa**

![](https://imgur.com/xp7VcFc.gif)

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,cs,dotnet,visualstudio)](https://skillicons.dev)