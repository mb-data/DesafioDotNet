# Desafio .NET
Desafio de contratação Khipo. Realize um fork deste repositório e faça as etapas referentes a sua vaga. O intuito desse teste é ser algo simples, porém suficiente para validar a qualidade do seu código.

## Etapa 1 (Backend)

Utilizando o framework NestJS(https://docs.nestjs.com/) crie uma ``API Rest``. Essa API deverá ser capaz de CRUD em um banco de dados de ``Produtos``. É permitido utilizar qualquer banco de dados relacional, fica a critério do programador.


``GET /api/v1/products``
Retorna todos os produtos em lista

``GET /api/v1/products/:productId``
Retorna apenas o produto do productId

``POST /api/v1/products``
Cria um produto

``PATCH /api/v1/products/:productId``
Edita o produto do productId

``DELETE /api/v1/products/:productId``
apaga o produto do productId

Exemplo de produtos:
```
[
 {
  "createdAt": "2022-05-20T00:31:08.822Z",
  "name": "Incredible Plastic Pants",
  "price": "827.00",
  "brand": "Hauck - Johnson",
  "image": "http://loremflickr.com/640/480/fashion",
  "id": "1"
 },
 {
  "createdAt": "2022-05-20T09:05:23.745Z",
  "name": "Electronic Wooden Tuna",
  "price": "765.00",
  "brand": "Johns - Farrell",
  "image": "http://loremflickr.com/640/480/food",
  "id": "2"
 },
 {
  "createdAt": "2022-05-20T02:07:28.065Z",
  "name": "Awesome Steel Mouse",
  "price": "143.00",
  "brand": "Paucek, Kuvalis and Zieme",
  "image": "http://loremflickr.com/640/480/technics",
  "id": "3"
 },
 ]
```

Observações
1. Não precisa hospedar a ``image`` em nenhum lugar, assuma que isso já está sendo feito e que você recebe apenas uma URL
2. Não permita dois ou mais produtos com o mesmo Id, ele deve ser incremental


## Etapa 2 (Frontend)

Faça um website com NextJS (https://nextjs.org/docs) e TypeScript. Esse site deve exibir uma lista de produtos de uma loja, através de uma API fornecida. Faça tratamento de erro para as chamadas.

### Design da tela
Exiba a seguinte tela, com ``Nome, Preço e Marca`` e renderize uma ``Foto`` de cada produto. Ordene por ordem de criação. 

<img width="600" alt="image" src="https://user-images.githubusercontent.com/830261/169680671-c7e5d740-fa82-4e0e-909e-aa9c5e573967.png">

Link do Figma: https://www.figma.com/file/T7afvsovDPP9IGPZqLb9us/Desafio-Khipo?node-id=0%3A1



Importante
1. É permitido a utilização de pacotes de UI
2. Utilizar DataTable e boas práticas é importante para o projeto

### Pontos Extras
- [ ] Fazer função de editar e deletar na tela
- [ ] Colocar Swagger
- [ ] Usar Docker
