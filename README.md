# Clube Da Leitura

## Introdução

Este é um sistema para o controle de um clube de leitura. 
Nele é possível gerenciar caixas de revistas, amigos e empréstimos.

## Funcionalidades

### **Controle de Amigos**

O sistema permite cadastrar, visualizar, editar e excluir amigos, tendo as seguintes validações:

- **Não é possível haver amigos com o mesmo nome e telefone**
- **Não é permitido excluir um amigo caso tenha empréstimos vinculados**

![](https://imgur.com/3jvpLFb.gif)

### **Controle de Caixas**

O sistema permite cadastrar, visualizar, editar e excluir caixas, tendo as seguintes validações:

- **Não é possível haver etiquetas duplicadas**
- **Não é permitido excluir uma caixa caso tenha revistas vinculadas**
- **Cada caixa define o prazo máximo para empréstimo de suas revistas**

![](https://imgur.com/0NZMO6B.gif)

### **Controle de Revistas**

O sistema permite cadastrar, visualizar, editar e excluir revistas, tendo as seguintes validações:

- **Não é possível haver revistas com mesmo título e edição**
- **As revistas podem ficar com status Disponível, Emprestada ou Reservada**
- **Cada revista deve ser vinculada a uma caixa**

![](https://imgur.com/OZCJw13.gif)

### **Controle de Empréstimos e Devoluções**

O sistema permite registrar e visualizar empréstimos e devoluções de revistas a amigos, tendo as seguintes validações:

- **Cada amigo só pode ter um empréstimo ativo por vez**
- **Os empréstimos podem ficar com status Aberto, Concluído ou Atrasado**
- **Empréstimos atrasados são destacados visualmente**
- **Só é possível realizar empréstimos para revistas com status "Disponível"**
- **A data de devolução é calculada automaticamente com base na quantidade de dias máximo de empréstimo de cada caixa**

![](https://imgur.com/xp7VcFc.gif)

### **Controle de Multas**

O sistema permite registrar, visualizar e quitar multas para empréstimos que estão com a devolução atrasada, tendo as seguintes validações:

- **O valor da multa é de R$ 2,00 por dia de atraso**
- **Amigos com multas em aberto não podem pegar novas revistas**
- **As multas podem ficar com status Pendente ou Quitada**

![](https://imgur.com/jRNbQGR.gif)

### **Controle de Reservas**

O sistema permite registrar, visualizar e cancelar reservas, bem como retirar revistas reservadas, tendo as seguintes validações:

- **Só é possível reservar revistas com status "Disponível"**
- **Não é possível emprestar revistas com reserva ativa**
- **Não é possível fazer reserva para amigos com multa pendente**
- **Ao retirar a revista, a reserva é convertida em um empréstimo**
- **Ao cancelar uma reserva, a revista volta a ficar disponível**

![](https://imgur.com/MiJPsTl.gif)

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,cs,dotnet,visualstudio)](https://skillicons.dev)