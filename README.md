# Gnios Cashback Api

Projeto feito para o desafio da BeBlue.

</p>

## Table of contents

<!-- toc -->

- [Gnios Cashback Api](#Gnios-Cashback-Api)
  - [Table of contents](#Table-of-contents)
  - [Getting started](#Getting-started)
  - [Rotas](#Rotas)
      - [Modificadoers de de consulta GET](#Modificadoers-de-de-consulta-GET)
    - [Filtros](#Filtros)
      - [Exemplo](#Exemplo)
      - [Operadores](#Operadores)
    - [Ordenação](#Ordena%C3%A7%C3%A3o)
  - [Desafios pessoais](#Desafios-pessoais)
      - [Api's genéricas](#Apis-gen%C3%A9ricas)
      - [Utilização de cache](#Utiliza%C3%A7%C3%A3o-de-cache)
      - [Banco de dados LITEDB.](#Banco-de-dados-LITEDB)
      - [Trabalhos futuros](#Trabalhos-futuros)
  - [License](#License)

<!-- tocstop -->

## Getting started

Para rodar o projeto basta ter acesso a internet (pois ele busca a api do SPOTFY para popular o banco de dados).


## Rotas

As rotas são criadas obedecendo os verbos HTTP:

```
GET    /posts
GET    /posts/1
POST   /posts
PUT    /posts/1
DELETE /posts/1
```

#### Modificadoers de de consulta GET

Todas as consultas `GET` que retornam uma lista, tem os paremtros opcionais
abaixo:

| parametro | tipo  | breve Descrição | Exemplo |
|---------|---|---|---|
| id_like   | array[integer]  | Retorna todos os objetos que possuem os ids informados aqui.  | `/api/Album?id_like=1&id_like=2`|
| _take   | integer  | Configura a quantidade de registros retornados na consulta, caso não informado, trará todos os registros. |`/api/Album?_take=15`|
| _sort   | string  | Ordena a lista de acordo com as propriedades passadas mais detalhes em [Ordenação](#Ordenação). |`/api/Album?_sort=name`|
| _skip   |  integer | Configura quantos registros devem ser pulados na consulta. |`/api/Album?_skip=10"`|
| _page   |  integer | Pagina a busca de acordo com a pagina informada. |`/api/Album?_page=2`|
| _filter   |  array[string] | Realiza a filtros na busca através das propriedades veja mais em [Filtros](#Filtros)|`/api/Album?_filter=name==Pharmacy&_filter=genre==pop`|


### Filtros

Adicione `_filter` nas chamadas `GET` para filtrar a lista.
Vale lembrar que quando adicionado mais de um `_filter` ele a composição destes filtros
será feita com `&&`

#### Exemplo
```
GET /api/Album?_filter=name==Pharmacy&_filter=genre==pop
GET /posts?_filter=id==1&_filter=id==2
GET /comments?_filter=author==typicode
```

#### Operadores

Nos filtros temos os operadores

| Operador | Descrição | Exemplo |
|---------|---|---|
| `==`   | Compara se a propriedade é igual ao valor  | `/api/Album?_filter=name==Pharmacy`|
| `>=`   | Compara se a propriedade é maior ou igual ao valor  | `posts?_filter=id>=1`|
| `<=`   | Compara se a propriedade é menor ou igual ao valor  |`posts?_filter=id<=1`|

### Ordenação

Adicione o `_sort` para ordenar a lista, e os valores deverão ser
as propiedades do objeto para se ordenar, o separador entre as propriedades deve ser `,`

```
GET /api/Album?_sort=name
GET /api/Album?_sort=name,id
```

Para ordenar uma propriedade de modo decrescente deve adicionar o `_desc`

```
GET /api/Album?_sort=name_desc
GET /api/Album?_sort=name_desc,id
```

## Desafios pessoais

#### Api's genéricas
Visto que muitas vezes eu preciso criar apis para os meus projetos, resolvi utilizar este desafio
para criar um conjunto de ferramentas que facilite a criação de apis, o resultado foi a possibilidade
de criar as apis apenas criando a entidade e o Dto, sem a necessidade de criar um controller para isso.

#### Utilização de cache
Outro ponto que adicionei no projeto foi o cache simples em memória, porém se a aplicação fosse de grande porte este cache poderia ser migrado para utilizar o REDIS. 


#### Banco de dados LITEDB.
O motivo para a escolha de utilizar o LiteDB foram duas, a primeira é que para este projeto um banco de dados NoSql faz sentido, uma vez que preciso guardar o histórico facil de minhas vendas. E o segundo motivo é por ser um bando de dados local, como o projeto é pequeno e para um teste, não vi a necessidade de criar um banco de dados Mongo ou algo do tipo.

#### Trabalhos futuros
Adicionar a autencicação JWT para a API.
Modularizar a logica de criação de API's genérica para criar um pacote NUGET.
Adicionar os testes unitários.
Adicionar uma ferramenta de CI (Circle, Travis, ect..).


## License

MIT
